# Working with Multiple Data Sources

Learn how to combine data from different sources in a single dashboard - SQL databases, REST APIs, Excel files, and cloud services.

## Overview

Modern dashboards often need to combine data from multiple sources to provide comprehensive insights. Reveal.Sdk.Dom makes this easy by allowing you to:

- Use different data source types in the same dashboard
- Reuse connection definitions across multiple data items
- Create relationships between data from different sources
- Apply consistent filtering across heterogeneous data

## Basic Multi-Source Dashboard

### Example: Sales + Marketing + Finance Dashboard

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

public class MultiSourceDashboardCreator
{
    public RdashDocument CreateMultiSourceDashboard()
    {
        var document = new RdashDocument("Executive Dashboard")
        {
            Description = "Sales, Marketing, and Finance metrics combined",
            UseAutoLayout = true,
            Theme = Theme.Ocean
        };

        // Create different data sources
        var sqlSalesData = CreateSqlSalesData();
        var restMarketingData = CreateRestMarketingData();
        var excelFinanceData = CreateExcelFinanceData();

        // Add global date filter that works across all sources
        var dateFilter = new DashboardDateFilter("Date Range");
        document.Filters.Add(dateFilter);

        // Sales visualizations (SQL Server)
        document.Visualizations.Add(CreateSalesKpi(sqlSalesData));
        document.Visualizations.Add(CreateRevenueTrend(sqlSalesData));

        // Marketing visualizations (REST API)
        document.Visualizations.Add(CreateMarketingSpend(restMarketingData));
        document.Visualizations.Add(CreateCampaignPerformance(restMarketingData));

        // Finance visualizations (Excel)
        document.Visualizations.Add(CreateBudgetAnalysis(excelFinanceData));
        document.Visualizations.Add(CreateExpenseBreakdown(excelFinanceData));

        return document;
    }

    private DataSourceItem CreateSqlSalesData()
    {
        var sqlDataSource = new MicrosoftSqlServerDataSource
        {
            Host = "sales-server.database.windows.net",
            Database = "SalesDB",
            Title = "Sales Database",
            Subtitle = "Production SQL Server"
        };

        return new TableDataSourceItem("Sales", sqlDataSource)
        {
            Title = "Sales Transactions",
            Table = "SalesData",
            // Fields auto-discovered from database schema
        };
    }

    private DataSourceItem CreateRestMarketingData()
    {
        var restDataSource = new RestDataSource
        {
            Title = "Marketing API",
            Subtitle = "Campaign data from marketing platform",
            Url = "https://api.marketing.example.com/v1"
        };

        var dataItem = new RestDataSourceItem("Marketing", restDataSource)
        {
            Title = "Campaign Data",
            Url = "https://api.marketing.example.com/v1/campaigns",
            Fields = new List<IField>
            {
                new DateField("Date"),
                new NumberField("Spend"),
                new NumberField("Impressions"),
                new NumberField("Clicks"),
                new NumberField("Conversions"),
                new TextField("CampaignName"),
                new TextField("Source")
            }
        };

        return dataItem;
    }

    private DataSourceItem CreateExcelFinanceData()
    {
        var excelDataSource = new ExcelDataSource
        {
            Title = "Finance Spreadsheet",
            Subtitle = "Monthly budget and expense data"
        };

        var dataItem = new ExcelDataSourceItem("Finance", excelDataSource)
        {
            Title = "Budget Data",
            ResourcePath = @"\\shared\finance\budget-2024.xlsx",
            Sheet = "Monthly Budget",
            FirstRowContainsLabels = true,
            Fields = new List<IField>
            {
                new DateField("Month"),
                new TextField("Department"),
                new NumberField("Budget"),
                new NumberField("Actual"),
                new NumberField("Variance"),
                new TextField("Category")
            }
        };

        return dataItem;
    }

    // Sales visualizations
    private Visualization CreateSalesKpi(DataSourceItem salesData)
    {
        var kpi = new KpiTargetVisualization("Revenue vs Target", salesData);
        kpi.Date = new DimensionDataField("OrderDate") { Aggregation = DateAggregationType.Month };
        kpi.Value = new MeasureDataField("Revenue") { Aggregation = AggregationType.Sum };
        kpi.Target = new MeasureDataField("Target") { Aggregation = AggregationType.Sum };
        return kpi;
    }

    private Visualization CreateRevenueTrend(DataSourceItem salesData)
    {
        var chart = new LineChartVisualization("Revenue Trend", salesData);
        chart.Labels.Add(new DimensionDataField("OrderDate") { Aggregation = DateAggregationType.Month });
        chart.Values.Add(new MeasureDataField("Revenue") { Aggregation = AggregationType.Sum });
        return chart;
    }

    // Marketing visualizations  
    private Visualization CreateMarketingSpend(DataSourceItem marketingData)
    {
        var chart = new ColumnChartVisualization("Marketing Spend by Source", marketingData);
        chart.Labels.Add(new DimensionDataField("Source"));
        chart.Values.Add(new MeasureDataField("Spend") { Aggregation = AggregationType.Sum });
        return chart;
    }

    private Visualization CreateCampaignPerformance(DataSourceItem marketingData)
    {
        var pivot = new PivotVisualization("Campaign Performance", marketingData);
        pivot.Rows.Add(new DimensionDataField("CampaignName"));
        pivot.Values.Add(new MeasureDataField("Spend") { Aggregation = AggregationType.Sum });
        pivot.Values.Add(new MeasureDataField("Conversions") { Aggregation = AggregationType.Sum });
        return pivot;
    }

    // Finance visualizations
    private Visualization CreateBudgetAnalysis(DataSourceItem financeData)
    {
        var chart = new BarChartVisualization("Budget vs Actual by Department", financeData);
        chart.Labels.Add(new DimensionDataField("Department"));
        chart.Values.Add(new MeasureDataField("Budget") { Aggregation = AggregationType.Sum });
        chart.Values.Add(new MeasureDataField("Actual") { Aggregation = AggregationType.Sum });
        return chart;
    }

    private Visualization CreateExpenseBreakdown(DataSourceItem financeData)
    {
        var pie = new PieChartVisualization("Expenses by Category", financeData);
        pie.Labels.Add(new DimensionDataField("Category"));
        pie.Values.Add(new MeasureDataField("Actual") { Aggregation = AggregationType.Sum });
        return pie;
    }
}
```

## Data Source Factory Pattern

For larger applications, centralize data source management:

```csharp
public class EnterpriseDataSourceFactory
{
    // Centralized data source definitions
    private static readonly MicrosoftSqlServerDataSource _salesDB = new()
    {
        Host = Configuration["Database:Sales:Host"],
        Database = Configuration["Database:Sales:Name"],
        Title = "Sales Database"
    };

    private static readonly RestDataSource _marketingAPI = new()
    {
        Title = "Marketing API",
        Url = Configuration["APIs:Marketing:BaseUrl"]
    };

    private static readonly ExcelDataSource _financeSheets = new()
    {
        Title = "Finance Spreadsheets"
    };

    // Sales data items
    public static DataSourceItem GetSalesTransactions()
    {
        return new TableDataSourceItem("Sales", _salesDB)
        {
            Title = "Sales Transactions",
            Table = "SalesTransactions"
        };
    }

    public static DataSourceItem GetCustomers()
    {
        return new TableDataSourceItem("Customers", _salesDB)
        {
            Title = "Customer Data",
            Table = "Customers"
        };
    }

    public static DataSourceItem GetProducts()
    {
        return new TableDataSourceItem("Products", _salesDB)
        {
            Title = "Product Catalog",
            Table = "Products"
        };
    }

    // Marketing data items
    public static DataSourceItem GetCampaigns()
    {
        var dataItem = new RestDataSourceItem("Campaigns", _marketingAPI)
        {
            Title = "Campaign Data",
            Url = $"{_marketingAPI.Url}/campaigns",
            Fields = new List<IField>
            {
                new TextField("CampaignId"),
                new TextField("CampaignName"),
                new DateField("StartDate"),
                new DateField("EndDate"),
                new NumberField("Budget"),
                new NumberField("Spend"),
                new TextField("Status")
            }
        };
        return dataItem;
    }

    public static DataSourceItem GetCampaignMetrics()
    {
        var dataItem = new RestDataSourceItem("CampaignMetrics", _marketingAPI)
        {
            Title = "Campaign Performance",
            Url = $"{_marketingAPI.Url}/metrics",
            Fields = new List<IField>
            {
                new TextField("CampaignId"),
                new DateField("Date"),
                new NumberField("Impressions"),
                new NumberField("Clicks"),
                new NumberField("Conversions"),
                new NumberField("Cost")
            }
        };
        return dataItem;
    }

    // Finance data items
    public static DataSourceItem GetBudgetData()
    {
        return new ExcelDataSourceItem("Budget", _financeSheets)
        {
            Title = "Annual Budget",
            ResourcePath = @"\\finance\shared\budget-2024.xlsx",
            Sheet = "Budget",
            FirstRowContainsLabels = true,
            Fields = new List<IField>
            {
                new TextField("Department"),
                new TextField("Category"),
                new NumberField("Q1Budget"),
                new NumberField("Q2Budget"),
                new NumberField("Q3Budget"),
                new NumberField("Q4Budget")
            }
        };
    }

    public static DataSourceItem GetExpenseData()
    {
        return new ExcelDataSourceItem("Expenses", _financeSheets)
        {
            Title = "Actual Expenses",
            ResourcePath = @"\\finance\shared\expenses-2024.xlsx",
            Sheet = "Expenses",
            FirstRowContainsLabels = true,
            Fields = new List<IField>
            {
                new DateField("Date"),
                new TextField("Department"),
                new TextField("Category"),
                new NumberField("Amount"),
                new TextField("Description")
            }
        };
    }
}
```

## Cloud Services Integration

### Combining OneDrive, SharePoint, and Google Sheets

```csharp
public class CloudDataDashboard
{
    public RdashDocument CreateCloudDashboard()
    {
        var document = new RdashDocument("Cloud Data Dashboard")
        {
            Description = "Data from OneDrive, SharePoint, and Google Sheets"
        };

        // OneDrive Excel file
        var oneDriveData = CreateOneDriveData();
        
        // SharePoint list
        var sharePointData = CreateSharePointData();
        
        // Google Sheets
        var googleSheetsData = CreateGoogleSheetsData();

        // Combine in visualizations
        document.Visualizations.Add(CreateOneDriveChart(oneDriveData));
        document.Visualizations.Add(CreateSharePointGrid(sharePointData));
        document.Visualizations.Add(CreateGoogleSheetsKpi(googleSheetsData));

        return document;
    }

    private DataSourceItem CreateOneDriveData()
    {
        var oneDriveSource = new MicrosoftOneDriveDataSource
        {
            Title = "OneDrive Files"
        };

        return new ExcelDataSourceItem("SalesData", oneDriveSource)
        {
            Title = "Sales Report",
            ResourcePath = "/Documents/Sales/Q4-2024-Sales.xlsx",
            Sheet = "Summary",
            FirstRowContainsLabels = true,
            Fields = new List<IField>
            {
                new DateField("Date"),
                new TextField("Region"),
                new NumberField("Revenue"),
                new NumberField("Units")
            }
        };
    }

    private DataSourceItem CreateSharePointData()
    {
        var sharePointSource = new MicrosoftSharePointDataSource
        {
            Title = "Company SharePoint",
            SiteUrl = "https://company.sharepoint.com/sites/data"
        };

        return new SharePointListDataSourceItem("Projects", sharePointSource)
        {
            Title = "Project List",
            ListName = "Active Projects",
            Fields = new List<IField>
            {
                new TextField("ProjectName"),
                new TextField("Owner"),
                new DateField("StartDate"),
                new DateField("DueDate"),
                new TextField("Status"),
                new NumberField("Budget")
            }
        };
    }

    private DataSourceItem CreateGoogleSheetsData()
    {
        var googleSheetsSource = new GoogleSheetsDataSource
        {
            Title = "Google Sheets Data"
        };

        return new GoogleSheetsDataSourceItem("Inventory", googleSheetsSource)
        {
            Title = "Inventory Tracking",
            ResourcePath = "1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms", // Sheet ID
            Sheet = "Inventory",
            Fields = new List<IField>
            {
                new TextField("ProductCode"),
                new TextField("ProductName"),
                new NumberField("QuantityOnHand"),
                new NumberField("ReorderLevel"),
                new TextField("Supplier")
            }
        };
    }

    private Visualization CreateOneDriveChart(DataSourceItem data)
    {
        var chart = new ColumnChartVisualization("Revenue by Region", data);
        chart.Labels.Add(new DimensionDataField("Region"));
        chart.Values.Add(new MeasureDataField("Revenue") { Aggregation = AggregationType.Sum });
        return chart;
    }

    private Visualization CreateSharePointGrid(DataSourceItem data)
    {
        var grid = new GridVisualization("Active Projects", data);
        grid.Columns.Add(new DimensionDataField("ProjectName"));
        grid.Columns.Add(new DimensionDataField("Owner"));
        grid.Columns.Add(new DateDataField("DueDate"));
        grid.Columns.Add(new DimensionDataField("Status"));
        return grid;
    }

    private Visualization CreateGoogleSheetsKpi(DataSourceItem data)
    {
        var kpi = new KpiTimeVisualization("Low Stock Items", data);
        kpi.Value = new MeasureDataField("ProductCode") { Aggregation = AggregationType.Count };
        // Add filter for low stock
        kpi.Filters.Add(new VisualizationFilter("QuantityOnHand")
        {
            FilterType = FilterType.FilterByRule,
            Rules = new List<FilterRule>
            {
                new NumberFilterRule
                {
                    RuleType = NumberRuleType.LessThan,
                    Value = 50 // Items with less than 50 units
                }
            }
        });
        return kpi;
    }
}
```

## Real-time Data Integration

### Combining Static and Real-time Sources

```csharp
public class RealTimeDashboard
{
    public RdashDocument CreateRealTimeDashboard()
    {
        var document = new RdashDocument("Real-time Business Monitor")
        {
            Description = "Combining real-time APIs with historical database data"
        };

        // Historical data from SQL Server
        var historicalSales = CreateHistoricalSalesData();
        
        // Real-time data from API
        var realTimeMetrics = CreateRealTimeMetricsData();
        
        // Static reference data from Excel
        var referenceData = CreateReferenceData();

        // Historical trend
        var trendChart = new LineChartVisualization("Sales Trend (Historical)", historicalSales);
        trendChart.Labels.Add(new DimensionDataField("Date") { Aggregation = DateAggregationType.Day });
        trendChart.Values.Add(new MeasureDataField("Revenue") { Aggregation = AggregationType.Sum });
        document.Visualizations.Add(trendChart);

        // Real-time KPIs
        var realTimeKpi = new KpiTimeVisualization("Current Performance", realTimeMetrics);
        realTimeKpi.Value = new MeasureDataField("CurrentSales") { Aggregation = AggregationType.Sum };
        document.Visualizations.Add(realTimeKpi);

        // Reference data grid
        var referenceGrid = new GridVisualization("Product Catalog", referenceData);
        referenceGrid.Columns.Add(new DimensionDataField("ProductCode"));
        referenceGrid.Columns.Add(new DimensionDataField("ProductName"));
        referenceGrid.Columns.Add(new MeasureDataField("Price"));
        document.Visualizations.Add(referenceGrid);

        return document;
    }

    private DataSourceItem CreateHistoricalSalesData()
    {
        var sqlSource = new MicrosoftSqlServerDataSource
        {
            Host = "warehouse.database.windows.net",
            Database = "DataWarehouse",
            Title = "Data Warehouse"
        };

        return new ViewDataSourceItem("HistoricalSales", sqlSource)
        {
            Title = "Historical Sales Data",
            View = "vw_SalesHistory" // Pre-aggregated view for performance
        };
    }

    private DataSourceItem CreateRealTimeMetricsData()
    {
        var apiSource = new RestDataSource
        {
            Title = "Real-time Metrics API",
            Url = "https://api.company.com/realtime"
        };

        return new RestDataSourceItem("RealTimeMetrics", apiSource)
        {
            Title = "Current Metrics",
            Url = "https://api.company.com/realtime/current",
            Fields = new List<IField>
            {
                new DateField("Timestamp"),
                new NumberField("CurrentSales"),
                new NumberField("ActiveUsers"),
                new NumberField("ConversionRate"),
                new TextField("TopProduct")
            }
        };
    }

    private DataSourceItem CreateReferenceData()
    {
        var excelSource = new ExcelDataSource
        {
            Title = "Reference Data"
        };

        return new ExcelDataSourceItem("Products", excelSource)
        {
            Title = "Product Master Data",
            ResourcePath = @"C:\ReferenceData\Products.xlsx",
            Sheet = "Products",
            FirstRowContainsLabels = true,
            Fields = new List<IField>
            {
                new TextField("ProductCode"),
                new TextField("ProductName"),
                new TextField("Category"),
                new NumberField("Price"),
                new TextField("Supplier")
            }
        };
    }
}
```

## Best Practices for Multi-Source Dashboards

### 1. Consistent Field Naming

Ensure similar fields across data sources use consistent names:

```csharp
// Good - Consistent naming
var salesData = new TableDataSourceItem("Sales", sqlSource);
var marketingData = new RestDataSourceItem("Marketing", apiSource)
{
    Fields = new List<IField>
    {
        new DateField("Date"),        // Same name as SQL field
        new NumberField("Revenue"),   // Same name as SQL field
        new TextField("Product")      // Same name as SQL field
    }
};

// This enables cross-visualization filtering
```

### 2. Data Source Validation

Validate data sources before use:

```csharp
public class DataSourceValidator
{
    public static bool ValidateDataSource(DataSourceItem dataItem)
    {
        if (string.IsNullOrEmpty(dataItem.Title))
            return false;

        // For REST APIs, ensure fields are defined
        if (dataItem is RestDataSourceItem restItem)
        {
            return restItem.Fields?.Count > 0;
        }

        // For Excel, ensure path and sheet are specified
        if (dataItem is ExcelDataSourceItem excelItem)
        {
            return !string.IsNullOrEmpty(excelItem.ResourcePath) && 
                   !string.IsNullOrEmpty(excelItem.Sheet);
        }

        return true;
    }
}
```

### 3. Error Handling

Handle data source connection issues gracefully:

```csharp
public class RobustDashboardCreator
{
    public RdashDocument CreateDashboardWithFallbacks()
    {
        var document = new RdashDocument("Resilient Dashboard");

        try
        {
            // Primary data source
            var primaryData = CreatePrimaryDataSource();
            document.Visualizations.Add(CreatePrimaryVisualization(primaryData));
        }
        catch (Exception ex)
        {
            // Fallback to secondary data source
            var fallbackData = CreateFallbackDataSource();
            document.Visualizations.Add(CreateFallbackVisualization(fallbackData));
            
            // Log the issue
            Console.WriteLine($"Primary data source failed: {ex.Message}");
        }

        return document;
    }

    private DataSourceItem CreatePrimaryDataSource()
    {
        // Attempt to connect to primary SQL database
        var sqlSource = new MicrosoftSqlServerDataSource
        {
            Host = "primary-db.database.windows.net",
            Database = "PrimaryDB"
        };

        return new TableDataSourceItem("Primary", sqlSource);
    }

    private DataSourceItem CreateFallbackDataSource()
    {
        // Fallback to local Excel file
        var excelSource = new ExcelDataSource();
        return new ExcelDataSourceItem("Fallback", excelSource)
        {
            ResourcePath = @"C:\Backup\data.xlsx",
            Sheet = "Data"
        };
    }
}
```

## Performance Considerations

### 1. Data Source Reuse

Reuse data source objects to minimize connections:

```csharp
// Create data source once
var sharedSqlSource = new MicrosoftSqlServerDataSource
{
    Host = "server.database.windows.net",
    Database = "SharedDB"
};

// Use for multiple tables
var salesData = new TableDataSourceItem("Sales", sharedSqlSource);
var customerData = new TableDataSourceItem("Customers", sharedSqlSource);
var productData = new TableDataSourceItem("Products", sharedSqlSource);
```

### 2. Optimize Field Definitions

Only define necessary fields for REST APIs and files:

```csharp
// Only include fields used in visualizations
var apiData = new RestDataSourceItem("API", apiSource)
{
    Fields = new List<IField>
    {
        new DateField("Date"),           // Used in trend chart
        new NumberField("Revenue"),      // Used in KPI
        new TextField("Category")        // Used in pie chart
        // Don't include unused fields
    }
};
```

## Related Topics

- [Data Sources Overview](../core-concepts/data-sources.md)
- [SQL Server Connection](connect-to-sql-server.md)
- [REST API Integration](connect-to-rest-api.md)
- [Excel Files](work-with-excel.md)
- [Dashboard Performance](../best-practices.md#performance)

## Next Steps

- Learn about [dashboard filters](../how-to/dashboard-management/work-with-filters.md) that work across data sources
- Explore [calculated fields](../how-to/advanced/calculations-aggregations.md) for combining data
- Check [authentication patterns](../how-to/advanced/authentication.md) for securing data sources