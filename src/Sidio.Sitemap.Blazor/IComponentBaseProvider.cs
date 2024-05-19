namespace Sidio.Sitemap.Blazor;

/// <summary>
/// The component base provider.
/// </summary>
public interface IComponentBaseProvider
{
    /// <summary>
    /// Gets the component base types.
    /// </summary>
    /// <returns>A collection of <see cref="Type"/>.</returns>
    IReadOnlyCollection<Type> GetComponentBaseTypes();
}