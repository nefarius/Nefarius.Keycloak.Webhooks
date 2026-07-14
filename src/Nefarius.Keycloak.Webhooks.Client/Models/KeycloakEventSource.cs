namespace Nefarius.Keycloak.Webhooks.Client.Models;

/// <summary>
/// Identifies the native Keycloak event store containing a source event.
/// </summary>
public enum KeycloakEventSource
{
    /// <summary>
    /// An administrative event.
    /// </summary>
    Admin,

    /// <summary>
    /// A user event.
    /// </summary>
    User
}