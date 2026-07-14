# KeycloakWebhookAuthenticationResult

Namespace: Nefarius.Keycloak.Webhooks.Authentication

Result of authenticating an inbound webhook request.

```csharp
public sealed class KeycloakWebhookAuthenticationResult
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [KeycloakWebhookAuthenticationResult](./nefarius.keycloak.webhooks.authentication.keycloakwebhookauthenticationresult.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-error"/>**Error**

Non-sensitive failure description.

```csharp
public string? Error { get; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-succeeded"/>**Succeeded**

Whether the request passed all configured checks.

```csharp
public bool Succeeded { get; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/dotnet/api/system.boolean)<br>

## Methods

### <a id="methods-failure"/>**Failure(String)**

Creates a failed result.

```csharp
public static KeycloakWebhookAuthenticationResult Failure(string error)
```

#### Parameters

`error` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>

#### Returns

[KeycloakWebhookAuthenticationResult](./nefarius.keycloak.webhooks.authentication.keycloakwebhookauthenticationresult.md)

### <a id="methods-success"/>**Success()**

Creates a successful result.

```csharp
public static KeycloakWebhookAuthenticationResult Success()
```

#### Returns

[KeycloakWebhookAuthenticationResult](./nefarius.keycloak.webhooks.authentication.keycloakwebhookauthenticationresult.md)
