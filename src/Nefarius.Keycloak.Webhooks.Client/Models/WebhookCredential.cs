namespace Nefarius.Keycloak.Webhooks.Client.Models;

/// <summary>
/// Contains a webhook credential returned by the secret endpoint.
/// </summary>
public sealed class WebhookCredential
{
    /// <summary>
    /// Gets or sets the credential type. Upstream v0.62 returns <c>secret</c>.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the credential value.
    /// </summary>
    public string? Value { get; set; }
}