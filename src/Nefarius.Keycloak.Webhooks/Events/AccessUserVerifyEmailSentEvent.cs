using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     A verification e-mail has been dispatched to a user (<c>access.SEND_VERIFY_EMAIL</c>).
/// </summary>
public sealed class AccessUserVerifyEmailSentEvent : WebhookBaseEvent
{
    /// <summary>Authentication protocol used, e.g. <c>openid-connect</c>.</summary>
    [JsonPropertyName("auth_method")]
    public string? AuthMethod { get; set; }

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

    /// <summary>Destination e-mail address to which the verification mail was sent.</summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>OIDC response mode, e.g. <c>fragment</c> or <c>query</c>.</summary>
    [JsonPropertyName("response_mode")]
    public string? ResponseMode { get; set; }

    /// <summary>Username of the user to whom the verification e-mail was dispatched.</summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
