# IKeycloakWebhookEventHandler

Namespace: Nefarius.Keycloak.Webhooks

Framework-agnostic contract for handling typed Keycloak webhook events.
 Implement this interface (or extend [KeycloakWebhookDispatcher](./nefarius.keycloak.webhooks.keycloakwebhookdispatcher.md)) to process events
 without depending on any specific HTTP framework.

```csharp
public interface IKeycloakWebhookEventHandler
```

Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute)

## Methods

### <a id="methods-onaccessuserregisteredasync"/>**OnAccessUserRegisteredAsync(AccessUserRegisteredEvent, CancellationToken)**

Called when a user self-registers.

```csharp
Task OnAccessUserRegisteredAsync(AccessUserRegisteredEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AccessUserRegisteredEvent](./nefarius.keycloak.webhooks.events.accessuserregisteredevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onaccessuserverifiedemailasync"/>**OnAccessUserVerifiedEmailAsync(AccessUserVerifiedEmailEvent, CancellationToken)**

Called when a user verifies their e-mail address.

```csharp
Task OnAccessUserVerifiedEmailAsync(AccessUserVerifiedEmailEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AccessUserVerifiedEmailEvent](./nefarius.keycloak.webhooks.events.accessuserverifiedemailevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onaccessuserverifyemailsentasync"/>**OnAccessUserVerifyEmailSentAsync(AccessUserVerifyEmailSentEvent, CancellationToken)**

Called when a verification e-mail is dispatched to a user.

```csharp
Task OnAccessUserVerifyEmailSentAsync(AccessUserVerifyEmailSentEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AccessUserVerifyEmailSentEvent](./nefarius.keycloak.webhooks.events.accessuserverifyemailsentevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onadmineventasync"/>**OnAdminEventAsync(AdminWebhookEvent, CancellationToken)**

Called for a native admin event without a more specific projection.

```csharp
Task OnAdminEventAsync(AdminWebhookEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AdminWebhookEvent](./nefarius.keycloak.webhooks.events.adminwebhookevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onadminrealmrolemappingcreatedasync"/>**OnAdminRealmRoleMappingCreatedAsync(AdminRealmRoleMappingCreatedEvent, CancellationToken)**

Called when a realm role is assigned to a user.

```csharp
Task OnAdminRealmRoleMappingCreatedAsync(AdminRealmRoleMappingCreatedEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AdminRealmRoleMappingCreatedEvent](./nefarius.keycloak.webhooks.events.adminrealmrolemappingcreatedevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onadminrealmrolemappingdeletedasync"/>**OnAdminRealmRoleMappingDeletedAsync(AdminRealmRoleMappingDeletedEvent, CancellationToken)**

Called when a realm role is removed from a user.

```csharp
Task OnAdminRealmRoleMappingDeletedAsync(AdminRealmRoleMappingDeletedEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AdminRealmRoleMappingDeletedEvent](./nefarius.keycloak.webhooks.events.adminrealmrolemappingdeletedevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onadminusercreatedasync"/>**OnAdminUserCreatedAsync(AdminUserCreatedEvent, CancellationToken)**

Called when an administrator creates a user.

```csharp
Task OnAdminUserCreatedAsync(AdminUserCreatedEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AdminUserCreatedEvent](./nefarius.keycloak.webhooks.events.adminusercreatedevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onadminuserdeletedasync"/>**OnAdminUserDeletedAsync(AdminUserDeletedEvent, CancellationToken)**

Called when a user is deleted.

```csharp
Task OnAdminUserDeletedAsync(AdminUserDeletedEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AdminUserDeletedEvent](./nefarius.keycloak.webhooks.events.adminuserdeletedevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onadminuserupdatedasync"/>**OnAdminUserUpdatedAsync(AdminUserUpdatedEvent, CancellationToken)**

Called when an administrator updates a user.

```csharp
Task OnAdminUserUpdatedAsync(AdminUserUpdatedEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [AdminUserUpdatedEvent](./nefarius.keycloak.webhooks.events.adminuserupdatedevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-oncustomeventasync"/>**OnCustomEventAsync(CustomWebhookEvent, CancellationToken)**

Called for an application-defined event published through Keycloak.

```csharp
Task OnCustomEventAsync(CustomWebhookEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [CustomWebhookEvent](./nefarius.keycloak.webhooks.events.customwebhookevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onunknowneventasync"/>**OnUnknownEventAsync(String, CancellationToken)**

Called when a payload does not contain enough information to classify an event.

```csharp
Task OnUnknownEventAsync(string? eventType, CancellationToken ct)
```

#### Parameters

`eventType` [String](https://learn.microsoft.com/dotnet/api/system.string)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)

### <a id="methods-onusereventasync"/>**OnUserEventAsync(UserWebhookEvent, CancellationToken)**

Called for a native user event without a more specific projection.

```csharp
Task OnUserEventAsync(UserWebhookEvent evt, CancellationToken ct)
```

#### Parameters

`evt` [UserWebhookEvent](./nefarius.keycloak.webhooks.events.userwebhookevent.md)<br>

`ct` [CancellationToken](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken)<br>

#### Returns

[Task](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task)
