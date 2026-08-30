using Soenneker.Docker.Hub.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Soenneker.Docker.Hub.OpenApiClientUtil.Abstract;
/// <summary>
/// Provides access to a cached, configured Docker Hub OpenAPI client.
/// </summary>
public interface IDockerHubOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured Docker Hub OpenAPI client for this utility's lifetime.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the cached Docker Hub OpenAPI client.</returns>
    ValueTask<DockerHubOpenApiClient> Get(CancellationToken cancellationToken = default);
}
