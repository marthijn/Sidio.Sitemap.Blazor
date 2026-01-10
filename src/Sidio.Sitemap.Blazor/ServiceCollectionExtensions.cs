using Microsoft.Extensions.DependencyInjection;

namespace Sidio.Sitemap.Blazor;

/// <summary>
/// The service collection extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds a custom sitemap node provider which will be used to provide additional sitemap nodes.
    /// </summary>
    /// <param name="serviceCollection">The service collection.</param>
    /// <param name="serviceLifetime">The service lifetime.</param>
    /// <typeparam name="T">The implementation of <see cref="IServiceCollection"/>.</typeparam>
    /// <returns>The <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddCustomSitemapNodeProvider<T>(
        this IServiceCollection serviceCollection,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        where T : class, ICustomSitemapNodeProvider
    {
        var serviceDescriptor = new ServiceDescriptor(typeof(ICustomSitemapNodeProvider), typeof(T), serviceLifetime);
        serviceCollection.Add(serviceDescriptor);
        return serviceCollection;
    }
}