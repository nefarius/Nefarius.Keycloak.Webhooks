using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     A user has been deleted (<c>admin.USER-DELETE</c>).
/// </summary>
public sealed class AdminUserDeletedEvent : WebhookBaseEvent
{
    /// <summary>Keycloak internal ID of the deleted user.</summary>
    [JsonPropertyName("userId")]
    public Guid UserId { get; set; }
}
