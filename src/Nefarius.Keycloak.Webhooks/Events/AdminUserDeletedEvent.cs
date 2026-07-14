using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     A user has been deleted (<c>admin.USER-DELETE</c>).
/// </summary>
public sealed class AdminUserDeletedEvent : AdminWebhookEvent
{
    /// <summary>Keycloak internal ID of the deleted user.</summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}