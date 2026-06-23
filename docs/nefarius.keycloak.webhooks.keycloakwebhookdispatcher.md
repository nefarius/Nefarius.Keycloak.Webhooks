# KeycloakWebhookDispatcher

Namespace: Nefarius.Keycloak.Webhooks

Abstract base that implements [IKeycloakWebhookEventHandler](./nefarius.keycloak.webhooks.ikeycloakwebhookeventhandler.md) with no-op defaults.
 Subclass and override only the event methods you care about, then call
 [KeycloakWebhookDispatcher.DispatchAsync(String, CancellationToken)](./nefarius.keycloak.webhooks.keycloakwebhookdispatcher.md#dispatchasyncstring-cancellationtoken) (or the JSON overload) to route
 an incoming event to the appropriate virtual method.

```csharp
public abstract class KeycloakWebhookDispatcher : IKeycloakWebhookEventHandler
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [KeycloakWebhookDispatcher](./nefarius.keycloak.webhooks.keycloakwebhookdispatcher.md)<br>
Implements [IKeycloakWebhookEventHandler](./nefarius.keycloak.webhooks.ikeycloakwebhookeventhandler.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Methods

### <a id="methods-dispatchasync"/>**DispatchAsync(String, CancellationToken)**

Parses `json` and routes the result to the appropriate `On*Async` method.

```csharp
public Task DispatchAsync(string json, CancellationToken ct)
```

#### Parameters

`json` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-dispatchasync"/>**DispatchAsync(KeycloakWebhookRequest, CancellationToken)**

Parses `raw` and routes the result to the appropriate `On*Async` method.

```csharp
public Task DispatchAsync(KeycloakWebhookRequest raw, CancellationToken ct)
```

#### Parameters

`raw` [KeycloakWebhookRequest](./nefarius.keycloak.webhooks.models.keycloakwebhookrequest.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-dispatchasync"/>**DispatchAsync(WebhookBaseEvent, CancellationToken)**

Routes an already-typed `evt` (or `null` for unknown) to the appropriate
 `On*Async` method.

```csharp
public Task DispatchAsync(WebhookBaseEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [WebhookBaseEvent](./nefarius.keycloak.webhooks.events.webhookbaseevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onaccessuserregisteredasync"/>**OnAccessUserRegisteredAsync(AccessUserRegisteredEvent, CancellationToken)**

Called when a user self-registers.

```csharp
public Task OnAccessUserRegisteredAsync(AccessUserRegisteredEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AccessUserRegisteredEvent](./nefarius.keycloak.webhooks.events.accessuserregisteredevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onaccessuserverifiedemailasync"/>**OnAccessUserVerifiedEmailAsync(AccessUserVerifiedEmailEvent, CancellationToken)**

Called when a user verifies their e-mail address.

```csharp
public Task OnAccessUserVerifiedEmailAsync(AccessUserVerifiedEmailEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AccessUserVerifiedEmailEvent](./nefarius.keycloak.webhooks.events.accessuserverifiedemailevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onaccessuserverifyemailsentasync"/>**OnAccessUserVerifyEmailSentAsync(AccessUserVerifyEmailSentEvent, CancellationToken)**

Called when a verification e-mail is dispatched to a user.

```csharp
public Task OnAccessUserVerifyEmailSentAsync(AccessUserVerifyEmailSentEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AccessUserVerifyEmailSentEvent](./nefarius.keycloak.webhooks.events.accessuserverifyemailsentevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onadminrealmrolemappingcreatedasync"/>**OnAdminRealmRoleMappingCreatedAsync(AdminRealmRoleMappingCreatedEvent, CancellationToken)**

Called when a realm role is assigned to a user.

```csharp
public Task OnAdminRealmRoleMappingCreatedAsync(AdminRealmRoleMappingCreatedEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AdminRealmRoleMappingCreatedEvent](./nefarius.keycloak.webhooks.events.adminrealmrolemappingcreatedevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onadminrealmrolemappingdeletedasync"/>**OnAdminRealmRoleMappingDeletedAsync(AdminRealmRoleMappingDeletedEvent, CancellationToken)**

Called when a realm role is removed from a user.

```csharp
public Task OnAdminRealmRoleMappingDeletedAsync(AdminRealmRoleMappingDeletedEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AdminRealmRoleMappingDeletedEvent](./nefarius.keycloak.webhooks.events.adminrealmrolemappingdeletedevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onadminusercreatedasync"/>**OnAdminUserCreatedAsync(AdminUserCreatedEvent, CancellationToken)**

Called when an administrator creates a user.

```csharp
public Task OnAdminUserCreatedAsync(AdminUserCreatedEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AdminUserCreatedEvent](./nefarius.keycloak.webhooks.events.adminusercreatedevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onadminuserdeletedasync"/>**OnAdminUserDeletedAsync(AdminUserDeletedEvent, CancellationToken)**

Called when a user is deleted.

```csharp
public Task OnAdminUserDeletedAsync(AdminUserDeletedEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AdminUserDeletedEvent](./nefarius.keycloak.webhooks.events.adminuserdeletedevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onadminuserupdatedasync"/>**OnAdminUserUpdatedAsync(AdminUserUpdatedEvent, CancellationToken)**

Called when an administrator updates a user.

```csharp
public Task OnAdminUserUpdatedAsync(AdminUserUpdatedEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AdminUserUpdatedEvent](./nefarius.keycloak.webhooks.events.adminuserupdatedevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onunknowneventasync"/>**OnUnknownEventAsync(String, CancellationToken)**

Called for any event type not recognised by the parser (i.e. [KeycloakWebhookParser.Parse(KeycloakWebhookRequest)](./nefarius.keycloak.webhooks.keycloakwebhookparser.md#parsekeycloakwebhookrequest) returned `null`).

```csharp
public Task OnUnknownEventAsync(string eventType, CancellationToken ct)
```

#### Parameters

`eventType` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
