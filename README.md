# <img src="assets/NSS-128x128.png" align="left" />Nefarius.Keycloak.Webhooks

[![.NET](https://github.com/nefarius/Nefarius.Keycloak.Webhooks/actions/workflows/build.yml/badge.svg)](https://github.com/nefarius/Nefarius.Keycloak.Webhooks/actions/workflows/build.yml)
[![Nuget](https://img.shields.io/nuget/v/Nefarius.Keycloak.Webhooks)](https://www.nuget.org/packages/Nefarius.Keycloak.Webhooks/)
[![Nuget](https://img.shields.io/nuget/dt/Nefarius.Keycloak.Webhooks)](https://www.nuget.org/packages/Nefarius.Keycloak.Webhooks/)

Receive and process [Keycloak `ext-event-webhook`](https://github.com/vymalo/keycloak-webhook) events as strongly-typed C# objects — no framework lock-in.

## About

This repository contains two NuGet packages:

| Package | Purpose |
|---|---|
| `Nefarius.Keycloak.Webhooks` | Dependency-free core: payload DTOs, typed event models, event-type constants, a JSON parser, and a framework-agnostic dispatcher base class. |
| `Nefarius.Keycloak.Webhooks.FastEndpoints` | Optional integration for [FastEndpoints](https://fast-endpoints.com/): a pre-built endpoint that receives Keycloak webhook POSTs and publishes typed events to the FastEndpoints event bus. |

## Features

- Typed event classes for all supported Keycloak webhook event types.
- `KeycloakWebhookParser` — static parser, `string` and `KeycloakWebhookRequest` overloads.
- `KeycloakWebhookDispatcher` — abstract base with no-op virtuals; override only what you need.
- `IKeycloakWebhookEventHandler` — implement directly if you prefer composition over inheritance.
- FastEndpoints integration wires up the HTTP endpoint and event bus automatically via DI.
- AOT-safe: event dispatch uses statically-resolved generic calls (no reflection).
- `GenerateDocumentationFile` enabled — full XML doc coverage.

## Supported frameworks

| Package | Frameworks |
|---|---|
| `Nefarius.Keycloak.Webhooks` | `netstandard2.0`, `net8.0`, `net9.0`, `net10.0` |
| `Nefarius.Keycloak.Webhooks.FastEndpoints` | `net8.0`, `net9.0`, `net10.0` |

## Known event types

| Constant | `type` value | Description |
|---|---|---|
| `AccessRegister` | `access.REGISTER` | User self-registered |
| `AccessVerifyEmail` | `access.VERIFY_EMAIL` | User verified their e-mail |
| `AccessSendVerifyEmail` | `access.SEND_VERIFY_EMAIL` | Verification e-mail dispatched |
| `AdminUserCreate` | `admin.USER-CREATE` | Admin created a user |
| `AdminUserUpdate` | `admin.USER-UPDATE` | Admin updated a user |
| `AdminUserDelete` | `admin.USER-DELETE` | User deleted |
| `AdminRealmRoleMappingCreate` | `admin.REALM_ROLE_MAPPING-CREATE` | Realm role assigned to a user |
| `AdminRealmRoleMappingDelete` | `admin.REALM_ROLE_MAPPING-DELETE` | Realm role removed from a user |

## Installation

### Core library (no framework dependency)

```powershell
dotnet add package Nefarius.Keycloak.Webhooks
```

### FastEndpoints integration

```powershell
dotnet add package Nefarius.Keycloak.Webhooks.FastEndpoints
```

## Usage

### With FastEndpoints

Register the integration in your `Program.cs` **before** `AddFastEndpoints()`:

```csharp
using Nefarius.Keycloak.Webhooks.FastEndpoints;

// Register options (optional — customise route and auth below)
builder.Services.AddKeycloakWebhooks(options =>
{
    options.Route = "/api/webhooks/{Id}"; // default
    options.AllowAnonymous = true;        // default
});

builder.Services.AddFastEndpoints();
```

Then implement a FastEndpoints `IEventHandler<T>` for each event type you care about:

```csharp
using FastEndpoints;
using Nefarius.Keycloak.Webhooks.Events;

public class UserRegisteredHandler : IEventHandler<AccessUserRegisteredEvent>
{
    public Task HandleAsync(AccessUserRegisteredEvent evt, CancellationToken ct)
    {
        Console.WriteLine($"New user registered: {evt.Email}");
        return Task.CompletedTask;
    }
}
```

### Without FastEndpoints (framework-agnostic)

Extend `KeycloakWebhookDispatcher` and override only the events you need, then call `DispatchAsync`:

```csharp
using Nefarius.Keycloak.Webhooks;
using Nefarius.Keycloak.Webhooks.Events;

public class MyWebhookHandler : KeycloakWebhookDispatcher
{
    public override Task OnAccessUserRegisteredAsync(AccessUserRegisteredEvent evt, CancellationToken ct = default)
    {
        Console.WriteLine($"Registered: {evt.Email}");
        return Task.CompletedTask;
    }
}

// Somewhere in your HTTP handler:
var handler = new MyWebhookHandler();
await handler.DispatchAsync(requestBodyJson, cancellationToken);
```

Alternatively, parse manually with `KeycloakWebhookParser`:

```csharp
using Nefarius.Keycloak.Webhooks;
using Nefarius.Keycloak.Webhooks.Events;

WebhookBaseEvent? evt = KeycloakWebhookParser.Parse(requestBodyJson);

if (evt is AccessUserRegisteredEvent reg)
{
    // handle registration
}
```

## Build

**Prerequisites:**

- .NET SDK 10.0 or later

```bash
git clone https://github.com/nefarius/Nefarius.Keycloak.Webhooks.git
cd Nefarius.Keycloak.Webhooks
dotnet build -c Release
```

Packages land in `bin/` at the repo root (configured in `Directory.Build.props`).

## API Documentation

Auto-generated API docs are published to [`/docs`](docs/) on every push to `master`.

## Support

This is a community library, not a commercial product.

- Search [existing issues](https://github.com/nefarius/Nefarius.Keycloak.Webhooks/issues) before opening a new one.
- The issue tracker is not a support forum. For general questions, use [GitHub Discussions](https://github.com/nefarius/Nefarius.Keycloak.Webhooks/discussions).
- No SLA or guaranteed response time.

## License

MIT — see [LICENSE](LICENSE).

## Sources & Credits

- [Keycloak `ext-event-webhook` extension](https://github.com/vymalo/keycloak-webhook) — the Keycloak plugin that delivers webhook events this library parses.
- [FastEndpoints](https://fast-endpoints.com/) — HTTP framework used by the optional integration package.
