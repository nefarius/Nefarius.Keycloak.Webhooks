# WebhookEventPayload

Namespace: Nefarius.Keycloak.Webhooks.Client.Models

Describes a normalized event payload stored by ext-event-webhook.

```csharp
public sealed class WebhookEventPayload
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [WebhookEventPayload](./nefarius.keycloak.webhooks.client.models.webhookeventpayload.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-additionalproperties"/>**AdditionalProperties**

Gets or sets additional payload properties emitted by the installed extension version.

```csharp
public IDictionary<String, JsonElement>? AdditionalProperties { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[String](https://learn.microsoft.com/dotnet/api/system.string), [JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)><br>

### <a id="properties-authdetails"/>**AuthDetails**

Gets or sets authentication details associated with the source event.

```csharp
public WebhookEventAuthenticationDetails? AuthDetails { get; set; }
```

#### Property Value

[WebhookEventAuthenticationDetails](./nefarius.keycloak.webhooks.client.models.webhookeventauthenticationdetails.md)<br>

### <a id="properties-details"/>**Details**

Gets or sets event-specific string details.

```csharp
public IDictionary<String, String>? Details { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[String](https://learn.microsoft.com/dotnet/api/system.string), [String](https://learn.microsoft.com/dotnet/api/system.string)><br>

### <a id="properties-error"/>**Error**

Gets or sets an event error value.

```csharp
public string? Error { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-id"/>**Id**

Gets or sets the source event identifier.

```csharp
public string? Id { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-operationtype"/>**OperationType**

Gets or sets the administrative operation type.

```csharp
public string? OperationType { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-realmid"/>**RealmId**

Gets or sets the realm identifier.

```csharp
public string? RealmId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-realmname"/>**RealmName**

Gets or sets the realm name.

```csharp
public string? RealmName { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-representation"/>**Representation**

Gets or sets the serialized source resource representation.

```csharp
public string? Representation { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-resourceid"/>**ResourceId**

Gets or sets the source resource identifier.

```csharp
public string? ResourceId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-resourcepath"/>**ResourcePath**

Gets or sets the administrative resource path.

```csharp
public string? ResourcePath { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-resourcetype"/>**ResourceType**

Gets or sets the administrative resource type.

```csharp
public string? ResourceType { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-time"/>**Time**

Gets or sets the event timestamp as Unix epoch milliseconds.

```csharp
public long Time { get; set; }
```

#### Property Value

[Int64](https://learn.microsoft.com/dotnet/api/system.int64)<br>

### <a id="properties-type"/>**Type**

Gets or sets the normalized event type.

```csharp
public string? Type { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-uid"/>**Uid**

Gets or sets the unique webhook payload identifier.

```csharp
public string? Uid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

## Constructors

### <a id="constructors-.ctor"/>**WebhookEventPayload()**

```csharp
public WebhookEventPayload()
```
