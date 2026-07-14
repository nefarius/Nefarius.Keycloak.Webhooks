# KeycloakWebhooksClient

Namespace: Nefarius.Keycloak.Webhooks.Client

Provides typed access to the management endpoints exposed by ext-event-webhook v0.62.

```csharp
public sealed class KeycloakWebhooksClient
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [KeycloakWebhooksClient](./nefarius.keycloak.webhooks.client.keycloakwebhooksclient.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

**Remarks:**

The supplied [HttpClient](https://learn.microsoft.com/dotnet/api/system.net.http.httpclient) must have an absolute [BaseAddress](https://learn.microsoft.com/dotnet/api/system.net.http.httpclient.baseaddress).
 Authentication, including bearer token configuration, remains the caller's responsibility.

## Constructors

### <a id="constructors-.ctor"/>**KeycloakWebhooksClient(HttpClient, JsonSerializerOptions)**

Initializes a new instance of the [KeycloakWebhooksClient](./nefarius.keycloak.webhooks.client.keycloakwebhooksclient.md) class.

```csharp
public KeycloakWebhooksClient(HttpClient httpClient, JsonSerializerOptions serializerOptions)
```

#### Parameters

`httpClient` [HttpClient](https://learn.microsoft.com/dotnet/api/system.net.http.httpclient)<br>
The HTTP client to use. Its base address may include a relative path such as `/auth`.

`serializerOptions` [JsonSerializerOptions](https://learn.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions)<br>
Optional JSON serializer options. Camel-case names and case-insensitive reads are used by default.

#### Exceptions

[ArgumentNullException](https://learn.microsoft.com/dotnet/api/system.argumentnullexception)<br>
`httpClient` is `null`.

## Methods

### <a id="methods-countwebhooksasync"/>**CountWebhooksAsync(String, String, CancellationToken)**

Counts webhook subscriptions in a realm.

```csharp
public Task<Int64> CountWebhooksAsync(string realm, string search, CancellationToken cancellationToken)
```

#### Parameters

`realm` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The realm name.

`search` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
An optional search value passed to the upstream endpoint. Upstream v0.62 accepts but does not apply it.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>
A token that cancels the operation.

#### Returns

The number of webhook subscriptions.

### <a id="methods-createwebhookasync"/>**CreateWebhookAsync(String, WebhookSubscription, CancellationToken)**

Creates a webhook subscription.

```csharp
public Task<Uri> CreateWebhookAsync(string realm, WebhookSubscription subscription, CancellationToken cancellationToken)
```

#### Parameters

`realm` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The realm name.

`subscription` [WebhookSubscription](./nefarius.keycloak.webhooks.client.models.webhooksubscription.md)<br>
The webhook subscription to create.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>
A token that cancels the operation.

#### Returns

The resource URI from the response's `Location` header, or `null` if omitted.

### <a id="methods-deletewebhookasync"/>**DeleteWebhookAsync(String, String, CancellationToken)**

Deletes a webhook subscription.

```csharp
public Task DeleteWebhookAsync(string realm, string webhookId, CancellationToken cancellationToken)
```

#### Parameters

`realm` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The realm name.

`webhookId` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The webhook identifier.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>
A token that cancels the operation.

#### Returns

A task representing the operation.

### <a id="methods-getpayloadbysourceeventasync"/>**GetPayloadBySourceEventAsync(String, KeycloakEventSource, String, CancellationToken)**

Gets the stored normalized payload for a native Keycloak source event.

```csharp
public Task<WebhookEventPayload> GetPayloadBySourceEventAsync(string realm, KeycloakEventSource source, string sourceEventId, CancellationToken cancellationToken)
```

#### Parameters

`realm` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The realm name.

`source` [KeycloakEventSource](./nefarius.keycloak.webhooks.client.models.keycloakeventsource.md)<br>
The native event source.

`sourceEventId` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The native Keycloak event identifier.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>
A token that cancels the operation.

#### Returns

The normalized event payload.

### <a id="methods-getwebhookasync"/>**GetWebhookAsync(String, String, CancellationToken)**

Gets a webhook subscription by identifier.

```csharp
public Task<WebhookSubscription> GetWebhookAsync(string realm, string webhookId, CancellationToken cancellationToken)
```

#### Parameters

`realm` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The realm name.

`webhookId` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The webhook identifier.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>
A token that cancels the operation.

#### Returns

The webhook subscription.

### <a id="methods-getwebhooksasync"/>**GetWebhooksAsync(String, PaginationOptions, CancellationToken)**

Lists webhook subscriptions in a realm.

```csharp
public Task<IReadOnlyList<WebhookSubscription>> GetWebhooksAsync(string realm, PaginationOptions pagination, CancellationToken cancellationToken)
```

#### Parameters

`realm` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The realm name.

`pagination` [PaginationOptions](./nefarius.keycloak.webhooks.client.models.paginationoptions.md)<br>
Optional pagination parameters.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>
A token that cancels the operation.

#### Returns

The webhook subscriptions.

### <a id="methods-getwebhooksecretasync"/>**GetWebhookSecretAsync(String, String, CancellationToken)**

Gets the secret credential for a webhook subscription.

```csharp
public Task<WebhookCredential> GetWebhookSecretAsync(string realm, string webhookId, CancellationToken cancellationToken)
```

#### Parameters

`realm` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The realm name.

`webhookId` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The webhook identifier.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>
A token that cancels the operation.

#### Returns

The webhook secret credential.

### <a id="methods-getwebhooksendasync"/>**GetWebhookSendAsync(String, String, String, CancellationToken)**

Gets one delivery attempt, including its raw payload.

```csharp
public Task<WebhookSendDetail> GetWebhookSendAsync(string realm, string webhookId, string sendId, CancellationToken cancellationToken)
```

#### Parameters

`realm` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The realm name.

`webhookId` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The webhook identifier.

`sendId` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The delivery attempt identifier.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>
A token that cancels the operation.

#### Returns

The detailed delivery attempt.

### <a id="methods-getwebhooksendsasync"/>**GetWebhookSendsAsync(String, String, PaginationOptions, CancellationToken)**

Lists delivery attempts for a webhook subscription.

```csharp
public Task<IReadOnlyList<WebhookSendSummary>> GetWebhookSendsAsync(string realm, string webhookId, PaginationOptions pagination, CancellationToken cancellationToken)
```

#### Parameters

`realm` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The realm name.

`webhookId` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The webhook identifier.

`pagination` [PaginationOptions](./nefarius.keycloak.webhooks.client.models.paginationoptions.md)<br>
Optional pagination parameters.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>
A token that cancels the operation.

#### Returns

Brief delivery attempt representations.

### <a id="methods-getwebhooksendsbysourceeventasync"/>**GetWebhookSendsBySourceEventAsync(String, KeycloakEventSource, String, CancellationToken)**

Lists all webhook delivery attempts triggered by a native Keycloak source event.

```csharp
public Task<IReadOnlyList<WebhookSendSummary>> GetWebhookSendsBySourceEventAsync(string realm, KeycloakEventSource source, string sourceEventId, CancellationToken cancellationToken)
```

#### Parameters

`realm` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The realm name.

`source` [KeycloakEventSource](./nefarius.keycloak.webhooks.client.models.keycloakeventsource.md)<br>
The native event source.

`sourceEventId` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The native Keycloak event identifier.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>
A token that cancels the operation.

#### Returns

Brief delivery attempt representations.

### <a id="methods-publishcustomeventasync"/>**PublishCustomEventAsync(String, CustomWebhookEvent, CancellationToken)**

Publishes a custom event to matching webhook subscriptions.

```csharp
public Task PublishCustomEventAsync(string realm, CustomWebhookEvent customEvent, CancellationToken cancellationToken)
```

#### Parameters

`realm` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The realm name.

`customEvent` [CustomWebhookEvent](./nefarius.keycloak.webhooks.client.models.customwebhookevent.md)<br>
The custom event to publish.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>
A token that cancels the operation.

#### Returns

A task representing the accepted publication request.

### <a id="methods-resendwebhookasync"/>**ResendWebhookAsync(String, String, String, CancellationToken)**

Requests redelivery of a stored webhook attempt.

```csharp
public Task ResendWebhookAsync(string realm, string webhookId, string sendId, CancellationToken cancellationToken)
```

#### Parameters

`realm` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The realm name.

`webhookId` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The webhook identifier.

`sendId` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The delivery attempt identifier.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>
A token that cancels the operation.

#### Returns

A task representing the accepted resend request.

### <a id="methods-updatewebhookasync"/>**UpdateWebhookAsync(String, String, WebhookSubscription, CancellationToken)**

Updates a webhook subscription.

```csharp
public Task UpdateWebhookAsync(string realm, string webhookId, WebhookSubscription subscription, CancellationToken cancellationToken)
```

#### Parameters

`realm` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The realm name.

`webhookId` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>
The webhook identifier.

`subscription` [WebhookSubscription](./nefarius.keycloak.webhooks.client.models.webhooksubscription.md)<br>
The replacement webhook values.

`cancellationToken` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>
A token that cancels the operation.

#### Returns

A task representing the operation.
