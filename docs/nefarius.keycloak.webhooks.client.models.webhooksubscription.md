# WebhookSubscription

Namespace: Nefarius.Keycloak.Webhooks.Client.Models

Describes an ext-event-webhook subscription.

```csharp
public sealed class WebhookSubscription
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [WebhookSubscription](./nefarius.keycloak.webhooks.client.models.webhooksubscription.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-algorithm"/>**Algorithm**

Gets or sets the signing algorithm, such as `HmacSHA256` or `RS256`.

```csharp
public string? Algorithm { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-audience"/>**Audience**

Gets or sets the expected audience for bearer JWT authentication.

```csharp
public string? Audience { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-authtype"/>**AuthType**

Gets or sets an authentication type from [WebhookAuthenticationTypes](./nefarius.keycloak.webhooks.client.models.webhookauthenticationtypes.md).

```csharp
public string? AuthType { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-createdat"/>**CreatedAt**

Gets or sets the webhook creation time.

```csharp
public Nullable<DateTimeOffset> CreatedAt { get; set; }
```

#### Property Value

[Nullable](https://learn.microsoft.com/dotnet/api/system.nullable-1)<[DateTimeOffset](https://learn.microsoft.com/dotnet/api/system.datetimeoffset)><br>

### <a id="properties-createdby"/>**CreatedBy**

Gets or sets the identifier of the user that created the webhook.

```csharp
public string? CreatedBy { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-enabled"/>**Enabled**

Gets or sets whether delivery is enabled.

```csharp
public bool Enabled { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/dotnet/api/system.boolean)<br>

### <a id="properties-eventtypes"/>**EventTypes**

Gets or sets event type expressions, including wildcard expressions such as `*`.

```csharp
public ISet<String>? EventTypes { get; set; }
```

#### Property Value

[ISet](https://learn.microsoft.com/dotnet/api/system.collections.generic.iset-1)<[String](https://learn.microsoft.com/dotnet/api/system.string)><br>

### <a id="properties-id"/>**Id**

Gets or sets the server-assigned webhook identifier.

```csharp
public string? Id { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-realm"/>**Realm**

Gets or sets the realm containing the webhook.

```csharp
public string? Realm { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-secret"/>**Secret**

Gets or sets the shared secret used for HMAC authentication.
 The API omits this property from normal webhook responses.

```csharp
public string? Secret { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-url"/>**Url**

Gets or sets the target URL.

```csharp
public string? Url { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

## Constructors

### <a id="constructors-.ctor"/>**WebhookSubscription()**

```csharp
public WebhookSubscription()
```
