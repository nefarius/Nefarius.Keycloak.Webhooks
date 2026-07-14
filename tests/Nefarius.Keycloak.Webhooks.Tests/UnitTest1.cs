using System.Net;
using System.Security.Cryptography;
using System.Text;

using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

using Nefarius.Keycloak.Webhooks.Authentication;
using Nefarius.Keycloak.Webhooks.Events;

namespace Nefarius.Keycloak.Webhooks.Tests;

public class WebhookCompatibilityTests
{
    [Fact]
    public void ParserPreservesOpenEndedUserPayload()
    {
        const string Json =
            """
            {
              "id":"source-event",
              "uid":"delivery-event",
              "type":"access.LOGIN_ERROR",
              "time":1700000000000,
              "realmId":"realm-uuid",
              "realmName":"acme",
              "error":"invalid_user_credentials",
              "authDetails":{"realmId":"acme","userId":"f:ldap:opaque-user","clientId":"portal"},
              "details":{"future_field":"future-value","username":"alice"}
            }
            """;

        UserWebhookEvent evt = Assert.IsType<UserWebhookEvent>(KeycloakWebhookParser.Parse(Json));

        Assert.Equal("source-event", evt.Id);
        Assert.Equal("delivery-event", evt.Uid);
        Assert.Equal("f:ldap:opaque-user", evt.UserId);
        Assert.Equal("future-value", evt.GetDetail("future_field"));
        Assert.True(evt.RawPayload.HasValue);
    }

    [Fact]
    public void ParserClassifiesAnyAdminAndCustomEvent()
    {
        AdminWebhookEvent admin = Assert.IsType<AdminWebhookEvent>(
            KeycloakWebhookParser.Parse(
                """{"uid":"1","type":"admin.CLIENT_SCOPE-UPDATE","resourceType":"CLIENT_SCOPE","operationType":"UPDATE","resourceId":"scope"}"""));
        CustomWebhookEvent custom = Assert.IsType<CustomWebhookEvent>(
            KeycloakWebhookParser.Parse("""{"uid":"2","type":"billing.invoice-issued","details":{"invoice":"42"}}"""));

        Assert.Equal("scope", admin.ResourceId);
        Assert.Equal("42", custom.GetDetail("invoice"));
    }

    [Fact]
    public void ParserNormalizesLegacyHttpSenderUserEvents()
    {
        UserWebhookEvent evt = Assert.IsType<UserWebhookEvent>(
            KeycloakWebhookParser.Parse(
                """{"type":"LOGIN","realmId":"r","userId":"opaque","clientId":"portal","details":{"username":"alice"}}"""));

        Assert.Equal("access.LOGIN", evt.Type);
    }

    [Fact]
    public void HmacVerificationUsesExactBodyAndHexDigest()
    {
        byte[] body = Encoding.UTF8.GetBytes("""{"type":"access.LOGIN"}""");
        byte[] digest;
        using (HMACSHA256 hmac = new(Encoding.UTF8.GetBytes("secret")))
        {
            digest = hmac.ComputeHash(body);
        }

        string signature = Convert.ToHexString(digest).ToLowerInvariant();
        Assert.True(KeycloakWebhookAuthenticator.VerifyHmac(body, signature, "secret").Succeeded);

        body[0] ^= 1;
        Assert.False(KeycloakWebhookAuthenticator.VerifyHmac(body, signature, "secret").Succeeded);
    }

    [Fact]
    public async Task BearerVerificationChecksSignatureAndBodyBinding()
    {
        byte[] body = Encoding.UTF8.GetBytes("""{"type":"access.LOGIN"}""");
        using RSA rsa = RSA.Create(2048);
        RsaSecurityKey signingKey = new(rsa) { KeyId = "test-key" };
        RSAParameters publicParameters = rsa.ExportParameters(false);
        string jwks =
            $$"""{"keys":[{"kty":"RSA","kid":"test-key","use":"sig","alg":"RS256","n":"{{Base64UrlEncoder.Encode(publicParameters.Modulus)}}","e":"{{Base64UrlEncoder.Encode(publicParameters.Exponent)}}"}]}""";
        using HttpClient httpClient = new(new StaticResponseHandler(jwks));
        KeycloakWebhookAuthenticator authenticator = new(httpClient);
        string bodyHash = Convert.ToHexString(SHA256.HashData(body)).ToLowerInvariant();
        JsonWebTokenHandler tokenHandler = new();
        string token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = "https://id.example/realms/acme",
            Audience = "https://receiver.example/webhook",
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(5),
            SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.RsaSha256),
            Claims = new Dictionary<string, object>
            {
                ["jti"] = Guid.NewGuid().ToString(),
                ["request_body_sha256"] = bodyHash
            }
        });
        KeycloakJwtValidationOptions options = new()
        {
            Issuer = "https://id.example/realms/acme",
            Audience = "https://receiver.example/webhook",
            JwksUri = new Uri("https://id.example/realms/acme/protocol/openid-connect/certs")
        };

        Assert.True((await authenticator.VerifyBearerAsync(body, token, options)).Succeeded);

        body[0] ^= 1;
        Assert.False((await authenticator.VerifyBearerAsync(body, token, options)).Succeeded);
    }

    private sealed class StaticResponseHandler(string content) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
            => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            });
    }
}