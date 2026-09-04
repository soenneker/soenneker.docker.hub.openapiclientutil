using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Docker.Hub.HttpClients.Abstract;
using Soenneker.Docker.Hub.OpenApiClientUtil.Abstract;
using Soenneker.Docker.Hub.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Docker.Hub.OpenApiClientUtil;

/// <inheritdoc cref="IDockerHubOpenApiClientUtil" />
public sealed class DockerHubOpenApiClientUtil : IDockerHubOpenApiClientUtil
{
    private readonly AsyncSingleton<DockerHubOpenApiClient> _client;

    public DockerHubOpenApiClientUtil(IDockerHubOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<DockerHubOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new DockerHubOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<DockerHubOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
