# KeycloakWebhookOptions

Namespace: Nefarius.Keycloak.Webhooks.FastEndpoints

Configuration options for the Keycloak webhook FastEndpoints integration.

```csharp
public sealed class KeycloakWebhookOptions
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [KeycloakWebhookOptions](./nefarius.keycloak.webhooks.fastendpoints.keycloakwebhookoptions.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-allowanonymous"/>**AllowAnonymous**

When `true` (default), the endpoint allows anonymous access.
 Set to `false` if you protect the route with network-level controls or custom auth.

```csharp
public bool AllowAnonymous { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/dotnet/api/system.boolean)<br>

### <a id="properties-route"/>**Route**

The route pattern on which the webhook endpoint listens.
 Defaults to `/api/webhooks/{Id}` (the `{Id}` segment is unused but kept for
 compatibility with existing Keycloak webhook URL configurations).

```csharp
public string Route { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

## Constructors

### <a id="constructors-.ctor"/>**KeycloakWebhookOptions()**

```csharp
public KeycloakWebhookOptions()
```
