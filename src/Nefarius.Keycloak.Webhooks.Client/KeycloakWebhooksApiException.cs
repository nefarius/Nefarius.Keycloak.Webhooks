using System.Net;

namespace Nefarius.Keycloak.Webhooks.Client;

/// <summary>
/// Represents a non-success response returned by the Keycloak webhook management API.
/// </summary>
public sealed class KeycloakWebhooksApiException : HttpRequestException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="KeycloakWebhooksApiException"/> class.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="statusCode">The HTTP response status code.</param>
    /// <param name="reasonPhrase">The HTTP response reason phrase.</param>
    /// <param name="responseBody">The response body, if one was returned.</param>
    /// <param name="responseHeaders">The response and content headers.</param>
    public KeycloakWebhooksApiException(
        string message,
        HttpStatusCode statusCode,
        string? reasonPhrase,
        string? responseBody,
        IReadOnlyDictionary<string, IEnumerable<string>> responseHeaders)
        : base(message)
    {
        StatusCode = statusCode;
        ReasonPhrase = reasonPhrase;
        ResponseBody = responseBody;
        ResponseHeaders = responseHeaders;
    }

    /// <summary>
    /// Gets the HTTP response status code.
    /// </summary>
#if NETSTANDARD2_0
    public HttpStatusCode StatusCode { get; }
#else
    public new HttpStatusCode StatusCode { get; }
#endif

    /// <summary>
    /// Gets the HTTP response reason phrase.
    /// </summary>
    public string? ReasonPhrase { get; }

    /// <summary>
    /// Gets the response body, if one was returned.
    /// </summary>
    public string? ResponseBody { get; }

    /// <summary>
    /// Gets the response and content headers.
    /// </summary>
    public IReadOnlyDictionary<string, IEnumerable<string>> ResponseHeaders { get; }
}