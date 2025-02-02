# Sidio.Sitemap.Blazor
Sidio.Sitemap.Blazor is a lightweight .NET library for generating sitemaps in Blazor server applications.

[![NuGet Version](https://img.shields.io/nuget/v/Sidio.Sitemap.Blazor)](https://www.nuget.org/packages/Sidio.Sitemap.Blazor/)

# Versions

|            | [Sidio.Sitemap.Core](https://github.com/marthijn/Sidio.Sitemap.Core)| [Sidio.Sitemap.AspNetCore](https://github.com/marthijn/Sidio.Sitemap.AspNetCore)                                                                                                                                                               | [Sidio.Sitemap.Blazor](https://github.com/marthijn/Sidio.Sitemap.Blazor)                                                                                                                                                           |
|------------|---------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| *NuGet*    | [![NuGet Version](https://img.shields.io/nuget/v/Sidio.Sitemap.Core)](https://www.nuget.org/packages/Sidio.Sitemap.Core/) | [![NuGet Version](https://img.shields.io/nuget/v/Sidio.Sitemap.AspNetCore)](https://www.nuget.org/packages/Sidio.Sitemap.AspNetCore/)                                                      | [![NuGet Version](https://img.shields.io/nuget/v/Sidio.Sitemap.Blazor)](https://www.nuget.org/packages/Sidio.Sitemap.Blazor/)                                                      |
| *Build*    | [![build](https://github.com/marthijn/Sidio.Sitemap.Core/actions/workflows/build.yml/badge.svg)](https://github.com/marthijn/Sidio.Sitemap.Core/actions/workflows/build.yml)| [![build](https://github.com/marthijn/Sidio.Sitemap.AspNetCore/actions/workflows/build.yml/badge.svg)](https://github.com/marthijn/Sidio.Sitemap.AspNetCore/actions/workflows/build.yml)   | [![build](https://github.com/marthijn/Sidio.Sitemap.Blazor/actions/workflows/build.yml/badge.svg)](https://github.com/marthijn/Sidio.Sitemap.Blazor/actions/workflows/build.yml)   |
| *Coverage* | [![Coverage Status](https://coveralls.io/repos/github/marthijn/Sidio.Sitemap.Core/badge.svg?branch=main)](https://coveralls.io/github/marthijn/Sidio.Sitemap.Core?branch=main)| [![Coverage Status](https://coveralls.io/repos/github/marthijn/Sidio.Sitemap.AspNetCore/badge.svg?branch=main)](https://coveralls.io/github/marthijn/Sidio.Sitemap.AspNetCore?branch=main) | [![Coverage Status](https://coveralls.io/repos/github/marthijn/Sidio.Sitemap.Blazor/badge.svg?branch=main)](https://coveralls.io/github/marthijn/Sidio.Sitemap.Blazor?branch=main) |
| *Requirements*|.NET Standard, .NET 8+, | .NET 8+, AspNetCore|.NET 8+, AspNetCore, Blazor server|

# Installation

Add [the package](https://www.nuget.org/packages/Sidio.Sitemap.Blazor/) to your project.

# Usage
## Sitemap

Register services:
```csharp
builder.Services
    .AddHttpContextAccessor()
    .AddDefaultSitemapServices<HttpContextBaseUrlProvider>();
```

Register the middleware. Make sure to choose the correct namespace.
```csharp
using Sidio.Sitemap.Blazor;

app.UseSitemap();
```

Add the following attribute to your components (pages) to include them in the sitemap:
```cshtml
@* default *@
@attribute [Sitemap]

@* override route url *@
@attribute [Sitemap("/custom-url")]

@* add change frequency, priority and last modified date *@
@attribute [Sitemap(ChangeFrequency.Daily, 0.5, "2024-01-01")]
```

The sitemap is accessible at `[domain]/sitemap.xml`.

# FAQ

* Exception: `Unable to resolve service for type 'Microsoft.AspNetCore.Http.IHttpContextAccessor' while attempting to activate 'Sidio.Sitemap.AspNetCore.HttpContextBaseUrlProvider'.`
    * Solution: call `services.AddHttpContextAccessor();` to register the `IHttpContextAccessor`.

# See also
* [Sidio.Sitemap.Core package](https://github.com/marthijn/Sidio.Sitemap.Core)