using System.Text.Json.Serialization;

namespace Nefarius.Keycloak.Webhooks.Client.Models;

/// <summary>
/// Describes an ext-event-webhook subscription.
/// </summary>
public sealed class WebhookSubscription
{
    /// <summary>
    /// Gets or sets the server-assigned webhook identifier.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets whether delivery is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets the target URL.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Gets or sets the shared secret used for HMAC authentication.
    /// The API omits this property from normal webhook responses.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Secret { get; set; }

    /// <summary>
    /// Gets or sets the signing algorithm, such as <c>HmacSHA256</c> or <c>RS256</c>.
    /// </summary>
    public string? Algorithm { get; set; }

    /// <summary>
    /// Gets or sets an authentication type from <see cref="WebhookAuthenticationTypes"/>.
    /// </summary>
    public string? AuthType { get; set; }

    /// <summary>
    /// Gets or sets the expected audience for bearer JWT authentication.
    /// </summary>
    public string? Audience { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user that created the webhook.
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the webhook creation time.
    /// </summary>
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the realm containing the webhook.
    /// </summary>
    public string? Realm { get; set; }

    /// <summary>
    /// Gets or sets event type expressions, including wildcard expressions such as <c>*</c>.
    /// </summary>
    public ISet<string>? EventTypes { get; set; }
}