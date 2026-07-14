namespace Nefarius.Keycloak.Webhooks.Client.Models;

/// <summary>
/// Specifies zero-based pagination parameters for list operations.
/// </summary>
public sealed class PaginationOptions
{
    /// <summary>
    /// Gets or sets the zero-based index of the first result.
    /// </summary>
    public int? First { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of results. Upstream v0.62 limits this value to 100.
    /// </summary>
    public int? Max { get; set; }
}