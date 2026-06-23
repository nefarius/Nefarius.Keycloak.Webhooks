using System.Text.Json.Serialization;

using Nefarius.Keycloak.Webhooks.Models;

namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     Common properties shared by every strongly-typed Keycloak webhook event.
/// </summary>
public abstract class WebhookBaseEvent
{
    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("realmId")]
    public string? RealmId { get; set; }

    [JsonPropertyName("uid")]
    public Guid Uid { get; set; }

    [JsonPropertyName("authDetails")]
    public AuthDetails AuthDetails { get; set; } = new();

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

    /// <summary>JSON-encoded resource snapshot, present on some admin events.</summary>
    [JsonPropertyName("representation")]
    public string? Representation { get; set; }
}
