using FastEndpoints;

using Microsoft.Extensions.Options;

using Nefarius.Keycloak.Webhooks.Events;
using Nefarius.Keycloak.Webhooks.Models;

namespace Nefarius.Keycloak.Webhooks.FastEndpoints;

/// <summary>
///     FastEndpoints receiver for Keycloak <c>ext-event-webhook</c> events.
///     Parses the raw payload with <see cref="KeycloakWebhookParser" /> and publishes each typed event
///     via the FastEndpoints internal event bus, so <c>IEventHandler&lt;T&gt;</c> implementations are
///     invoked automatically.
/// </summary>
public class KeycloakWebhookEndpoint : Endpoint<KeycloakWebhookRequest>
{
    private readonly KeycloakWebhookOptions _options;

    public KeycloakWebhookEndpoint(IOptions<KeycloakWebhookOptions> options)
    {
        _options = options.Value;
    }

    public override void Configure()
    {
        Post(_options.Route);

        if (_options.AllowAnonymous)
        {
            AllowAnonymous();
        }
    }

    public override async Task HandleAsync(KeycloakWebhookRequest req, CancellationToken ct)
    {
        WebhookBaseEvent? evt = KeycloakWebhookParser.Parse(req);

        if (evt is not null)
        {
            await PublishEventAsync(evt, ct);
        }

        await Send.OkAsync("OK", ct);
    }

    /// <summary>
    ///     Routes the typed event to <see cref="Endpoint{TRequest}.PublishAsync{TEvent}" />.
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
            _ => Task.CompletedTask
        };
    }
}
