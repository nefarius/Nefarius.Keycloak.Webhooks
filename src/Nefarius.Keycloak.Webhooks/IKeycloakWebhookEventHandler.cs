using Nefarius.Keycloak.Webhooks.Events;

namespace Nefarius.Keycloak.Webhooks;

/// <summary>
///     Framework-agnostic contract for handling typed Keycloak webhook events.
///     Implement this interface (or extend <see cref="KeycloakWebhookDispatcher" />) to process events
///     without depending on any specific HTTP framework.
/// </summary>
public interface IKeycloakWebhookEventHandler
{
    /// <summary>Called when a user self-registers.</summary>
    Task OnAccessUserRegisteredAsync(AccessUserRegisteredEvent evt, CancellationToken ct = default);

    /// <summary>Called when a user verifies their e-mail address.</summary>
    Task OnAccessUserVerifiedEmailAsync(AccessUserVerifiedEmailEvent evt, CancellationToken ct = default);

    /// <summary>Called when a verification e-mail is dispatched to a user.</summary>
    Task OnAccessUserVerifyEmailSentAsync(AccessUserVerifyEmailSentEvent evt, CancellationToken ct = default);

    /// <summary>Called when an administrator creates a user.</summary>
    Task OnAdminUserCreatedAsync(AdminUserCreatedEvent evt, CancellationToken ct = default);

    /// <summary>Called when an administrator updates a user.</summary>
    Task OnAdminUserUpdatedAsync(AdminUserUpdatedEvent evt, CancellationToken ct = default);

    /// <summary>Called when a user is deleted.</summary>
    Task OnAdminUserDeletedAsync(AdminUserDeletedEvent evt, CancellationToken ct = default);

    /// <summary>Called when a realm role is assigned to a user.</summary>
    Task OnAdminRealmRoleMappingCreatedAsync(AdminRealmRoleMappingCreatedEvent evt, CancellationToken ct = default);

    /// <summary>Called when a realm role is removed from a user.</summary>
    Task OnAdminRealmRoleMappingDeletedAsync(AdminRealmRoleMappingDeletedEvent evt, CancellationToken ct = default);

    /// <summary>Called for any event type not recognised by the parser (i.e. <see cref="KeycloakWebhookParser.Parse(Models.KeycloakWebhookRequest)" /> returned <c>null</c>).</summary>
    Task OnUnknownEventAsync(string? eventType, CancellationToken ct = default);
}
