using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     A new user has self-registered via Keycloak (<c>access.REGISTER</c>).
/// </summary>
public sealed class AccessUserRegisteredEvent : WebhookBaseEvent
{
    /// <summary>Authentication protocol used, e.g. <c>openid-connect</c>.</summary>
    [JsonPropertyName("auth_method")]
    public string? AuthMethod { get; set; }

    /// <summary>OAuth 2.0 / OIDC grant type, e.g. <c>code</c>.</summary>
    [JsonPropertyName("auth_type")]
    public string? AuthType { get; set; }

    /// <summary>Registration method, e.g. <c>form</c>.</summary>
    [JsonPropertyName("register_method")]
    public string? RegisterMethod { get; set; }

    /// <summary>Last name provided during registration.</summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    /// <summary>Client redirect URI that initiated the registration flow.</summary>
    [JsonPropertyName("redirect_uri")]
    public string? RedirectUri { get; set; }

    /// <summary>First name provided during registration.</summary>
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <summary>OIDC auth code / session correlation id.</summary>
    [JsonPropertyName("code_id")]
    public Guid CodeId { get; set; }

    /// <summary>E-mail address of the newly registered user.</summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>Username chosen by the newly registered user.</summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
