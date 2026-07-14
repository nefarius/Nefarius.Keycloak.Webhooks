using System.Net;

using Microsoft.Extensions.DependencyInjection;

using Nefarius.Keycloak.Webhooks.Authentication;

namespace Nefarius.Keycloak.Webhooks.FastEndpoints;

/// <summary>
///     Extension methods for registering the Keycloak webhook FastEndpoints integration.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Registers <see cref="KeycloakWebhookOptions" /> so that <see cref="KeycloakWebhookEndpoint" />
    ///     is configured correctly. Call this before <c>AddFastEndpoints()</c>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">Optional delegate to customise <see cref="KeycloakWebhookOptions" />.</param>
    public static IServiceCollection AddKeycloakWebhooks(
        this IServiceCollection services,
        Action<KeycloakWebhookOptions>? configure = null)
    {
        services
            .AddOptions<KeycloakWebhookOptions>()
            .Validate(
                options => options.MaxRequestBodySize > 0,
                "MaxRequestBodySize must be greater than zero.")
            .Validate(
                options => options.AuthenticationMode is not (
                    KeycloakWebhookAuthenticationMode.HmacSha1 or
                    KeycloakWebhookAuthenticationMode.HmacSha256) ||
                           !string.IsNullOrEmpty(options.HmacSecret),
                "HmacSecret is required for HMAC authentication.")
            .Validate(
                options => options.AuthenticationMode != KeycloakWebhookAuthenticationMode.Bearer ||
                           HasValidBearerSettings(options.Jwt),
                "Bearer authentication requires a valid issuer, audience, RS256, and an HTTPS or loopback JWKS URI.")
            .ValidateOnStart();

        if (configure is not null)
        {
            services.Configure(configure);
        }

        services.AddHttpClient("Nefarius.Keycloak.Webhooks");
        services.AddSingleton(serviceProvider =>
            new KeycloakWebhookAuthenticator(
                serviceProvider
                    .GetRequiredService<IHttpClientFactory>()
                    .CreateClient("Nefarius.Keycloak.Webhooks")));

        return services;
    }

    private static bool HasValidBearerSettings(KeycloakJwtValidationOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.Audience) ||
            !Uri.TryCreate(options.Issuer, UriKind.Absolute, out Uri? issuer) ||
            issuer.Scheme is not ("https" or "http") ||
            string.IsNullOrWhiteSpace(issuer.Host) ||
            !string.IsNullOrEmpty(issuer.Query) ||
            !string.IsNullOrEmpty(issuer.Fragment) ||
            options.ValidAlgorithms.Count != 1 ||
            !options.ValidAlgorithms.Contains("RS256", StringComparer.Ordinal))
        {
            return false;
        }

        Uri jwksUri;
        try
        {
            jwksUri = options.JwksUri ??
                      new Uri(
                          $"{issuer.ToString().TrimEnd('/')}/protocol/openid-connect/certs",
                          UriKind.Absolute);
        }
        catch (UriFormatException)
        {
            return false;
        }

        if (!jwksUri.IsAbsoluteUri)
        {
            return false;
        }

        bool isLoopback = string.Equals(jwksUri.Host, "localhost", StringComparison.OrdinalIgnoreCase) ||
                          IPAddress.TryParse(jwksUri.Host, out IPAddress? address) &&
                          IPAddress.IsLoopback(address);
        return string.Equals(jwksUri.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase) ||
               isLoopback;
    }
}