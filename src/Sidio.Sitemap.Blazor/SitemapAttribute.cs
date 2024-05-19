using Sidio.Sitemap.Core;

namespace Sidio.Sitemap.Blazor;

/// <summary>
/// The sitemap attribute.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class SitemapAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SitemapAttribute"/> class.
    /// </summary>
    public SitemapAttribute()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SitemapAttribute"/> class.
    /// </summary>
    /// <param name="url"></param>
    public SitemapAttribute(string url)
        : this(url, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SitemapAttribute"/> class.
    /// </summary>
    /// <param name="url"></param>
    /// <param name="changeFrequency"></param>
    /// <param name="priority"></param>
    /// <param name="lastModified"></param>
    public SitemapAttribute(string?  url = null, ChangeFrequency? changeFrequency = null, decimal? priority = null, DateTime? lastModified = null)
    {
        Url = url;
        ChangeFrequency = changeFrequency;
        Priority = priority;
        LastModified = lastModified;
    }

    /// <summary>
    /// Gets the URL.
    /// </summary>
    public string? Url { get; }

    /// <summary>
    /// Gets the change frequency.
    /// </summary>
    public ChangeFrequency? ChangeFrequency { get; }

    /// <summary>
    /// Gets the priority.
    /// </summary>
    public decimal? Priority { get; }

    /// <summary>
    /// Gets the last modified date.
    /// </summary>
    public DateTime? LastModified { get; }
}