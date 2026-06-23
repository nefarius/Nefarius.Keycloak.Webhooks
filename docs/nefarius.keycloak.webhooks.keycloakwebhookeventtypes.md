# KeycloakWebhookEventTypes

Namespace: Nefarius.Keycloak.Webhooks

String constants for all known Keycloak `ext-event-webhook` event type values,
 as they appear in the `type` field of the webhook payload.

```csharp
public static class KeycloakWebhookEventTypes
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [KeycloakWebhookEventTypes](./nefarius.keycloak.webhooks.keycloakwebhookeventtypes.md)<br>
Attributes [NullableContextAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### <a id="fields-accessregister"/>**AccessRegister**

A new user has self-registered.

```csharp
public static string AccessRegister;
```

### <a id="fields-accesssendverifyemail"/>**AccessSendVerifyEmail**

A verification e-mail has been sent to a user.

```csharp
public static string AccessSendVerifyEmail;
```

### <a id="fields-accessverifyemail"/>**AccessVerifyEmail**

A user has verified their e-mail address.

```csharp
public static string AccessVerifyEmail;
```

### <a id="fields-adminrealmrolemappingcreate"/>**AdminRealmRoleMappingCreate**

A realm role has been assigned to a user.

```csharp
public static string AdminRealmRoleMappingCreate;
```

### <a id="fields-adminrealmrolemappingdelete"/>**AdminRealmRoleMappingDelete**

A realm role has been removed from a user.

```csharp
public static string AdminRealmRoleMappingDelete;
```

### <a id="fields-adminusercreate"/>**AdminUserCreate**

An administrator has created a new user.

```csharp
public static string AdminUserCreate;
```

### <a id="fields-adminuserdelete"/>**AdminUserDelete**

A user has been deleted.

```csharp
public static string AdminUserDelete;
```

### <a id="fields-adminuserupdate"/>**AdminUserUpdate**

An administrator has updated a user.

```csharp
public static string AdminUserUpdate;
```
