namespace Nefarius.Keycloak.Webhooks;

/// <summary>
///     String constants for all known Keycloak <c>ext-event-webhook</c> event type values,
///     as they appear in the <c>type</c> field of the webhook payload.
/// </summary>
public static class KeycloakWebhookEventTypes
{
    // ── Access events ─────────────────────────────────────────────────────────

    /// <summary>A new user has self-registered.</summary>
    public const string AccessRegister = "access.REGISTER";

    /// <summary>A user has verified their e-mail address.</summary>
    public const string AccessVerifyEmail = "access.VERIFY_EMAIL";

    /// <summary>A verification e-mail has been sent to a user.</summary>
    public const string AccessSendVerifyEmail = "access.SEND_VERIFY_EMAIL";

    // ── Admin / user events ───────────────────────────────────────────────────

    /// <summary>An administrator has created a new user.</summary>
    public const string AdminUserCreate = "admin.USER-CREATE";

    /// <summary>An administrator has updated a user.</summary>
    public const string AdminUserUpdate = "admin.USER-UPDATE";

    /// <summary>A user has been deleted.</summary>
    public const string AdminUserDelete = "admin.USER-DELETE";

    // ── Admin / role-mapping events ───────────────────────────────────────────

    /// <summary>A realm role has been assigned to a user.</summary>
    public const string AdminRealmRoleMappingCreate = "admin.REALM_ROLE_MAPPING-CREATE";

    /// <summary>A realm role has been removed from a user.</summary>
    public const string AdminRealmRoleMappingDelete = "admin.REALM_ROLE_MAPPING-DELETE";
}
