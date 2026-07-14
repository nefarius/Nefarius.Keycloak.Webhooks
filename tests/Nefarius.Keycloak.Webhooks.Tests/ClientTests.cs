using System.Net;
using System.Text;

using Nefarius.Keycloak.Webhooks.Client;
using Nefarius.Keycloak.Webhooks.Client.Models;

namespace Nefarius.Keycloak.Webhooks.Tests;

public sealed class ClientTests
{
    [Fact]
    public async Task ClientCoversEveryUpstreamRouteAndPreservesBasePath()
    {
        RoutingHandler handler = new();
        using HttpClient http = new(handler)
        {
            BaseAddress = new Uri("https://id.example/auth/")
        };
        KeycloakWebhooksClient client = new(http);
        WebhookSubscription webhook = new()
        {
            Enabled = true,
            Url = "https://receiver.example/hook",
            AuthType = WebhookAuthenticationTypes.Hmac,
            Secret = "secret",
            EventTypes = new HashSet<string> { "*" }
        };

        await client.GetWebhooksAsync("realm name", new PaginationOptions { First = 1, Max = 10 });
        Assert.Equal(2, await client.CountWebhooksAsync("realm name", "needle"));
        await client.CreateWebhookAsync("realm name", webhook);
        await client.GetWebhookAsync("realm name", "hook/id");
        await client.UpdateWebhookAsync("realm name", "hook/id", webhook);
        await client.DeleteWebhookAsync("realm name", "hook/id");
        await client.GetWebhookSecretAsync("realm name", "hook/id");
        await client.GetWebhookSendsAsync("realm name", "hook/id", new PaginationOptions { Max = 5 });
        await client.GetWebhookSendAsync("realm name", "hook/id", "send/id");
        await client.ResendWebhookAsync("realm name", "hook/id", "send/id");
        await client.GetPayloadBySourceEventAsync("realm name", KeycloakEventSource.Admin, "event/id");
        await client.GetWebhookSendsBySourceEventAsync("realm name", KeycloakEventSource.User, "event/id");
        await client.PublishCustomEventAsync(
            "realm name",
            new CustomWebhookEvent
            {
                Type = "billing.invoice-issued",
                Details = new Dictionary<string, string> { ["id"] = "42" }
            });

        Assert.Equal(13, handler.Requests.Count);
        Assert.All(handler.Requests, request => Assert.StartsWith("/auth/realms/realm%20name/", request.Uri.PathAndQuery));
        Assert.Contains(handler.Requests, request =>
            request.Method == HttpMethod.Get &&
            request.Uri.PathAndQuery.EndsWith("/webhooks?first=1&max=10", StringComparison.Ordinal));
        Assert.Contains(handler.Requests, request =>
            request.Method == HttpMethod.Post &&
            request.Uri.AbsolutePath.EndsWith("/events", StringComparison.Ordinal) &&
            request.Body!.Contains("\"type\":\"billing.invoice-issued\"", StringComparison.Ordinal));
        Assert.Contains(handler.Requests, request =>
            request.Uri.AbsolutePath.Contains("hook%2Fid/sends/send%2Fid/resend", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task ClientPreservesNonSuccessResponseDetails()
    {
        using HttpClient http = new(new ErrorHandler())
        {
            BaseAddress = new Uri("https://id.example/")
        };
        KeycloakWebhooksClient client = new(http);

        KeycloakWebhooksApiException exception = await Assert.ThrowsAsync<KeycloakWebhooksApiException>(
            () => client.PublishCustomEventAsync(
                "acme",
                new CustomWebhookEvent { Type = "access.LOGIN" }));

        Assert.Equal(HttpStatusCode.Conflict, exception.StatusCode);
        Assert.Equal("Reserved event type.", exception.ResponseBody);
        Assert.Equal("test", exception.ResponseHeaders["X-Test"].Single());
    }

    private sealed class RoutingHandler : HttpMessageHandler
    {
        public List<RecordedRequest> Requests { get; } = new();

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            string? body = request.Content is null
                ? null
                : await request.Content.ReadAsStringAsync(cancellationToken);
            Requests.Add(new RecordedRequest(request.Method, request.RequestUri!, body));
            string path = request.RequestUri!.AbsolutePath;
            HttpStatusCode status = request.Method == HttpMethod.Post
                ? HttpStatusCode.Accepted
                : request.Method is { Method: "PUT" } or { Method: "DELETE" }
                    ? HttpStatusCode.NoContent
                    : HttpStatusCode.OK;
            string json = path.EndsWith("/count", StringComparison.Ordinal) ? "2" :
                path.EndsWith("/secret", StringComparison.Ordinal) ? """{"type":"secret","value":"x"}""" :
                path.Contains("/payload/", StringComparison.Ordinal) ? "{}" :
                path.Contains("/webhooks/sends/", StringComparison.Ordinal) ? "[]" :
                path.EndsWith("/sends", StringComparison.Ordinal) ? "[]" :
                path.Contains("/sends/", StringComparison.Ordinal) ? "{}" :
                path.EndsWith("/webhooks", StringComparison.Ordinal) && request.Method == HttpMethod.Get ? "[]" :
                "{}";
            HttpResponseMessage response = new(status)
            {
                Content = status == HttpStatusCode.NoContent
                    ? null
                    : new StringContent(json, Encoding.UTF8, "application/json")
            };
            if (request.Method == HttpMethod.Post && path.EndsWith("/webhooks", StringComparison.Ordinal))
            {
                response.StatusCode = HttpStatusCode.Created;
                response.Headers.Location = new Uri("/auth/realms/realm%20name/webhooks/new", UriKind.Relative);
            }

            return response;
        }
    }

    private sealed class ErrorHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new(HttpStatusCode.Conflict)
            {
                Content = new StringContent("Reserved event type.")
            };
            response.Headers.Add("X-Test", "test");
            return Task.FromResult(response);
        }
    }

    private sealed record RecordedRequest(HttpMethod Method, Uri Uri, string? Body);
}