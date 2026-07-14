# KeycloakWebhookAuthenticationMode

Namespace: Nefarius.Keycloak.Webhooks.Authentication

Authentication modes supported by the Keycloak webhook sender.

```csharp
public enum KeycloakWebhookAuthenticationMode
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [ValueType](https://learn.microsoft.com/dotnet/api/system.valuetype) → [Enum](https://learn.microsoft.com/dotnet/api/system.enum) → [KeycloakWebhookAuthenticationMode](./nefarius.keycloak.webhooks.authentication.keycloakwebhookauthenticationmode.md)<br>
Implements [IComparable](https://learn.microsoft.com/dotnet/api/system.icomparable), [ISpanFormattable](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [IFormattable](https://learn.microsoft.com/dotnet/api/system.iformattable), [IConvertible](https://learn.microsoft.com/dotnet/api/system.iconvertible)

## Fields

| Name | Value | Description |
| --- | --: | --- |
| None | 0 | The request carries no sender authentication. |
| HmacSha256 | 1 | The raw request body is authenticated by `X-Keycloak-Signature`. |
| HmacSha1 | 2 | Legacy HMAC-SHA1 authentication. |
| Bearer | 3 | The request carries a realm-signed bearer JWT. |
