namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     A realm role has been removed from a user (<c>admin.REALM_ROLE_MAPPING-DELETE</c>).
///     The affected user ID can be extracted from <see cref="WebhookBaseEvent.ResourcePath" />.
/// </summary>
public sealed class AdminRealmRoleMappingDeletedEvent : AdminWebhookEvent
{
}