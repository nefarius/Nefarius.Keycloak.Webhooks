using Microsoft.Extensions.DependencyInjection;

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
        services.AddOptions<KeycloakWebhookOptions>();

        if (configure is not null)
        {
            services.Configure(configure);
        }

        return services;
    }
}
