using Soenneker.Docker.Hub.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Docker.Hub.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class DockerHubOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IDockerHubOpenApiClientUtil _openapiclientutil;

    public DockerHubOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IDockerHubOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
