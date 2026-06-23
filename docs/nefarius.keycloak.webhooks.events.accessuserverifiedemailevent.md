# AccessUserVerifiedEmailEvent

Namespace: Nefarius.Keycloak.Webhooks.Events

A user has successfully verified their e-mail address (`access.VERIFY_EMAIL`).

```csharp
public sealed class AccessUserVerifiedEmailEvent : WebhookBaseEvent
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [WebhookBaseEvent](./nefarius.keycloak.webhooks.events.webhookbaseevent.md) → [AccessUserVerifiedEmailEvent](./nefarius.keycloak.webhooks.events.accessuserverifiedemailevent.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-action"/>**Action**

Required action that was executed, e.g. `VERIFY_EMAIL`.

```csharp
public string Action { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-authdetails"/>**AuthDetails**

Authentication context of the actor who triggered the event.

```csharp
public AuthDetails AuthDetails { get; set; }
```

#### Property Value

[AuthDetails](./nefarius.keycloak.webhooks.models.authdetails.md)<br>

### <a id="properties-authmethod"/>**AuthMethod**

Authentication protocol used, e.g. `openid-connect`.

```csharp
public string AuthMethod { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-codeid"/>**CodeId**

OIDC auth code / session correlation id.

```csharp
public Guid CodeId { get; set; }
```

#### Property Value

[Guid](https://learn.microsoft.com/dotnet/api/system.guid)<br>

### <a id="properties-email"/>**Email**

E-mail address that was verified.

```csharp
public string Email { get; set; }
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

### <a id="properties-redirecturi"/>**RedirectUri**

Client redirect URI that was active during the flow.

```csharp
public string RedirectUri { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-rememberme"/>**RememberMe**

Whether the user selected "remember me" (`true`/`false` as string).

```csharp
public string RememberMe { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-representation"/>**Representation**

JSON-encoded snapshot of the affected resource.
 Only populated when [WebhookBaseEvent.OperationType](./nefarius.keycloak.webhooks.events.webhookbaseevent.md#operationtype) is `CREATE` or `UPDATE`; `null` otherwise.

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

### <a id="properties-responsemode"/>**ResponseMode**

OIDC response mode, e.g. `fragment` or `query`.

```csharp
public string ResponseMode { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-responsetype"/>**ResponseType**

OIDC response type requested by the client, e.g. `code`.

```csharp
public string ResponseType { get; set; }
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

### <a id="properties-tokenid"/>**TokenId**

ID of the action token that was consumed to verify the address.

```csharp
public Guid TokenId { get; set; }
```

#### Property Value

[Guid](https://learn.microsoft.com/dotnet/api/system.guid)<br>

### <a id="properties-type"/>**Type**

Full event type string (e.g. `access.REGISTER` or `admin.USER-CREATE`).
 For admin events this is the concatenation of [WebhookBaseEvent.ResourceType](./nefarius.keycloak.webhooks.events.webhookbaseevent.md#resourcetype) and [WebhookBaseEvent.OperationType](./nefarius.keycloak.webhooks.events.webhookbaseevent.md#operationtype)
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

### <a id="properties-username"/>**Username**

Username of the user who verified their e-mail address.

```csharp
public string Username { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

## Constructors

### <a id="constructors-.ctor"/>**AccessUserVerifiedEmailEvent()**

```csharp
public AccessUserVerifiedEmailEvent()
```
