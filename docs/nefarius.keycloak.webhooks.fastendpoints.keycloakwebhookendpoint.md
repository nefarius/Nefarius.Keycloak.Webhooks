# Class KeycloakWebhookEndpoint

Namespace: `Nefarius.Keycloak.Webhooks.FastEndpoints`

FastEndpoints receiver for `keycloak-events` webhook POST requests.

The endpoint:

- Reads and limits the exact request body.
- Verifies the configured unauthenticated, HMAC-SHA256, HMAC-SHA1, or bearer JWT mode.
- Parses all user, admin, and custom event types.
- Publishes specialized or category-level events through the FastEndpoints event bus.
- Returns `400` for malformed payloads, `401` for failed authentication, `413` for oversized bodies, and `200` only after event handlers complete.

## Constructor

```csharp
public KeycloakWebhookEndpoint(
    IOptions<KeycloakWebhookOptions> options,
    KeycloakWebhookAuthenticator authenticator)
```

## Methods

### Configure

```csharp
public override void Configure()
```

Registers the configured POST route and optional ASP.NET Core anonymous-access policy.

### HandleAsync

```csharp
public override Task HandleAsync(CancellationToken ct)
```

Authenticates, parses, and publishes one webhook request.
