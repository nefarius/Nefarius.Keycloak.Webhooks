# KeycloakWebhookAuthenticator

Namespace: Nefarius.Keycloak.Webhooks.Authentication

Verifies authentication data emitted by `ext-event-webhook`.

```csharp
public sealed class KeycloakWebhookAuthenticator
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [KeycloakWebhookAuthenticator](./nefarius.keycloak.webhooks.authentication.keycloakwebhookauthenticator.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Constructors

### <a id="constructors-.ctor"/>**KeycloakWebhookAuthenticator(HttpClient)**

Creates an authenticator that retrieves realm signing keys with `httpClient`.

```csharp
public KeycloakWebhookAuthenticator(HttpClient httpClient)
```

#### Parameters

`httpClient` [HttpClient](https://learn.microsoft.com/dotnet/api/system.net.http.httpclient)<br>

## Methods

### <a id="methods-verifybearerasync"/>**VerifyBearerAsync(ReadOnlyMemory&lt;Byte&gt;, String, KeycloakJwtValidationOptions, CancellationToken)**

Verifies a realm-signed JWT, including issuer, audience, time, signature, and the
 `request_body_sha256` binding.

```csharp
public Task<KeycloakWebhookAuthenticationResult> VerifyBearerAsync(ReadOnlyMemory<Byte> body, string? token, KeycloakJwtValidationOptions options, CancellationToken cancellationToken)
```

#### Parameters

`body` [ReadOnlyMemory](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)<[Byte](https://learn.microsoft.com/dotnet/api/system.byte)><br>

`token` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>

`options` [KeycloakJwtValidationOptions](./nefarius.keycloak.webhooks.authentication.keycloakjwtvalidationoptions.md)<br>

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)<[KeycloakWebhookAuthenticationResult](./nefarius.keycloak.webhooks.authentication.keycloakwebhookauthenticationresult.md)>

### <a id="methods-verifyhmac"/>**VerifyHmac(ReadOnlyMemory&lt;Byte&gt;, String, String, KeycloakWebhookAuthenticationMode)**

Verifies the hexadecimal HMAC signature over the exact raw request bytes.

```csharp
public static KeycloakWebhookAuthenticationResult VerifyHmac(ReadOnlyMemory<Byte> body, string? signature, string secret, KeycloakWebhookAuthenticationMode mode)
```

#### Parameters

`body` [ReadOnlyMemory](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)<[Byte](https://learn.microsoft.com/dotnet/api/system.byte)><br>

`signature` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>

`secret` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>

`mode` [KeycloakWebhookAuthenticationMode](./nefarius.keycloak.webhooks.authentication.keycloakwebhookauthenticationmode.md)<br>

#### Returns

[KeycloakWebhookAuthenticationResult](./nefarius.keycloak.webhooks.authentication.keycloakwebhookauthenticationresult.md)
