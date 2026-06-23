# EventDetails

Namespace: Nefarius.Keycloak.Webhooks.Models

Event-specific detail fields present on both access and admin events.

```csharp
public sealed class EventDetails
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [EventDetails](./nefarius.keycloak.webhooks.models.eventdetails.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-action"/>**Action**

Required action that was executed, e.g. `VERIFY_EMAIL`.

```csharp
public string Action { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-authmethod"/>**AuthMethod**

Authentication protocol used, e.g. `openid-connect`.

```csharp
public string AuthMethod { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-authtype"/>**AuthType**

OAuth 2.0 / OIDC grant type, e.g. `code`.

```csharp
public string AuthType { get; set; }
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

E-mail address of the user.

```csharp
public string Email { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-firstname"/>**FirstName**

First name of the user (present on registration events).

```csharp
public string FirstName { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-lastname"/>**LastName**

Last name of the user (present on registration events).

```csharp
public string LastName { get; set; }
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

### <a id="properties-registermethod"/>**RegisterMethod**

Registration method, e.g. `form`.

```csharp
public string RegisterMethod { get; set; }
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

### <a id="properties-tokenid"/>**TokenId**

ID of the action token consumed by the event (e.g. email verification token).

```csharp
public Guid TokenId { get; set; }
```

#### Property Value

[Guid](https://learn.microsoft.com/dotnet/api/system.guid)<br>

### <a id="properties-userid"/>**UserId**

Keycloak internal ID of the affected user (present on admin user events).

```csharp
public Guid UserId { get; set; }
```

#### Property Value

[Guid](https://learn.microsoft.com/dotnet/api/system.guid)<br>

### <a id="properties-username"/>**Username**

Username of the user.

```csharp
public string Username { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

## Constructors

### <a id="constructors-.ctor"/>**EventDetails()**

```csharp
public EventDetails()
```
