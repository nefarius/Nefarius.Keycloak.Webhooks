using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Models;

/// <summary>
///     Authentication details attached to an event by Keycloak.
/// </summary>
public sealed class AuthDetails
{
    /// <summary>
    ///     Name of the realm in which the actor authenticated. The upstream wire name is
    ///     <c>realmId</c> for historical reasons.
    /// </summary>
    [JsonPropertyName("realmId")]
    public string? RealmId { get; set; }

    /// <summary>Name of the realm in which the actor authenticated, when supplied by Keycloak.</summary>
    [JsonPropertyName("realmName")]
    public string? RealmName { get; set; }

    /// <summary>Client (application) ID that initiated the request.</summary>
    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    /// <summary>Opaque Keycloak ID of the authenticated actor (user or service account).</summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

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

    /// <summary>Name of the realm in which the event occurred.</summary>
    [JsonPropertyName("realmName")]
    public string? RealmName { get; set; }

    /// <summary>Original Keycloak event identifier, shared by deliveries to multiple webhooks.</summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>Unique identifier of this webhook delivery.</summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>Authentication context of the actor who triggered the event.</summary>
    [JsonPropertyName("authDetails")]
    public AuthDetails? AuthDetails { get; set; }

    /// <summary>Legacy <c>ext-event-http</c> client identifier.</summary>
    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    /// <summary>Legacy <c>ext-event-http</c> user identifier.</summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    /// <summary>Legacy <c>ext-event-http</c> session identifier.</summary>
    [JsonPropertyName("sessionId")]
    public string? SessionId { get; set; }

    /// <summary>Legacy <c>ext-event-http</c> source address.</summary>
    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    /// <summary>
    ///     Full event type string (e.g. <c>access.REGISTER</c> or <c>admin.USER-CREATE</c>).
    ///     For admin events this is the concatenation of <see cref="ResourceType" /> and <see cref="OperationType" />
    ///     with an <c>admin.</c> prefix.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>Open-ended event details supplied by Keycloak.</summary>
    [JsonPropertyName("details")]
    public Dictionary<string, string?>? Details { get; set; }

    /// <summary>Error associated with a failed user or admin event.</summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>Present on admin events only.</summary>
    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    /// <summary>Opaque identifier of the affected admin resource, when available.</summary>
    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    /// <summary>Present on admin events only.</summary>
    [JsonPropertyName("operationType")]
    public string? OperationType { get; set; }

    /// <summary>Present on admin events only, e.g. <c>users/{id}/role-mappings/realm</c>.</summary>
    [JsonPropertyName("resourcePath")]
    public string? ResourcePath { get; set; }

    /// <summary>
    ///     JSON-encoded snapshot of the affected resource when Keycloak admin-event details are enabled.
    /// </summary>
    [JsonPropertyName("representation")]
    public string? Representation { get; set; }

    /// <summary>Additional fields emitted by Keycloak or future extension versions.</summary>
    [JsonExtensionData]
    public Dictionary<string, System.Text.Json.JsonElement>? ExtensionData { get; set; }
}