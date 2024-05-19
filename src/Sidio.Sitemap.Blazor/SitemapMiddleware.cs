using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sidio.Sitemap.Core;
using Sidio.Sitemap.Core.Services;

namespace Sidio.Sitemap.Blazor;

internal sealed class SitemapMiddleware
{
    private const string ContentType = "application/xml";

    private static readonly PathString SitemapPath = new("/sitemap.xml");

    private readonly RequestDelegate _next;

    public SitemapMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == SitemapPath)
        {
            var sitemapService = context.RequestServices.GetRequiredService<ISitemapService>();
            var componentBaseProvider = context.RequestServices.GetService<IComponentBaseProvider>() ??
                                        new ComponentBaseProvider();

            var sitemap = CreateSitemap(componentBaseProvider);
            var xml = await sitemapService.SerializeAsync(sitemap);

            context.Response.ContentType = ContentType;
            await context.Response.WriteAsync(xml, Encoding.UTF8);

            return;
        }

        await _next(context);
    }

    private static Sidio.Sitemap.Core.Sitemap CreateSitemap(IComponentBaseProvider componentBaseProvider)
    {
        var types = componentBaseProvider.GetComponentBaseTypes();
        var nodes = new List<SitemapNode>();

        foreach (var type in types)
        {
            var sitemapAttribute = type.GetCustomAttribute<SitemapAttribute>();
            var routeAttribute = type.GetCustomAttribute<RouteAttribute>();
            if (sitemapAttribute != null && routeAttribute != null)
            {
                nodes.Add(CreateNode(sitemapAttribute, routeAttribute));
            }
        }

        return new Sidio.Sitemap.Core.Sitemap(nodes);
    }

    private static SitemapNode CreateNode(SitemapAttribute sitemapAttribute, RouteAttribute routeAttribute) => new(
        sitemapAttribute.Url ?? routeAttribute.Template,
        sitemapAttribute.LastModified,
        sitemapAttribute.ChangeFrequency,
        sitemapAttribute.Priority);
}