# RdashDocument

The `RdashDocument` class is the root object that represents a complete Reveal dashboard. It contains all visualizations, data sources, filters, variables, and settings for a dashboard.

## Overview

An `.rdash` file is essentially a JSON file that contains a complete dashboard definition. The `RdashDocument` class provides a strongly-typed API to work with these files programmatically.

## Creating a Document

### New Dashboard

Create a new, empty dashboard:

```csharp
var document = new RdashDocument("My Dashboard");
```

With additional properties:

```csharp
var document = new RdashDocument("Sales Dashboard")
{
    Description = "Quarterly sales performance metrics",
    UseAutoLayout = true,
    ShowFilters = true
};
```

### From Existing File

Load an existing `.rdash` file:

```csharp
var document = RdashDocument.Load("path/to/dashboard.rdash");
```

From JSON string:

```csharp
var document = RdashDocument.LoadFromJson(jsonString);
```

## Properties

### Basic Information

```csharp
document.Title = "Sales Dashboard";              // Dashboard title
document.Description = "Q4 2024 Sales Metrics";  // Optional description
document.Tag = "sales-2024";                      // Optional tag for categorization
```

### Layout Settings

```csharp
document.UseAutoLayout = true;  // Let Reveal handle positioning automatically
```

When `UseAutoLayout` is false, you must specify position for each visualization:

```csharp
document.UseAutoLayout = false;

var chart = new BarChartVisualization("Sales", dataSourceItem)
{
    Column = 0,       // X position (0-based)
    Row = 0,          // Y position (0-based)
    ColumnSpan = 6,   // Width (out of 12 columns)
    RowSpan = 4       // Height (rows)
};
```

### Filter Settings

```csharp
document.ShowFilters = true;   // Show filter panel
document.DateFilter = ...;     // Global date filter configuration
```

## Collections

### Visualizations

Add and manage visualizations:

```csharp
// Add visualization
var chart = new PieChartVisualization("Sales by Category", dataSourceItem);
document.Visualizations.Add(chart);

// Access visualizations
var firstViz = document.Visualizations[0];
var vizCount = document.Visualizations.Count;

// Remove visualization
document.Visualizations.Remove(chart);

// Clear all
document.Visualizations.Clear();

// Iterate
foreach (var viz in document.Visualizations)
{
    Console.WriteLine(viz.Title);
}
```

### Data Sources

The document tracks all data sources used:

```csharp
// Data sources are automatically added when you create visualizations
var dataSources = document.DataSources;

// Access data source by ID
var dataSource = document.DataSources
    .FirstOrDefault(ds => ds.Id == "specific-id");
```

### Filters

Dashboard-level filters affect all compatible visualizations:

```csharp
// Add date filter
var dateFilter = new DashboardDateFilter("Date Range");
document.Filters.Add(dateFilter);

// Add data filter
var categoryFilter = new DashboardDataFilter("Category", dataSourceItem);
categoryFilter.SelectedField = new DimensionDataField("CategoryName");
document.Filters.Add(categoryFilter);

// Iterate filters
foreach (var filter in document.Filters)
{
    Console.WriteLine($"Filter: {filter.Title}");
}
```

### Variables

Dashboard variables provide dynamic values:

```csharp
// Add variable
var yearVariable = new DashboardVariable("SelectedYear")
{
    Value = "2024"
};
document.Variables.Add(yearVariable);

// Access variables
var vars = document.Variables;
```

## Methods

### Save

Save the dashboard to a file:

```csharp
// Save to file
document.Save("dashboard.rdash");

// Save to specific location
var path = Path.Combine(Directory.GetCurrentDirectory(), "output", "dashboard.rdash");
document.Save(path);
```

### Export to JSON

Convert to JSON string for use with Reveal SDK:

```csharp
var json = document.ToJsonString();

// Use with Reveal SDK
var revealDashboard = await RVDashboard.LoadFromJsonAsync(json);
```

### Export with Formatting

```csharp
var json = document.ToJsonString(Formatting.Indented);
File.WriteAllText("dashboard-readable.json", json);
```

## Working with Dashboard Settings

### Theme and Appearance

```csharp
// Set dashboard theme
document.Theme = new DashboardTheme
{
    Name = "Ocean",
    Colors = new List<string> 
    { 
        "#1f77b4", "#ff7f0e", "#2ca02c", "#d62728" 
    }
};
```

### Date Filter Configuration

```csharp
document.DateFilter = new DateFilter
{
    DefaultRange = DateRange.LastYear,
    AllowedRanges = new List<DateRange> 
    { 
        DateRange.Today,
        DateRange.LastWeek,
        DateRange.LastMonth,
        DateRange.LastYear
    }
};
```

## Common Operations

### Clone a Dashboard

```csharp
// Load original
var original = RdashDocument.Load("original.rdash");

// Modify and save as new
original.Title = "Copy of " + original.Title;
original.Save("copy.rdash");
```

### Merge Dashboards

```csharp
var dashboard1 = RdashDocument.Load("dashboard1.rdash");
var dashboard2 = RdashDocument.Load("dashboard2.rdash");

// Add all visualizations from dashboard2 to dashboard1
foreach (var viz in dashboard2.Visualizations)
{
    dashboard1.Visualizations.Add(viz);
}

dashboard1.Save("merged.rdash");
```

### Find Visualizations

```csharp
// Find by title
var salesChart = document.Visualizations
    .FirstOrDefault(v => v.Title == "Sales Chart");

// Find by type
var allGrids = document.Visualizations
    .OfType<GridVisualization>();

// Find by data source
var vizsUsingDataSource = document.Visualizations
    .Where(v => v.DataDefinition?.DataSourceItem?.Id == dataSourceId);
```

### Update All Visualizations

```csharp
// Make all visualizations visible
foreach (var viz in document.Visualizations)
{
    viz.IsTitleVisible = true;
}

// Update data source for all visualizations
var newDataSource = CreateNewDataSource();
foreach (var viz in document.Visualizations)
{
    viz.DataDefinition.DataSourceItem = newDataSource;
}
```

## Advanced Scenarios

### Conditional Dashboard Building

```csharp
var document = new RdashDocument("Dynamic Dashboard");

// Add visualizations based on data availability
if (HasSalesData())
{
    document.Visualizations.Add(CreateSalesChart());
}

if (HasInventoryData())
{
    document.Visualizations.Add(CreateInventoryGrid());
}

if (HasGeographicData())
{
    document.Visualizations.Add(CreateMap());
}
```

### Template Dashboards

```csharp
public RdashDocument CreateDashboardFromTemplate(string templatePath, 
    Dictionary<string, DataSourceItem> dataSources)
{
    // Load template
    var document = RdashDocument.Load(templatePath);
    
    // Replace data sources
    foreach (var viz in document.Visualizations)
    {
        var dataKey = viz.Tag; // Assuming tag identifies data source
        if (dataSources.ContainsKey(dataKey))
        {
            viz.DataDefinition.DataSourceItem = dataSources[dataKey];
        }
    }
    
    return document;
}
```

### Dashboard Validation

```csharp
public bool ValidateDashboard(RdashDocument document)
{
    // Check has title
    if (string.IsNullOrEmpty(document.Title))
        return false;
    
    // Check has visualizations
    if (document.Visualizations.Count == 0)
        return false;
    
    // Validate each visualization
    foreach (var viz in document.Visualizations)
    {
        if (viz.DataDefinition?.DataSourceItem == null)
            return false;
    }
    
    return true;
}
```

## Best Practices

### 1. Use Meaningful Titles

```csharp
// Good
var document = new RdashDocument("Q4 2024 Sales Performance Dashboard");

// Avoid
var document = new RdashDocument("Dashboard1");
```

### 2. Add Descriptions

```csharp
document.Description = "This dashboard tracks key sales metrics including " +
    "revenue by region, top performing products, and sales trends over time.";
```

### 3. Organize Data Sources

Keep track of data sources to avoid duplication:

```csharp
// Create reusable data source
var salesDB = new MicrosoftSqlServerDataSource 
{ 
    Host = "server.database.windows.net",
    Database = "SalesDB" 
};

// Use for multiple data source items
var salesItem = new TableDataSourceItem("Sales", salesDB);
var productsItem = new TableDataSourceItem("Products", salesDB);
```

### 4. Error Handling

```csharp
try
{
    var document = RdashDocument.Load(filePath);
    // Work with document
}
catch (FileNotFoundException)
{
    Console.WriteLine("Dashboard file not found");
}
catch (JsonException ex)
{
    Console.WriteLine($"Invalid dashboard format: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error loading dashboard: {ex.Message}");
}
```

### 5. Version Control

Include metadata for tracking:

```csharp
document.Tag = $"v1.0_{DateTime.Now:yyyyMMdd}";
document.Description = $"Created: {DateTime.Now:yyyy-MM-dd} by {Environment.UserName}";
```

## File Format

The `.rdash` file is a JSON file with this basic structure:

```json
{
  "Title": "Dashboard Title",
  "Description": "Dashboard description",
  "DataSources": [...],
  "Visualizations": [...],
  "Filters": [...],
  "Variables": [...]
}
```

You can inspect `.rdash` files in a text editor to see the underlying JSON structure.

## Performance Considerations

### Large Dashboards

For dashboards with many visualizations:

```csharp
// Load only when needed
var document = RdashDocument.Load("large-dashboard.rdash");

// Work with specific visualizations
var targetViz = document.Visualizations
    .FirstOrDefault(v => v.Title == "Specific Chart");

// Modify and save
document.Save("large-dashboard.rdash");
```

### Memory Management

```csharp
// Dispose of documents when done (if implementing IDisposable pattern)
using (var document = RdashDocument.Load("dashboard.rdash"))
{
    // Work with document
    ProcessDashboard(document);
}
// Document is disposed here
```

## Related Topics

- [Data Sources](data-sources.md) - Understanding data sources
- [Visualizations](visualizations.md) - Working with visualizations
- [Filters](filters.md) - Implementing filters
- [Variables](variables.md) - Using variables
- [How to Load and Save Dashboards](../how-to/dashboard-management/load-dashboards.md)

## Examples

See complete examples:
- [Sales Dashboard](../examples/sales-dashboard.md)
- [Healthcare Dashboard](../examples/healthcare-dashboard.md)
- [Marketing Dashboard](../examples/marketing-dashboard.md)
