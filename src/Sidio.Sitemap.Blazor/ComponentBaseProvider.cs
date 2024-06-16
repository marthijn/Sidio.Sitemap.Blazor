using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace Sidio.Sitemap.Blazor;

[ExcludeFromCodeCoverage]
internal sealed class ComponentBaseProvider : IComponentBaseProvider
{
    public IReadOnlyCollection<Type> GetComponentBaseTypes()
    {
        var entryAssembly = Assembly.GetEntryAssembly() ?? throw new InvalidOperationException("Entry assembly not found.");
        return entryAssembly.GetTypes().Where(x => typeof(ComponentBase).IsAssignableFrom(x)).ToList();
    }
}