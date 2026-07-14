using System.Net;
using System.Security.Cryptography;
using System.Text;

using FastEndpoints;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.TestHost;

using Nefarius.Keycloak.Webhooks.Authentication;
using Nefarius.Keycloak.Webhooks.FastEndpoints;

namespace Nefarius.Keycloak.Webhooks.Tests;

public sealed class FastEndpointTests
{
    [Fact]
    public async Task EndpointRejectsBadSignatureAndAcknowledgesValidPayload()
    {
        const string Body = """{"uid":"delivery","type":"billing.invoice-issued","details":{"id":"42"}}""";
        await using WebApplication app = await CreateApplicationAsync();
        HttpClient client = app.GetTestClient();

        using HttpRequestMessage badRequest = CreateRequest(Body, "invalid");
        using HttpResponseMessage badResponse = await client.SendAsync(badRequest);
        Assert.Equal(HttpStatusCode.Unauthorized, badResponse.StatusCode);

        string signature;
        using (HMACSHA256 hmac = new(Encoding.UTF8.GetBytes("secret")))
        {
            signature = Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(Body))).ToLowerInvariant();
        }

        using HttpRequestMessage validRequest = CreateRequest(Body, signature);
        using HttpResponseMessage validResponse = await client.SendAsync(validRequest);
        Assert.Equal(HttpStatusCode.OK, validResponse.StatusCode);
    }

    [Fact]
    public async Task EndpointRejectsMalformedPayloadWithoutAcknowledgingIt()
    {
        const string Body = "{";
        await using WebApplication app = await CreateApplicationAsync();
        HttpClient client = app.GetTestClient();
        string signature;
        using (HMACSHA256 hmac = new(Encoding.UTF8.GetBytes("secret")))
        {
            signature = Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(Body))).ToLowerInvariant();
        }

        using HttpRequestMessage request = CreateRequest(Body, signature);
        using HttpResponseMessage response = await client.SendAsync(request);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    private static HttpRequestMessage CreateRequest(string body, string signature)
    {
        HttpRequestMessage request = new(HttpMethod.Post, "/api/webhooks/one")
        {
            Content = new StringContent(body, Encoding.UTF8, "application/json")
        };
        request.Headers.Add("X-Keycloak-Signature", signature);
        return request;
    }

    private static async Task<WebApplication> CreateApplicationAsync()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddKeycloakWebhooks(options =>
        {
            options.AuthenticationMode = KeycloakWebhookAuthenticationMode.HmacSha256;
            options.HmacSecret = "secret";
        });
        builder.Services.AddFastEndpoints(options =>
            options.Assemblies = new[] { typeof(KeycloakWebhookEndpoint).Assembly });
        WebApplication app = builder.Build();
        app.UseFastEndpoints();
        await app.StartAsync();
        return app;
    }
}