using System.Globalization;
using Sidio.Sitemap.Core;

namespace Sidio.Sitemap.Blazor.Tests;

public sealed class SitemapAttributeTests
{
    private readonly Fixture _fixture = new();
    
    [Fact]
    public void Constructor_EmptyConstructor_ShouldCreateInstance()
    {
        // act
        var sitemapAttribute = new SitemapAttribute();

        // assert
        sitemapAttribute.Should().NotBeNull();
        sitemapAttribute.Url.Should().BeNull();
    }

    [Fact]
    public void Constructor_GivenUrl_ShouldCreateInstance()
    {
        // arrange
        var url = _fixture.Create<string>();

        // act
        var sitemapAttribute = new SitemapAttribute(url);

        // assert
        sitemapAttribute.Should().NotBeNull();
        sitemapAttribute.Url.Should().Be(url);
    }

    [Fact]
    public void Constructor_GivenChangeFrequency_ShouldCreateInstance()
    {
        // arrange
        var changeFrequency = _fixture.Create<ChangeFrequency>();

        // act
        var sitemapAttribute = new SitemapAttribute(changeFrequency);

        // assert
        sitemapAttribute.Should().NotBeNull();
        sitemapAttribute.ChangeFrequency.Should().Be(changeFrequency);
    }

    [Fact]
    public void Constructor_GivenChangeFrequencyAndPriority_ShouldCreateInstance()
    {
        // arrange
        var changeFrequency = _fixture.Create<ChangeFrequency>();
        var priority = _fixture.Create<double>();

        // act
        var sitemapAttribute = new SitemapAttribute(changeFrequency, priority);

        // assert
        sitemapAttribute.Should().NotBeNull();
        sitemapAttribute.ChangeFrequency.Should().Be(changeFrequency);
        sitemapAttribute.Priority.Should().Be((decimal)priority);
    }

    [Fact]
    public void Constructor_GivenChangeFrequencyAndPriorityAndLastModified_ShouldCreateInstance()
    {
        // arrange
        var changeFrequency = _fixture.Create<ChangeFrequency>();
        var priority = _fixture.Create<double>();
        var lastModified = _fixture.Create<DateTime>().ToString(CultureInfo.CurrentCulture);

        // act
        var sitemapAttribute = new SitemapAttribute(changeFrequency, priority, lastModified);

        // assert
        sitemapAttribute.Should().NotBeNull();
        sitemapAttribute.ChangeFrequency.Should().Be(changeFrequency);
        sitemapAttribute.Priority.Should().Be((decimal)priority);
        sitemapAttribute.LastModified.Should().Be(DateTime.Parse(lastModified));
    }

    [Fact]
    public void Constructor_GivenChangeFrequencyAndPriorityAndLastModifiedAndUrl_ShouldCreateInstance()
    {
        // arrange
        var changeFrequency = _fixture.Create<ChangeFrequency>();
        var priority = _fixture.Create<double>();
        var lastModified = _fixture.Create<DateTime>().ToString(CultureInfo.CurrentCulture);
        var url = _fixture.Create<string>();

        // act
        var sitemapAttribute = new SitemapAttribute(url, changeFrequency, priority, lastModified);

        // assert
        sitemapAttribute.Should().NotBeNull();
        sitemapAttribute.ChangeFrequency.Should().Be(changeFrequency);
        sitemapAttribute.Priority.Should().Be((decimal)priority);
        sitemapAttribute.LastModified.Should().Be(DateTime.Parse(lastModified));
        sitemapAttribute.Url.Should().Be(url);
    }
}