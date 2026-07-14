# AccessUserRegisteredEvent

Namespace: Nefarius.Keycloak.Webhooks.Events

A new user has self-registered via Keycloak (`access.REGISTER`).

```csharp
public sealed class AccessUserRegisteredEvent : UserWebhookEvent
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [WebhookBaseEvent](./nefarius.keycloak.webhooks.events.webhookbaseevent.md) → [UserWebhookEvent](./nefarius.keycloak.webhooks.events.userwebhookevent.md) → [AccessUserRegisteredEvent](./nefarius.keycloak.webhooks.events.accessuserregisteredevent.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-authdetails"/>**AuthDetails**

Authentication context of the actor who triggered the event.

```csharp
public AuthDetails? AuthDetails { get; set; }
```

#### Property Value

[AuthDetails](./nefarius.keycloak.webhooks.models.authdetails.md)<br>

### <a id="properties-authmethod"/>**AuthMethod**

Authentication protocol used, e.g. `openid-connect`.

```csharp
public string? AuthMethod { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-authtype"/>**AuthType**

OAuth 2.0 / OIDC grant type, e.g. `code`.

```csharp
public string? AuthType { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-clientid"/>**ClientId**

Client that initiated the user event.

```csharp
public string? ClientId { get; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-codeid"/>**CodeId**

OIDC auth code / session correlation id.

```csharp
public string? CodeId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-details"/>**Details**

Open-ended event details supplied by Keycloak.

```csharp
public IReadOnlyDictionary<String, String?> Details { get; set; }
```

#### Property Value

[IReadOnlyDictionary](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlydictionary-2)<[String](https://learn.microsoft.com/dotnet/api/system.string), [String](https://learn.microsoft.com/dotnet/api/system.string)><br>

### <a id="properties-email"/>**Email**

E-mail address of the newly registered user.

```csharp
public string? Email { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-error"/>**Error**

Error associated with a failed user or admin event.

```csharp
public string? Error { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-firstname"/>**FirstName**

First name provided during registration.

```csharp
public string? FirstName { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-id"/>**Id**

Original Keycloak event identifier, shared by fan-out deliveries and retries.

```csharp
public string? Id { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-ipaddress"/>**IpAddress**

Address from which the event originated.

```csharp
public string? IpAddress { get; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-lastname"/>**LastName**

Last name provided during registration.

```csharp
public string? LastName { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-operationtype"/>**OperationType**

Present on admin events only.

```csharp
public string? OperationType { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-rawpayload"/>**RawPayload**

Exact parsed JSON payload when the event was created by [KeycloakWebhookParser.Parse(String, JsonSerializerOptions)](./nefarius.keycloak.webhooks.keycloakwebhookparser.md#parsestring-jsonserializeroptions).

```csharp
public Nullable<JsonElement> RawPayload { get; internal set; }
```

#### Property Value

[Nullable](https://learn.microsoft.com/dotnet/api/system.nullable-1)<[JsonElement](https://learn.microsoft.com/dotnet/api/system.text.json.jsonelement)><br>

### <a id="properties-realmid"/>**RealmId**

ID of the Keycloak realm in which the event occurred.

```csharp
public string? RealmId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-realmname"/>**RealmName**

Name of the realm in which the event occurred.

```csharp
public string? RealmName { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-redirecturi"/>**RedirectUri**

Client redirect URI that initiated the registration flow.

```csharp
public string? RedirectUri { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-registermethod"/>**RegisterMethod**

Registration method, e.g. `form`.

```csharp
public string? RegisterMethod { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-representation"/>**Representation**

JSON-encoded snapshot of the affected resource.
 Only populated when [WebhookBaseEvent.OperationType](./nefarius.keycloak.webhooks.events.webhookbaseevent.md#operationtype) is `CREATE` or `UPDATE`; `null` otherwise.

```csharp
public string? Representation { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-resourceid"/>**ResourceId**

Opaque identifier of the affected admin resource, when available.

```csharp
public string? ResourceId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-resourcepath"/>**ResourcePath**

Present on admin events only, e.g. `users/{id}/role-mappings/realm`.

```csharp
public string? ResourcePath { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-resourcetype"/>**ResourceType**

Present on admin events only.

```csharp
public string? ResourceType { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-sessionid"/>**SessionId**

Keycloak user-session identifier.

```csharp
public string? SessionId { get; }
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
 For admin events this is the concatenation of [WebhookBaseEvent.ResourceType](./nefarius.keycloak.webhooks.events.webhookbaseevent.md#resourcetype) and [WebhookBaseEvent.OperationType](./nefarius.keycloak.webhooks.events.webhookbaseevent.md#operationtype)
 with an `admin.` prefix.

```csharp
public string? Type { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-uid"/>**Uid**

Unique identifier of this webhook delivery.

```csharp
public string? Uid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-userid"/>**UserId**

User affected by the event.

```csharp
public string? UserId { get; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-username"/>**Username**

Username chosen by the newly registered user.

```csharp
public string? Username { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

## Constructors

### <a id="constructors-.ctor"/>**AccessUserRegisteredEvent()**

```csharp
public AccessUserRegisteredEvent()
```
