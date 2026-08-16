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
    ValueTask<DockerHubOpenApiClient> Get(CancellationToken cancellationToken = default);
}
