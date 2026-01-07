using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sidio.Sitemap.AspNetCore.Middleware;
using Sidio.Sitemap.Core;
using Sidio.Sitemap.Core.Services;

namespace Sidio.Sitemap.Blazor.Tests;

public sealed class SitemapMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_WhenRequestPathIsNotSitemapPath_ShouldCallNext()
    {
        // arrange
        var context = new DefaultHttpContext();
        var next = new RequestDelegate(_ => Task.CompletedTask);
        var middleware = new SitemapMiddleware(next);

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task InvokeAsync_WhenRequestPathIsSitemapPath_ShouldReturnSitemapXml()
    {
        // arrange
        var sitemapServiceMock = new Mock<ISitemapService>();
        sitemapServiceMock
            .Setup(x => x.SerializeAsync(It.IsAny<Sidio.Sitemap.Core.Sitemap>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("<sitemap></sitemap>");

        var componentBaseProviderMock = new Mock<IComponentBaseProvider>();
        componentBaseProviderMock.Setup(x => x.GetComponentBaseTypes()).Returns(new List<Type>());

        var services = new ServiceCollection();
        services.AddScoped<ISitemapService>(_ => sitemapServiceMock.Object);
        services.AddScoped<IComponentBaseProvider>(_ => componentBaseProviderMock.Object);

        var context = new DefaultHttpContext
        {
            Request =
            {
                Path = "/sitemap.xml"
            },
            RequestServices = services.BuildServiceProvider()
        };
        var next = new RequestDelegate(_ => Task.CompletedTask);
        var middleware = new SitemapMiddleware(next);

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.ContentType.Should().Be("application/xml");
        context.Response.StatusCode.Should().Be(StatusCodes.Status200OK);
        componentBaseProviderMock.VerifyAll();
        sitemapServiceMock.VerifyAll();
    }

    [Fact]
    public async Task InvokeAsync_WhenRequestPathIsSitemapPathAndWithCustomNodeProvider_ShouldReturnSitemapXml()
    {
        // arrange
        var sitemapServiceMock = new Mock<ISitemapService>();
        sitemapServiceMock
            .Setup(x => x.SerializeAsync(It.IsAny<Sidio.Sitemap.Core.Sitemap>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("<sitemap></sitemap>");

        var componentBaseProviderMock = new Mock<IComponentBaseProvider>();
        componentBaseProviderMock.Setup(x => x.GetComponentBaseTypes()).Returns(new List<Type>());

        var customSitemapNodeProviderMock = new Mock<ICustomSitemapNodeProvider>();
        customSitemapNodeProviderMock.Setup(x => x.GetNodes())
            .Returns(new List<SitemapNode> { new ("/custom") });

        var services = new ServiceCollection();
        services.AddScoped<ISitemapService>(_ => sitemapServiceMock.Object);
        services.AddScoped<IComponentBaseProvider>(_ => componentBaseProviderMock.Object);
        services.AddScoped<ICustomSitemapNodeProvider>(_ => customSitemapNodeProviderMock.Object);

        var context = new DefaultHttpContext
        {
            Request =
            {
                Path = "/sitemap.xml"
            },
            RequestServices = services.BuildServiceProvider()
        };
        var next = new RequestDelegate(_ => Task.CompletedTask);
        var middleware = new SitemapMiddleware(next);

        // act
        await middleware.InvokeAsync(context);

        // assert
        context.Response.ContentType.Should().Be("application/xml");
        context.Response.StatusCode.Should().Be(StatusCodes.Status200OK);
        componentBaseProviderMock.VerifyAll();
        customSitemapNodeProviderMock.VerifyAll();

        sitemapServiceMock
            .Verify(
                x => x.SerializeAsync(
                    It.Is<Sidio.Sitemap.Core.Sitemap>(y => y.Nodes.Any(z => z.Url == "/custom")),
                    It.IsAny<CancellationToken>()),
                Times.Once);
    }
}