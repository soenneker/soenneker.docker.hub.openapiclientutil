[![](https://img.shields.io/nuget/v/soenneker.docker.hub.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.docker.hub.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.docker.hub.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.docker.hub.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.docker.hub.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.docker.hub.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.docker.hub.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.docker.hub.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Docker.Hub.OpenApiClientUtil

Provides a dependency-injection-friendly, cached instance of the generated Docker Hub API client.

## Installation

```bash
dotnet add package Soenneker.Docker.Hub.OpenApiClientUtil
```

## Configuration

```json
{
  "DockerHub": {
    "AccessToken": "your-access-token"
  }
}
```

Keep the token in a secret provider rather than source control.

## Registration

```csharp
using Soenneker.Docker.Hub.OpenApiClientUtil.Registrars;

services.AddDockerHubOpenApiClientUtilAsScoped();
```

The scoped registration creates one cached generated client per dependency-injection scope while retaining the underlying Docker Hub HTTP client provider as a singleton. Disposing the util at the end of a scope does not destroy that shared transport.

Use `AddDockerHubOpenApiClientUtilAsSingleton()` when the generated-client holder should also live for the application lifetime.

## Usage

```csharp
using Soenneker.Docker.Hub.OpenApiClient;
using Soenneker.Docker.Hub.OpenApiClient.Models;
using Soenneker.Docker.Hub.OpenApiClientUtil.Abstract;

public sealed class AccessTokenReader(IDockerHubOpenApiClientUtil clientUtil)
{
    public async Task<IReadOnlyList<GetAccessTokensResponseResultsItem>> GetPage(
        int page,
        CancellationToken cancellationToken)
    {
        DockerHubOpenApiClient client = await clientUtil.Get(cancellationToken);

        GetAccessTokensResponse? response = await client.V2.AccessTokens.GetAsync(
            request =>
            {
                request.QueryParameters.Page = page;
                request.QueryParameters.PageSize = 25;
            },
            cancellationToken);

        return response?.Results ?? [];
    }
}
```

`Get` returns the same generated client for the lifetime of the util. Pass cancellation tokens to both `Get` and API operations. Pagination remains explicit; use the response’s `Next`, `Previous`, and `Count` values to drive subsequent requests.

Documented non-success responses are surfaced through generated Kiota error models deriving from `ApiException`. The exact error type varies by endpoint, so translate failures at the application boundary rather than assuming one universal Docker Hub error shape.

Optional transport overrides use the `Hub:ClientBaseUrl`, `Hub:AuthHeaderName`, and `Hub:AuthHeaderValueTemplate` keys. Treat them as trusted configuration because they determine where and how the access token is sent.
