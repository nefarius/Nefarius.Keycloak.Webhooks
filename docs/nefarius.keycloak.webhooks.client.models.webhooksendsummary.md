# WebhookSendSummary

Namespace: Nefarius.Keycloak.Webhooks.Client.Models

Summarizes a webhook delivery attempt.

```csharp
public class WebhookSendSummary
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [WebhookSendSummary](./nefarius.keycloak.webhooks.client.models.webhooksendsummary.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### <a id="properties-eventid"/>**EventId**

Gets or sets the stored webhook event identifier.

```csharp
public string EventId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-eventtype"/>**EventType**

Gets or sets the normalized event type delivered to the webhook.

```csharp
public string EventType { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-id"/>**Id**

Gets or sets the delivery attempt identifier.

```csharp
public string Id { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-keycloakeventid"/>**KeycloakEventId**

Gets or sets the source Keycloak event identifier.

```csharp
public string KeycloakEventId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-keycloakeventtype"/>**KeycloakEventType**

Gets or sets the native Keycloak event category, normally `ADMIN` or `USER`.

```csharp
public string KeycloakEventType { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-retries"/>**Retries**

Gets or sets the number of retries recorded for the attempt.

```csharp
public Nullable<Int32> Retries { get; set; }
```

#### Property Value

[Nullable](https://learn.microsoft.com/dotnet/api/system.nullable-1)<[Int32](https://learn.microsoft.com/dotnet/api/system.int32)><br>

### <a id="properties-sentat"/>**SentAt**

Gets or sets when the attempt was sent.

```csharp
public Nullable<DateTimeOffset> SentAt { get; set; }
```

#### Property Value

[Nullable](https://learn.microsoft.com/dotnet/api/system.nullable-1)<[DateTimeOffset](https://learn.microsoft.com/dotnet/api/system.datetimeoffset)><br>

### <a id="properties-status"/>**Status**

Gets or sets the HTTP status code returned by the target.

```csharp
public Nullable<Int32> Status { get; set; }
```

#### Property Value

[Nullable](https://learn.microsoft.com/dotnet/api/system.nullable-1)<[Int32](https://learn.microsoft.com/dotnet/api/system.int32)><br>

### <a id="properties-statusmessage"/>**StatusMessage**

Gets or sets the human-readable target response status.

```csharp
public string StatusMessage { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/dotnet/api/system.string)<br>

### <a id="properties-webhook"/>**Webhook**

Gets or sets a brief representation of the target webhook.

```csharp
public WebhookSubscription Webhook { get; set; }
```

#### Property Value

[WebhookSubscription](./nefarius.keycloak.webhooks.client.models.webhooksubscription.md)<br>

## Constructors

### <a id="constructors-.ctor"/>**WebhookSendSummary()**

```csharp
public WebhookSendSummary()
```
