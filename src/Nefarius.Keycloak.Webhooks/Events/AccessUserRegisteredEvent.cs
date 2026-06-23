using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     A new user has self-registered via Keycloak (<c>access.REGISTER</c>).
/// </summary>
public sealed class AccessUserRegisteredEvent : WebhookBaseEvent
{
    [JsonPropertyName("auth_method")]
    public string? AuthMethod { get; set; }

    [JsonPropertyName("auth_type")]
    public string? AuthType { get; set; }

    [JsonPropertyName("register_method")]
    public string? RegisterMethod { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("redirect_uri")]
    public string? RedirectUri { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("code_id")]
    public Guid CodeId { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
