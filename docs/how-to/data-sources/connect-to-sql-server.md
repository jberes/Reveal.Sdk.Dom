# How to Connect to SQL Server

Learn how to connect to Microsoft SQL Server databases and create visualizations from SQL data.

## Basic Connection

### Step 1: Create the Data Source

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;

var sqlDataSource = new MicrosoftSqlServerDataSource
{
    Host = "myserver.database.windows.net",
    Database = "SalesDB",
    Title = "Sales Database",
    Subtitle = "Production"
};
```

### Step 2: Create a Data Source Item

For a table:

```csharp
var salesTable = new TableDataSourceItem("Sales", sqlDataSource)
{
    Title = "Sales Data",
    Subtitle = "All Sales Records",
    Table = "Sales"
};
```

For a view:

```csharp
var salesView = new TableDataSourceItem("Sales Summary", sqlDataSource)
{
    Title = "Sales Summary",
    Table = "vw_SalesSummary"
};
```

### Step 3: Create a Visualization

```csharp
var document = new RdashDocument("Sales Dashboard");

var chart = new BarChartVisualization("Sales by Region", salesTable);
chart.Labels.Add(new DimensionDataField("Region"));
chart.Values.Add(new MeasureDataField("TotalSales") 
{ 
    Aggregation = AggregationType.Sum 
});

document.Visualizations.Add(chart);
document.Save("sales-dashboard.rdash");
```

## Using Stored Procedures

### Simple Stored Procedure

```csharp
var salesProc = new ProcedureDataSourceItem("Monthly Sales", sqlDataSource)
{
    Procedure = "usp_GetMonthlySales"
};

var chart = new LineChartVisualization("Monthly Trends", salesProc);
chart.Labels.Add(new DateDataField("Month"));
chart.Values.Add(new MeasureDataField("Sales"));
```

### Stored Procedure with Parameters

```csharp
var salesProcWithParams = new ProcedureDataSourceItem("Filtered Sales", sqlDataSource)
{
    Procedure = "usp_GetSalesByYearAndRegion",
    ProcedureParameters = new Dictionary<string, object>
    {
        { "@Year", 2024 },
        { "@Region", "North America" }
    }
};
```

## Using Functions

### Table-Valued Function

```csharp
var salesFunction = new FunctionDataSourceItem("Sales Function", sqlDataSource)
{
    Function = "fn_GetTopProducts",
    FunctionParameters = new Dictionary<string, object>
    {
        { "@TopN", 10 },
        { "@StartDate", new DateTime(2024, 1, 1) }
    }
};
```

## Multiple Tables from Same Database

Reuse the connection for multiple tables:

```csharp
var sqlDataSource = new MicrosoftSqlServerDataSource
{
    Host = "myserver.database.windows.net",
    Database = "CompanyDB",
    Title = "Company Database"
};

// Create multiple data source items
var salesTable = new TableDataSourceItem("Sales", sqlDataSource)
{
    Table = "Sales"
};

var customersTable = new TableDataSourceItem("Customers", sqlDataSource)
{
    Table = "Customers"
};

var productsTable = new TableDataSourceItem("Products", sqlDataSource)
{
    Table = "Products"
};

// Create visualizations from different tables
var document = new RdashDocument("Company Dashboard");

var salesChart = new BarChartVisualization("Sales", salesTable);
// Configure salesChart...
document.Visualizations.Add(salesChart);

var customerGrid = new GridVisualization("Customers", customersTable);
// Configure customerGrid...
document.Visualizations.Add(customerGrid);
```

## Schema Specification

If your tables are in specific schemas:

```csharp
var salesTable = new TableDataSourceItem("Sales", sqlDataSource)
{
    Schema = "sales",
    Table = "Orders"
};

var hrTable = new TableDataSourceItem("Employees", sqlDataSource)
{
    Schema = "hr",
    Table = "Employees"
};
```

## Azure SQL Database

For Azure SQL Database, use the same approach or the Azure-specific class:

```csharp
var azureSql = new MicrosoftAzureSqlServerDataSource
{
    Host = "myserver.database.windows.net",
    Database = "SalesDB",
    Title = "Azure Sales DB"
};

var salesData = new TableDataSourceItem("Sales", azureSql)
{
    Table = "Sales"
};
```

## Advanced Example: Complete Dashboard

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

public class SalesDashboardBuilder
{
    public RdashDocument CreateSalesDashboard(string server, string database)
    {
        // Create data source
        var sqlDataSource = new MicrosoftSqlServerDataSource
        {
            Host = server,
            Database = database,
            Title = "Sales Database"
        };

        // Create data source items
        var salesTable = new TableDataSourceItem("Sales", sqlDataSource)
        {
            Table = "Sales"
        };

        var productsTable = new TableDataSourceItem("Products", sqlDataSource)
{
            Table = "Products"
        };

        // Create dashboard
        var document = new RdashDocument("Sales Performance Dashboard")
        {
            Description = "Comprehensive sales metrics and analysis",
            UseAutoLayout = true
        };

        // Add KPI
        var kpi = new KpiTargetVisualization("Total Sales", salesTable);
        kpi.Value = new MeasureDataField("Revenue") 
        { 
            Aggregation = AggregationType.Sum,
            FieldLabel = "Total Revenue"
        };
        kpi.Target = new MeasureDataField("Target") 
        { 
            Aggregation = AggregationType.Sum 
        };
        kpi.Date = new DateDataField("OrderDate");
        document.Visualizations.Add(kpi);

        // Add sales by region chart
        var regionChart = new ColumnChartVisualization("Sales by Region", salesTable);
        regionChart.Labels.Add(new DimensionDataField("Region"));
        regionChart.Values.Add(new MeasureDataField("Revenue") 
        { 
            Aggregation = AggregationType.Sum,
            FieldLabel = "Revenue"
        });
        document.Visualizations.Add(regionChart);

        // Add trend chart
        var trendChart = new LineChartVisualization("Sales Trend", salesTable);
        trendChart.Labels.Add(new DateDataField("OrderDate"));
        trendChart.Values.Add(new MeasureDataField("Revenue") 
        { 
            Aggregation = AggregationType.Sum 
        });
        document.Visualizations.Add(trendChart);

        // Add products grid
        var productsGrid = new GridVisualization("Products", productsTable);
        productsGrid.Columns.Add(new DimensionDataField("ProductName"));
        productsGrid.Columns.Add(new DimensionDataField("Category"));
        productsGrid.Columns.Add(new MeasureDataField("Price"));
        productsGrid.Columns.Add(new MeasureDataField("UnitsInStock"));
        document.Visualizations.Add(productsGrid);

        return document;
    }
}

// Usage
var builder = new SalesDashboardBuilder();
var dashboard = builder.CreateSalesDashboard(
    "myserver.database.windows.net", 
    "SalesDB"
);
dashboard.Save("sales-dashboard.rdash");
```

## Connection String Configuration

Store connection details in configuration:

```csharp
using Microsoft.Extensions.Configuration;

public class DataSourceFactory
{
    private readonly IConfiguration _configuration;

    public DataSourceFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public MicrosoftSqlServerDataSource CreateProductionDatabase()
    {
        return new MicrosoftSqlServerDataSource
        {
            Host = _configuration["Database:Host"],
            Database = _configuration["Database:Name"],
            Port = int.Parse(_configuration["Database:Port"] ?? "1433"),
            Title = "Production Database"
        };
    }
}
```

## Best Practices

### 1. Reuse Data Source Definitions

```csharp
// Create once
var sqlDataSource = new MicrosoftSqlServerDataSource { ... };

// Use multiple times
var table1 = new TableDataSourceItem("Table1", sqlDataSource);
var table2 = new TableDataSourceItem("Table2", sqlDataSource);
```

### 2. Use Meaningful Titles

```csharp
var salesData = new TableDataSourceItem("Sales Data", sqlDataSource)
{
    Title = "Sales Transactions",
    Subtitle = "Last 12 Months",
    Table = "Sales"
};
```

### 3. Organize by Purpose

```csharp
public class DataSourceRepository
{
    private readonly MicrosoftSqlServerDataSource _salesDB;

    public DataSourceRepository()
    {
        _salesDB = new MicrosoftSqlServerDataSource { ... };
    }

    public TableDataSourceItem GetSalesData() => 
        new TableDataSourceItem("Sales", _salesDB) { Table = "Sales" };

    public TableDataSourceItem GetCustomersData() => 
        new TableDataSourceItem("Customers", _salesDB) { Table = "Customers" };
}
```

### 4. Handle Different Environments

```csharp
public MicrosoftSqlServerDataSource GetDataSource(string environment)
{
    return environment switch
    {
        "Production" => new MicrosoftSqlServerDataSource
        {
            Host = "prod-server.database.windows.net",
            Database = "ProdDB"
        },
        "Development" => new MicrosoftSqlServerDataSource
        {
            Host = "dev-server.database.windows.net",
            Database = "DevDB"
        },
        _ => throw new ArgumentException("Unknown environment")
    };
}
```

## Troubleshooting

### Issue: Cannot connect to database

**Solution**: Ensure firewall rules allow connection and credentials are correct. Authentication is configured at runtime in the Reveal SDK.

### Issue: Table not found

**Solution**: Check table name spelling and schema:

```csharp
var salesTable = new TableDataSourceItem("Sales", sqlDataSource)
{
    Schema = "dbo",  // Specify schema if needed
    Table = "Sales"
};
```

### Issue: Procedure parameters not working

**Solution**: Ensure parameter names match exactly:

```csharp
ProcedureParameters = new Dictionary<string, object>
{
    { "@Year", 2024 },  // Include @ if procedure expects it
    { "@Region", "North" }
}
```

## Related Topics

- [Data Sources Overview](../../core-concepts/data-sources.md)
- [Connect to REST APIs](connect-to-rest-api.md)
- [Work with Excel Files](work-with-excel.md)
- [Data Sources API Reference](../../api-reference/data-sources/README.md)

## Examples

See complete examples:
- [Sales Dashboard](../../examples/sales-dashboard.md)
- [Healthcare Dashboard](../../examples/healthcare-dashboard.md)
