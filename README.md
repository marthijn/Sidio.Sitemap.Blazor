# Sidio.Sitemap.Blazor
Sidio.Sitemap.Blazor is a lightweight .NET library for generating sitemaps in Blazor applications.

[![build](https://github.com/marthijn/Sidio.Sitemap.Blazor/actions/workflows/build.yml/badge.svg)](https://github.com/marthijn/Sidio.Sitemap.Blazor/actions/workflows/build.yml)
[![NuGet Version](https://img.shields.io/nuget/v/Sidio.Sitemap.Blazor)](https://www.nuget.org/packages/Sidio.Sitemap.Blazor/)
[![Coverage Status](https://coveralls.io/repos/github/marthijn/Sidio.Sitemap.Blazor/badge.svg?branch=main)](https://coveralls.io/github/marthijn/Sidio.Sitemap.Blazor?branch=main)

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