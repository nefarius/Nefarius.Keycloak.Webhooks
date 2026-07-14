namespace Nefarius.Keycloak.Webhooks.Authentication;

/// <summary>Result of authenticating an inbound webhook request.</summary>
public sealed class KeycloakWebhookAuthenticationResult
{
    private KeycloakWebhookAuthenticationResult(bool succeeded, string? error)
    {
        Succeeded = succeeded;
        Error = error;
    }

    /// <summary>Whether the request passed all configured checks.</summary>
    public bool Succeeded { get; }

    /// <summary>Non-sensitive failure description.</summary>
    public string? Error { get; }

    /// <summary>Creates a successful result.</summary>
    public static KeycloakWebhookAuthenticationResult Success()
        => new(true, null);

    /// <summary>Creates a failed result.</summary>
    public static KeycloakWebhookAuthenticationResult Failure(string error)
        => new(false, error);
}