using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     An administrator has created a new user (<c>admin.USER-CREATE</c>).
/// </summary>
public sealed class AdminUserCreatedEvent : AdminWebhookEvent
{
    /// <summary>Keycloak internal ID of the newly created user.</summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    /// <summary>Username assigned to the newly created user.</summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }
}