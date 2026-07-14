namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     Any native Keycloak user event. Its <see cref="WebhookBaseEvent.Type" /> starts with
///     <c>access.</c>.
/// </summary>
public class UserWebhookEvent : WebhookBaseEvent
{
    /// <summary>Client that initiated the user event.</summary>
    public string? ClientId => AuthDetails?.ClientId;

    /// <summary>User affected by the event.</summary>
    public string? UserId => AuthDetails?.UserId;

    /// <summary>Keycloak user-session identifier.</summary>
    public string? SessionId => AuthDetails?.SessionId;

    /// <summary>Address from which the event originated.</summary>
    public string? IpAddress => AuthDetails?.IpAddress;
}