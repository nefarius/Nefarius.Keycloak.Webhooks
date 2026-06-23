using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Models;

/// <summary>
///     Authentication details carried on every Keycloak access event.
/// </summary>
public sealed class AuthDetails
{
    /// <summary>ID of the realm in which the authentication took place.</summary>
    [JsonPropertyName("realmId")]
    public string? RealmId { get; set; }

    /// <summary>Client (application) ID that initiated the request.</summary>
    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    /// <summary>Keycloak internal ID of the authenticated actor (user or service account).</summary>
    [JsonPropertyName("userId")]
    public Guid UserId { get; set; }

    /// <summary>IP address of the actor.</summary>
    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    /// <summary>Username of the authenticated actor.</summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>Keycloak session ID associated with the request.</summary>
    [JsonPropertyName("sessionId")]
    public string? SessionId { get; set; }
}

/// <summary>
///     Event-specific detail fields present on both access and admin events.
/// </summary>
public sealed class EventDetails
{
    /// <summary>Authentication protocol used, e.g. <c>openid-connect</c>.</summary>
    [JsonPropertyName("auth_method")]
    public string? AuthMethod { get; set; }

    /// <summary>OAuth 2.0 / OIDC grant type, e.g. <c>code</c>.</summary>
    [JsonPropertyName("auth_type")]
    public string? AuthType { get; set; }

    /// <summary>OIDC response type requested by the client, e.g. <c>code</c>.</summary>
    [JsonPropertyName("response_type")]
    public string? ResponseType { get; set; }

    /// <summary>Registration method, e.g. <c>form</c>.</summary>
    [JsonPropertyName("register_method")]
    public string? RegisterMethod { get; set; }

    /// <summary>Last name of the user (present on registration events).</summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    /// <summary>Client redirect URI that was active during the flow.</summary>
    [JsonPropertyName("redirect_uri")]
    public string? RedirectUri { get; set; }

    /// <summary>First name of the user (present on registration events).</summary>
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <summary>OIDC auth code / session correlation id.</summary>
    [JsonPropertyName("code_id")]
    public Guid CodeId { get; set; }

    /// <summary>E-mail address of the user.</summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>Username of the user.</summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>Whether the user selected "remember me" (<c>true</c>/<c>false</c> as string).</summary>
    [JsonPropertyName("remember_me")]
    public string? RememberMe { get; set; }

    /// <summary>OIDC response mode, e.g. <c>fragment</c> or <c>query</c>.</summary>
    [JsonPropertyName("response_mode")]
    public string? ResponseMode { get; set; }

    /// <summary>ID of the action token consumed by the event (e.g. email verification token).</summary>
    [JsonPropertyName("token_id")]
    public Guid TokenId { get; set; }

    /// <summary>Required action that was executed, e.g. <c>VERIFY_EMAIL</c>.</summary>
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    /// <summary>Keycloak internal ID of the affected user (present on admin user events).</summary>
    [JsonPropertyName("userId")]
    public Guid UserId { get; set; }
}

/// <summary>
///     Raw inbound payload delivered by the Keycloak <c>ext-event-webhook</c> extension.
/// </summary>
public sealed class KeycloakWebhookRequest
{
    /// <summary>Event timestamp as Unix epoch milliseconds.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }

    /// <summary>ID of the Keycloak realm in which the event occurred.</summary>
    [JsonPropertyName("realmId")]
    public string? RealmId { get; set; }

    /// <summary>Unique identifier of this event instance.</summary>
    [JsonPropertyName("uid")]
    public Guid Uid { get; set; }

    /// <summary>Authentication context of the actor who triggered the event.</summary>
    [JsonPropertyName("authDetails")]
    public AuthDetails? AuthDetails { get; set; }

    /// <summary>
    ///     Full event type string (e.g. <c>access.REGISTER</c> or <c>admin.USER-CREATE</c>).
    ///     For admin events this is the concatenation of <see cref="ResourceType" /> and <see cref="OperationType" />
    ///     with an <c>admin.</c> prefix.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>Event-specific detail fields; present on access events.</summary>
    [JsonPropertyName("details")]
    public EventDetails? Details { get; set; }

    /// <summary>Present on admin events only.</summary>
    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    /// <summary>Present on admin events only.</summary>
    [JsonPropertyName("operationType")]
    public string? OperationType { get; set; }

    /// <summary>Present on admin events only, e.g. <c>users/{id}/role-mappings/realm</c>.</summary>
    [JsonPropertyName("resourcePath")]
    public string? ResourcePath { get; set; }

    /// <summary>
    ///     JSON-encoded snapshot of the affected resource.
    ///     Only populated when <see cref="OperationType" /> is <c>CREATE</c> or <c>UPDATE</c>; <c>null</c> otherwise.
    /// </summary>
    [JsonPropertyName("representation")]
    public string? Representation { get; set; }
}
