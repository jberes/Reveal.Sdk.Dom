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
// Add a bar chart
var barChart = new BarChartVisualization("Top Products", dataSourceItem);
barChart.Labels.Add(new DimensionDataField("ProductName"));
barChart.Values.Add(new MeasureDataField("ProductSales"));
document.Visualizations.Add(barChart);

// Add a KPI
var kpi = new KpiTargetVisualization("Total Sales", dataSourceItem);
kpi.Date = new DimensionDataField("Date");
kpi.Value = new MeasureDataField("ProductSales") { Aggregation = AggregationType.Sum };
document.Visualizations.Add(kpi);
```

### Load an Existing Dashboard

Modify an existing `.rdash` file:

```csharp
var existingDocument = RdashDocument.Load("existing-dashboard.rdash");
existingDocument.Title = "Updated Dashboard";
existingDocument.Save("modified-dashboard.rdash");
```

### Use Different Data Sources

Connect to SQL Server:

```csharp
var sqlDataSource = new MicrosoftSqlServerDataSource
{
    Host = "your-server.database.windows.net",
    Database = "SalesDB",
    Title = "Sales Database"
};

var sqlDataSourceItem = new TableDataSourceItem("Sales", sqlDataSource)
{
    Table = "SalesData"
};
```

### Add Filters

Add dashboard-level filters:

```csharp
var dateFilter = new DashboardDateFilter("Date Range");
document.Filters.Add(dateFilter);

var categoryFilter = new DashboardDataFilter("Category", dataSourceItem);
categoryFilter.SelectedField = new DimensionDataField("CategoryName");
document.Filters.Add(categoryFilter);
```

## Learn More

- [Basic Concepts](basic-concepts.md) - Understand key concepts
- [Core Concepts](../core-concepts/rdash-document.md) - Deep dive into the document structure
- [How-To Guides](../how-to/README.md) - Task-specific guides
- [Examples](../examples/README.md) - More complete examples

## Common Patterns

### Builder Pattern (Alternative Approach)

You can also use builders for a more fluent API:

```csharp
var dataSourceItem = new RestServiceBuilder("https://api.example.com/data")
    .SetTitle("My API Data")
    .SetSubtitle("Sales Information")
    .SetFields(new List<Field>
    {
        new TextField("Name"),
        new NumberField("Amount")
    })
    .Build();
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
