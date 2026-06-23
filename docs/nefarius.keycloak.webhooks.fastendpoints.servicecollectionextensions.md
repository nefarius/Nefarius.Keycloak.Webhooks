# ServiceCollectionExtensions

Namespace: Nefarius.Keycloak.Webhooks.FastEndpoints

Extension methods for registering the Keycloak webhook FastEndpoints integration.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [Object](https://learn.microsoft.com/dotnet/api/system.object) → [ServiceCollectionExtensions](./nefarius.keycloak.webhooks.fastendpoints.servicecollectionextensions.md)<br>
Attributes [ExtensionAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### <a id="methods-addkeycloakwebhooks"/>**AddKeycloakWebhooks(IServiceCollection, Action&lt;KeycloakWebhookOptions&gt;)**

Registers [KeycloakWebhookOptions](./nefarius.keycloak.webhooks.fastendpoints.keycloakwebhookoptions.md) so that [KeycloakWebhookEndpoint](./nefarius.keycloak.webhooks.fastendpoints.keycloakwebhookendpoint.md)
 is configured correctly. Call this before `AddFastEndpoints()`.

```csharp
public static IServiceCollection AddKeycloakWebhooks(IServiceCollection services, Action<KeycloakWebhookOptions> configure)
```

#### Parameters

`services` [IServiceCollection](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection)<br>
The service collection.

`configure` [Action](https://learn.microsoft.com/dotnet/api/system.action-1)<[KeycloakWebhookOptions](./nefarius.keycloak.webhooks.fastendpoints.keycloakwebhookoptions.md)><br>
Optional delegate to customise [KeycloakWebhookOptions](./nefarius.keycloak.webhooks.fastendpoints.keycloakwebhookoptions.md).

#### Returns

[IServiceCollection](https://learn.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection)
