# Basic Concepts

Understanding these fundamental concepts will help you work effectively with Reveal.Sdk.Dom.

> **💡 Essential Reference**: Before diving in, familiarize yourself with the **[Types and Enums Reference](../core-concepts/types-and-enums.md)**. This guide covers all the field types, aggregation types, visualization types, and data source types you'll be working with. It's an essential reference that will help you understand the building blocks used throughout this guide.

## Overview

Reveal.Sdk.Dom is designed around a hierarchical structure that mirrors the organization of a Reveal dashboard. At the highest level, you have a **Document**, which contains **Visualizations**, which display data from **Data Sources**.

```
RdashDocument
├── Visualizations
│   ├── Visualization 1
│   ├── Visualization 2
│   └── ...
├── Data Sources
│   ├── Data Source 1
│   ├── Data Source 2
│   └── ...
├── Filters
└── Variables
```

## Core Components

### 1. RdashDocument

The `RdashDocument` is the root object that represents an entire Reveal dashboard. It contains all visualizations, data sources, filters, and settings.

```csharp
var document = new RdashDocument("My Dashboard");
document.Description = "A comprehensive business dashboard";
document.UseAutoLayout = true;
```

**Key Properties:**
- `Title` - The dashboard title
- `Description` - Optional dashboard description
- `Visualizations` - Collection of visualizations on the dashboard
- `Filters` - Dashboard-level filters
- `Variables` - Dashboard variables
- `UseAutoLayout` - Whether to use automatic layout

### 2. Data Sources

Data sources define where your data comes from. Reveal.Sdk.Dom distinguishes between two types:

#### DataSource

The connection definition (server, credentials, etc.):

```csharp
var sqlDataSource = new MicrosoftSqlServerDataSource
{
    Host = "server.database.windows.net",
    Database = "SalesDB",
    Title = "Sales Database"
};
```

#### DataSourceItem

A specific dataset from a data source (table, view, query, file, etc.):

```csharp
var dataSourceItem = new TableDataSourceItem("Sales", sqlDataSource)
{
    Table = "SalesData"
};
```

**Key Concept**: 
- **DataSource** = "Connect to SQL Server at this address"
- **DataSourceItem** = "Get data from the 'Sales' table"

### 3. Visualizations

Visualizations display your data in various formats (charts, grids, gauges, etc.). Each visualization:

- Has a **title** and optional **description**
- References a **DataSourceItem** for its data
- Defines which **fields** to display and how
- Has type-specific **settings** (colors, labels, etc.)

```csharp
var barChart = new BarChartVisualization("Top Products", dataSourceItem);
barChart.Labels.Add(new DimensionDataField("ProductName"));
barChart.Values.Add(new MeasureDataField("Sales") 
{ 
    Aggregation = AggregationType.Sum 
});
```

### 4. Fields

Fields represent the columns/properties in your data. There are different field types:

#### DimensionDataField
Used for categorical data (labels, categories, groups):

```csharp
var categoryField = new DimensionDataField("CategoryName");
```

#### MeasureDataField
Used for numeric data that can be aggregated:

```csharp
var salesField = new MeasureDataField("Sales")
{
    Aggregation = AggregationType.Sum,
    FieldLabel = "Total Sales"
};
```

#### DateDataField
Used for date and time data:

```csharp
var dateField = new DateDataField("OrderDate");
```

### 5. Field Definitions

When creating data sources (especially for REST APIs, JSON, or Excel files), you must define the schema:

```csharp
var dataSourceItem = new RestDataSourceItem("API Data", restDataSource);
dataSourceItem.Fields.Add(new TextField("Name"));
dataSourceItem.Fields.Add(new NumberField("Amount"));
dataSourceItem.Fields.Add(new DateField("Date"));
```

**Field Types:**
- `TextField` - String data
- `NumberField` - Numeric data  
- `DateField` - Date/time data
- `BooleanField` - Boolean data

**💡 Key Types to Know**: Understanding field types is crucial for working with data. Each type corresponds to how your data is structured and determines what operations are available. For complete type information, see the **[Types and Enums Reference](../core-concepts/types-and-enums.md)**.

## Data Flow

Understanding how data flows through the SDK:

```
1. Define Data Source (Connection)
        ↓
2. Create Data Source Item (Specific Dataset)
        ↓
3. Define Fields (Schema)
        ↓
4. Create Visualization
        ↓
5. Map Fields to Visualization Properties
        ↓
6. Add to Document
```

### Example Data Flow

```csharp
// 1. Data Source - Connection information
var restDataSource = new RestDataSource
{
    Url = "https://api.example.com/sales",
    Title = "Sales API"
};

// 2. Data Source Item - Specific dataset
var dataSourceItem = new RestDataSourceItem("Sales", restDataSource);

// 3. Field Definitions - Schema
dataSourceItem.Fields.Add(new TextField("Product"));
dataSourceItem.Fields.Add(new NumberField("Revenue"));

// 4. Create Visualization
var chart = new ColumnChartVisualization("Revenue by Product", dataSourceItem);

// 5. Map Fields
chart.Labels.Add(new DimensionDataField("Product"));
chart.Values.Add(new MeasureDataField("Revenue") 
{ 
    Aggregation = AggregationType.Sum 
});

// 6. Add to Document
document.Visualizations.Add(chart);
```

## Aggregation

Aggregation is how numeric data is combined:

```csharp
var salesField = new MeasureDataField("Sales")
{
    Aggregation = AggregationType.Sum  // Sum all values
};
```

**Common Aggregation Types:**
- `Sum` - Add all values
- `Average` - Calculate average
- `Count` - Count number of records
- `Min` - Minimum value
- `Max` - Maximum value

**💡 More Aggregation Types**: The SDK supports many more aggregation types including `DistinctCount`, `Median`, `StdDev`, and `Variance`. See the complete list in the **[Types and Enums Reference](../core-concepts/types-and-enums.md#aggregation-types)**.

## Filters

Filters allow users to narrow down data:

### Dashboard Filters
Apply to all visualizations that use the filtered field:

```csharp
var dateFilter = new DashboardDateFilter("Date Range");
document.Filters.Add(dateFilter);

var categoryFilter = new DashboardDataFilter("Category", dataSourceItem);
categoryFilter.SelectedField = new DimensionDataField("CategoryName");
document.Filters.Add(categoryFilter);
```

### Visualization Filters
Apply only to a specific visualization:

```csharp
var vizFilter = new VisualizationFilter();
vizFilter.Field = new DimensionDataField("Region");
vizFilter.FilterType = FilterType.Include;
chart.Filters.Add(vizFilter);
```

## Connecting Filters to Visualizations

Filters are automatically connected to visualizations that use matching fields:

```csharp
// Create filter
var dateFilter = new DashboardDateFilter("Date Range");
document.Filters.Add(dateFilter);

// Visualization will be filtered if it uses a date field
var chart = new LineChartVisualization("Sales Over Time", dataSourceItem);
chart.Labels.Add(new DateDataField("OrderDate")); // This connects to the date filter
```

## Variables

Variables allow dynamic values in your dashboard:

```csharp
var variable = new DashboardVariable("CurrentYear")
{
    Value = "2024"
};
document.Variables.Add(variable);

// Use in filters or calculations
```

## Layout

Control how visualizations are positioned on the dashboard:

### Auto Layout
```csharp
document.UseAutoLayout = true;  // Reveal handles positioning
```

### Manual Layout
```csharp
document.UseAutoLayout = false;

// Set position and size for each visualization
var chart = new BarChartVisualization("Sales", dataSourceItem);
chart.ColumnSpan = 6;  // Width (out of 12 columns)
chart.RowSpan = 4;     // Height
chart.Column = 0;      // X position
chart.Row = 0;         // Y position
```

## Serialization

Dashboards can be saved and loaded:

### Save to File
```csharp
document.Save("dashboard.rdash");
```

### Load from File
```csharp
var document = RdashDocument.Load("dashboard.rdash");
```

### Export to JSON
```csharp
var json = document.ToJsonString();
// Use with Reveal SDK
```

### Import from JSON
```csharp
var document = RdashDocument.LoadFromJson(jsonString);
```

## Best Practices

### 1. Naming Conventions
Use clear, descriptive names for everything:

```csharp
// Good
var salesByRegion = new BarChartVisualization("Sales by Region", salesData);

// Avoid
var chart1 = new BarChartVisualization("Chart", data);
```

### 2. Organize Data Sources
Reuse data source definitions when possible:

```csharp
// Define once
var sqlDataSource = new MicrosoftSqlServerDataSource { ... };

// Use multiple times
var salesItem = new TableDataSourceItem("Sales", sqlDataSource);
var customersItem = new TableDataSourceItem("Customers", sqlDataSource);
```

### 3. Field Labels
Provide user-friendly labels:

```csharp
var salesField = new MeasureDataField("total_sales_amount")
{
    FieldLabel = "Total Sales",  // User sees this
    Aggregation = AggregationType.Sum
};
```

### 4. Error Handling
Always handle potential errors:

```csharp
try
{
    var document = RdashDocument.Load("dashboard.rdash");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Dashboard file not found");
}
catch (Exception ex)
{
    Console.WriteLine($"Error loading dashboard: {ex.Message}");
}
```

## Common Patterns

### Creating Multiple Visualizations from Same Data

```csharp
var dataSourceItem = GetDataSource();

// Create multiple visualizations
var chart = new ColumnChartVisualization("Chart", dataSourceItem);
var grid = new GridVisualization("Details", dataSourceItem);
var kpi = new KpiTargetVisualization("KPI", dataSourceItem);

// Add all to document
document.Visualizations.Add(chart);
document.Visualizations.Add(grid);
document.Visualizations.Add(kpi);
```

### Conditional Visualization Creation

```csharp
if (includeGeographicData)
{
    var map = new ChoroplethVisualization("Sales by Region", geoData);
    document.Visualizations.Add(map);
}
```

## Next Steps

Now that you understand the basic concepts:

- Explore [Core Concepts](../core-concepts/rdash-document.md) for deeper understanding
- Read [How-To Guides](../how-to/README.md) for specific tasks
- Check out [Examples](../examples/README.md) for complete working code

## Quick Reference

| Concept | Purpose | Example |
|---------|---------|---------|
| RdashDocument | Container for entire dashboard | `new RdashDocument("Title")` |
| DataSource | Connection definition | `new RestDataSource { Url = "..." }` |
| DataSourceItem | Specific dataset | `new TableDataSourceItem("Sales", ds)` |
| Visualization | Display component | `new PieChartVisualization("Chart", item)` |
| DimensionDataField | Categorical data | `new DimensionDataField("Category")` |
| MeasureDataField | Numeric data | `new MeasureDataField("Sales")` |
| Filter | Data filtering | `new DashboardDateFilter("Date")` |
| Variable | Dynamic value | `new DashboardVariable("Year")` |
