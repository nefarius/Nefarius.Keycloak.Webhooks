using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Client.Models;

/// <summary>
/// Describes caller-supplied data for a custom webhook event.
/// </summary>
public sealed class CustomWebhookEvent
{
    /// <summary>
    /// Gets or sets the custom event type. Values beginning with <c>access.</c>, <c>admin.</c>, or
    /// <c>system.</c> are reserved by the server.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the event timestamp as Unix epoch milliseconds. The server supplies the current time when omitted.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? Time { get; set; }

    /// <summary>
    /// Gets or sets application-defined string details.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IDictionary<string, string>? Details { get; set; }

    /// <summary>
    /// Gets or sets an application-defined event identifier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets an optional resource type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ResourceType { get; set; }

    /// <summary>
    /// Gets or sets an optional operation type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OperationType { get; set; }

    /// <summary>
    /// Gets or sets an optional resource path.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ResourcePath { get; set; }

    /// <summary>
    /// Gets or sets an optional serialized resource representation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Representation { get; set; }

    /// <summary>
    /// Gets or sets an optional error value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Error { get; set; }

    /// <summary>
    /// Gets or sets additional JSON properties included in the custom event.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? AdditionalProperties { get; set; }
}

/// <summary>
/// Describes a normalized event payload stored by ext-event-webhook.
/// </summary>
public sealed class WebhookEventPayload
{
    /// <summary>
    /// Gets or sets the unique webhook payload identifier.
    /// </summary>
    public string? Uid { get; set; }

    /// <summary>
    /// Gets or sets the normalized event type.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the event timestamp as Unix epoch milliseconds.
    /// </summary>
    public long Time { get; set; }

    /// <summary>
    /// Gets or sets the source event identifier.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the realm identifier.
    /// </summary>
    public string? RealmId { get; set; }

    /// <summary>
    /// Gets or sets the realm name.
    /// </summary>
    public string? RealmName { get; set; }

    /// <summary>
    /// Gets or sets authentication details associated with the source event.
    /// </summary>
    public WebhookEventAuthenticationDetails? AuthDetails { get; set; }

    /// <summary>
    /// Gets or sets event-specific string details.
    /// </summary>
    public IDictionary<string, string>? Details { get; set; }

    /// <summary>
    /// Gets or sets the administrative resource type.
    /// </summary>
    public string? ResourceType { get; set; }

    /// <summary>
    /// Gets or sets the administrative operation type.
    /// </summary>
    public string? OperationType { get; set; }

    /// <summary>
    /// Gets or sets the administrative resource path.
    /// </summary>
    public string? ResourcePath { get; set; }

    /// <summary>
    /// Gets or sets the source resource identifier.
    /// </summary>
    public string? ResourceId { get; set; }

    /// <summary>
    /// Gets or sets the serialized source resource representation.
    /// </summary>
    public string? Representation { get; set; }

    /// <summary>
    /// Gets or sets an event error value.
    /// </summary>
    public string? Error { get; set; }

    /// <summary>
    /// Gets or sets additional payload properties emitted by the installed extension version.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement>? AdditionalProperties { get; set; }
}

/// <summary>
/// Describes authentication context attached to a normalized webhook event.
/// </summary>
public sealed class WebhookEventAuthenticationDetails
{
    /// <summary>
    /// Gets or sets the authenticating realm identifier or name.
    /// </summary>
    public string? RealmId { get; set; }

    /// <summary>
    /// Gets or sets the authenticating client identifier.
    /// </summary>
    public string? ClientId { get; set; }

    /// <summary>
    /// Gets or sets the source IP address.
    /// </summary>
    public string? IpAddress { get; set; }

    /// <summary>
    /// Gets or sets the authenticating user identifier.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Gets or sets the authenticating username.
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the authentication session identifier.
    /// </summary>
    public string? SessionId { get; set; }
}