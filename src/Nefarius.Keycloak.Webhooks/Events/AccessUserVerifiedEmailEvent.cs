using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     A user has successfully verified their e-mail address (<c>access.VERIFY_EMAIL</c>).
/// </summary>
public sealed class AccessUserVerifiedEmailEvent : WebhookBaseEvent
{
    /// <summary>Authentication protocol used, e.g. <c>openid-connect</c>.</summary>
    [JsonPropertyName("auth_method")]
    public string? AuthMethod { get; set; }

    /// <summary>ID of the action token that was consumed to verify the address.</summary>
    [JsonPropertyName("token_id")]
    public Guid TokenId { get; set; }

    /// <summary>Required action that was executed, e.g. <c>VERIFY_EMAIL</c>.</summary>
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    /// <summary>OIDC response type requested by the client, e.g. <c>code</c>.</summary>
    [JsonPropertyName("response_type")]
    public string? ResponseType { get; set; }

    /// <summary>Client redirect URI that was active during the flow.</summary>
    [JsonPropertyName("redirect_uri")]
    public string? RedirectUri { get; set; }

    /// <summary>Whether the user selected "remember me" (<c>true</c>/<c>false</c> as string).</summary>
    [JsonPropertyName("remember_me")]
    public string? RememberMe { get; set; }

    /// <summary>OIDC auth code / session correlation id.</summary>
    [JsonPropertyName("code_id")]
    public Guid CodeId { get; set; }

    /// <summary>E-mail address that was verified.</summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>OIDC response mode, e.g. <c>fragment</c> or <c>query</c>.</summary>
    [JsonPropertyName("response_mode")]
    public string? ResponseMode { get; set; }

    /// <summary>Username of the user who verified their e-mail address.</summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
