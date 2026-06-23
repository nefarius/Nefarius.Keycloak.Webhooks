using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     An administrator has created a new user (<c>admin.USER-CREATE</c>).
/// </summary>
public sealed class AdminUserCreatedEvent : WebhookBaseEvent
{
    [JsonPropertyName("userId")]
    public Guid UserId { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
