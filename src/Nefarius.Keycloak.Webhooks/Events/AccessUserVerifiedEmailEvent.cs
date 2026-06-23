using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     A user has successfully verified their e-mail address (<c>access.VERIFY_EMAIL</c>).
/// </summary>
public sealed class AccessUserVerifiedEmailEvent : WebhookBaseEvent
{
    [JsonPropertyName("auth_method")]
    public string? AuthMethod { get; set; }

    [JsonPropertyName("token_id")]
    public Guid TokenId { get; set; }

    [JsonPropertyName("action")]
    public string? Action { get; set; }

    [JsonPropertyName("response_type")]
    public string? ResponseType { get; set; }

    [JsonPropertyName("redirect_uri")]
    public string? RedirectUri { get; set; }

    [JsonPropertyName("remember_me")]
    public string? RememberMe { get; set; }

    [JsonPropertyName("code_id")]
    public Guid CodeId { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("response_mode")]
    public string? ResponseMode { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
