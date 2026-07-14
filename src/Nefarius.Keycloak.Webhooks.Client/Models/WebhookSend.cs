using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Client.Models;

/// <summary>
/// Summarizes a webhook delivery attempt.
/// </summary>
public class WebhookSendSummary
{
    /// <summary>
    /// Gets or sets the delivery attempt identifier.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the normalized event type delivered to the webhook.
    /// </summary>
    [JsonPropertyName("type")]
    public string? EventType { get; set; }

    /// <summary>
    /// Gets or sets a brief representation of the target webhook.
    /// </summary>
    public WebhookSubscription? Webhook { get; set; }

    /// <summary>
    /// Gets or sets the HTTP status code returned by the target.
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// Gets or sets the human-readable target response status.
    /// </summary>
    [JsonPropertyName("status_message")]
    public string? StatusMessage { get; set; }

    /// <summary>
    /// Gets or sets the number of retries recorded for the attempt.
    /// </summary>
    public int? Retries { get; set; }

    /// <summary>
    /// Gets or sets when the attempt was sent.
    /// </summary>
    [JsonPropertyName("sent_at")]
    public DateTimeOffset? SentAt { get; set; }

    /// <summary>
    /// Gets or sets the stored webhook event identifier.
    /// </summary>
    [JsonPropertyName("event_id")]
    public string? EventId { get; set; }

    /// <summary>
    /// Gets or sets the native Keycloak event category, normally <c>ADMIN</c> or <c>USER</c>.
    /// </summary>
    [JsonPropertyName("keycloak_event_type")]
    public string? KeycloakEventType { get; set; }

    /// <summary>
    /// Gets or sets the source Keycloak event identifier.
    /// </summary>
    [JsonPropertyName("keycloak_event_id")]
    public string? KeycloakEventId { get; set; }
}

/// <summary>
/// Describes a webhook delivery attempt together with its raw JSON payload.
/// </summary>
public sealed class WebhookSendDetail : WebhookSendSummary
{
    /// <summary>
    /// Gets or sets the raw JSON payload sent to the target.
    /// </summary>
    public string? Payload { get; set; }
}