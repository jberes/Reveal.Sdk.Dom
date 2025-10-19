# Quick Start: Build Your First Sales Dashboard

Transform raw sales data into a professional, interactive dashboard in 15 minutes using Reveal.Sdk.Dom.

## Learning Scenario: From Data to Insights

**Imagine this scenario:** You're a business analyst who has been given a REST API containing sales data by product category. Your manager needs a professional dashboard to visualize this data for tomorrow's executive meeting. You need to create an interactive dashboard that shows sales performance by category with just a few lines of code.

## What You'll Learn

By completing this quick start, you'll understand:

- **Dashboard Development Workflow** - The complete process from data to visualization
- **Data Source Integration** - How to connect to REST APIs and define data schemas
- **Visualization Creation** - Building charts with proper field mappings and aggregations
- **Document Architecture** - Understanding RdashDocument structure and properties
- **Code-First Approach** - Creating dashboards programmatically vs. manual design tools
- **Best Practices** - Professional patterns for reusable, maintainable dashboard code

## Why This Matters

This quick start demonstrates the **power of code-first dashboard development**:

- **Speed** - Create dashboards in minutes, not hours
- **Consistency** - Standardized styling and structure across all dashboards
- **Version Control** - Track dashboard changes like any other code
- **Automation** - Generate dashboards dynamically from templates
- **Integration** - Embed dashboard creation into your application workflows
- **Scalability** - Build once, deploy everywhere

## Learning Outcomes

After completing this guide, you'll have:

✅ **A working sales dashboard** (.rdash file) with professional pie chart visualization  
✅ **Practical experience** with the core Reveal.Sdk.Dom concepts  
✅ **Reusable code patterns** for connecting to APIs and creating visualizations  
✅ **Foundation knowledge** to build complex multi-visualization dashboards  
✅ **Confidence** to integrate dashboard generation into your applications

> 💡 **Time Investment**: 15 minutes to complete | **Prerequisites**: .NET development environment with Visual Studio or VS Code

## The Complete Journey: Step-by-Step

Let's build a professional sales dashboard that transforms this raw JSON data:

```json
[
  { "CategoryID": 1, "CategoryName": "Electronics", "ProductName": "Laptop", "ProductSales": 15000 },
  { "CategoryID": 1, "CategoryName": "Electronics", "ProductName": "Phone", "ProductSales": 12000 },
  { "CategoryID": 2, "CategoryName": "Clothing", "ProductName": "Jacket", "ProductSales": 8000 }
]
```

Into this beautiful, interactive dashboard visualization:
- **Professional pie chart** showing sales distribution by category
- **Proper data aggregation** summing sales across products
- **Interactive elements** for drilling down into data
- **Clean, modern styling** ready for executive presentation

Into this beautiful, interactive dashboard visualization:

- **Professional pie chart** showing sales distribution by category
- **Proper data aggregation** summing sales across products
- **Interactive elements** for drilling down into data
- **Clean, modern styling** ready for executive presentation

## Phase 1: Environment Setup (3 minutes)

### What We're Doing
Setting up a .NET project with Reveal.Sdk.Dom package and understanding the development environment.

### Why This Step Matters
A proper project setup ensures you have all dependencies and can focus on dashboard logic rather than configuration issues.

### Step 1: Create Your Project Foundation

```bash
# Create a new console application
dotnet new console -n SalesDashboardQuickStart

# Navigate to your project
cd SalesDashboardQuickStart

# Add the Reveal.Sdk.Dom package
dotnet add package Reveal.Sdk.Dom

# Verify installation
dotnet restore
```

### Step 2: Prepare Your Development Environment

Open `Program.cs` and replace the entire content with this foundation:

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.IO;

namespace SalesDashboardQuickStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🚀 Building your first sales dashboard...");
            
            // We'll build our dashboard here step by step
            
            Console.WriteLine("✅ Dashboard creation complete!");
        }
    }
}
```

**Checkpoint:** Run `dotnet run` to ensure everything compiles without errors.

```bash
dotnet run
# Expected output:
# 🚀 Building your first sales dashboard...
# ✅ Dashboard creation complete!
```

## Phase 2: Data Connection (4 minutes)

### What We're Doing
Connecting to a live REST API containing sales data and defining the data schema that Reveal needs to understand the structure.

### Why This Step Matters
Data sources are the foundation of any dashboard. Understanding how to connect to APIs and define schemas is essential for real-world dashboard development.

### Step 3: Create Your Data Source Connection

Add this code inside your `Main` method, replacing the comment:

```csharp
// Step 3: Create the dashboard document
var document = new RdashDocument("Sales Performance Dashboard")
{
    Description = "Executive sales overview - Built with Reveal.Sdk.Dom",
    Theme = Theme.Mountain  // Professional theme for business presentations
};

// Step 4: Connect to our sales data API
var salesAPI = new RestDataSource
{
    Title = "Sales Data Service",
    Subtitle = "Live sales data by product category", 
    Url = "https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9"
};

Console.WriteLine("📊 Connected to sales data API...");
```

### Step 4: Define Your Data Schema

APIs don't automatically provide schema information like databases do, so we must explicitly define what fields are available:

```csharp
// Step 5: Create data source item with explicit schema definition
var salesDataset = new RestDataSourceItem("Product Sales", salesAPI)
{
    Title = "Product Sales by Category",
    Subtitle = "Aggregated sales performance data"
};

// Step 6: Define the data fields (CRITICAL for API sources)
salesDataset.Fields.Add(new NumberField("CategoryID") 
{ 
    FieldLabel = "Category ID" 
});

salesDataset.Fields.Add(new TextField("CategoryName") 
{ 
    FieldLabel = "Product Category" 
});

salesDataset.Fields.Add(new TextField("ProductName") 
{ 
    FieldLabel = "Product Name" 
});

salesDataset.Fields.Add(new NumberField("ProductSales") 
{ 
    FieldLabel = "Sales Amount ($)" 
});

Console.WriteLine("📋 Defined data schema with 4 fields...");
```

**Understanding the Schema:**
- `NumberField` - For numeric data (IDs, sales amounts, quantities)
- `TextField` - For text data (names, categories, descriptions)  
- `DateField` - For dates and timestamps
- `BooleanField` - For true/false values

## Phase 3: Visualization Creation (5 minutes)

### What We're Doing
Creating a professional pie chart that aggregates sales data by category, with proper formatting and interactive features.

### Why This Step Matters
Visualizations transform raw data into insights. Understanding field mapping and aggregation is crucial for creating meaningful charts.

### Step 5: Build Your Professional Pie Chart

```csharp
// Step 7: Create an executive-ready pie chart
var salesPieChart = new PieChartVisualization("Sales Distribution by Category", salesDataset)
{
    IsTitleVisible = true,
    Description = "Revenue breakdown across product categories"
};

// Step 8: Configure the chart data mapping
// Labels: What categories to show (CategoryName field)
salesPieChart.Labels.Add(new DimensionDataField("CategoryName") 
{
    FieldLabel = "Product Category"
});

// Values: What to measure (ProductSales field, summed up)
salesPieChart.Values.Add(new MeasureDataField("ProductSales") 
{
    FieldLabel = "Total Sales ($)",
    Aggregation = AggregationType.Sum  // Sum all sales within each category
});

Console.WriteLine("📈 Created professional pie chart visualization...");
```

**Understanding the Field Mapping:**
- **Labels (Dimensions)** - How to group/categorize the data (CategoryName)
- **Values (Measures)** - What to calculate/aggregate (ProductSales summed by category)
- **Aggregation** - How to combine multiple values (Sum, Average, Count, etc.)

### Step 6: Add Visualization to Dashboard

```csharp
// Step 9: Add the chart to our dashboard
document.Visualizations.Add(salesPieChart);

Console.WriteLine("✨ Added visualization to dashboard...");
```

## Phase 4: Dashboard Generation (3 minutes)

### What We're Doing
Saving our dashboard to a .rdash file and understanding the output format for integration with Reveal applications.

### Why This Step Matters
The .rdash file is the portable dashboard format that can be loaded by Reveal SDK applications, shared with team members, or modified later.

### Step 7: Generate Your Dashboard File

```csharp
// Step 10: Save the dashboard to a file
var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SalesPerformanceDashboard.rdash");
document.Save(outputPath);

// Step 11: Provide success feedback
Console.WriteLine($"🎉 Dashboard saved successfully!");
Console.WriteLine($"📁 Location: {outputPath}");
Console.WriteLine($"📊 Contains: {document.Visualizations.Count} visualization(s)");
Console.WriteLine($"🏷️  Title: {document.Title}");
```

### Step 8: Test Your Complete Solution

Your final `Program.cs` should now contain the complete dashboard creation code. Run it to see your dashboard come to life:

```bash
dotnet run
```

**Expected Output:**
```bash
🚀 Building your first sales dashboard...
📊 Connected to sales data API...
📋 Defined data schema with 4 fields...
📈 Created professional pie chart visualization...
✨ Added visualization to dashboard...
🎉 Dashboard saved successfully!
📁 Location: C:\path\to\SalesPerformanceDashboard.rdash
📊 Contains: 1 visualization(s)
🏷️  Title: Sales Performance Dashboard
✅ Dashboard creation complete!
```

**Expected Output:**

```bash
🚀 Building your first sales dashboard...
📊 Connected to sales data API...
📋 Defined data schema with 4 fields...
📈 Created professional pie chart visualization...
✨ Added visualization to dashboard...
🎉 Dashboard saved successfully!
📁 Location: C:\path\to\SalesPerformanceDashboard.rdash
📊 Contains: 1 visualization(s)
🏷️  Title: Sales Performance Dashboard
✅ Dashboard creation complete!
```

## Understanding What You Built

Let's examine the key concepts you just implemented:

### The Dashboard Architecture

```csharp
var document = new RdashDocument("Sales Performance Dashboard")
```

**RdashDocument** is the root container that represents your entire dashboard. It's like a canvas that holds:

- **Metadata** - Title, description, theme
- **Visualizations** - Charts, grids, KPIs
- **Filters** - Interactive controls
- **Layout** - How components are arranged

### The Data Connection Pattern

```csharp
var salesAPI = new RestDataSource();           // Connection layer
var salesDataset = new RestDataSourceItem();   // Dataset layer
```

This **two-tier architecture** separates concerns:

- **DataSource** - "How do I connect?" (URL, authentication, connection settings)
- **DataSourceItem** - "What data do I get?" (specific endpoints, field definitions)

### Field Mapping and Aggregation

```csharp
pieChart.Labels.Add(new DimensionDataField("CategoryName"));
pieChart.Values.Add(new MeasureDataField("ProductSales") { Aggregation = AggregationType.Sum });
```

**Understanding the difference:**

- **Dimensions** - Categorical data for grouping (CategoryName, Region, Product)
- **Measures** - Numeric data for calculation (Sales, Revenue, Quantity)
- **Aggregation** - How to combine values (Sum, Average, Count, Min, Max)

### Dashboard Output Format

The `.rdash` file is a JSON-based format that contains:

```json
{
  "Title": "Sales Performance Dashboard",
  "Description": "Executive sales overview...",
  "Visualizations": [...],
  "DataSources": [...],
  "Filters": [...]
}
```

This format can be:

- **Loaded by Reveal SDK** applications
- **Shared with team members**
- **Version controlled** like any code file
- **Modified programmatically** for dynamic dashboards

## Your Next Learning Steps

Now that you've mastered the basics, expand your dashboard capabilities:

### 1. Add Multiple Visualizations (Next 10 minutes)

Enhance your dashboard with additional charts:

```csharp
// Add a bar chart for product comparison
var productBarChart = new BarChartVisualization("Top Products by Sales", salesDataset);
productBarChart.Labels.Add(new DimensionDataField("ProductName"));
productBarChart.Values.Add(new MeasureDataField("ProductSales") { Aggregation = AggregationType.Sum });
document.Visualizations.Add(productBarChart);

// Add a KPI for total sales
var totalSalesKPI = new KpiTargetVisualization("Total Sales Performance", salesDataset);
totalSalesKPI.Value = new MeasureDataField("ProductSales") { Aggregation = AggregationType.Sum };
document.Visualizations.Add(totalSalesKPI);

// Add a data grid for detailed view
var salesGrid = new GridVisualization("Sales Detail", salesDataset);
salesGrid.Columns.Add(new DimensionDataField("CategoryName"));
salesGrid.Columns.Add(new DimensionDataField("ProductName"));
salesGrid.Columns.Add(new MeasureDataField("ProductSales"));
document.Visualizations.Add(salesGrid);
```

### 2. Connect to Different Data Sources (Next tutorial)

Explore other data source types:

```csharp
// SQL Server database
var sqlSource = new MicrosoftSqlServerDataSource
{
    Host = "your-server.database.windows.net",
    Database = "SalesDB"
};

// Excel file
var excelSource = new ExcelDataSource();
var excelData = new ExcelDataSourceItem("Sales", excelSource)
{
    ResourcePath = @"C:\Data\Sales.xlsx",
    Sheet = "Sheet1"
};

// Google Sheets
var googleSource = new GoogleSheetsDataSource();
var sheetData = new GoogleSheetsDataSourceItem("Sales", googleSource);
```

### 3. Add Interactive Filters (Advanced topic)

Make your dashboard interactive:

```csharp
// Date range filter
var dateFilter = new DashboardDateFilter("Date Range");
document.Filters.Add(dateFilter);

// Category filter
var categoryFilter = new DashboardDataFilter("Category", salesDataset);
categoryFilter.SelectedField = new DimensionDataField("CategoryName");
document.Filters.Add(categoryFilter);
```

## Real-World Application Patterns

### Pattern 1: Data Source Factory

For production applications, use a factory pattern:

```csharp
public static class DataSourceFactory
{
    public static DataSourceItem GetSalesData(string environment)
    {
        var apiUrl = environment switch
        {
            "production" => "https://prod-api.company.com/sales",
            "staging" => "https://staging-api.company.com/sales",
            _ => "https://dev-api.company.com/sales"
        };

        var source = new RestDataSource { Url = apiUrl };
        var dataset = new RestDataSourceItem("Sales", source);
        
        // Add field definitions...
        
        return dataset;
    }
}
```

### Pattern 2: Dashboard Template System

Create reusable dashboard templates:

```csharp
public class SalesDashboardTemplate
{
    public static RdashDocument CreateExecutiveDashboard(DataSourceItem salesData)
    {
        var document = new RdashDocument("Executive Sales Dashboard")
        {
            Theme = Theme.Mountain,
            UseAutoLayout = true
        };

        // Add standard executive visualizations
        document.Visualizations.Add(CreateSalesKPI(salesData));
        document.Visualizations.Add(CreateTrendChart(salesData));
        document.Visualizations.Add(CreateCategoryBreakdown(salesData));

        return document;
    }

    private static KpiTargetVisualization CreateSalesKPI(DataSourceItem data)
    {
        var kpi = new KpiTargetVisualization("Sales Performance", data);
        kpi.Value = new MeasureDataField("ProductSales") { Aggregation = AggregationType.Sum };
        return kpi;
    }
    
    // Additional helper methods...
}
```

### Pattern 3: Configuration-Driven Dashboards

Generate dashboards from configuration:

```csharp
public class DashboardConfiguration
{
    public string Title { get; set; }
    public string DataSourceUrl { get; set; }
    public List<VisualizationConfig> Visualizations { get; set; }
}

public class VisualizationConfig
{
    public string Type { get; set; }  // "pie", "bar", "line"
    public string Title { get; set; }
    public string LabelField { get; set; }
    public string ValueField { get; set; }
}

public static RdashDocument CreateFromConfig(DashboardConfiguration config)
{
    var document = new RdashDocument(config.Title);
    var dataSource = CreateDataSource(config.DataSourceUrl);
    
    foreach (var vizConfig in config.Visualizations)
    {
        var visualization = vizConfig.Type switch
        {
            "pie" => CreatePieChart(vizConfig, dataSource),
            "bar" => CreateBarChart(vizConfig, dataSource),
            "line" => CreateLineChart(vizConfig, dataSource),
            _ => throw new ArgumentException($"Unknown visualization type: {vizConfig.Type}")
        };
        
        document.Visualizations.Add(visualization);
    }
    
    return document;
}
```

## Troubleshooting Your Dashboard

### Common Issues and Solutions

**Problem:** "Fields not found" error
```csharp
// ❌ Incorrect field name
pieChart.Labels.Add(new DimensionDataField("Category"));  // Field doesn't exist

// ✅ Correct field name (matches what you defined)
pieChart.Labels.Add(new DimensionDataField("CategoryName"));  // Matches field definition
```

**Problem:** No data showing in visualization
```csharp
// ❌ Missing aggregation for measures
pieChart.Values.Add(new MeasureDataField("ProductSales"));  // No aggregation

// ✅ Proper aggregation specified
pieChart.Values.Add(new MeasureDataField("ProductSales") { Aggregation = AggregationType.Sum });
```

**Problem:** API connection issues
```csharp
// ✅ Add error handling for production
try
{
    var document = CreateDashboard();
    document.Save("dashboard.rdash");
    Console.WriteLine("Dashboard created successfully!");
}
catch (Exception ex)
{
    Console.WriteLine($"Error creating dashboard: {ex.Message}");
    // Log error details for debugging
}
```

## Congratulations! 🎉

You've successfully completed your first Reveal.Sdk.Dom dashboard! You now understand:

✅ **The complete workflow** from data source to visualization  
✅ **Core architecture concepts** that apply to all dashboard development  
✅ **Professional patterns** for reusable, maintainable code  
✅ **Foundation skills** to build complex, multi-visualization dashboards

## Continue Your Learning Journey

Ready to take your dashboard skills to the next level?

### Immediate Next Steps

1. **[Basic Concepts](basic-concepts.md)** - Deep dive into core concepts and terminology
2. **[Data Sources Guide](../core-concepts/data-sources.md)** - Master all 30+ data source types
3. **[Visualization Guide](../how-to/visualizations/create-charts.md)** - Explore all chart types and customization options

### Skill-Building Tutorials

4. **[Connect to SQL Server](../how-to/data-sources/connect-to-sql-server.md)** - Enterprise database integration
5. **[Multi-Source Dashboards](../examples/multi-source-dashboard.md)** - Combine data from multiple systems
6. **[Advanced Filtering](../how-to/filters/dashboard-filters.md)** - Create interactive, drill-down experiences

### Professional Development

7. **[Best Practices](../best-practices.md)** - Production-ready patterns and performance optimization
8. **[Enterprise Examples](../examples/README.md)** - Real-world dashboard implementations
9. **[API Reference](../api-reference/README.md)** - Complete technical documentation

> 💡 **Pro Tip**: The concepts you learned here (data sources, visualizations, field mapping) apply to every dashboard you'll build. Master these fundamentals, and complex dashboards become simple combinations of these building blocks.

Ready to build your next dashboard? Start with the scenario that matches your needs!
