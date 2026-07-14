using System.Text;
using System.Text.Json;

using FastEndpoints;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;

using Nefarius.Keycloak.Webhooks.Authentication;
using Nefarius.Keycloak.Webhooks.Events;

namespace Nefarius.Keycloak.Webhooks.FastEndpoints;

/// <summary>
///     FastEndpoints receiver for Keycloak <c>ext-event-webhook</c> events.
///     Parses the raw payload with <see cref="KeycloakWebhookParser" /> and publishes each typed event
///     via the FastEndpoints internal event bus, so <c>IEventHandler&lt;T&gt;</c> implementations are
///     invoked automatically.
/// </summary>
public class KeycloakWebhookEndpoint : EndpointWithoutRequest
{
    private readonly KeycloakWebhookOptions _options;
    private readonly KeycloakWebhookAuthenticator _authenticator;

    /// <summary>Initialises the endpoint with the resolved <see cref="KeycloakWebhookOptions" />.</summary>
    /// <param name="options">Resolved options instance.</param>
    /// <param name="authenticator">Verifier for realm-signed bearer webhook tokens.</param>
    public KeycloakWebhookEndpoint(
        IOptions<KeycloakWebhookOptions> options,
        KeycloakWebhookAuthenticator authenticator)
    {
        _options = options.Value;
        _authenticator = authenticator;
    }

    /// <inheritdoc />
    public override void Configure()
    {
        Post(_options.Route);

        if (_options.AllowAnonymous)
        {
            AllowAnonymous();
        }
    }

    /// <inheritdoc />
    public override async Task HandleAsync(CancellationToken ct)
    {
        IHttpMaxRequestBodySizeFeature? maxBodyFeature =
            HttpContext.Features.Get<IHttpMaxRequestBodySizeFeature>();
        if (maxBodyFeature is { IsReadOnly: false })
        {
            maxBodyFeature.MaxRequestBodySize = _options.MaxRequestBodySize;
        }

        if (HttpContext.Request.ContentLength > _options.MaxRequestBodySize)
        {
            await WriteResponseAsync(413, "Webhook payload is too large.", ct);
            return;
        }

        byte[] body;
        using (MemoryStream stream = new())
        {
            byte[] buffer = new byte[81920];
            long totalBytes = 0;
            int bytesRead;
            while ((bytesRead = await HttpContext.Request.Body.ReadAsync(buffer, ct)) > 0)
            {
                totalBytes += bytesRead;
                if (totalBytes > _options.MaxRequestBodySize)
                {
                    await WriteResponseAsync(413, "Webhook payload is too large.", ct);
                    return;
                }

                await stream.WriteAsync(buffer.AsMemory(0, bytesRead), ct);
            }

            body = stream.ToArray();
        }

        KeycloakWebhookAuthenticationResult authentication = await AuthenticateAsync(body, ct);
        if (!authentication.Succeeded)
        {
            await WriteResponseAsync(401, authentication.Error ?? "Webhook authentication failed.", ct);
            return;
        }

        WebhookBaseEvent? evt;
        try
        {
            evt = KeycloakWebhookParser.Parse(Encoding.UTF8.GetString(body));
        }
        catch (JsonException)
        {
            await WriteResponseAsync(400, "Malformed webhook JSON.", ct);
            return;
        }

        if (evt is null)
        {
            await WriteResponseAsync(400, "The payload does not identify an event type.", ct);
            return;
        }

        await PublishEventAsync(evt, ct);
        await Send.OkAsync("OK", ct);
    }

    private Task<KeycloakWebhookAuthenticationResult> AuthenticateAsync(
        ReadOnlyMemory<byte> body,
        CancellationToken ct)
    {
        switch (_options.AuthenticationMode)
        {
            case KeycloakWebhookAuthenticationMode.None:
                return Task.FromResult(KeycloakWebhookAuthenticationResult.Success());
            case KeycloakWebhookAuthenticationMode.HmacSha1:
            case KeycloakWebhookAuthenticationMode.HmacSha256:
                return Task.FromResult(KeycloakWebhookAuthenticator.VerifyHmac(
                    body,
                    HttpContext.Request.Headers["X-Keycloak-Signature"].ToString(),
                    _options.HmacSecret ?? string.Empty,
                    _options.AuthenticationMode));
            case KeycloakWebhookAuthenticationMode.Bearer:
                string authorization = HttpContext.Request.Headers.Authorization.ToString();
                string? token = authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase)
                    ? authorization.Substring("Bearer ".Length).Trim()
                    : null;
                return _authenticator.VerifyBearerAsync(body, token, _options.Jwt, ct);
            default:
                return Task.FromResult(
                    KeycloakWebhookAuthenticationResult.Failure("Unsupported authentication mode."));
        }
    }

    private async Task WriteResponseAsync(int statusCode, string message, CancellationToken ct)
    {
        HttpContext.Response.StatusCode = statusCode;
        HttpContext.Response.ContentType = "text/plain";
        await HttpContext.Response.WriteAsync(message, ct);
    }

    /// <summary>
    ///     Routes the typed event to <c>PublishAsync&lt;TEvent&gt;</c>.
    ///     A switch on concrete type is used to keep generics statically resolved (AOT-safe).
    /// </summary>
    private Task PublishEventAsync(WebhookBaseEvent evt, CancellationToken ct)
    {
        return evt switch
        {
            AccessUserRegisteredEvent e => PublishAsync(e, cancellation: ct),
            AccessUserVerifiedEmailEvent e => PublishAsync(e, cancellation: ct),
            AccessUserVerifyEmailSentEvent e => PublishAsync(e, cancellation: ct),
            AdminUserCreatedEvent e => PublishAsync(e, cancellation: ct),
            AdminUserUpdatedEvent e => PublishAsync(e, cancellation: ct),
            AdminUserDeletedEvent e => PublishAsync(e, cancellation: ct),
            AdminRealmRoleMappingCreatedEvent e => PublishAsync(e, cancellation: ct),
            AdminRealmRoleMappingDeletedEvent e => PublishAsync(e, cancellation: ct),
            UserWebhookEvent e => PublishAsync(e, cancellation: ct),
            AdminWebhookEvent e => PublishAsync(e, cancellation: ct),
            CustomWebhookEvent e => PublishAsync(e, cancellation: ct),
            _ => PublishAsync(evt, cancellation: ct)
        };
    }
}