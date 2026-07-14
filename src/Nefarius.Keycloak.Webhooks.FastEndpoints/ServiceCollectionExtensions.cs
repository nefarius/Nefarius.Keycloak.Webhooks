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
                           !string.IsNullOrWhiteSpace(options.Jwt.Issuer) &&
                           !string.IsNullOrWhiteSpace(options.Jwt.Audience),
                "JWT issuer and audience are required for bearer authentication.")
            .ValidateOnStart();

        if (configure is not null)
        {
            services.Configure(configure);
        }

        services.AddHttpClient<KeycloakWebhookAuthenticator>();

        return services;
    }
}