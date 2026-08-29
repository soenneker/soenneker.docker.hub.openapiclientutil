using Soenneker.Docker.Hub.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Soenneker.Docker.Hub.OpenApiClientUtil.Abstract;
/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IDockerHubOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured docker Hub OpenAPI Client used by the Docker Hub OpenAPI Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested docker Hub OpenAPI Client.</returns>
    ValueTask<DockerHubOpenApiClient> Get(CancellationToken cancellationToken = default);
}
