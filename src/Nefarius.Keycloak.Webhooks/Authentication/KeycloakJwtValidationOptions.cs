namespace Nefarius.Keycloak.Webhooks.Authentication;

/// <summary>Validation settings for realm-signed Keycloak webhook JWTs.</summary>
public sealed class KeycloakJwtValidationOptions
{
    /// <summary>Expected realm issuer, for example <c>https://id.example/realms/acme</c>.</summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>Expected webhook audience.</summary>
    public string Audience { get; set; } = string.Empty;

    /// <summary>
    ///     Realm JSON Web Key Set endpoint. Defaults to
    ///     <c>{Issuer}/protocol/openid-connect/certs</c>.
    /// </summary>
    public Uri? JwksUri { get; set; }

    /// <summary>Allowed signing algorithms. Keycloak defaults to RS256.</summary>
    public IReadOnlyCollection<string> ValidAlgorithms { get; set; } = new[] { "RS256" };

    /// <summary>Permitted clock difference while validating token times.</summary>
    public TimeSpan ClockSkew { get; set; } = TimeSpan.FromMinutes(1);

    /// <summary>How long downloaded signing keys may be reused.</summary>
    public TimeSpan JwksCacheDuration { get; set; } = TimeSpan.FromMinutes(15);

    internal Uri ResolveJwksUri()
    {
        if (JwksUri is not null)
        {
            return JwksUri;
        }

        return new Uri($"{Issuer.TrimEnd('/')}/protocol/openid-connect/certs", UriKind.Absolute);
    }
}