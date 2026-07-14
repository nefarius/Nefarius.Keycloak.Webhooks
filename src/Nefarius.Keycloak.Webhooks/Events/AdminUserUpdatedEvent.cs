using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     An administrator has updated a user (<c>admin.USER-UPDATE</c>).
/// </summary>
public sealed class AdminUserUpdatedEvent : AdminWebhookEvent
{
    /// <summary>Keycloak internal ID of the updated user.</summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    /// <summary>Username of the updated user.</summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }
}