using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     An administrator has updated a user (<c>admin.USER-UPDATE</c>).
/// </summary>
public sealed class AdminUserUpdatedEvent : WebhookBaseEvent
{
    /// <summary>Keycloak internal ID of the updated user.</summary>
    [JsonPropertyName("userId")]
    public Guid UserId { get; set; }

    /// <summary>Username of the updated user.</summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
