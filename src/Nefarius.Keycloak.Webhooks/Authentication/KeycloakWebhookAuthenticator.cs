using System.Net;
using System.Security.Cryptography;
using System.Text;

using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Nefarius.Keycloak.Webhooks.Authentication;

/// <summary>Verifies authentication data emitted by <c>ext-event-webhook</c>.</summary>
public sealed class KeycloakWebhookAuthenticator
{
    private readonly HttpClient _httpClient;
    private readonly SemaphoreSlim _jwksLock = new(1, 1);
    private IReadOnlyCollection<SecurityKey>? _cachedKeys;
    private Uri? _cachedJwksUri;
    private DateTimeOffset _keysExpireAt;

    /// <summary>Creates an authenticator that retrieves realm signing keys with <paramref name="httpClient" />.</summary>
    public KeycloakWebhookAuthenticator(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    /// <summary>Verifies the hexadecimal HMAC signature over the exact raw request bytes.</summary>
    public static KeycloakWebhookAuthenticationResult VerifyHmac(
        ReadOnlyMemory<byte> body,
        string? signature,
        string secret,
        KeycloakWebhookAuthenticationMode mode = KeycloakWebhookAuthenticationMode.HmacSha256)
    {
        if (string.IsNullOrWhiteSpace(signature))
        {
            return KeycloakWebhookAuthenticationResult.Failure("The X-Keycloak-Signature header is missing.");
        }

        if (string.IsNullOrEmpty(secret))
        {
            return KeycloakWebhookAuthenticationResult.Failure("No HMAC secret is configured.");
        }

        byte[] actual;
        try
        {
            actual = FromHex(signature!.Trim());
        }
        catch (FormatException)
        {
            return KeycloakWebhookAuthenticationResult.Failure("The X-Keycloak-Signature header is not hexadecimal.");
        }

        byte[] expected;
        byte[] key = Encoding.UTF8.GetBytes(secret);
        switch (mode)
        {
            case KeycloakWebhookAuthenticationMode.HmacSha1:
                using (HMACSHA1 hmac = new(key))
                {
                    expected = hmac.ComputeHash(body.ToArray());
                }
                break;
            case KeycloakWebhookAuthenticationMode.HmacSha256:
                using (HMACSHA256 hmac = new(key))
                {
                    expected = hmac.ComputeHash(body.ToArray());
                }
                break;
            default:
                return KeycloakWebhookAuthenticationResult.Failure("The selected mode is not an HMAC mode.");
        }

        return FixedTimeEquals(expected, actual)
            ? KeycloakWebhookAuthenticationResult.Success()
            : KeycloakWebhookAuthenticationResult.Failure("The webhook signature is invalid.");
    }

    /// <summary>
    ///     Verifies a realm-signed JWT, including issuer, audience, time, signature, and the
    ///     <c>request_body_sha256</c> binding.
    /// </summary>
    public async Task<KeycloakWebhookAuthenticationResult> VerifyBearerAsync(
        ReadOnlyMemory<byte> body,
        string? token,
        KeycloakJwtValidationOptions options,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return KeycloakWebhookAuthenticationResult.Failure("The bearer token is missing.");
        }

        if (string.IsNullOrWhiteSpace(options.Issuer) || string.IsNullOrWhiteSpace(options.Audience))
        {
            return KeycloakWebhookAuthenticationResult.Failure("JWT issuer and audience must be configured.");
        }

        try
        {
            IReadOnlyCollection<SecurityKey> signingKeys = await GetSigningKeysAsync(options, cancellationToken)
                .ConfigureAwait(false);
            TokenValidationParameters parameters = new()
            {
                ValidateIssuer = true,
                ValidIssuer = options.Issuer.TrimEnd('/'),
                ValidateAudience = true,
                ValidAudience = options.Audience,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                RequireSignedTokens = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKeys = signingKeys,
                ValidAlgorithms = options.ValidAlgorithms,
                ClockSkew = options.ClockSkew
            };

            JsonWebTokenHandler handler = new();
            TokenValidationResult validation = await handler.ValidateTokenAsync(token, parameters).ConfigureAwait(false);
            if (!validation.IsValid)
            {
                return KeycloakWebhookAuthenticationResult.Failure(
                    validation.Exception?.Message ?? "The bearer token is invalid.");
            }

            JsonWebToken jwt = new(token);
            if (string.IsNullOrWhiteSpace(jwt.Id))
            {
                return KeycloakWebhookAuthenticationResult.Failure("The bearer token has no jti claim.");
            }

            if (!jwt.TryGetPayloadValue("request_body_sha256", out string? claimedHash) ||
                string.IsNullOrWhiteSpace(claimedHash))
            {
                return KeycloakWebhookAuthenticationResult.Failure(
                    "The bearer token has no request_body_sha256 claim.");
            }

            byte[] expectedHash;
            using (SHA256 sha = SHA256.Create())
            {
                expectedHash = sha.ComputeHash(body.ToArray());
            }

            byte[] claimedHashBytes;
            try
            {
                claimedHashBytes = FromHex(claimedHash!);
            }
            catch (FormatException)
            {
                return KeycloakWebhookAuthenticationResult.Failure(
                    "The request_body_sha256 claim is not hexadecimal.");
            }

            return FixedTimeEquals(expectedHash, claimedHashBytes)
                ? KeycloakWebhookAuthenticationResult.Success()
                : KeycloakWebhookAuthenticationResult.Failure(
                    "The bearer token is not bound to this request body.");
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch (Exception ex)
        {
            return KeycloakWebhookAuthenticationResult.Failure($"JWT validation failed: {ex.Message}");
        }
    }

    private async Task<IReadOnlyCollection<SecurityKey>> GetSigningKeysAsync(
        KeycloakJwtValidationOptions options,
        CancellationToken cancellationToken)
    {
        Uri jwksUri = options.ResolveJwksUri();
        bool isLoopback = string.Equals(jwksUri.Host, "localhost", StringComparison.OrdinalIgnoreCase) ||
                          IPAddress.TryParse(jwksUri.Host, out IPAddress? address) &&
                          IPAddress.IsLoopback(address);
        if (!string.Equals(jwksUri.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase) && !isLoopback)
        {
            throw new SecurityTokenException("The JWKS URI must use HTTPS.");
        }

        if (_cachedKeys is not null && _cachedJwksUri == jwksUri && DateTimeOffset.UtcNow < _keysExpireAt)
        {
            return _cachedKeys;
        }

        await _jwksLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_cachedKeys is not null && _cachedJwksUri == jwksUri && DateTimeOffset.UtcNow < _keysExpireAt)
            {
                return _cachedKeys;
            }

            using HttpResponseMessage response = await _httpClient.GetAsync(jwksUri, cancellationToken)
                .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            JsonWebKeySet keySet = new(json);
            IReadOnlyCollection<SecurityKey> keys = keySet.GetSigningKeys().ToArray();
            if (keys.Count == 0)
            {
                throw new SecurityTokenException("The JWKS document contains no signing keys.");
            }

            _cachedKeys = keys;
            _cachedJwksUri = jwksUri;
            _keysExpireAt = DateTimeOffset.UtcNow.Add(options.JwksCacheDuration);
            return keys;
        }
        finally
        {
            _jwksLock.Release();
        }
    }

    private static byte[] FromHex(string value)
    {
        if (value.Length % 2 != 0)
        {
            throw new FormatException();
        }

        byte[] bytes = new byte[value.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
        }

        return bytes;
    }

    private static bool FixedTimeEquals(byte[] left, byte[] right)
    {
        int difference = left.Length ^ right.Length;
        int length = Math.Min(left.Length, right.Length);
        for (int i = 0; i < length; i++)
        {
            difference |= left[i] ^ right[i];
        }

        return difference == 0;
    }
}