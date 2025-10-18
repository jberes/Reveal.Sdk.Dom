# Reveal.Sdk.Dom Documentation

Welcome to the **Reveal.Sdk.Dom** documentation! This library provides a comprehensive Document Object Model (DOM) for working with Reveal BI dashboards in .NET applications.

## What is Reveal.Sdk.Dom?

Reveal.Sdk.Dom is a .NET library that allows developers to programmatically load, create, and edit Reveal BI dashboard files (`.rdash` format). It provides a fluent, type-safe API for working with all aspects of Reveal dashboards, including data sources, visualizations, filters, and more.

**Key Features:**
- Load and modify existing `.rdash` dashboard files
- Create new dashboards programmatically
- Support for 40+ visualization types
- Connect to 30+ data sources (databases, cloud services, files)
- Configure filters, variables, and dashboard settings
- Export dashboards to JSON for use with Reveal SDK

## Documentation Structure

### Getting Started
- [Installation](getting-started/installation.md) - Install the NuGet package and set up your project
- [Quick Start](getting-started/quick-start.md) - Create your first dashboard in minutes
- [Basic Concepts](getting-started/basic-concepts.md) - Understand the core concepts of the SDK

### Core Concepts
- [RdashDocument](core-concepts/rdash-document.md) - The main dashboard document
- [Data Sources](core-concepts/data-sources.md) - Understanding data sources and data source items
- [Visualizations](core-concepts/visualizations.md) - Overview of visualization types and their properties
- [Filters](core-concepts/filters.md) - Dashboard and visualization filters
- [Variables](core-concepts/variables.md) - Using dashboard variables
- [Document Structure](core-concepts/document-structure.md) - Understanding the `.rdash` file format

### How-To Guides

#### Data Sources
- [Connect to SQL Server](how-to/data-sources/connect-to-sql-server.md)
- [Connect to REST APIs](how-to/data-sources/connect-to-rest-api.md)
- [Work with Excel Files](how-to/data-sources/work-with-excel.md)
- [Use JSON Data](how-to/data-sources/use-json-data.md)
- [Connect to Cloud Services](how-to/data-sources/connect-to-cloud-services.md)

#### Visualizations
- [Create Charts](how-to/visualizations/create-charts.md)
- [Create KPIs](how-to/visualizations/create-kpis.md)
- [Create Grids and Pivot Tables](how-to/visualizations/create-grids.md)
- [Create Gauges](how-to/visualizations/create-gauges.md)
- [Customize Visualization Settings](how-to/visualizations/customize-settings.md)
- [Set Colors and Themes](how-to/visualizations/set-colors-themes.md)

#### Dashboard Management
- [Load Existing Dashboards](how-to/dashboard-management/load-dashboards.md)
- [Save Dashboards](how-to/dashboard-management/save-dashboards.md)
- [Modify Dashboard Settings](how-to/dashboard-management/modify-settings.md)
- [Work with Dashboard Filters](how-to/dashboard-management/work-with-filters.md)
- [Implement Dashboard Linking](how-to/dashboard-management/dashboard-linking.md)

#### Advanced Topics
- [Custom Visualizations](how-to/advanced/custom-visualizations.md)
- [Working with Variables](how-to/advanced/working-with-variables.md)
- [Conditional Formatting](how-to/advanced/conditional-formatting.md)
- [Calculations and Aggregations](how-to/advanced/calculations-aggregations.md)
- [Export to Reveal SDK](how-to/advanced/export-to-reveal-sdk.md)

### API Reference
- [Data Sources Reference](api-reference/data-sources/README.md) - Complete list of supported data sources
- [Visualizations Reference](api-reference/visualizations/README.md) - Complete list of visualization types
- [Enums Reference](api-reference/enums.md) - All enumeration types
- [Builders Reference](api-reference/builders.md) - Fluent builder APIs

### Examples
- [Complete Examples](examples/README.md) - Full working examples
- [Sales Dashboard](examples/sales-dashboard.md) - Comprehensive sales analytics dashboard
- [Healthcare Dashboard](examples/healthcare-dashboard.md) - Healthcare metrics and KPIs
- [Marketing Dashboard](examples/marketing-dashboard.md) - Marketing campaign analytics

### Additional Resources
- [Best Practices](best-practices.md) - Recommended patterns and practices
- [Troubleshooting](troubleshooting.md) - Common issues and solutions
- [FAQ](faq.md) - Frequently asked questions
- [Migration Guide](migration-guide.md) - Upgrading from previous versions
- [Glossary](glossary.md) - Terms and definitions

## Quick Links

- [GitHub Repository](https://github.com/RevealBi/Reveal.Sdk.Dom)
- [NuGet Package](https://www.nuget.org/packages/Reveal.Sdk.Dom/)
- [Reveal BI Website](https://www.revealbi.io/)
- [Reveal SDK Documentation](https://help.revealbi.io/)

## Support

- [GitHub Issues](https://github.com/RevealBi/Reveal.Sdk.Dom/issues) - Report bugs or request features
- [Reveal Community Forums](https://www.revealbi.io/community) - Ask questions and share knowledge

## License

This project is licensed under the terms specified in the [LICENSE](../LICENSE) file.

---

*Note: This library is currently in **BETA**. Features may change between releases.*
