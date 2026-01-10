using Sidio.Sitemap.Core;

namespace Sidio.Sitemap.Blazor.Examples.WebApp;

public sealed class CustomSitemapNodeProvider : ICustomSitemapNodeProvider
{
    public IEnumerable<SitemapNode> GetNodes()
    {
        yield return new SitemapNode("/custom-page-1");
    }
}