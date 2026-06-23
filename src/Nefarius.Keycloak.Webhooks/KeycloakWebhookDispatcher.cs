using Nefarius.Keycloak.Webhooks.Events;
using Nefarius.Keycloak.Webhooks.Models;

namespace Nefarius.Keycloak.Webhooks;

/// <summary>
///     Abstract base that implements <see cref="IKeycloakWebhookEventHandler" /> with no-op defaults.
///     Subclass and override only the event methods you care about, then call
///     <see cref="DispatchAsync(WebhookBaseEvent,CancellationToken)" /> (or the JSON overload) to route
///     an incoming event to the appropriate virtual method.
/// </summary>
public abstract class KeycloakWebhookDispatcher : IKeycloakWebhookEventHandler
{
    /// <inheritdoc />
    public virtual Task OnAccessUserRegisteredAsync(AccessUserRegisteredEvent evt, CancellationToken ct = default)
        => Task.CompletedTask;

    /// <inheritdoc />
    public virtual Task OnAccessUserVerifiedEmailAsync(AccessUserVerifiedEmailEvent evt, CancellationToken ct = default)
        => Task.CompletedTask;

    /// <inheritdoc />
    public virtual Task OnAccessUserVerifyEmailSentAsync(AccessUserVerifyEmailSentEvent evt, CancellationToken ct = default)
        => Task.CompletedTask;

    /// <inheritdoc />
    public virtual Task OnAdminUserCreatedAsync(AdminUserCreatedEvent evt, CancellationToken ct = default)
        => Task.CompletedTask;

    /// <inheritdoc />
    public virtual Task OnAdminUserUpdatedAsync(AdminUserUpdatedEvent evt, CancellationToken ct = default)
        => Task.CompletedTask;

    /// <inheritdoc />
    public virtual Task OnAdminUserDeletedAsync(AdminUserDeletedEvent evt, CancellationToken ct = default)
        => Task.CompletedTask;

    /// <inheritdoc />
    public virtual Task OnAdminRealmRoleMappingCreatedAsync(AdminRealmRoleMappingCreatedEvent evt, CancellationToken ct = default)
        => Task.CompletedTask;

    /// <inheritdoc />
    public virtual Task OnAdminRealmRoleMappingDeletedAsync(AdminRealmRoleMappingDeletedEvent evt, CancellationToken ct = default)
        => Task.CompletedTask;

    /// <inheritdoc />
    public virtual Task OnUnknownEventAsync(string? eventType, CancellationToken ct = default)
        => Task.CompletedTask;

    // ── Dispatch helpers ──────────────────────────────────────────────────────

    /// <summary>
    ///     Parses <paramref name="json" /> and routes the result to the appropriate <c>On*Async</c> method.
    /// </summary>
    public Task DispatchAsync(string json, CancellationToken ct = default)
    {
        WebhookBaseEvent? evt = KeycloakWebhookParser.Parse(json);
        return DispatchAsync(evt, ct);
    }

    /// <summary>
    ///     Parses <paramref name="raw" /> and routes the result to the appropriate <c>On*Async</c> method.
    /// </summary>
    public Task DispatchAsync(KeycloakWebhookRequest raw, CancellationToken ct = default)
    {
        WebhookBaseEvent? evt = KeycloakWebhookParser.Parse(raw);
        return DispatchAsync(evt, ct);
    }

    /// <summary>
    ///     Routes an already-typed <paramref name="evt" /> (or <c>null</c> for unknown) to the appropriate
    ///     <c>On*Async</c> method.
    /// </summary>
    public Task DispatchAsync(WebhookBaseEvent? evt, CancellationToken ct = default)
    {
        return evt switch
        {
            AccessUserRegisteredEvent e => OnAccessUserRegisteredAsync(e, ct),
            AccessUserVerifiedEmailEvent e => OnAccessUserVerifiedEmailAsync(e, ct),
            AccessUserVerifyEmailSentEvent e => OnAccessUserVerifyEmailSentAsync(e, ct),
            AdminUserCreatedEvent e => OnAdminUserCreatedAsync(e, ct),
            AdminUserUpdatedEvent e => OnAdminUserUpdatedAsync(e, ct),
            AdminUserDeletedEvent e => OnAdminUserDeletedAsync(e, ct),
            AdminRealmRoleMappingCreatedEvent e => OnAdminRealmRoleMappingCreatedAsync(e, ct),
            AdminRealmRoleMappingDeletedEvent e => OnAdminRealmRoleMappingDeletedAsync(e, ct),
            null => OnUnknownEventAsync(null, ct),
            _ => OnUnknownEventAsync(evt.Type, ct)
        };
    }
}
