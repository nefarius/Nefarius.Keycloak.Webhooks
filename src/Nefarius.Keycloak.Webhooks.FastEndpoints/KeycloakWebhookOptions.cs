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
}
