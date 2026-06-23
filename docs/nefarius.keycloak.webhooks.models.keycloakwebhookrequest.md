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

### <a id="properties-details"/>**Details**

Event-specific detail fields; present on access events.

```csharp
public EventDetails Details { get; set; }
```

#### Property Value

[EventDetails](./nefarius.keycloak.webhooks.models.eventdetails.md)<br>

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

### <a id="properties-representation"/>**Representation**

JSON-encoded snapshot of the affected resource.
 Only populated when [KeycloakWebhookRequest.OperationType](./nefarius.keycloak.webhooks.models.keycloakwebhookrequest.md#operationtype) is `CREATE` or `UPDATE`; `null` otherwise.

```csharp
public string Representation { get; set; }
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

Unique identifier of this event instance.

```csharp
public Guid Uid { get; set; }
```

#### Property Value

[Guid](https://learn.microsoft.com/dotnet/api/system.guid)<br>

## Constructors

### <a id="constructors-.ctor"/>**KeycloakWebhookRequest()**

```csharp
public KeycloakWebhookRequest()
```
