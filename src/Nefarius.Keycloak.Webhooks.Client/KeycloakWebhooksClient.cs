using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

using Nefarius.Keycloak.Webhooks.Client.Models;

namespace Nefarius.Keycloak.Webhooks.Client;

/// <summary>
/// Provides typed access to the management endpoints exposed by ext-event-webhook v0.62.
/// </summary>
/// <remarks>
/// The supplied <see cref="HttpClient"/> must have an absolute <see cref="HttpClient.BaseAddress"/>.
/// Authentication, including bearer token configuration, remains the caller's responsibility.
/// </remarks>
public sealed class KeycloakWebhooksClient
{
    private static readonly JsonSerializerOptions DefaultSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _serializerOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="KeycloakWebhooksClient"/> class.
    /// </summary>
    /// <param name="httpClient">
    /// The HTTP client to use. Its base address may include a relative path such as <c>/auth</c>.
    /// </param>
    /// <param name="serializerOptions">
    /// Optional JSON serializer options. Camel-case names and case-insensitive reads are used by default.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="httpClient"/> is <see langword="null"/>.</exception>
    public KeycloakWebhooksClient(HttpClient httpClient, JsonSerializerOptions? serializerOptions = null)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _serializerOptions = serializerOptions ?? DefaultSerializerOptions;
    }

    /// <summary>
    /// Lists webhook subscriptions in a realm.
    /// </summary>
    /// <param name="realm">The realm name.</param>
    /// <param name="pagination">Optional pagination parameters.</param>
    /// <param name="cancellationToken">A token that cancels the operation.</param>
    /// <returns>The webhook subscriptions.</returns>
    public Task<IReadOnlyList<WebhookSubscription>> GetWebhooksAsync(
        string realm,
        PaginationOptions? pagination = null,
        CancellationToken cancellationToken = default)
    {
        string path = RealmPath(realm, "webhooks") + BuildPaginationQuery(pagination);
        return GetListAsync<WebhookSubscription>(path, cancellationToken);
    }

    /// <summary>
    /// Counts webhook subscriptions in a realm.
    /// </summary>
    /// <param name="realm">The realm name.</param>
    /// <param name="search">
    /// An optional search value passed to the upstream endpoint. Upstream v0.62 accepts but does not apply it.
    /// </param>
    /// <param name="cancellationToken">A token that cancels the operation.</param>
    /// <returns>The number of webhook subscriptions.</returns>
    public Task<long> CountWebhooksAsync(
        string realm,
        string? search = null,
        CancellationToken cancellationToken = default)
    {
        string path = RealmPath(realm, "webhooks/count");
        if (search is not null)
        {
            path += "?search=" + Uri.EscapeDataString(search);
        }

        return GetAsync<long>(path, cancellationToken);
    }

    /// <summary>
    /// Creates a webhook subscription.
    /// </summary>
    /// <param name="realm">The realm name.</param>
    /// <param name="subscription">The webhook subscription to create.</param>
    /// <param name="cancellationToken">A token that cancels the operation.</param>
    /// <returns>The resource URI from the response's <c>Location</c> header, or <see langword="null"/> if omitted.</returns>
    public async Task<Uri?> CreateWebhookAsync(
        string realm,
        WebhookSubscription subscription,
        CancellationToken cancellationToken = default)
    {
        if (subscription is null)
        {
            throw new ArgumentNullException(nameof(subscription));
        }

        using HttpRequestMessage request =
            CreateJsonRequest(HttpMethod.Post, RealmPath(realm, "webhooks"), subscription);
        using HttpResponseMessage response = await _httpClient
            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
            .ConfigureAwait(false);
        await ThrowIfNotSuccessfulAsync(response, cancellationToken).ConfigureAwait(false);

        Uri? location = response.Headers.Location;
        if (location is not null && !location.IsAbsoluteUri && request.RequestUri is not null)
        {
            location = new Uri(request.RequestUri, location);
        }

        return location;
    }

    /// <summary>
    /// Gets a webhook subscription by identifier.
    /// </summary>
    /// <param name="realm">The realm name.</param>
    /// <param name="webhookId">The webhook identifier.</param>
    /// <param name="cancellationToken">A token that cancels the operation.</param>
    /// <returns>The webhook subscription.</returns>
    public Task<WebhookSubscription> GetWebhookAsync(
        string realm,
        string webhookId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<WebhookSubscription>(
            RealmPath(realm, "webhooks/" + EscapeSegment(webhookId, nameof(webhookId))),
            cancellationToken);
    }

    /// <summary>
    /// Updates a webhook subscription.
    /// </summary>
    /// <param name="realm">The realm name.</param>
    /// <param name="webhookId">The webhook identifier.</param>
    /// <param name="subscription">The replacement webhook values.</param>
    /// <param name="cancellationToken">A token that cancels the operation.</param>
    /// <returns>A task representing the operation.</returns>
    public Task UpdateWebhookAsync(
        string realm,
        string webhookId,
        WebhookSubscription subscription,
        CancellationToken cancellationToken = default)
    {
        if (subscription is null)
        {
            throw new ArgumentNullException(nameof(subscription));
        }

        return SendJsonWithoutResultAsync(
            HttpMethod.Put,
            RealmPath(realm, "webhooks/" + EscapeSegment(webhookId, nameof(webhookId))),
            subscription,
            cancellationToken);
    }

    /// <summary>
    /// Deletes a webhook subscription.
    /// </summary>
    /// <param name="realm">The realm name.</param>
    /// <param name="webhookId">The webhook identifier.</param>
    /// <param name="cancellationToken">A token that cancels the operation.</param>
    /// <returns>A task representing the operation.</returns>
    public Task DeleteWebhookAsync(
        string realm,
        string webhookId,
        CancellationToken cancellationToken = default)
    {
        return SendWithoutResultAsync(
            HttpMethod.Delete,
            RealmPath(realm, "webhooks/" + EscapeSegment(webhookId, nameof(webhookId))),
            cancellationToken);
    }

    /// <summary>
    /// Gets the secret credential for a webhook subscription.
    /// </summary>
    /// <param name="realm">The realm name.</param>
    /// <param name="webhookId">The webhook identifier.</param>
    /// <param name="cancellationToken">A token that cancels the operation.</param>
    /// <returns>The webhook secret credential.</returns>
    public Task<WebhookCredential> GetWebhookSecretAsync(
        string realm,
        string webhookId,
        CancellationToken cancellationToken = default)
    {
        return GetAsync<WebhookCredential>(
            RealmPath(realm, "webhooks/" + EscapeSegment(webhookId, nameof(webhookId)) + "/secret"),
            cancellationToken);
    }

    /// <summary>
    /// Lists delivery attempts for a webhook subscription.
    /// </summary>
    /// <param name="realm">The realm name.</param>
    /// <param name="webhookId">The webhook identifier.</param>
    /// <param name="pagination">Optional pagination parameters.</param>
    /// <param name="cancellationToken">A token that cancels the operation.</param>
    /// <returns>Brief delivery attempt representations.</returns>
    public Task<IReadOnlyList<WebhookSendSummary>> GetWebhookSendsAsync(
        string realm,
        string webhookId,
        PaginationOptions? pagination = null,
        CancellationToken cancellationToken = default)
    {
        string path =
            RealmPath(realm, "webhooks/" + EscapeSegment(webhookId, nameof(webhookId)) + "/sends") +
            BuildPaginationQuery(pagination);
        return GetListAsync<WebhookSendSummary>(path, cancellationToken);
    }

    /// <summary>
    /// Gets one delivery attempt, including its raw payload.
    /// </summary>
    /// <param name="realm">The realm name.</param>
    /// <param name="webhookId">The webhook identifier.</param>
    /// <param name="sendId">The delivery attempt identifier.</param>
    /// <param name="cancellationToken">A token that cancels the operation.</param>
    /// <returns>The detailed delivery attempt.</returns>
    public Task<WebhookSendDetail> GetWebhookSendAsync(
        string realm,
        string webhookId,
        string sendId,
        CancellationToken cancellationToken = default)
    {
        string path = "webhooks/" + EscapeSegment(webhookId, nameof(webhookId)) +
                      "/sends/" + EscapeSegment(sendId, nameof(sendId));
        return GetAsync<WebhookSendDetail>(RealmPath(realm, path), cancellationToken);
    }

    /// <summary>
    /// Requests redelivery of a stored webhook attempt.
    /// </summary>
    /// <param name="realm">The realm name.</param>
    /// <param name="webhookId">The webhook identifier.</param>
    /// <param name="sendId">The delivery attempt identifier.</param>
    /// <param name="cancellationToken">A token that cancels the operation.</param>
    /// <returns>A task representing the accepted resend request.</returns>
    public Task ResendWebhookAsync(
        string realm,
        string webhookId,
        string sendId,
        CancellationToken cancellationToken = default)
    {
        string path = "webhooks/" + EscapeSegment(webhookId, nameof(webhookId)) +
                      "/sends/" + EscapeSegment(sendId, nameof(sendId)) + "/resend";
        return SendWithoutResultAsync(HttpMethod.Post, RealmPath(realm, path), cancellationToken);
    }

    /// <summary>
    /// Gets the stored normalized payload for a native Keycloak source event.
    /// </summary>
    /// <param name="realm">The realm name.</param>
    /// <param name="source">The native event source.</param>
    /// <param name="sourceEventId">The native Keycloak event identifier.</param>
    /// <param name="cancellationToken">A token that cancels the operation.</param>
    /// <returns>The normalized event payload.</returns>
    public Task<WebhookEventPayload> GetPayloadBySourceEventAsync(
        string realm,
        KeycloakEventSource source,
        string sourceEventId,
        CancellationToken cancellationToken = default)
    {
        string path = "webhooks/payload/" + SourceSegment(source) + "/" +
                      EscapeSegment(sourceEventId, nameof(sourceEventId));
        return GetAsync<WebhookEventPayload>(RealmPath(realm, path), cancellationToken);
    }

    /// <summary>
    /// Lists all webhook delivery attempts triggered by a native Keycloak source event.
    /// </summary>
    /// <param name="realm">The realm name.</param>
    /// <param name="source">The native event source.</param>
    /// <param name="sourceEventId">The native Keycloak event identifier.</param>
    /// <param name="cancellationToken">A token that cancels the operation.</param>
    /// <returns>Brief delivery attempt representations.</returns>
    public Task<IReadOnlyList<WebhookSendSummary>> GetWebhookSendsBySourceEventAsync(
        string realm,
        KeycloakEventSource source,
        string sourceEventId,
        CancellationToken cancellationToken = default)
    {
        string path = "webhooks/sends/" + SourceSegment(source) + "/" +
                      EscapeSegment(sourceEventId, nameof(sourceEventId));
        return GetListAsync<WebhookSendSummary>(RealmPath(realm, path), cancellationToken);
    }

    /// <summary>
    /// Publishes a custom event to matching webhook subscriptions.
    /// </summary>
    /// <param name="realm">The realm name.</param>
    /// <param name="customEvent">The custom event to publish.</param>
    /// <param name="cancellationToken">A token that cancels the operation.</param>
    /// <returns>A task representing the accepted publication request.</returns>
    public Task PublishCustomEventAsync(
        string realm,
        CustomWebhookEvent customEvent,
        CancellationToken cancellationToken = default)
    {
        if (customEvent is null)
        {
            throw new ArgumentNullException(nameof(customEvent));
        }

        return SendJsonWithoutResultAsync(
            HttpMethod.Post,
            RealmPath(realm, "events"),
            customEvent,
            cancellationToken);
    }

    private async Task<T> GetAsync<T>(string path, CancellationToken cancellationToken)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, BuildUri(path));
        using HttpResponseMessage response = await _httpClient
            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
            .ConfigureAwait(false);
        string body = await ReadSuccessfulBodyAsync(response, cancellationToken).ConfigureAwait(false);
        T? result = JsonSerializer.Deserialize<T>(body, _serializerOptions);
        if (result is null)
        {
            throw new JsonException("The Keycloak webhook API returned an empty JSON value.");
        }

        return result;
    }

    private async Task<IReadOnlyList<T>> GetListAsync<T>(string path, CancellationToken cancellationToken)
    {
        List<T> result = await GetAsync<List<T>>(path, cancellationToken).ConfigureAwait(false);
        return result;
    }

    private async Task SendJsonWithoutResultAsync<T>(
        HttpMethod method,
        string path,
        T value,
        CancellationToken cancellationToken)
    {
        using HttpRequestMessage request = CreateJsonRequest(method, path, value);
        using HttpResponseMessage response = await _httpClient
            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
            .ConfigureAwait(false);
        await ThrowIfNotSuccessfulAsync(response, cancellationToken).ConfigureAwait(false);
    }

    private async Task SendWithoutResultAsync(
        HttpMethod method,
        string path,
        CancellationToken cancellationToken)
    {
        using HttpRequestMessage request = new(method, BuildUri(path));
        using HttpResponseMessage response = await _httpClient
            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
            .ConfigureAwait(false);
        await ThrowIfNotSuccessfulAsync(response, cancellationToken).ConfigureAwait(false);
    }

    private HttpRequestMessage CreateJsonRequest<T>(HttpMethod method, string path, T value)
    {
        string json = JsonSerializer.Serialize(value, _serializerOptions);
        return new HttpRequestMessage(method, BuildUri(path))
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
    }

    private async Task<string> ReadSuccessfulBodyAsync(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        string body = await ReadBodyAsync(response, cancellationToken).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw CreateApiException(response, body);
        }

        return body;
    }

    private async Task ThrowIfNotSuccessfulAsync(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        if (response.IsSuccessStatusCode)
        {
            return;
        }

        string body = await ReadBodyAsync(response, cancellationToken).ConfigureAwait(false);
        throw CreateApiException(response, body);
    }

    private static async Task<string> ReadBodyAsync(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
#if NET8_0_OR_GREATER
        return await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
#else
        cancellationToken.ThrowIfCancellationRequested();
        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
#endif
    }

    private static KeycloakWebhooksApiException CreateApiException(
        HttpResponseMessage response,
        string responseBody)
    {
        Dictionary<string, IEnumerable<string>> headers =
            new(StringComparer.OrdinalIgnoreCase);
        AddHeaders(headers, response.Headers);
        AddHeaders(headers, response.Content.Headers);

        string message = string.Format(
            CultureInfo.InvariantCulture,
            "Keycloak webhook API returned HTTP {0} ({1}).",
            (int)response.StatusCode,
            response.ReasonPhrase ?? "Unknown");

        return new KeycloakWebhooksApiException(
            message,
            response.StatusCode,
            response.ReasonPhrase,
            responseBody,
            headers);
    }

    private static void AddHeaders(
        IDictionary<string, IEnumerable<string>> destination,
        HttpHeaders source)
    {
        foreach (KeyValuePair<string, IEnumerable<string>> header in source)
        {
            destination[header.Key] = header.Value;
        }
    }

    private Uri BuildUri(string relativePath)
    {
        Uri? baseAddress = _httpClient.BaseAddress;
        if (baseAddress is null || !baseAddress.IsAbsoluteUri)
        {
            throw new InvalidOperationException(
                "The injected HttpClient must have an absolute BaseAddress.");
        }

        int queryIndex = relativePath.IndexOf('?');
        string path = queryIndex >= 0 ? relativePath.Substring(0, queryIndex) : relativePath;
        string query = queryIndex >= 0 ? relativePath.Substring(queryIndex + 1) : string.Empty;

        UriBuilder builder = new(baseAddress)
        {
            Path = baseAddress.AbsolutePath.TrimEnd('/') + "/" + path.TrimStart('/'),
            Query = query,
            Fragment = string.Empty
        };
        return builder.Uri;
    }

    private static string RealmPath(string realm, string suffix)
    {
        return "realms/" + EscapeSegment(realm, nameof(realm)) + "/" + suffix;
    }

    private static string EscapeSegment(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("The value cannot be null, empty, or whitespace.", parameterName);
        }

        return Uri.EscapeDataString(value);
    }

    private static string SourceSegment(KeycloakEventSource source)
    {
        switch (source)
        {
            case KeycloakEventSource.Admin:
                return "admin";
            case KeycloakEventSource.User:
                return "user";
            default:
                throw new ArgumentOutOfRangeException(nameof(source), source, "Unknown Keycloak event source.");
        }
    }

    private static string BuildPaginationQuery(PaginationOptions? pagination)
    {
        if (pagination is null || (pagination.First is null && pagination.Max is null))
        {
            return string.Empty;
        }

        if (pagination.First < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pagination), "First cannot be negative.");
        }

        if (pagination.Max <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pagination), "Max must be greater than zero.");
        }

        List<string> parameters = new();
        if (pagination.First.HasValue)
        {
            parameters.Add("first=" + pagination.First.Value.ToString(CultureInfo.InvariantCulture));
        }

        if (pagination.Max.HasValue)
        {
            parameters.Add("max=" + pagination.Max.Value.ToString(CultureInfo.InvariantCulture));
        }

        return "?" + string.Join("&", parameters);
    }
}