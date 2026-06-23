# AuthDetails

Namespace: Nefarius.Keycloak.Webhooks.Models

Authentication details carried on every Keycloak access event.

```csharp
public sealed class AuthDetails
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [AuthDetails](./nefarius.keycloak.webhooks.models.authdetails.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-clientid"/>**ClientId**

```csharp
public string ClientId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-ipaddress"/>**IpAddress**

```csharp
public string IpAddress { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-realmid"/>**RealmId**

```csharp
public string RealmId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-sessionid"/>**SessionId**

```csharp
public string SessionId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-userid"/>**UserId**

```csharp
public Guid UserId { get; set; }
```

#### Property Value

[Guid](https://learn.microsoft.com/dotnet/api/system.guid)<br>

### <a id="properties-username"/>**Username**

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
