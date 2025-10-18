# Quick Start Guide

Get started with Reveal.Sdk.Dom by creating your first dashboard in just a few minutes.

## Your First Dashboard

This guide will walk you through creating a simple dashboard with a pie chart visualization using data from a REST API.

### Step 1: Create a New Project

If you haven't already, create a new .NET console application:

```bash
dotnet new console -n MyRevealDashboard
cd MyRevealDashboard
dotnet add package Reveal.Sdk.Dom
```

### Step 2: Import Namespaces

Open `Program.cs` and add the necessary using statements:

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.IO;
```

### Step 3: Create a Dashboard with a Visualization

Replace the contents of your `Program.cs` with the following code:

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using System.IO;

namespace MyRevealDashboard
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Create the dashboard document
            var document = new RdashDocument("Sales by Category");
            document.Description = "My first Reveal dashboard created with code!";

            // Step 2: Create a REST data source
            var restDataSource = new RestDataSource
            {
                Title = "Sales Data",
                Subtitle = "Product Sales by Category",
                Url = "https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9"
            };

            // Step 3: Create a data source item with field definitions
            var dataSourceItem = new RestDataSourceItem("Sales Data", restDataSource);
            dataSourceItem.Fields.Add(new NumberField("CategoryID"));
            dataSourceItem.Fields.Add(new TextField("CategoryName"));
            dataSourceItem.Fields.Add(new TextField("ProductName"));
            dataSourceItem.Fields.Add(new NumberField("ProductSales"));

            // Step 4: Create a pie chart visualization
            var pieChart = new PieChartVisualization("Sales by Category", dataSourceItem)
            {
                IsTitleVisible = true,
                Description = "Product sales broken down by category"
            };
            
            // Configure the chart
            pieChart.Labels.Add(new DimensionDataField("CategoryName"));
            pieChart.Values.Add(new MeasureDataField("ProductSales")
            {
                Aggregation = AggregationType.Sum
            });

            // Step 5: Add the visualization to the dashboard
            document.Visualizations.Add(pieChart);

            // Step 6: Save the dashboard
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "MySalesDashboard.rdash");
            document.Save(filePath);

            Console.WriteLine($"Dashboard created successfully!");
            Console.WriteLine($"Location: {filePath}");
        }
    }
}
```

### Step 4: Run the Application

Run your application:

```bash
dotnet run
```

You should see output similar to:

```
Dashboard created successfully!
Location: C:\path\to\MySalesDashboard.rdash
```

### Step 5: View Your Dashboard

You can now:

1. **Use the Reveal SDK** to load and display the `.rdash` file in your application
2. **Open it in Reveal** if you have the Reveal application installed
3. **Inspect the file** - it's a JSON-based format that you can examine

## Understanding the Code

Let's break down what we just did:

### Creating the Document

```csharp
var document = new RdashDocument("Sales by Category");
```

The `RdashDocument` is the root object that represents your entire dashboard. You can set properties like title, description, and theme.

### Defining the Data Source

```csharp
var restDataSource = new RestDataSource
{
    Url = "https://excel2json.io/api/share/..."
};
```

Data sources define where your data comes from. Reveal.Sdk.Dom supports 30+ data source types including SQL Server, Excel, REST APIs, and more.

### Creating a Data Source Item

```csharp
var dataSourceItem = new RestDataSourceItem("Sales Data", restDataSource);
dataSourceItem.Fields.Add(new NumberField("CategoryID"));
```

Data source items represent a specific dataset from a data source (like a table, query result, or API response). You must define the fields returned by the data.

### Creating a Visualization

```csharp
var pieChart = new PieChartVisualization("Sales by Category", dataSourceItem);
pieChart.Labels.Add(new DimensionDataField("CategoryName"));
pieChart.Values.Add(new MeasureDataField("ProductSales"));
```

Visualizations display your data. Each visualization type has specific properties for labels, values, colors, etc.

### Saving the Dashboard

```csharp
document.Save(filePath);
```

This saves your dashboard to a `.rdash` file that can be loaded by the Reveal SDK or modified later.

## Next Steps

Now that you've created your first dashboard, explore more features:

### Add More Visualizations

Add different chart types to your dashboard:

```csharp
// Add a bar chart for top products
var barChart = new BarChartVisualization("Top Products", dataSourceItem);
barChart.Labels.Add(new DimensionDataField("ProductName"));
barChart.Values.Add(new MeasureDataField("ProductSales") { Aggregation = AggregationType.Sum });
document.Visualizations.Add(barChart);

// Add a KPI for total sales
var kpi = new KpiTargetVisualization("Total Sales", dataSourceItem);
kpi.Date = new DateDataField("Date") { Aggregation = DateAggregationType.Month };
kpi.Value = new MeasureDataField("ProductSales") { Aggregation = AggregationType.Sum };
kpi.Target = new MeasureDataField("TargetSales") { Aggregation = AggregationType.Sum };
document.Visualizations.Add(kpi);

// Add a line chart for trends
var lineChart = new LineChartVisualization("Sales Trend", dataSourceItem);
lineChart.Labels.Add(new DateDataField("Date") { Aggregation = DateAggregationType.Month });
lineChart.Values.Add(new MeasureDataField("ProductSales") { Aggregation = AggregationType.Sum });
document.Visualizations.Add(lineChart);
```

### Load an Existing Dashboard

Modify an existing `.rdash` file:

```csharp
// Load existing dashboard
var existingDocument = RdashDocument.Load("existing-dashboard.rdash");
existingDocument.Title = "Updated Dashboard";

// Add new visualization
var newChart = new ColumnChartVisualization("New Chart", dataSourceItem);
newChart.Labels.Add(new DimensionDataField("Category"));
newChart.Values.Add(new MeasureDataField("Sales") { Aggregation = AggregationType.Sum });
existingDocument.Visualizations.Add(newChart);

// Save with new name
existingDocument.Save("modified-dashboard.rdash");
```

### Use Different Data Sources

#### SQL Server Example

```csharp
var sqlDataSource = new MicrosoftSqlServerDataSource
{
    Host = "your-server.database.windows.net",
    Database = "SalesDB",
    Title = "Sales Database"
};

var sqlDataSourceItem = new TableDataSourceItem("Sales", sqlDataSource)
{
    Table = "SalesData",
    Title = "Sales Transactions"
};

// Use in visualization
var sqlChart = new BarChartVisualization("SQL Sales", sqlDataSourceItem);
sqlChart.Labels.Add(new DimensionDataField("Region"));
sqlChart.Values.Add(new MeasureDataField("Revenue") { Aggregation = AggregationType.Sum });
```

#### Excel File Example

```csharp
var excelDataSource = new ExcelDataSource
{
    Title = "Sales Spreadsheet"
};

var excelDataSourceItem = new ExcelDataSourceItem("Sales", excelDataSource)
{
    ResourcePath = @"C:\Data\Sales.xlsx",
    Sheet = "Sheet1",
    FirstRowContainsLabels = true,
    Fields = new List<IField>
    {
        new TextField("Product"),
        new NumberField("Revenue"),
        new DateField("Date")
    }
};
```

### Add Dashboard Filters

Make your dashboard interactive with filters:

```csharp
// Add date range filter
var dateFilter = new DashboardDateFilter("Date Range");
document.Filters.Add(dateFilter);

// Add category filter
var categoryFilter = new DashboardDataFilter("Category", dataSourceItem);
categoryFilter.SelectedField = new DimensionDataField("CategoryName");
document.Filters.Add(categoryFilter);

// Filters automatically connect to visualizations that use matching fields
```

## Learn More

- [Basic Concepts](basic-concepts.md) - Understand key concepts
- [Core Concepts](../core-concepts/rdash-document.md) - Deep dive into the document structure
- [How-To Guides](../how-to/README.md) - Task-specific guides
- [Examples](../examples/README.md) - More complete examples

## Advanced Patterns

### Builder Pattern with Data Source Factory

For larger applications, use a factory pattern to manage data sources:

```csharp
public class DataSourceFactory
{
    private static readonly RestDataSource _excelSource = new RestDataSource
    {
        Id = "SampleExcel",
        Title = "Sample Excel Data",
        Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx"
    };

    public static DataSourceItem GetSalesData()
    {
        var dataItem = new RestDataSourceItem("Sales", _excelSource)
        {
            Title = "Sales Data",
            Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx",
            IsAnonymous = true,
            Fields = new List<IField>
            {
                new TextField("Territory"),
                new DateField("Date"),
                new NumberField("Revenue"),
                new NumberField("Target"),
                new TextField("Product")
            }
        };
        dataItem.UseExcel("Sales");
        return dataItem;
    }

    public static DataSourceItem GetMarketingData()
    {
        var dataItem = new RestDataSourceItem("Marketing", _excelSource)
        {
            Title = "Marketing Data",
            Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx",
            IsAnonymous = true,
            Fields = new List<IField>
            {
                new DateField("Date"),
                new NumberField("Spend"),
                new NumberField("Budget"),
                new NumberField("CTR"),
                new TextField("CampaignID")
            }
        };
        dataItem.UseExcel("Marketing");
        return dataItem;
    }
}

// Usage
var salesData = DataSourceFactory.GetSalesData();
var marketingData = DataSourceFactory.GetMarketingData();
```

### Complete Dashboard with Multiple Visualizations and Filters

```csharp
public RdashDocument CreateComprehensiveDashboard()
{
    var document = new RdashDocument("Business Performance Dashboard")
    {
        Description = "Comprehensive business metrics and KPIs",
        UseAutoLayout = true,
        Theme = Theme.Ocean
    };

    // Get data sources
    var salesData = DataSourceFactory.GetSalesData();
    var marketingData = DataSourceFactory.GetMarketingData();

    // Add dashboard filters
    var dateFilter = new DashboardDateFilter("Date Range");
    document.Filters.Add(dateFilter);

    var territoryFilter = new DashboardDataFilter("Territory", salesData);
    territoryFilter.SelectedField = new DimensionDataField("Territory");
    document.Filters.Add(territoryFilter);

    // 1. Sales KPI with target
    var salesKpi = new KpiTargetVisualization("Sales Performance", salesData)
    {
        IsTitleVisible = true
    };
    salesKpi.Date = new DimensionDataField("Date") { Aggregation = DateAggregationType.Month };
    salesKpi.Value = new MeasureDataField("Revenue") 
    { 
        Aggregation = AggregationType.Sum,
        Formatting = new NumberFormatting
        {
            FormatType = NumberFormattingType.Currency,
            CurrencySymbol = "$",
            ShowGroupingSeparator = true
        }
    };
    salesKpi.Target = new MeasureDataField("Target") { Aggregation = AggregationType.Sum };
    document.Visualizations.Add(salesKpi);

    // 2. Revenue trend line chart
    var revenueTrend = new LineChartVisualization("Revenue Trend", salesData);
    revenueTrend.Labels.Add(new DimensionDataField("Date") { Aggregation = DateAggregationType.Month });
    revenueTrend.Values.Add(new MeasureDataField("Revenue") { Aggregation = AggregationType.Sum });
    document.Visualizations.Add(revenueTrend);

    // 3. Sales by territory bar chart
    var territoryChart = new BarChartVisualization("Sales by Territory", salesData);
    territoryChart.Labels.Add(new DimensionDataField("Territory"));
    territoryChart.Values.Add(new MeasureDataField("Revenue") 
    { 
        Aggregation = AggregationType.Sum,
        Sorting = SortingType.Desc  // Sort by highest first
    });
    document.Visualizations.Add(territoryChart);

    // 4. Marketing spend vs budget
    var marketingKpi = new KpiTargetVisualization("Marketing Spend vs Budget", marketingData);
    marketingKpi.Date = new DimensionDataField("Date") { Aggregation = DateAggregationType.Month };
    marketingKpi.Value = new MeasureDataField("Spend") { Aggregation = AggregationType.Sum };
    marketingKpi.Target = new MeasureDataField("Budget") { Aggregation = AggregationType.Sum };
    document.Visualizations.Add(marketingKpi);

    // 5. Campaign performance pivot table
    var campaignPivot = new PivotVisualization("Campaign Performance", marketingData);
    campaignPivot.Rows.Add(new DimensionDataField("CampaignID"));
    campaignPivot.Values.Add(new MeasureDataField("Spend") { Aggregation = AggregationType.Sum });
    campaignPivot.Values.Add(new MeasureDataField("CTR") 
    { 
        Aggregation = AggregationType.Average,
        Formatting = new NumberFormatting { FormatType = NumberFormattingType.Percent }
    });
    document.Visualizations.Add(campaignPivot);

    // 6. Product sales pie chart
    var productPie = new PieChartVisualization("Sales by Product", salesData);
    productPie.Labels.Add(new DimensionDataField("Product"));
    productPie.Values.Add(new MeasureDataField("Revenue") { Aggregation = AggregationType.Sum });
    document.Visualizations.Add(productPie);

    return document;
}
```

### Working with Manual Layout

For precise dashboard layouts, use manual positioning:

```csharp
var document = new RdashDocument("Precision Dashboard")
{
    UseAutoLayout = false  // Enable manual positioning
};

// Top row - KPIs
var kpi1 = new KpiTargetVisualization("Sales", salesData)
{
    Column = 0,      // Left position
    Row = 0,         // Top position
    ColumnSpan = 20, // Width (out of 48 columns)
    RowSpan = 15     // Height
};

var kpi2 = new KpiTargetVisualization("Marketing", marketingData)
{
    Column = 20,     // Next to first KPI
    Row = 0,
    ColumnSpan = 20,
    RowSpan = 15
};

// Bottom row - Charts
var chart1 = new LineChartVisualization("Trend", salesData)
{
    Column = 0,
    Row = 15,        // Below KPIs
    ColumnSpan = 24, // Half width
    RowSpan = 20
};

var chart2 = new BarChartVisualization("Comparison", salesData)
{
    Column = 24,     // Right side
    Row = 15,
    ColumnSpan = 24, // Half width
    RowSpan = 20
};

document.Visualizations.Add(kpi1);
document.Visualizations.Add(kpi2);
document.Visualizations.Add(chart1);
document.Visualizations.Add(chart2);
```

### Export to Reveal SDK

Convert your dashboard to JSON for use in the Reveal SDK:

```csharp
var json = document.ToJsonString();
// Use with Reveal SDK:
// var revealDashboard = await RVDashboard.LoadFromJsonAsync(json);
```

## Need Help?

- Check the [FAQ](../faq.md) for common questions
- See [Troubleshooting](../troubleshooting.md) for solutions to common issues
- Visit [GitHub Issues](https://github.com/RevealBi/Reveal.Sdk.Dom/issues) to report problems
