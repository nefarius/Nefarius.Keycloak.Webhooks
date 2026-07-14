namespace Nefarius.Keycloak.Webhooks.Client.Models;

/// <summary>
/// Authentication type values accepted by the ext-event-webhook API.
/// </summary>
public static class WebhookAuthenticationTypes
{
    /// <summary>
    /// Sends webhook payloads without authentication.
    /// </summary>
    public const string None = "none";

    /// <summary>
    /// Signs webhook payloads with a shared-secret HMAC.
    /// </summary>
    public const string Hmac = "hmac";

    /// <summary>
    /// Authenticates webhook payloads with a realm-signed bearer JWT.
    /// </summary>
    public const string Bearer = "bearer";
}