# <img src="assets/NSS-128x128.png" align="left" />Nefarius.Keycloak.Webhooks

[![.NET](https://github.com/nefarius/Nefarius.Keycloak.Webhooks/actions/workflows/build.yml/badge.svg)](https://github.com/nefarius/Nefarius.Keycloak.Webhooks/actions/workflows/build.yml)
[![Nuget](https://img.shields.io/nuget/v/Nefarius.Keycloak.Webhooks)](https://www.nuget.org/packages/Nefarius.Keycloak.Webhooks/)
[![Nuget](https://img.shields.io/nuget/dt/Nefarius.Keycloak.Webhooks)](https://www.nuget.org/packages/Nefarius.Keycloak.Webhooks/)
[![Assisted by Cursor AI](https://img.shields.io/badge/Assisted%20by-Cursor%20AI-8B5CF6?style=flat)](https://cursor.com/)

Receive and process [Keycloak `keycloak-events`](https://github.com/p2-inc/keycloak-events) webhook events as strongly-typed C# objects — no framework lock-in.

## About

This repository contains three NuGet packages:

| Package | Purpose |
|---|---|
| `Nefarius.Keycloak.Webhooks` | Complete payload models, open-ended event parsing and dispatch, HMAC verification, and realm-signed JWT verification. |
| `Nefarius.Keycloak.Webhooks.FastEndpoints` | HTTP receiver for [FastEndpoints](https://fast-endpoints.com/) with exact-body authentication and event-bus publishing. |
| `Nefarius.Keycloak.Webhooks.Client` | Typed client for webhook CRUD, secrets, persisted sends/resends, stored payloads, and custom event publishing. |

## Features

- Generic user, admin, and custom event models cover every current and future upstream event type.
- Specialized projections remain available for registration, e-mail verification, user CRUD, and realm-role mappings.
- Complete upstream payload preservation, including source `id`, delivery `uid`, realm name, resource ID, arbitrary details, errors, and raw JSON.
- `KeycloakWebhookParser` — static parser, `string` and `KeycloakWebhookRequest` overloads.
- `KeycloakWebhookDispatcher` — specialized and category-level callbacks with no-op defaults.
- `IKeycloakWebhookEventHandler` — implement directly if you prefer composition over inheritance.
- HMAC-SHA256, legacy HMAC-SHA1, unauthenticated, and realm-signed bearer JWT receiver modes.
- Typed access to every `keycloak-events` v0.62 webhook and custom-event REST endpoint.
- AOT-safe: event dispatch uses statically-resolved generic calls (no reflection).
- `GenerateDocumentationFile` enabled — full XML doc coverage.

## Supported frameworks

| Package | Frameworks |
|---|---|
| `Nefarius.Keycloak.Webhooks` | `netstandard2.0`, `net8.0`, `net9.0`, `net10.0` |
| `Nefarius.Keycloak.Webhooks.FastEndpoints` | `net8.0`, `net9.0`, `net10.0` |
| `Nefarius.Keycloak.Webhooks.Client` | `netstandard2.0`, `net8.0`, `net9.0`, `net10.0` |

Tested compatibility:

- `p2-inc/keycloak-events` v0.62
- Keycloak 26.6.3
- Legacy `ext-event-http` user/admin payloads from the same extension release

Upstream only supports the Keycloak version declared by its release. Other extension or Keycloak versions are not claimed as supported.

## Event coverage

- `access.*` becomes `UserWebhookEvent`.
- `admin.*` becomes `AdminWebhookEvent`.
- Application-defined event names become `CustomWebhookEvent`.
- The existing eight event constants and specialized classes remain available as convenience projections.
- Unknown detail keys and new resource types are preserved; valid events are not silently discarded while returning success.

## Limitations

- This repository does not install or replace the Java Keycloak extension.
- Receiver-side deduplication is application-specific and is not persisted by these packages.
- Bearer verification requires access to the configured realm JWKS endpoint.
- Legacy `ext-event-http` payloads do not carry the managed webhook delivery `uid`.

## Version 2 migration

Keycloak identifiers are opaque strings, not guaranteed UUIDs. Version 2 changes `Guid` identifier properties to nullable `string` values and adds category callbacks to `IKeycloakWebhookEventHandler`. Recompile handlers and remove assumptions that missing IDs equal `Guid.Empty`.

## Installation

### Core library (no framework dependency)

```powershell
dotnet add package Nefarius.Keycloak.Webhooks
```

### FastEndpoints integration

```powershell
dotnet add package Nefarius.Keycloak.Webhooks.FastEndpoints
```

### Keycloak management client

```powershell
dotnet add package Nefarius.Keycloak.Webhooks.Client
```

## Usage

### With FastEndpoints

Register the integration in your `Program.cs` **before** `AddFastEndpoints()`:

```csharp
using Nefarius.Keycloak.Webhooks.Authentication;
using Nefarius.Keycloak.Webhooks.FastEndpoints;

// Register options (optional — customise route and auth below)
builder.Services.AddKeycloakWebhooks(options =>
{
    options.Route = "/api/webhooks/{Id}";
    options.AuthenticationMode = KeycloakWebhookAuthenticationMode.HmacSha256;
    options.HmacSecret = builder.Configuration["Keycloak:WebhookSecret"];
});

builder.Services.AddFastEndpoints();
```

For realm-signed bearer authentication:

```csharp
builder.Services.AddKeycloakWebhooks(options =>
{
    options.AuthenticationMode = KeycloakWebhookAuthenticationMode.Bearer;
    options.Jwt.Issuer = "https://id.example/realms/acme";
    options.Jwt.Audience = "https://receiver.example/api/webhooks/keycloak";
});
```

The endpoint validates the realm signing key from the issuer JWKS, issuer, audience, expiry, `jti`, and `request_body_sha256`. JWKS endpoints must use HTTPS, except loopback addresses used in tests.

`AuthenticationMode.None` is available for explicitly unauthenticated webhooks. Do not use it on an Internet-facing endpoint without equivalent network controls.

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

### Management client

Configure the `HttpClient` with a Keycloak access token that has `view-events`, `manage-events`, or `publish-events` as required:

```csharp
using System.Net.Http.Headers;

using Nefarius.Keycloak.Webhooks.Client;

var http = new HttpClient
{
    BaseAddress = new Uri("https://id.example/") // may include a relative path such as /auth/
};
http.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", accessToken);

var client = new KeycloakWebhooksClient(http);
var webhooks = await client.GetWebhooksAsync("acme");
```

The client covers webhook list/count/create/get/update/delete, secret retrieval, send history, send detail/resend, stored payload lookup, sends by source event, and custom event publishing.

### Delivery semantics

- Keycloak treats every 2xx response as delivered and retries non-2xx responses.
- The FastEndpoints receiver returns 2xx only after authentication, parsing, and event handlers succeed.
- Keycloak can deliver the same event more than once. Make handlers idempotent using delivery `uid` or source event `id`, depending on the required scope.
- HMAC and JWT body-hash checks use the exact request bytes. Do not deserialize and reserialize before verification.

## Build

**Prerequisites:**

- .NET SDK 10.0 or later

```bash
git clone https://github.com/nefarius/Nefarius.Keycloak.Webhooks.git
cd Nefarius.Keycloak.Webhooks
dotnet restore
dotnet test -c Release
dotnet pack -c Release --no-restore
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

Keycloak is a trademark of Red Hat, Inc. This project is independent and is not affiliated with or endorsed by Red Hat or Phase Two.

## Sources & Credits

- [p2-inc/keycloak-events v0.62](https://github.com/p2-inc/keycloak-events/tree/v0.62) — the Elastic License 2.0 Keycloak extension whose external protocol and REST resources this library implements.
- [FastEndpoints](https://fast-endpoints.com/) — HTTP framework used by the optional integration package.
- [Microsoft.IdentityModel.JsonWebTokens](https://www.nuget.org/packages/Microsoft.IdentityModel.JsonWebTokens) — JWT signature and claims validation.
