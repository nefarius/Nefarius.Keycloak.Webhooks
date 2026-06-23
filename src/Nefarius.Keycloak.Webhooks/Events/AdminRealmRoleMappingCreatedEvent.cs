namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     A realm role has been assigned to a user (<c>admin.REALM_ROLE_MAPPING-CREATE</c>).
///     The affected user ID can be extracted from <see cref="WebhookBaseEvent.ResourcePath" />.
/// </summary>
public sealed class AdminRealmRoleMappingCreatedEvent : WebhookBaseEvent
{
}
