[![](https://img.shields.io/nuget/v/soenneker.docker.hub.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.docker.hub.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.docker.hub.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.docker.hub.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.docker.hub.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.docker.hub.openapiclientutil/)

# Soenneker.Docker.Hub.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.Docker.Hub.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.Docker.Hub.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddDockerHubOpenApiClientUtilAsSingleton();
```

Adds `DockerHubOpenApiClientUtil` as a singleton service.

## What you get

- `IDockerHubOpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `DockerHubOpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `DockerHubOpenApiClientUtilRegistrar.AddDockerHubOpenApiClientUtilAsSingleton(services)` | Adds `DockerHubOpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `DockerHubOpenApiClientUtilRegistrar.AddDockerHubOpenApiClientUtilAsScoped(services)` | Adds `DockerHubOpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
