# WebhookAuthenticationTypes

Namespace: Nefarius.Keycloak.Webhooks.Client.Models

Authentication type values accepted by the ext-event-webhook API.

```csharp
public static class WebhookAuthenticationTypes
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [WebhookAuthenticationTypes](./nefarius.keycloak.webhooks.client.models.webhookauthenticationtypes.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### <a id="fields-bearer"/>**Bearer**

Authenticates webhook payloads with a realm-signed bearer JWT.

```csharp
public static string Bearer;
```

### <a id="fields-hmac"/>**Hmac**

Signs webhook payloads with a shared-secret HMAC.

```csharp
public static string Hmac;
```

### <a id="fields-none"/>**None**

Sends webhook payloads without authentication.

```csharp
public static string None;
```
