# Installation

Learn how to install and configure Reveal.Sdk.Dom in your .NET project.

## Prerequisites

Before installing Reveal.Sdk.Dom, ensure you have:

- **.NET Framework 4.6.2** or higher, **OR**
- **.NET 6.0** or higher (including .NET 7.0, 8.0, and 9.0)
- **Visual Studio 2022** or later (recommended) or any compatible IDE
- **NuGet Package Manager**

## Install via NuGet Package Manager

### Using Visual Studio

1. Right-click on your project in Solution Explorer
2. Select **Manage NuGet Packages**
3. Click on the **Browse** tab
4. Search for `Reveal.Sdk.Dom`
5. Select the package and click **Install**
6. Accept any license agreements

### Using Package Manager Console

Open the Package Manager Console (Tools > NuGet Package Manager > Package Manager Console) and run:

```powershell
Install-Package Reveal.Sdk.Dom
```

To install a specific version:

```powershell
Install-Package Reveal.Sdk.Dom -Version 1.x.x
```

### Using .NET CLI

Open a terminal in your project directory and run:

```bash
dotnet add package Reveal.Sdk.Dom
```

To install a specific version:

```bash
dotnet add package Reveal.Sdk.Dom --version 1.x.x
```

### Using PackageReference

Add the following to your `.csproj` file:

```xml
<ItemGroup>
  <PackageReference Include="Reveal.Sdk.Dom" Version="1.*" />
</ItemGroup>
```

Then restore packages:

```bash
dotnet restore
```

## Verify Installation

After installation, verify that the package is installed correctly by checking your project file or packages.config:

### For SDK-style projects (.csproj)

```xml
<ItemGroup>
  <PackageReference Include="Reveal.Sdk.Dom" Version="1.x.x" />
</ItemGroup>
```

### Test the Installation

Create a simple test to verify the installation:

```csharp
using Reveal.Sdk.Dom;
using System;

namespace RevealTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new dashboard
            var document = new RdashDocument("Test Dashboard");
            
            Console.WriteLine($"Successfully created dashboard: {document.Title}");
            Console.WriteLine("Reveal.Sdk.Dom is installed correctly!");
        }
    }
}
```

If this code compiles and runs without errors, your installation is successful!

## Supported Target Frameworks

Reveal.Sdk.Dom supports multiple target frameworks:

- **.NET Framework 4.6.2** - For legacy applications
- **.NET 6.0** - Long-term support (LTS)
- **.NET 7.0** - Standard-term support
- **.NET 8.0** - Long-term support (LTS)
- **.NET 9.0** - Latest version

## Dependencies

Reveal.Sdk.Dom has minimal dependencies:

- **Newtonsoft.Json** (13.0.3 or higher) - For JSON serialization
- **System.IO.Compression** (4.3.0 or higher, .NET Framework 4.6.2 only)

These dependencies are automatically installed when you install Reveal.Sdk.Dom.

## Version Information

You can check the latest version at:
- [NuGet Gallery](https://www.nuget.org/packages/Reveal.Sdk.Dom/)
- [GitHub Releases](https://github.com/RevealBi/Reveal.Sdk.Dom/releases)

## Beta Notice

⚠️ **Important**: Reveal.Sdk.Dom is currently in **BETA**. While it's functional and ready for use, be aware that:

- APIs may change between releases
- Some features might not be fully stable
- Breaking changes may occur in minor version updates

We recommend:
- Testing thoroughly before production use
- Pinning to specific versions in production
- Reviewing release notes before upgrading

## Next Steps

- [Quick Start Guide](quick-start.md) - Create your first dashboard
- [Basic Concepts](basic-concepts.md) - Learn core concepts
- [Examples](../examples/README.md) - Explore working examples

## Troubleshooting

### Common Installation Issues

**Issue**: Package not found
- **Solution**: Ensure you have the correct NuGet package source configured. The default nuget.org source should work.

**Issue**: Version conflicts with Newtonsoft.Json
- **Solution**: Update Newtonsoft.Json to version 13.0.3 or higher in your project.

**Issue**: Target framework mismatch
- **Solution**: Ensure your project targets one of the supported frameworks listed above.

For more issues, see the [Troubleshooting Guide](../troubleshooting.md).
