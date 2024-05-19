using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing;

namespace Sidio.Sitemap.Blazor;

[ExcludeFromDescription]
internal sealed class ComponentBaseProvider : IComponentBaseProvider
{
    public IReadOnlyCollection<Type> GetComponentBaseTypes()
    {
        var entryAssembly = Assembly.GetEntryAssembly() ?? throw new InvalidOperationException("Entry assembly not found.");
        return entryAssembly.GetTypes().Where(x => typeof(ComponentBase).IsAssignableFrom(x)).ToList();
    }
}