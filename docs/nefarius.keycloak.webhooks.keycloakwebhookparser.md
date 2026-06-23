# KeycloakWebhookParser

Namespace: Nefarius.Keycloak.Webhooks

Parses raw Keycloak webhook payloads into strongly-typed [WebhookBaseEvent](./nefarius.keycloak.webhooks.events.webhookbaseevent.md) instances.

```csharp
public static class KeycloakWebhookParser
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [KeycloakWebhookParser](./nefarius.keycloak.webhooks.keycloakwebhookparser.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Methods

### <a id="methods-parse"/>**Parse(String, JsonSerializerOptions)**

Parses a raw JSON string into a strongly-typed webhook event.

```csharp
public static WebhookBaseEvent Parse(string json, JsonSerializerOptions options)
```

#### Parameters

`json` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The JSON body received from Keycloak.

`options` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)<br>
Optional custom serialiser options; defaults to case-insensitive property matching.

#### Returns

A typed event, or `null` if the event type is not recognised.

### <a id="methods-parse"/>**Parse(KeycloakWebhookRequest)**

Maps an already-deserialised [KeycloakWebhookRequest](./nefarius.keycloak.webhooks.models.keycloakwebhookrequest.md) to a strongly-typed event.

```csharp
public static WebhookBaseEvent Parse(KeycloakWebhookRequest raw)
```

#### Parameters

`raw` [KeycloakWebhookRequest](./nefarius.keycloak.webhooks.models.keycloakwebhookrequest.md)<br>
The deserialised raw request.

#### Returns

A typed event, or `null` if the event type is not recognised.
