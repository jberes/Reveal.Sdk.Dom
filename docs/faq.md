# Frequently Asked Questions (FAQ)

Common questions about using Reveal.Sdk.Dom.

## General Questions

### What is Reveal.Sdk.Dom?

Reveal.Sdk.Dom is a .NET library that provides a Document Object Model for working with Reveal BI dashboard files (`.rdash`). It allows you to programmatically create, load, and modify dashboards without needing the full Reveal SDK UI components.

### Is Reveal.Sdk.Dom free to use?

Reveal.Sdk.Dom follows the same licensing as Reveal SDK. Check the [Reveal website](https://www.revealbi.io/) for current licensing information.

### What's the difference between Reveal.Sdk.Dom and Reveal SDK?

- **Reveal SDK** - Full BI platform including UI components for displaying dashboards in applications
- **Reveal.Sdk.Dom** - Programmatic API for creating and modifying dashboard files without UI

They work together: Use Reveal.Sdk.Dom to create/modify `.rdash` files, then load them in Reveal SDK for display.

### Is it production-ready?

Reveal.Sdk.Dom is currently in **BETA**. While functional, expect potential API changes and breaking changes between versions. Test thoroughly before production use.

## Installation & Setup

### What .NET versions are supported?

- .NET Framework 4.6.2+
- .NET 6.0+
- .NET 7.0+
- .NET 8.0+
- .NET 9.0+

### How do I install Reveal.Sdk.Dom?

Via NuGet Package Manager:
```powershell
Install-Package Reveal.Sdk.Dom
```

Or .NET CLI:
```bash
dotnet add package Reveal.Sdk.Dom
```

See [Installation Guide](getting-started/installation.md) for details.

### Do I need the full Reveal SDK to use Reveal.Sdk.Dom?

No. Reveal.Sdk.Dom is standalone for creating/modifying dashboard files. You only need Reveal SDK if you want to display dashboards in your application.

## Creating Dashboards

### How do I create a new dashboard?

```csharp
var document = new RdashDocument("My Dashboard");
// Add visualizations
document.Save("dashboard.rdash");
```

See [Quick Start Guide](getting-started/quick-start.md) for a complete example.

### Can I load and modify existing dashboards?

Yes:
```csharp
var document = RdashDocument.Load("existing.rdash");
document.Title = "Updated Dashboard";
document.Save("modified.rdash");
```

### How many visualizations can I add to a dashboard?

There's no hard limit, but for performance and usability, we recommend:
- **10-15 visualizations** for optimal performance
- **20+ visualizations** - consider splitting into multiple dashboards

## Data Sources

### What data sources are supported?

40+ data sources including:
- Databases (SQL Server, MySQL, PostgreSQL, Oracle, MongoDB, etc.)
- Cloud services (OneDrive, SharePoint, Google Drive, Dropbox, S3, etc.)
- APIs (REST, OData, Web Services)
- Files (Excel, CSV, JSON)

See [Data Sources API Reference](api-reference/data-sources/README.md) for the complete list.

### Do I need to define fields for all data sources?

No, only for certain types:
- **Required**: REST APIs, Excel, CSV, JSON
- **Not required**: SQL tables (schema comes from database)

### How do I connect to a SQL database?

```csharp
var sqlDataSource = new MicrosoftSqlServerDataSource
{
    Host = "server.database.windows.net",
    Database = "MyDB"
};

var table = new TableDataSourceItem("Data", sqlDataSource)
{
    Table = "Sales"
};
```

See [Connect to SQL Server](how-to/data-sources/connect-to-sql-server.md) for details.

### How do I use a REST API?

```csharp
var restSource = new RestDataSource 
{ 
    Url = "https://api.example.com" 
};

var apiData = new RestDataSourceItem("API Data", restSource);
apiData.Fields.Add(new TextField("Name"));
apiData.Fields.Add(new NumberField("Value"));
```

See [Connect to REST APIs](how-to/data-sources/connect-to-rest-api.md) for details.

### Can I use multiple data sources in one dashboard?

Yes! Each visualization can use a different data source:

```csharp
var sqlData = new TableDataSourceItem("SQL", sqlSource);
var apiData = new RestDataSourceItem("API", restSource);

document.Visualizations.Add(new BarChartVisualization("SQL Data", sqlData));
document.Visualizations.Add(new LineChartVisualization("API Data", apiData));
```

## Visualizations

### What visualization types are supported?

40+ types including:
- Charts (Bar, Column, Line, Pie, Area, etc.)
- KPIs and Gauges
- Grids and Pivot Tables
- Maps (Choropleth, Scatter)
- Financial charts (Candlestick, OHLC)
- And more...

See [Visualizations API Reference](api-reference/visualizations/README.md) for the complete list.

### How do I create a simple chart?

```csharp
var chart = new BarChartVisualization("Sales by Region", dataSourceItem);
chart.Labels.Add(new DimensionDataField("Region"));
chart.Values.Add(new MeasureDataField("Sales") 
{ 
    Aggregation = AggregationType.Sum 
});
document.Visualizations.Add(chart);
```

### What's the difference between DimensionDataField and MeasureDataField?

- **DimensionDataField** - Categorical data (labels, categories, groups). Example: Product names, regions, categories
- **MeasureDataField** - Numeric data that can be aggregated. Example: Sales, quantities, prices

### What aggregation types are available?

- Sum
- Average
- Count
- DistinctCount
- Min
- Max
- Median
- StdDev
- Variance

### Can I customize colors and formatting?

Yes, through visualization settings:

```csharp
var chart = new BarChartVisualization("Sales", dataSourceItem)
{
    ShowLegend = true,
    StartColorIndex = 2
};

var field = new MeasureDataField("Revenue")
{
    Formatting = new NumberFormatting
    {
        FormatType = NumberFormattingType.Currency,
        DecimalPlaces = 2
    }
};
```

## Filters

### How do I add dashboard filters?

```csharp
// Date filter
var dateFilter = new DashboardDateFilter("Date Range");
document.Filters.Add(dateFilter);

// Data filter
var categoryFilter = new DashboardDataFilter("Category", dataSourceItem);
categoryFilter.SelectedField = new DimensionDataField("CategoryName");
document.Filters.Add(categoryFilter);
```

### Do filters automatically apply to visualizations?

Yes, dashboard filters automatically apply to visualizations that use matching fields.

### Can I add visualization-specific filters?

Yes:

```csharp
var vizFilter = new VisualizationFilter
{
    Field = new DimensionDataField("Region"),
    FilterType = FilterType.Include
};
chart.Filters.Add(vizFilter);
```

## Saving and Loading

### What file format does Reveal.Sdk.Dom use?

`.rdash` files, which are JSON-based dashboard definitions.

### Can I view .rdash files as text?

Yes! `.rdash` files are JSON. You can open them in any text editor:

```bash
# View file
cat dashboard.rdash
```

### How do I save a dashboard?

```csharp
document.Save("dashboard.rdash");
```

Or specify full path:

```csharp
var path = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.MyDocuments), "dashboard.rdash");
document.Save(path);
```

### How do I load a dashboard?

```csharp
var document = RdashDocument.Load("dashboard.rdash");
```

### Can I convert to/from JSON?

Yes:

```csharp
// To JSON
var json = document.ToJsonString();

// From JSON
var document = RdashDocument.LoadFromJson(jsonString);
```

### How do I use with Reveal SDK?

Export to JSON and load in Reveal SDK:

```csharp
// Create with Reveal.Sdk.Dom
var document = new RdashDocument("Dashboard");
// ... configure dashboard ...
var json = document.ToJsonString();

// Load in Reveal SDK
var revealDashboard = await RVDashboard.LoadFromJsonAsync(json);
revealView.Dashboard = revealDashboard;
```

## Troubleshooting

### My dashboard file won't load

**Possible causes**:
1. File doesn't exist - check path
2. Invalid JSON - check file wasn't manually edited incorrectly
3. Version incompatibility - created with newer version

**Solution**: Always use the same version of Reveal.Sdk.Dom to create and load files.

### Fields aren't showing up

**For REST/Excel/JSON**: You must define fields:

```csharp
dataSourceItem.Fields.Add(new TextField("Name"));
dataSourceItem.Fields.Add(new NumberField("Value"));
```

**For SQL**: Fields come from database schema automatically.

### Visualizations overlap

When `UseAutoLayout = false`, you must set positions:

```csharp
chart.Column = 0;
chart.Row = 0;
chart.ColumnSpan = 6;
chart.RowSpan = 4;
```

Or use auto layout:

```csharp
document.UseAutoLayout = true;
```

### Authentication errors

Authentication is configured in Reveal SDK at runtime, not in Reveal.Sdk.Dom. The `.rdash` file only defines what data sources are needed.

## Best Practices

### Should I use auto layout?

**Yes**, for most cases:
```csharp
document.UseAutoLayout = true;
```

Use manual layout only when you need precise control over positioning.

### How should I organize my code?

Create factory classes:

```csharp
public class DashboardFactory
{
    public RdashDocument CreateSalesDashboard() { ... }
    public RdashDocument CreateMarketingDashboard() { ... }
}

public class DataSourceFactory
{
    public static DataSourceItem GetSalesData() { ... }
    public static DataSourceItem GetCustomerData() { ... }
}
```

### Should I commit .rdash files to source control?

**Template files**: Yes - commit dashboard templates
**Generated files**: No - exclude output files

```gitignore
# .gitignore
*.rdash
!templates/*.rdash  # Keep templates
```

### How do I handle different environments?

Use configuration:

```csharp
var dataSource = new MicrosoftSqlServerDataSource
{
    Host = Configuration["Database:Host"],
    Database = Configuration["Database:Name"]
};
```

## Performance

### How large can dashboards be?

Recommendations:
- **10-15 visualizations** - Optimal
- **20-30 visualizations** - Acceptable
- **30+ visualizations** - Consider splitting

### Does Reveal.Sdk.Dom cache data?

No. Reveal.Sdk.Dom only creates dashboard definitions. Data is fetched by Reveal SDK at runtime.

### Can I create dashboards asynchronously?

Dashboard creation in Reveal.Sdk.Dom is synchronous and fast (milliseconds). If you need async, wrap in Task:

```csharp
await Task.Run(() =>
{
    var document = CreateDashboard();
    document.Save("dashboard.rdash");
});
```

## Migration & Compatibility

### Can I migrate from older versions?

Generally yes, but check release notes for breaking changes. The library is in BETA so APIs may change.

### Are .rdash files backward compatible?

Dashboards created with newer versions may not work with older Reveal SDK versions. Use matching versions when possible.

### Can I use Reveal.Sdk.Dom with Reveal SDK for Web?

Yes! Create dashboards with Reveal.Sdk.Dom, then load them in Reveal SDK for Web, WPF, WinForms, etc.

## Support

### Where can I get help?

- [GitHub Issues](https://github.com/RevealBi/Reveal.Sdk.Dom/issues)
- [Reveal Community Forums](https://www.revealbi.io/community)
- [Documentation](README.md)

### How do I report a bug?

Open an issue on [GitHub](https://github.com/RevealBi/Reveal.Sdk.Dom/issues) with:
- Clear description
- Code to reproduce
- Expected vs actual behavior
- Version information

### Can I contribute?

Check the repository for contribution guidelines. Pull requests are welcome!

## Related Resources

- [Getting Started Guide](getting-started/quick-start.md)
- [API Reference](api-reference/)
- [Examples](examples/README.md)
- [Best Practices](best-practices.md)
- [Troubleshooting Guide](troubleshooting.md)
