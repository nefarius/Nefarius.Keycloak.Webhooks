using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Models;

/// <summary>
///     Authentication details carried on every Keycloak access event.
/// </summary>
public sealed class AuthDetails
{
    [JsonPropertyName("realmId")]
    public string? RealmId { get; set; }

    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("userId")]
    public Guid UserId { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("sessionId")]
    public string? SessionId { get; set; }
}

/// <summary>
///     Event-specific detail fields present on both access and admin events.
/// </summary>
public sealed class EventDetails
{
    [JsonPropertyName("auth_method")]
    public string? AuthMethod { get; set; }

    [JsonPropertyName("auth_type")]
    public string? AuthType { get; set; }

    [JsonPropertyName("response_type")]
    public string? ResponseType { get; set; }

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

    [JsonPropertyName("remember_me")]
    public string? RememberMe { get; set; }

    [JsonPropertyName("response_mode")]
    public string? ResponseMode { get; set; }

    [JsonPropertyName("token_id")]
    public Guid TokenId { get; set; }

    [JsonPropertyName("action")]
    public string? Action { get; set; }

    [JsonPropertyName("userId")]
    public Guid UserId { get; set; }
}

/// <summary>
///     Raw inbound payload delivered by the Keycloak <c>ext-event-webhook</c> extension.
/// </summary>
public sealed class KeycloakWebhookRequest
{
    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("realmId")]
    public string? RealmId { get; set; }

    [JsonPropertyName("uid")]
    public Guid Uid { get; set; }

    [JsonPropertyName("authDetails")]
    public AuthDetails? AuthDetails { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

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

    /// <summary>JSON-encoded resource snapshot, present on some admin events.</summary>
    [JsonPropertyName("representation")]
    public string? Representation { get; set; }
}
