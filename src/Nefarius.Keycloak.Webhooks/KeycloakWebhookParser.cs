using System.Text.Json;

using Nefarius.Keycloak.Webhooks.Events;
using Nefarius.Keycloak.Webhooks.Models;

namespace Nefarius.Keycloak.Webhooks;

/// <summary>
///     Parses raw Keycloak webhook payloads into strongly-typed <see cref="WebhookBaseEvent" /> instances.
/// </summary>
public static class KeycloakWebhookParser
{
    private static readonly JsonSerializerOptions DefaultOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    /// <summary>
    ///     Parses a raw JSON string into a strongly-typed webhook event.
    /// </summary>
    /// <param name="json">The JSON body received from Keycloak.</param>
    /// <param name="options">Optional custom serialiser options; defaults to case-insensitive property matching.</param>
    /// <returns>A typed event, or <c>null</c> if the event type is not recognised.</returns>
    public static WebhookBaseEvent? Parse(string json, JsonSerializerOptions? options = null)
    {
        KeycloakWebhookRequest? raw = JsonSerializer.Deserialize<KeycloakWebhookRequest>(json, options ?? DefaultOptions);
        return raw is null ? null : Parse(raw);
    }

    /// <summary>
    ///     Maps an already-deserialised <see cref="KeycloakWebhookRequest" /> to a strongly-typed event.
    /// </summary>
    /// <param name="raw">The deserialised raw request.</param>
    /// <returns>A typed event, or <c>null</c> if the event type is not recognised.</returns>
    public static WebhookBaseEvent? Parse(KeycloakWebhookRequest raw)
    {
        return raw.Type switch
        {
            KeycloakWebhookEventTypes.AccessRegister => MapRegister(raw),
            KeycloakWebhookEventTypes.AccessVerifyEmail => MapVerifyEmail(raw),
            KeycloakWebhookEventTypes.AccessSendVerifyEmail => MapSendVerifyEmail(raw),
            KeycloakWebhookEventTypes.AdminUserCreate => MapAdminUserCreate(raw),
            KeycloakWebhookEventTypes.AdminUserUpdate => MapAdminUserUpdate(raw),
            KeycloakWebhookEventTypes.AdminUserDelete => MapAdminUserDelete(raw),
            KeycloakWebhookEventTypes.AdminRealmRoleMappingCreate => MapAdminRealmRoleMappingCreate(raw),
            KeycloakWebhookEventTypes.AdminRealmRoleMappingDelete => MapAdminRealmRoleMappingDelete(raw),
            _ => null
        };
    }

    // ── Helpers ───────────────────────────────────────────────────────────────

    private static TEvent MapBase<TEvent>(KeycloakWebhookRequest raw)
        where TEvent : WebhookBaseEvent, new()
        => new()
        {
            Time = raw.Time,
            RealmId = raw.RealmId,
            Uid = raw.Uid,
            AuthDetails = raw.AuthDetails ?? new AuthDetails(),
            Type = raw.Type,
            ResourceType = raw.ResourceType,
            OperationType = raw.OperationType,
            ResourcePath = raw.ResourcePath,
            Representation = raw.Representation
        };

    // ── Access event mappers ──────────────────────────────────────────────────

    private static AccessUserRegisteredEvent MapRegister(KeycloakWebhookRequest raw)
    {
        AccessUserRegisteredEvent evt = MapBase<AccessUserRegisteredEvent>(raw);
        EventDetails? d = raw.Details;
        if (d is null) return evt;

        evt.AuthMethod = d.AuthMethod;
        evt.AuthType = d.AuthType;
        evt.RegisterMethod = d.RegisterMethod;
        evt.LastName = d.LastName;
        evt.RedirectUri = d.RedirectUri;
        evt.FirstName = d.FirstName;
        evt.CodeId = d.CodeId;
        evt.Email = d.Email;
        evt.Username = d.Username;

        return evt;
    }

    private static AccessUserVerifiedEmailEvent MapVerifyEmail(KeycloakWebhookRequest raw)
    {
        AccessUserVerifiedEmailEvent evt = MapBase<AccessUserVerifiedEmailEvent>(raw);
        EventDetails? d = raw.Details;
        if (d is null) return evt;

        evt.AuthMethod = d.AuthMethod;
        evt.TokenId = d.TokenId;
        evt.Action = d.Action;           // fixed: was overwritten by ResponseType in the original app
        evt.ResponseType = d.ResponseType;
        evt.RedirectUri = d.RedirectUri;
        evt.RememberMe = d.RememberMe;
        evt.CodeId = d.CodeId;
        evt.Email = d.Email;
        evt.ResponseMode = d.ResponseMode;
        evt.Username = d.Username;

        return evt;
    }

    private static AccessUserVerifyEmailSentEvent MapSendVerifyEmail(KeycloakWebhookRequest raw)
    {
        AccessUserVerifyEmailSentEvent evt = MapBase<AccessUserVerifyEmailSentEvent>(raw);
        EventDetails? d = raw.Details;
        if (d is null) return evt;

        evt.AuthMethod = d.AuthMethod;
        evt.ResponseType = d.ResponseType;
        evt.RedirectUri = d.RedirectUri;
        evt.RememberMe = d.RememberMe;
        evt.CodeId = d.CodeId;
        evt.Email = d.Email;
        evt.ResponseMode = d.ResponseMode;
        evt.Username = d.Username;

        return evt;
    }

    // ── Admin user event mappers ──────────────────────────────────────────────

    private static AdminUserCreatedEvent MapAdminUserCreate(KeycloakWebhookRequest raw)
    {
        AdminUserCreatedEvent evt = MapBase<AdminUserCreatedEvent>(raw);
        evt.UserId = raw.Details?.UserId ?? Guid.Empty;
        evt.Username = raw.Details?.Username;
        return evt;
    }

    private static AdminUserUpdatedEvent MapAdminUserUpdate(KeycloakWebhookRequest raw)
    {
        AdminUserUpdatedEvent evt = MapBase<AdminUserUpdatedEvent>(raw);
        evt.UserId = raw.Details?.UserId ?? Guid.Empty;
        evt.Username = raw.Details?.Username;
        return evt;
    }

    private static AdminUserDeletedEvent MapAdminUserDelete(KeycloakWebhookRequest raw)
    {
        AdminUserDeletedEvent evt = MapBase<AdminUserDeletedEvent>(raw);
        evt.UserId = raw.Details?.UserId ?? Guid.Empty;
        return evt;
    }

    // ── Admin role-mapping event mappers ──────────────────────────────────────

    private static AdminRealmRoleMappingCreatedEvent MapAdminRealmRoleMappingCreate(KeycloakWebhookRequest raw)
        => MapBase<AdminRealmRoleMappingCreatedEvent>(raw);

    private static AdminRealmRoleMappingDeletedEvent MapAdminRealmRoleMappingDelete(KeycloakWebhookRequest raw)
        => MapBase<AdminRealmRoleMappingDeletedEvent>(raw);
}
