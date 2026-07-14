# KeycloakWebhookRequest

Namespace: Nefarius.Keycloak.Webhooks.Models

Raw inbound payload delivered by the Keycloak `ext-event-webhook` extension.

```csharp
public sealed class KeycloakWebhookRequest
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [KeycloakWebhookRequest](./nefarius.keycloak.webhooks.models.keycloakwebhookrequest.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-authdetails"/>**AuthDetails**

Authentication context of the actor who triggered the event.

```csharp
public AuthDetails AuthDetails { get; set; }
```

#### Property Value

[AuthDetails](./nefarius.keycloak.webhooks.models.authdetails.md)<br>

### <a id="properties-clientid"/>**ClientId**

Legacy `ext-event-http` client identifier.

```csharp
public string ClientId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-details"/>**Details**

Open-ended event details supplied by Keycloak.

```csharp
public Dictionary<String, String> Details { get; set; }
```

#### Property Value

[Dictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.dictionary-2)<[String](https://learn.microsoft.com/dotnet/api/system.string), [String](https://learn.microsoft.com/dotnet/api/system.string)><br>

### <a id="properties-error"/>**Error**

Error associated with a failed user or admin event.

```csharp
public string Error { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-extensiondata"/>**ExtensionData**

Additional fields emitted by Keycloak or future extension versions.

```csharp
public Dictionary<String, JsonElement> ExtensionData { get; set; }
```

#### Property Value

[Dictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.dictionary-2)<[String](https://learn.microsoft.com/dotnet/api/system.string), [JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)><br>

### <a id="properties-id"/>**Id**

Original Keycloak event identifier, shared by deliveries to multiple webhooks.

```csharp
public string Id { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-ipaddress"/>**IpAddress**

Legacy `ext-event-http` source address.

```csharp
public string IpAddress { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-operationtype"/>**OperationType**

Present on admin events only.

```csharp
public string OperationType { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-realmid"/>**RealmId**

ID of the Keycloak realm in which the event occurred.

```csharp
public string RealmId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-realmname"/>**RealmName**

Name of the realm in which the event occurred.

```csharp
public string RealmName { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-representation"/>**Representation**

JSON-encoded snapshot of the affected resource when Keycloak admin-event details are enabled.

```csharp
public string Representation { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-resourceid"/>**ResourceId**

Opaque identifier of the affected admin resource, when available.

```csharp
public string ResourceId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-resourcepath"/>**ResourcePath**

Present on admin events only, e.g. `users/{id}/role-mappings/realm`.

```csharp
public string ResourcePath { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-resourcetype"/>**ResourceType**

Present on admin events only.

```csharp
public string ResourceType { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-sessionid"/>**SessionId**

Legacy `ext-event-http` session identifier.

```csharp
public string SessionId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-time"/>**Time**

Event timestamp as Unix epoch milliseconds.

```csharp
public long Time { get; set; }
```

#### Property Value

[Int64](https://learn.microsoft.com/dotnet/api/system.int64)<br>

### <a id="properties-type"/>**Type**

Full event type string (e.g. `access.REGISTER` or `admin.USER-CREATE`).
 For admin events this is the concatenation of [KeycloakWebhookRequest.ResourceType](./nefarius.keycloak.webhooks.models.keycloakwebhookrequest.md#resourcetype) and [KeycloakWebhookRequest.OperationType](./nefarius.keycloak.webhooks.models.keycloakwebhookrequest.md#operationtype)
 with an `admin.` prefix.

```csharp
public string Type { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-uid"/>**Uid**

Unique identifier of this webhook delivery.

```csharp
public string Uid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-userid"/>**UserId**

Legacy `ext-event-http` user identifier.

```csharp
public string UserId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

## Constructors

### <a id="constructors-.ctor"/>**KeycloakWebhookRequest()**

```csharp
public KeycloakWebhookRequest()
```
