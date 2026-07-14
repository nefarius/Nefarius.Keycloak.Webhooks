using System.Text.Json;
using System.Text.Json.Serialization;

using Nefarius.Keycloak.Webhooks.Models;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     Common properties shared by every strongly-typed Keycloak webhook event.
/// </summary>
public abstract class WebhookBaseEvent
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

    /// <summary>Original Keycloak event identifier, shared by fan-out deliveries and retries.</summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>Unique identifier of this webhook delivery.</summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

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

    /// <summary>Open-ended event details supplied by Keycloak.</summary>
    [JsonPropertyName("details")]
    public IReadOnlyDictionary<string, string?> Details { get; set; } =
        new Dictionary<string, string?>();

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
    ///     JSON-encoded snapshot of the affected resource.
    ///     Only populated when <see cref="OperationType" /> is <c>CREATE</c> or <c>UPDATE</c>; <c>null</c> otherwise.
    /// </summary>
    [JsonPropertyName("representation")]
    public string? Representation { get; set; }

    /// <summary>
    ///     Exact parsed JSON payload when the event was created by <see cref="KeycloakWebhookParser.Parse(string,System.Text.Json.JsonSerializerOptions?)" />.
    /// </summary>
    [JsonIgnore]
    public JsonElement? RawPayload { get; internal set; }

    /// <summary>Returns an event detail value, or <c>null</c> when it is absent.</summary>
    public string? GetDetail(string name)
        => Details.TryGetValue(name, out string? value) ? value : null;

    /// <summary>Deserializes the JSON-encoded admin representation.</summary>
    public T? DeserializeRepresentation<T>(JsonSerializerOptions? options = null)
        => Representation is null ? default : JsonSerializer.Deserialize<T>(Representation, options);
}