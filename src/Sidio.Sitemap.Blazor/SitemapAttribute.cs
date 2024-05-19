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
    /// <param name="url">The URL.</param>
    public SitemapAttribute(string url)
    {
        Url = url;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SitemapAttribute"/> class.
    /// </summary>
    /// <param name="changeFrequency">The change frequency.</param>
    public SitemapAttribute(ChangeFrequency changeFrequency)
    {
        ChangeFrequency = changeFrequency;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SitemapAttribute"/> class.
    /// </summary>
    /// <param name="changeFrequency">The change frequency.</param>
    /// <param name="priority">The priority.</param>
    public SitemapAttribute(ChangeFrequency changeFrequency, double priority)
    {
        ChangeFrequency = changeFrequency;
        Priority = (decimal)priority;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SitemapAttribute"/> class.
    /// </summary>
    /// <param name="changeFrequency">The change frequency.</param>
    /// <param name="priority">The priority.</param>
    /// <param name="lastModified">Last modified date.</param>
    public SitemapAttribute(ChangeFrequency changeFrequency, double priority, string lastModified)
    {
        ChangeFrequency = changeFrequency;
        Priority = (decimal)priority;
        LastModified = DateTime.Parse(lastModified);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SitemapAttribute"/> class.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <param name="changeFrequency">The change frequency.</param>
    /// <param name="priority">The priority.</param>
    /// <param name="lastModified">Last modified date.</param>
    public SitemapAttribute(string  url, ChangeFrequency changeFrequency, double priority, string lastModified)
    {
        Url = url;
        ChangeFrequency = changeFrequency;
        Priority = (decimal)priority;
        LastModified = DateTime.Parse(lastModified);
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