# WebhookEventAuthenticationDetails

Namespace: Nefarius.Keycloak.Webhooks.Client.Models

Describes authentication context attached to a normalized webhook event.

```csharp
public sealed class WebhookEventAuthenticationDetails
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [WebhookEventAuthenticationDetails](./nefarius.keycloak.webhooks.client.models.webhookeventauthenticationdetails.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-clientid"/>**ClientId**

Gets or sets the authenticating client identifier.

```csharp
public string? ClientId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-ipaddress"/>**IpAddress**

Gets or sets the source IP address.

```csharp
public string? IpAddress { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-realmid"/>**RealmId**

Gets or sets the authenticating realm identifier or name.

```csharp
public string? RealmId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-sessionid"/>**SessionId**

Gets or sets the authentication session identifier.

```csharp
public string? SessionId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-userid"/>**UserId**

Gets or sets the authenticating user identifier.

```csharp
public string? UserId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-username"/>**Username**

Gets or sets the authenticating username.

```csharp
public string? Username { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

## Constructors

### <a id="constructors-.ctor"/>**WebhookEventAuthenticationDetails()**

```csharp
public WebhookEventAuthenticationDetails()
```
