param(
    [string]$DocsPath = (Join-Path $PSScriptRoot "..\docs")
)

$ErrorActionPreference = "Stop"

$staleEventDetails = Join-Path $DocsPath "nefarius.keycloak.webhooks.models.eventdetails.md"
if (Test-Path $staleEventDetails) {
    Remove-Item $staleEventDetails
}

function Update-Doc {
    param(
        [string]$Name,
        [scriptblock]$Transform
    )

    $path = Join-Path $DocsPath $Name
    if (-not (Test-Path $path)) {
        throw "Generated API page not found: $path"
    }

    $content = [IO.File]::ReadAllText($path)
    $updated = & $Transform $content
    [IO.File]::WriteAllText($path, $updated)
}

# XMLDoc2Markdown 1.8 does not inspect nullable metadata. Restore nullable
# signatures from the public C# contracts after every generation run.
Get-ChildItem $DocsPath -Filter "nefarius.keycloak.webhooks.events.*.md" | ForEach-Object {
    $content = [IO.File]::ReadAllText($_.FullName)
    $content = $content -replace 'public AuthDetails AuthDetails', 'public AuthDetails? AuthDetails'
    $content = $content -replace `
        'public IReadOnlyDictionary<String, String> Details', `
        'public IReadOnlyDictionary<String, String?> Details'
    $content = $content -replace 'public string ([A-Za-z0-9_]+) \{', 'public string? $1 {'
    [IO.File]::WriteAllText($_.FullName, $content)
}

Get-ChildItem $DocsPath -Filter "nefarius.keycloak.webhooks.models.*.md" | ForEach-Object {
    $content = [IO.File]::ReadAllText($_.FullName)
    $content = $content -replace 'public AuthDetails AuthDetails', 'public AuthDetails? AuthDetails'
    $content = $content -replace 'public string ([A-Za-z0-9_]+) \{', 'public string? $1 {'
    $content = $content -replace `
        'public Dictionary<String, String> Details', `
        'public Dictionary<String, String?>? Details'
    [IO.File]::WriteAllText($_.FullName, $content)
}

Update-Doc "nefarius.keycloak.webhooks.authentication.keycloakjwtvalidationoptions.md" {
    param($content)
    $content -replace 'public Uri JwksUri', 'public Uri? JwksUri'
}

Update-Doc "nefarius.keycloak.webhooks.authentication.keycloakwebhookauthenticationresult.md" {
    param($content)
    $content -replace 'public string Error', 'public string? Error'
}

Update-Doc "nefarius.keycloak.webhooks.authentication.keycloakwebhookauthenticator.md" {
    param($content)
    $content `
        -replace 'string token,', 'string? token,' `
        -replace 'string signature,', 'string? signature,'
}

Update-Doc "nefarius.keycloak.webhooks.ikeycloakwebhookeventhandler.md" {
    param($content)
    $content -replace 'string eventType,', 'string? eventType,'
}

Update-Doc "nefarius.keycloak.webhooks.keycloakwebhookdispatcher.md" {
    param($content)
    $content -replace 'string eventType,', 'string? eventType,'
}

Update-Doc "nefarius.keycloak.webhooks.client.keycloakwebhooksclient.md" {
    param($content)
    $content `
        -replace 'JsonSerializerOptions serializerOptions', 'JsonSerializerOptions? serializerOptions' `
        -replace 'string search,', 'string? search,' `
        -replace 'PaginationOptions pagination,', 'PaginationOptions? pagination,' `
        -replace 'Task<Uri> CreateWebhookAsync', 'Task<Uri?> CreateWebhookAsync'
}

Get-ChildItem $DocsPath -Filter "nefarius.keycloak.webhooks.client.models.*.md" | ForEach-Object {
    $content = [IO.File]::ReadAllText($_.FullName)
    $content = $content -replace 'public string ([A-Za-z0-9_]+) \{', 'public string? $1 {'
    $content = $content -replace `
        'public IDictionary<String, String> ([A-Za-z0-9_]+) \{', `
        'public IDictionary<String, String>? $1 {'
    $content = $content -replace `
        'public IDictionary<String, JsonElement> ([A-Za-z0-9_]+) \{', `
        'public IDictionary<String, JsonElement>? $1 {'
    $content = $content -replace 'public ISet<String> EventTypes \{', 'public ISet<String>? EventTypes {'
    $content = $content -replace `
        'public WebhookEventAuthenticationDetails AuthDetails \{', `
        'public WebhookEventAuthenticationDetails? AuthDetails {'
    $content = $content -replace `
        'public WebhookSubscription Webhook \{', `
        'public WebhookSubscription? Webhook {'
    [IO.File]::WriteAllText($_.FullName, $content)
}

Update-Doc "nefarius.keycloak.webhooks.client.models.webhookauthenticationtypes.md" {
    param($content)
    $content `
        -replace 'public static string Bearer;', 'public const string Bearer = "bearer";' `
        -replace 'public static string Hmac;', 'public const string Hmac = "hmac";' `
        -replace 'public static string None;', 'public const string None = "none";'
}

$typeDescriptions = @{
    "nefarius.keycloak.webhooks.events.adminwebhookevent.md" =
        "Admin event type formed from the resource and operation, for example ``admin.USER-CREATE``."
    "nefarius.keycloak.webhooks.events.customwebhookevent.md" =
        "Application-defined event type, for example ``billing.invoice-issued``."
    "nefarius.keycloak.webhooks.events.userwebhookevent.md" =
        "Native user event type with an ``access.`` prefix, for example ``access.REGISTER``."
}

foreach ($entry in $typeDescriptions.GetEnumerator()) {
    Update-Doc $entry.Key {
        param($content)
        $pattern = '(?s)(### <a id="properties-type"/>\*\*Type\*\*\r?\n\r?\n).*?(?=\r?\n```csharp)'
        [regex]::Replace($content, $pattern, ('$1' + $entry.Value + "`r`n"))
    }
}
