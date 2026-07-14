namespace Nefarius.Keycloak.Webhooks.Events;

/// <summary>
///     Any native Keycloak admin event. Its <see cref="WebhookBaseEvent.Type" /> starts with
///     <c>admin.</c>.
/// </summary>
public class AdminWebhookEvent : WebhookBaseEvent
{
}