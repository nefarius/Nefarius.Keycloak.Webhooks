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

    /// <summary>Unique identifier of this event instance.</summary>
    [JsonPropertyName("uid")]
    public Guid Uid { get; set; }

    /// <summary>Authentication context of the actor who triggered the event.</summary>
    [JsonPropertyName("authDetails")]
    public AuthDetails AuthDetails { get; set; } = new();

    /// <summary>
    ///     Full event type string (e.g. <c>access.REGISTER</c> or <c>admin.USER-CREATE</c>).
    ///     For admin events this is the concatenation of <see cref="ResourceType" /> and <see cref="OperationType" />
    ///     with an <c>admin.</c> prefix.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

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
