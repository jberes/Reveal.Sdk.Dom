# Examples

Complete working examples demonstrating Reveal.Sdk.Dom capabilities.

## Overview

This section contains full, working examples that demonstrate how to create various types of dashboards using Reveal.Sdk.Dom. Each example includes complete code and explanations.

## Available Examples

### Business Dashboards

- **[Sales Dashboard](sales-dashboard.md)** - Comprehensive sales analytics with KPIs, charts, and trends
- **[Marketing Dashboard](marketing-dashboard.md)** - Marketing campaign performance and metrics  
- **[Healthcare Dashboard](healthcare-dashboard.md)** - Healthcare metrics and patient data visualization
- **[Manufacturing Dashboard](manufacturing-dashboard.md)** - Production metrics and operational KPIs
- **[Campaigns Dashboard](campaigns-dashboard.md)** - Campaign analytics and conversion tracking

### Data Source Examples

- **[SQL Server Dashboard](sql-server-dashboard.md)** - Connecting to and visualizing SQL Server data
- **[REST API Dashboard](rest-api-dashboard.md)** - Consuming and displaying REST API data
- **[Excel Dashboard](excel-dashboard.md)** - Working with Excel data sources via REST
- **[Multi-Source Dashboard](multi-source-dashboard.md)** - Combining data from multiple sources
- **[Real-time Dashboard](realtime-dashboard.md)** - Working with live data sources

### Visualization Examples

- **[Charts Gallery](charts-gallery.md)** - Showcasing different chart types with real data
- **[KPI Dashboard](kpi-dashboard.md)** - Creating effective KPI visualizations
- **[Geographic Dashboard](geographic-dashboard.md)** - Working with maps and geographic data
- **[Grid and Pivot](grid-pivot-dashboard.md)** - Data tables and pivot tables
- **[Advanced Visualizations](advanced-visualizations.md)** - Sparklines, gauges, and bullet graphs

## Quick Examples

### Simple Bar Chart Dashboard

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;

// Create document
var document = new RdashDocument("Sales by Region");

// Create REST data source
var restSource = new RestDataSource
{
    Url = "https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9",
    Title = "Sales Data"
};

// Create data source item with fields
var dataItem = new RestDataSourceItem("Sales", restSource);
dataItem.Fields.Add(new TextField("CategoryName"));
dataItem.Fields.Add(new NumberField("ProductSales"));

// Create bar chart
var chart = new BarChartVisualization("Sales by Category", dataItem);
chart.Labels.Add(new DimensionDataField("CategoryName"));
chart.Values.Add(new MeasureDataField("ProductSales") 
{ 
    Aggregation = AggregationType.Sum 
});

// Add to document and save
document.Visualizations.Add(chart);
document.Save("sales-chart.rdash");
```

### Multi-Visualization Dashboard

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;

var document = new RdashDocument("Performance Dashboard")
{
    UseAutoLayout = true
};

// Create data source
var sqlSource = new MicrosoftSqlServerDataSource
{
    Host = "server.database.windows.net",
    Database = "SalesDB"
};

var salesData = new TableDataSourceItem("Sales", sqlSource)
{
    Table = "Sales"
};

// KPI
var kpi = new KpiTargetVisualization("Total Sales", salesData);
kpi.Value = new MeasureDataField("Revenue") { Aggregation = AggregationType.Sum };
kpi.Target = new MeasureDataField("Target") { Aggregation = AggregationType.Sum };
kpi.Date = new DateDataField("Date");
document.Visualizations.Add(kpi);

// Trend Chart
var trendChart = new LineChartVisualization("Sales Trend", salesData);
trendChart.Labels.Add(new DateDataField("Date"));
trendChart.Values.Add(new MeasureDataField("Revenue") { Aggregation = AggregationType.Sum });
document.Visualizations.Add(trendChart);

// Regional Chart
var regionChart = new ColumnChartVisualization("Sales by Region", salesData);
regionChart.Labels.Add(new DimensionDataField("Region"));
regionChart.Values.Add(new MeasureDataField("Revenue") { Aggregation = AggregationType.Sum });
document.Visualizations.Add(regionChart);

// Detail Grid
var grid = new GridVisualization("Sales Details", salesData);
grid.Columns.Add(new DateDataField("Date"));
grid.Columns.Add(new DimensionDataField("Product"));
grid.Columns.Add(new DimensionDataField("Region"));
grid.Columns.Add(new MeasureDataField("Revenue"));
document.Visualizations.Add(grid);

document.Save("performance-dashboard.rdash");
```

### Dashboard with Filters

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Filters;

var document = new RdashDocument("Filtered Dashboard");

// Create data source
var dataSource = new MicrosoftSqlServerDataSource { ... };
var salesData = new TableDataSourceItem("Sales", dataSource);

// Add date filter
var dateFilter = new DashboardDateFilter("Date Range");
document.Filters.Add(dateFilter);

// Add category filter
var categoryFilter = new DashboardDataFilter("Category", salesData);
categoryFilter.SelectedField = new DimensionDataField("CategoryName");
document.Filters.Add(categoryFilter);

// Add region filter
var regionFilter = new DashboardDataFilter("Region", salesData);
regionFilter.SelectedField = new DimensionDataField("Region");
document.Filters.Add(regionFilter);

// Create visualizations - they'll automatically use filters
var chart = new ColumnChartVisualization("Sales", salesData);
chart.Labels.Add(new DateDataField("Date"));  // Connects to date filter
chart.Values.Add(new MeasureDataField("Revenue"));
document.Visualizations.Add(chart);

document.Save("filtered-dashboard.rdash");
```

## Example Categories

### By Industry

- **Retail**: Sales, inventory, customer analytics
- **Healthcare**: Patient metrics, facility management
- **Finance**: Financial KPIs, portfolio analysis
- **Manufacturing**: Production metrics, quality control
- **Marketing**: Campaign performance, lead tracking

### By Complexity

- **Beginner**: Simple single-visualization dashboards
- **Intermediate**: Multi-visualization dashboards with filters
- **Advanced**: Complex dashboards with multiple data sources, custom calculations

### By Data Source

- **Databases**: SQL Server, PostgreSQL, MySQL
- **Cloud**: Azure, AWS, Google Cloud
- **APIs**: REST, OData, Web Services
- **Files**: Excel, CSV, JSON

## Code Samples Repository

Complete, runnable examples are available in the repository:

```
/e2e/Sandbox/DashboardCreators/
├── Examples/
│   ├── SalesDashboard.cs
│   ├── MarketingDashboard.cs
│   ├── HealthcareDashboard.cs
│   ├── ManufacturingDashboard.cs
│   └── CampaignsDashboard.cs
├── DataSources/
│   └── (Various data source examples)
├── Visualizations/
│   └── (Various visualization examples)
└── Features/
    └── (Feature-specific examples)
```

## Running Examples

### Prerequisites

```bash
# Clone the repository
git clone https://github.com/RevealBi/Reveal.Sdk.Dom.git

# Navigate to sandbox
cd Reveal.Sdk.Dom/e2e/Sandbox

# Restore packages
dotnet restore

# Build
dotnet build
```

### Running Specific Examples

```csharp
// In the Sandbox application
var creator = new SalesDashboard();
var dashboard = creator.CreateDashboard();
dashboard.Save("output/sales-dashboard.rdash");
```

## Learning Path

We recommend following this progression:

1. **Start with Quick Start** - [Quick Start Guide](../getting-started/quick-start.md)
2. **Simple Charts** - Single visualization examples
3. **Multiple Visualizations** - Combining charts, grids, KPIs
4. **Add Filters** - Dashboard and visualization filters
5. **Multiple Data Sources** - Combining different data sources
6. **Advanced Features** - Variables, linking, custom visualizations

## Contributing Examples

Want to contribute an example? We welcome pull requests!

1. Create a complete, working example
2. Include comments explaining key concepts
3. Add it to the appropriate section
4. Update this README

## Tips for Using Examples

### Adapt to Your Data

Examples use sample data. Adapt them to your needs:

```csharp
// Example uses
var dataSource = new MicrosoftSqlServerDataSource
{
    Host = "example.database.windows.net",
    Database = "SampleDB"
};

// Change to your data
var dataSource = new MicrosoftSqlServerDataSource
{
    Host = "your-server.database.windows.net",
    Database = "YourDatabase"
};
```

### Mix and Match

Combine elements from different examples:

```csharp
// Take KPI from one example
var kpi = CreateKPIFromExample1();

// Take chart from another
var chart = CreateChartFromExample2();

// Combine in one dashboard
document.Visualizations.Add(kpi);
document.Visualizations.Add(chart);
```

### Start Simple

Begin with simple examples and gradually add complexity:

1. Start with single visualization
2. Add more visualizations
3. Add filters
4. Add multiple data sources
5. Customize styling and layout

## Related Topics

- [Getting Started](../getting-started/quick-start.md)
- [How-To Guides](../how-to/)
- [API Reference](../api-reference/)
- [Best Practices](../best-practices.md)

## Need Help?

- Review the [FAQ](../faq.md)
- Check [Troubleshooting](../troubleshooting.md)
- Ask in [GitHub Issues](https://github.com/RevealBi/Reveal.Sdk.Dom/issues)
