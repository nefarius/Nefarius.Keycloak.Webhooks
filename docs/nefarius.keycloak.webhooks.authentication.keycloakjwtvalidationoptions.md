# KeycloakJwtValidationOptions

Namespace: Nefarius.Keycloak.Webhooks.Authentication

Validation settings for realm-signed Keycloak webhook JWTs.

```csharp
public sealed class KeycloakJwtValidationOptions
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [KeycloakJwtValidationOptions](./nefarius.keycloak.webhooks.authentication.keycloakjwtvalidationoptions.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-audience"/>**Audience**

Expected webhook audience.

```csharp
public string Audience { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-clockskew"/>**ClockSkew**

Permitted clock difference while validating token times.

```csharp
public TimeSpan ClockSkew { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)<br>

### <a id="properties-issuer"/>**Issuer**

Expected realm issuer, for example `https://id.example/realms/acme`.

```csharp
public string Issuer { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-jwkscacheduration"/>**JwksCacheDuration**

How long downloaded signing keys may be reused.

```csharp
public TimeSpan JwksCacheDuration { get; set; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/dotnet/api/system.timespan)<br>

### <a id="properties-jwksuri"/>**JwksUri**

Realm JSON Web Key Set endpoint. Defaults to
 `{Issuer}/protocol/openid-connect/certs`.

```csharp
public Uri JwksUri { get; set; }
```

#### Property Value

[Uri](https://learn.microsoft.com/dotnet/api/system.uri)<br>

### <a id="properties-validalgorithms"/>**ValidAlgorithms**

Allowed signing algorithms. Keycloak defaults to RS256.

```csharp
public IReadOnlyCollection<String> ValidAlgorithms { get; set; }
```

#### Property Value

[IReadOnlyCollection](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlycollection-1)<[String](https://learn.microsoft.com/dotnet/api/system.string)><br>

## Constructors

### <a id="constructors-.ctor"/>**KeycloakJwtValidationOptions()**

```csharp
public KeycloakJwtValidationOptions()
```

## Methods

### <a id="methods-resolvejwksuri"/>**ResolveJwksUri()**

```csharp
internal Uri ResolveJwksUri()
```

#### Returns

[Uri](https://learn.microsoft.com/dotnet/api/system.uri)
