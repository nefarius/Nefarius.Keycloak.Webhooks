using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     An administrator has updated a user (<c>admin.USER-UPDATE</c>).
/// </summary>
public sealed class AdminUserUpdatedEvent : WebhookBaseEvent
{
    [JsonPropertyName("userId")]
    public Guid UserId { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
