using Microsoft.Extensions.DependencyInjection;
using Sidio.Sitemap.Core;

namespace Sidio.Sitemap.Blazor.Tests;

public sealed class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddCustomSitemapNodeProvider_ShouldRegisterServiceWithScopedLifetime_ByDefault()
    {
        // arrange
        var services = new ServiceCollection();

        // act
        services.AddCustomSitemapNodeProvider<TestCustomSitemapNodeProvider>();

        // assert
        var serviceDescriptor = services.FirstOrDefault(s => s.ServiceType == typeof(ICustomSitemapNodeProvider));
        serviceDescriptor.Should().NotBeNull();
        serviceDescriptor.Lifetime.Should().Be(ServiceLifetime.Scoped);
        serviceDescriptor.ImplementationType.Should().Be(typeof(TestCustomSitemapNodeProvider));
    }

    [Theory]
    [InlineData(ServiceLifetime.Singleton)]
    [InlineData(ServiceLifetime.Scoped)]
    [InlineData(ServiceLifetime.Transient)]
    public void AddCustomSitemapNodeProvider_ShouldRegisterServiceWithSpecifiedLifetime(ServiceLifetime serviceLifetime)
    {
        // arrange
        var services = new ServiceCollection();

        // act
        services.AddCustomSitemapNodeProvider<TestCustomSitemapNodeProvider>(serviceLifetime);

        // assert
        var serviceDescriptor = services.FirstOrDefault(s => s.ServiceType == typeof(ICustomSitemapNodeProvider));
        serviceDescriptor.Should().NotBeNull();
        serviceDescriptor.Lifetime.Should().Be(serviceLifetime);
    }

    [Fact]
    public void AddCustomSitemapNodeProvider_ShouldReturnServiceCollection()
    {
        // arrange
        var services = new ServiceCollection();

        // act
        var result = services.AddCustomSitemapNodeProvider<TestCustomSitemapNodeProvider>();

        // assert
        result.Should().BeSameAs(services);
    }

    [Fact]
    public void AddCustomSitemapNodeProvider_ShouldAllowResolvingService()
    {
        // arrange
        var services = new ServiceCollection();
        services.AddCustomSitemapNodeProvider<TestCustomSitemapNodeProvider>();
        var serviceProvider = services.BuildServiceProvider();

        // act
        var provider = serviceProvider.GetService<ICustomSitemapNodeProvider>();

        // assert
        provider.Should().NotBeNull();
        provider.Should().BeOfType<TestCustomSitemapNodeProvider>();
    }

    private sealed class TestCustomSitemapNodeProvider : ICustomSitemapNodeProvider
    {
        public IEnumerable<SitemapNode> GetNodes()
        {
            yield return new SitemapNode("/test-page");
        }
    }
}