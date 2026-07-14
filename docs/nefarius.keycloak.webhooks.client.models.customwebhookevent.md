# CustomWebhookEvent

Namespace: Nefarius.Keycloak.Webhooks.Client.Models

Describes caller-supplied data for a custom webhook event.

```csharp
public sealed class CustomWebhookEvent
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [CustomWebhookEvent](./nefarius.keycloak.webhooks.client.models.customwebhookevent.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-additionalproperties"/>**AdditionalProperties**

Gets or sets additional JSON properties included in the custom event.

```csharp
public IDictionary<String, JsonElement> AdditionalProperties { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[String](https://learn.microsoft.com/dotnet/api/system.string), [JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)><br>

### <a id="properties-details"/>**Details**

Gets or sets application-defined string details.

```csharp
public IDictionary<String, String> Details { get; set; }
```

#### Property Value

[IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.idictionary-2)<[String](https://learn.microsoft.com/dotnet/api/system.string), [String](https://learn.microsoft.com/dotnet/api/system.string)><br>

### <a id="properties-error"/>**Error**

Gets or sets an optional error value.

```csharp
public string Error { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-id"/>**Id**

Gets or sets an application-defined event identifier.

```csharp
public string Id { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-operationtype"/>**OperationType**

Gets or sets an optional operation type.

```csharp
public string OperationType { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-representation"/>**Representation**

Gets or sets an optional serialized resource representation.

```csharp
public string Representation { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-resourcepath"/>**ResourcePath**

Gets or sets an optional resource path.

```csharp
public string ResourcePath { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-resourcetype"/>**ResourceType**

Gets or sets an optional resource type.

```csharp
public string ResourceType { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-time"/>**Time**

Gets or sets the event timestamp as Unix epoch milliseconds. The server supplies the current time when omitted.

```csharp
public Nullable<Int64> Time { get; set; }
```

#### Property Value

[Nullable](https://learn.microsoft.com/dotnet/api/system.nullable-1)<[Int64](https://learn.microsoft.com/dotnet/api/system.int64)><br>

### <a id="properties-type"/>**Type**

Gets or sets the custom event type. Values beginning with `access.`, `admin.`, or
 `system.` are reserved by the server.

```csharp
public string Type { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

## Constructors

### <a id="constructors-.ctor"/>**CustomWebhookEvent()**

```csharp
public CustomWebhookEvent()
```
