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
        using JsonDocument document = JsonDocument.Parse(json);
        KeycloakWebhookRequest? raw = document.RootElement.Deserialize<KeycloakWebhookRequest>(options ?? DefaultOptions);
        WebhookBaseEvent? evt = raw is null ? null : Parse(raw);
        if (evt is not null)
        {
            evt.RawPayload = document.RootElement.Clone();
        }

        return evt;
    }

    /// <summary>
    ///     Maps an already-deserialised <see cref="KeycloakWebhookRequest" /> to a strongly-typed event.
    /// </summary>
    /// <param name="raw">The deserialised raw request.</param>
    /// <returns>A typed event, or <c>null</c> if the event type is not recognised.</returns>
    public static WebhookBaseEvent? Parse(KeycloakWebhookRequest raw)
    {
        string? type = NormalizeType(raw);
        return type switch
        {
            null => null,
            KeycloakWebhookEventTypes.AccessRegister => MapRegister(raw, type),
            KeycloakWebhookEventTypes.AccessVerifyEmail => MapVerifyEmail(raw, type),
            KeycloakWebhookEventTypes.AccessSendVerifyEmail => MapSendVerifyEmail(raw, type),
            KeycloakWebhookEventTypes.AdminUserCreate => MapAdminUserCreate(raw, type),
            KeycloakWebhookEventTypes.AdminUserUpdate => MapAdminUserUpdate(raw, type),
            KeycloakWebhookEventTypes.AdminUserDelete => MapAdminUserDelete(raw, type),
            KeycloakWebhookEventTypes.AdminRealmRoleMappingCreate => MapBase<AdminRealmRoleMappingCreatedEvent>(raw, type),
            KeycloakWebhookEventTypes.AdminRealmRoleMappingDelete => MapBase<AdminRealmRoleMappingDeletedEvent>(raw, type),
            _ when type.StartsWith("access.", StringComparison.OrdinalIgnoreCase) =>
                MapBase<UserWebhookEvent>(raw, type),
            _ when type.StartsWith("admin.", StringComparison.OrdinalIgnoreCase) =>
                MapBase<AdminWebhookEvent>(raw, type),
            _ => MapBase<CustomWebhookEvent>(raw, type)
        };
    }

    // ── Helpers ───────────────────────────────────────────────────────────────

    private static string? NormalizeType(KeycloakWebhookRequest raw)
    {
        if (!string.IsNullOrWhiteSpace(raw.Type))
        {
            string wireType = raw.Type!;
            if (wireType.StartsWith("access.", StringComparison.OrdinalIgnoreCase) ||
                wireType.StartsWith("admin.", StringComparison.OrdinalIgnoreCase) ||
                wireType.StartsWith("system.", StringComparison.OrdinalIgnoreCase) ||
                raw.Uid is not null)
            {
                return wireType;
            }

            // ext-event-http sends native EventRepresentation names such as LOGIN.
            return $"access.{wireType}";
        }

        if (raw.ResourceType is null && raw.OperationType is null)
        {
            return null;
        }

        return $"admin.{raw.ResourceType}{(raw.ResourceType is not null && raw.OperationType is not null ? "-" : string.Empty)}{raw.OperationType}";
    }

    private static string? Detail(KeycloakWebhookRequest raw, string name)
        => raw.Details is not null && raw.Details.TryGetValue(name, out string? value) ? value : null;

    private static AuthDetails? MapAuthDetails(KeycloakWebhookRequest raw)
    {
        if (raw.AuthDetails is not null)
        {
            return raw.AuthDetails;
        }

        if (raw.ClientId is null && raw.UserId is null && raw.SessionId is null && raw.IpAddress is null)
        {
            return null;
        }

        return new AuthDetails
        {
            RealmId = raw.RealmName,
            ClientId = raw.ClientId,
            UserId = raw.UserId,
            SessionId = raw.SessionId,
            IpAddress = raw.IpAddress
        };
    }

    private static TEvent MapBase<TEvent>(KeycloakWebhookRequest raw, string type)
        where TEvent : WebhookBaseEvent, new()
        => new()
        {
            Time = raw.Time,
            RealmId = raw.RealmId,
            RealmName = raw.RealmName,
            Id = raw.Id,
            Uid = raw.Uid,
            AuthDetails = MapAuthDetails(raw),
            Type = type,
            Details = raw.Details is null
                ? new Dictionary<string, string?>()
                : new Dictionary<string, string?>(raw.Details),
            Error = raw.Error,
            ResourceType = raw.ResourceType,
            ResourceId = raw.ResourceId,
            OperationType = raw.OperationType,
            ResourcePath = raw.ResourcePath,
            Representation = raw.Representation
        };

    // ── Access event mappers ──────────────────────────────────────────────────

    private static AccessUserRegisteredEvent MapRegister(KeycloakWebhookRequest raw, string type)
    {
        AccessUserRegisteredEvent evt = MapBase<AccessUserRegisteredEvent>(raw, type);
        evt.AuthMethod = Detail(raw, "auth_method");
        evt.AuthType = Detail(raw, "auth_type");
        evt.RegisterMethod = Detail(raw, "register_method");
        evt.LastName = Detail(raw, "last_name");
        evt.RedirectUri = Detail(raw, "redirect_uri");
        evt.FirstName = Detail(raw, "first_name");
        evt.CodeId = Detail(raw, "code_id");
        evt.Email = Detail(raw, "email");
        evt.Username = Detail(raw, "username");

        return evt;
    }

    private static AccessUserVerifiedEmailEvent MapVerifyEmail(KeycloakWebhookRequest raw, string type)
    {
        AccessUserVerifiedEmailEvent evt = MapBase<AccessUserVerifiedEmailEvent>(raw, type);
        evt.AuthMethod = Detail(raw, "auth_method");
        evt.TokenId = Detail(raw, "token_id");
        evt.Action = Detail(raw, "action");
        evt.ResponseType = Detail(raw, "response_type");
        evt.RedirectUri = Detail(raw, "redirect_uri");
        evt.RememberMe = Detail(raw, "remember_me");
        evt.CodeId = Detail(raw, "code_id");
        evt.Email = Detail(raw, "email");
        evt.ResponseMode = Detail(raw, "response_mode");
        evt.Username = Detail(raw, "username");

        return evt;
    }

    private static AccessUserVerifyEmailSentEvent MapSendVerifyEmail(KeycloakWebhookRequest raw, string type)
    {
        AccessUserVerifyEmailSentEvent evt = MapBase<AccessUserVerifyEmailSentEvent>(raw, type);
        evt.AuthMethod = Detail(raw, "auth_method");
        evt.ResponseType = Detail(raw, "response_type");
        evt.RedirectUri = Detail(raw, "redirect_uri");
        evt.RememberMe = Detail(raw, "remember_me");
        evt.CodeId = Detail(raw, "code_id");
        evt.Email = Detail(raw, "email");
        evt.ResponseMode = Detail(raw, "response_mode");
        evt.Username = Detail(raw, "username");

        return evt;
    }

    // ── Admin user event mappers ──────────────────────────────────────────────

    private static AdminUserCreatedEvent MapAdminUserCreate(KeycloakWebhookRequest raw, string type)
    {
        AdminUserCreatedEvent evt = MapBase<AdminUserCreatedEvent>(raw, type);
        evt.UserId = Detail(raw, "userId");
        evt.Username = Detail(raw, "username");
        return evt;
    }

    private static AdminUserUpdatedEvent MapAdminUserUpdate(KeycloakWebhookRequest raw, string type)
    {
        AdminUserUpdatedEvent evt = MapBase<AdminUserUpdatedEvent>(raw, type);
        evt.UserId = Detail(raw, "userId");
        evt.Username = Detail(raw, "username");
        return evt;
    }

    private static AdminUserDeletedEvent MapAdminUserDelete(KeycloakWebhookRequest raw, string type)
    {
        AdminUserDeletedEvent evt = MapBase<AdminUserDeletedEvent>(raw, type);
        evt.UserId = Detail(raw, "userId");
        return evt;
    }
}