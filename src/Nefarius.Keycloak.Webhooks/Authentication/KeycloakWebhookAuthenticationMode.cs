namespace Nefarius.Keycloak.Webhooks.Authentication;

/// <summary>Authentication modes supported by the Keycloak webhook sender.</summary>
public enum KeycloakWebhookAuthenticationMode
{
    /// <summary>The request carries no sender authentication.</summary>
    None,

    /// <summary>The raw request body is authenticated by <c>X-Keycloak-Signature</c>.</summary>
    HmacSha256,

    /// <summary>Legacy HMAC-SHA1 authentication.</summary>
    HmacSha1,

    /// <summary>The request carries a realm-signed bearer JWT.</summary>
    Bearer
}