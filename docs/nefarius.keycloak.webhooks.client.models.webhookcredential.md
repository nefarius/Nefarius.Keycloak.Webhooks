# WebhookCredential

Namespace: Nefarius.Keycloak.Webhooks.Client.Models

Contains a webhook credential returned by the secret endpoint.

```csharp
public sealed class WebhookCredential
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [WebhookCredential](./nefarius.keycloak.webhooks.client.models.webhookcredential.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-type"/>**Type**

Gets or sets the credential type. Upstream v0.62 returns `secret`.

```csharp
public string? Type { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-value"/>**Value**

Gets or sets the credential value.

```csharp
public string? Value { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

## Constructors

### <a id="constructors-.ctor"/>**WebhookCredential()**

```csharp
public WebhookCredential()
```
