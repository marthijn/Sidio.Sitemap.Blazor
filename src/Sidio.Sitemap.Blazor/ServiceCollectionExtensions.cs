using Microsoft.Extensions.DependencyInjection;
using Sidio.Sitemap.AspNetCore.Middleware;

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
        // this function calls the AspNetCore version to avoid namespace conflicts in Program.cs files.
        Sidio.Sitemap.AspNetCore.Middleware.ServiceCollectionExtensions.AddCustomSitemapNodeProvider<T>(serviceCollection, serviceLifetime);
        return serviceCollection;
    }
}