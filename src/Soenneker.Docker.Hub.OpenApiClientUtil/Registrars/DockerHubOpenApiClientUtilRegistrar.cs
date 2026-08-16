using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Docker.Hub.HttpClients.Registrars;
using Soenneker.Docker.Hub.OpenApiClientUtil.Abstract;

namespace Soenneker.Docker.Hub.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class DockerHubOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="DockerHubOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddDockerHubOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddDockerHubOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IDockerHubOpenApiClientUtil, DockerHubOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="DockerHubOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddDockerHubOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddDockerHubOpenApiHttpClientAsSingleton()
                .TryAddScoped<IDockerHubOpenApiClientUtil, DockerHubOpenApiClientUtil>();

        return services;
    }
}
