using Nefarius.Keycloak.Webhooks.Authentication;

namespace Nefarius.Keycloak.Webhooks.FastEndpoints;

/// <summary>
///     Configuration options for the Keycloak webhook FastEndpoints integration.
/// </summary>
public sealed class KeycloakWebhookOptions
{
    /// <summary>
    ///     The route pattern on which the webhook endpoint listens.
    ///     Defaults to <c>/api/webhooks/{Id}</c> (the <c>{Id}</c> segment is unused but kept for
    ///     compatibility with existing Keycloak webhook URL configurations).
    /// </summary>
    public string Route { get; set; } = "/api/webhooks/{Id}";

    /// <summary>
    ///     When <c>true</c> (default), the endpoint allows anonymous access.
    ///     Set to <c>false</c> if you protect the route with network-level controls or custom auth.
    /// </summary>
    public bool AllowAnonymous { get; set; } = true;

    /// <summary>
    ///     Sender authentication mode. Defaults to <see cref="KeycloakWebhookAuthenticationMode.None" />
    ///     for compatibility; authenticated production webhooks should select HMAC or bearer.
    /// </summary>
    public KeycloakWebhookAuthenticationMode AuthenticationMode { get; set; } =
        KeycloakWebhookAuthenticationMode.None;

    /// <summary>Shared secret used by HMAC-SHA256 or HMAC-SHA1 authentication.</summary>
    public string? HmacSecret { get; set; }

    /// <summary>Validation settings used by bearer authentication.</summary>
    public KeycloakJwtValidationOptions Jwt { get; set; } = new();

    /// <summary>Maximum accepted request-body size in bytes.</summary>
    public long MaxRequestBodySize { get; set; } = 1024 * 1024;
}