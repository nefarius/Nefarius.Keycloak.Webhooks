using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     An administrator has created a new user (<c>admin.USER-CREATE</c>).
/// </summary>
public sealed class AdminUserCreatedEvent : WebhookBaseEvent
{
    /// <summary>Keycloak internal ID of the newly created user.</summary>
    [JsonPropertyName("userId")]
    public Guid UserId { get; set; }

    /// <summary>Username assigned to the newly created user.</summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
