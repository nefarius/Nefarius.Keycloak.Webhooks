# AuthDetails

Namespace: Nefarius.Keycloak.Webhooks.Models

Authentication details attached to an event by Keycloak.

```csharp
public sealed class AuthDetails
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [AuthDetails](./nefarius.keycloak.webhooks.models.authdetails.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-clientid"/>**ClientId**

Client (application) ID that initiated the request.

```csharp
public string ClientId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-ipaddress"/>**IpAddress**

IP address of the actor.

```csharp
public string IpAddress { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-realmid"/>**RealmId**

Name of the realm in which the actor authenticated. The upstream wire name is
 `realmId` for historical reasons.

```csharp
public string RealmId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-realmname"/>**RealmName**

Name of the realm in which the actor authenticated, when supplied by Keycloak.

```csharp
public string RealmName { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-sessionid"/>**SessionId**

Keycloak session ID associated with the request.

```csharp
public string SessionId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-userid"/>**UserId**

Opaque Keycloak ID of the authenticated actor (user or service account).

```csharp
public string UserId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-username"/>**Username**

Username of the authenticated actor.

```csharp
public string Username { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

## Constructors

### <a id="constructors-.ctor"/>**AuthDetails()**

```csharp
public AuthDetails()
```
