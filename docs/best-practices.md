# Best Practices

Recommended patterns and practices for working with Reveal.Sdk.Dom.

## Code Organization

### Use Factory Pattern

Create factory classes to centralize dashboard and data source creation:

```csharp
public class DataSourceFactory
{
    private static MicrosoftSqlServerDataSource _productionDB;
    
    public static MicrosoftSqlServerDataSource ProductionDatabase
    {
        get
        {
            if (_productionDB == null)
            {
                _productionDB = new MicrosoftSqlServerDataSource
                {
                    Host = Configuration["Database:Host"],
                    Database = Configuration["Database:Name"],
                    Title = "Production Database"
                };
            }
            return _productionDB;
        }
    }
    
    public static TableDataSourceItem GetSalesData()
    {
        return new TableDataSourceItem("Sales", ProductionDatabase)
        {
            Title = "Sales Data",
            Table = "Sales"
        };
    }
    
    public static TableDataSourceItem GetCustomersData()
    {
        return new TableDataSourceItem("Customers", ProductionDatabase)
        {
            Title = "Customer Data",
            Table = "Customers"
        };
    }
}
```

### Separate Dashboard Creation Logic

```csharp
public class SalesDashboardBuilder
{
    private readonly RdashDocument _document;
    
    public SalesDashboardBuilder(string title)
    {
        _document = new RdashDocument(title)
        {
            UseAutoLayout = true
        };
    }
    
    public SalesDashboardBuilder AddKPI()
    {
        var salesData = DataSourceFactory.GetSalesData();
        var kpi = CreateKPI(salesData);
        _document.Visualizations.Add(kpi);
        return this;
    }
    
    public SalesDashboardBuilder AddSalesChart()
    {
        var salesData = DataSourceFactory.GetSalesData();
        var chart = CreateSalesChart(salesData);
        _document.Visualizations.Add(chart);
        return this;
    }
    
    public RdashDocument Build() => _document;
    
    private KpiTargetVisualization CreateKPI(DataSourceItem data) { ... }
    private BarChartVisualization CreateSalesChart(DataSourceItem data) { ... }
}

// Usage
var dashboard = new SalesDashboardBuilder("Q4 Sales")
    .AddKPI()
    .AddSalesChart()
    .Build();
```

## Naming Conventions

### Use Clear, Descriptive Names

```csharp
// Good
var salesByRegionChart = new BarChartVisualization("Sales by Region", salesData);
var customerDemographicsGrid = new GridVisualization("Customer Demographics", customerData);

// Avoid
var chart1 = new BarChartVisualization("Chart", data);
var grid = new GridVisualization("Grid", data);
```

### Title Conventions

```csharp
// Dashboard titles - Be specific
document.Title = "Q4 2024 Sales Performance Dashboard";

// Visualization titles - Describe what's shown
var chart = new ColumnChartVisualization("Revenue by Product Category", data);

// Data source titles - Identify source
var dataSource = new MicrosoftSqlServerDataSource
{
    Title = "Production SQL Server",
    Subtitle = "Sales Database"
};
```

### Field Labels

Provide user-friendly labels:

```csharp
var revenueField = new MeasureDataField("total_revenue_usd")
{
    FieldLabel = "Total Revenue (USD)",  // User sees this
    Aggregation = AggregationType.Sum
};
```

## Data Source Management

### Reuse Data Source Definitions

```csharp
// Create once
var sqlDataSource = new MicrosoftSqlServerDataSource
{
    Host = "server.database.windows.net",
    Database = "CompanyDB",
    Title = "Company Database"
};

// Reuse for multiple items
var salesTable = new TableDataSourceItem("Sales", sqlDataSource);
var ordersTable = new TableDataSourceItem("Orders", sqlDataSource);
var customersTable = new TableDataSourceItem("Customers", sqlDataSource);
```

### Environment-Specific Configuration

Use configuration files for different environments:

```csharp
public class DataSourceConfiguration
{
    private readonly IConfiguration _config;
    
    public DataSourceConfiguration(IConfiguration config)
    {
        _config = config;
    }
    
    public MicrosoftSqlServerDataSource CreateDataSource()
    {
        return new MicrosoftSqlServerDataSource
        {
            Host = _config["Database:Host"],
            Database = _config["Database:Name"],
            Port = _config.GetValue<int>("Database:Port", 1433),
            Title = _config["Database:DisplayName"]
        };
    }
}
```

### Always Define Fields for File/API Sources

```csharp
// Required for REST APIs, Excel, JSON, CSV
var apiData = new RestDataSourceItem("API Data", restSource);
apiData.Fields.Add(new TextField("ProductName"));
apiData.Fields.Add(new NumberField("Revenue"));
apiData.Fields.Add(new DateField("OrderDate"));

// Not needed for SQL - schema comes from database
var sqlData = new TableDataSourceItem("Sales", sqlSource)
{
    Table = "Sales"  // Fields auto-discovered
};
```

## Visualization Best Practices

### Choose Appropriate Visualization Types

| Data Type | Best Visualization |
|-----------|-------------------|
| Categories comparison | Bar/Column Chart |
| Trends over time | Line/Area Chart |
| Part-to-whole | Pie/Doughnut Chart (max 7-10 segments) |
| Geographic data | Choropleth/Scatter Map |
| Detailed data | Grid/Pivot Table |
| Key metrics | KPI/Gauge |
| Correlation | Scatter/Bubble Chart |

### Limit Visualizations Per Dashboard

```csharp
// Optimal: 10-15 visualizations
// Maximum recommended: 20-25 visualizations

// If you need more, split into multiple dashboards
var salesDashboard = CreateSalesDashboard();        // 10 visualizations
var marketingDashboard = CreateMarketingDashboard(); // 10 visualizations
```

### Use Auto Layout When Possible

```csharp
// Recommended
document.UseAutoLayout = true;

// Only use manual layout when absolutely necessary
document.UseAutoLayout = false;
chart.Column = 0;
chart.Row = 0;
chart.ColumnSpan = 6;
chart.RowSpan = 4;
```

### Apply Consistent Styling

```csharp
public class VisualizationStyler
{
    public static void ApplyStandardStyle(Visualization viz)
    {
        viz.IsTitleVisible = true;
        viz.IsDescriptionVisible = false;
        // Apply other consistent settings
    }
}

// Usage
var chart = new BarChartVisualization("Sales", data);
VisualizationStyler.ApplyStandardStyle(chart);
```

## Aggregation and Formatting

### Choose Appropriate Aggregations

```csharp
// Sum for totals
var totalSales = new MeasureDataField("Sales")
{
    Aggregation = AggregationType.Sum,
    FieldLabel = "Total Sales"
};

// Average for metrics
var avgRating = new MeasureDataField("Rating")
{
    Aggregation = AggregationType.Average,
    FieldLabel = "Average Rating"
};

// Count for quantities
var orderCount = new MeasureDataField("OrderID")
{
    Aggregation = AggregationType.Count,
    FieldLabel = "Number of Orders"
};
```

### Apply Consistent Formatting

```csharp
public class FieldFormatter
{
    public static MeasureDataField CreateCurrencyField(string fieldName, string label)
    {
        return new MeasureDataField(fieldName)
        {
            FieldLabel = label,
            Aggregation = AggregationType.Sum,
            Formatting = new NumberFormatting
            {
                FormatType = NumberFormattingType.Currency,
                DecimalPlaces = 2,
                CurrencySymbol = "$"
            }
        };
    }
    
    public static MeasureDataField CreatePercentField(string fieldName, string label)
    {
        return new MeasureDataField(fieldName)
        {
            FieldLabel = label,
            Formatting = new NumberFormatting
            {
                FormatType = NumberFormattingType.Percent,
                DecimalPlaces = 1
            }
        };
    }
}

// Usage
var revenue = FieldFormatter.CreateCurrencyField("Revenue", "Total Revenue");
var growth = FieldFormatter.CreatePercentField("GrowthRate", "Growth Rate");
```

## Error Handling

### Always Handle File Operations

```csharp
public bool SaveDashboard(RdashDocument document, string filePath)
{
    try
    {
        // Ensure directory exists
        var directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        
        document.Save(filePath);
        return true;
    }
    catch (UnauthorizedAccessException)
    {
        Console.WriteLine($"Access denied to {filePath}");
        return false;
    }
    catch (IOException ex)
    {
        Console.WriteLine($"IO error saving dashboard: {ex.Message}");
        return false;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unexpected error: {ex.Message}");
        return false;
    }
}
```

### Validate Before Saving

```csharp
public class DashboardValidator
{
    public static bool Validate(RdashDocument document, out List<string> errors)
    {
        errors = new List<string>();
        
        if (string.IsNullOrWhiteSpace(document.Title))
            errors.Add("Dashboard must have a title");
        
        if (document.Visualizations.Count == 0)
            errors.Add("Dashboard must have at least one visualization");
        
        foreach (var viz in document.Visualizations)
        {
            if (viz.DataDefinition?.DataSourceItem == null)
                errors.Add($"Visualization '{viz.Title}' has no data source");
        }
        
        return errors.Count == 0;
    }
}

// Usage
if (DashboardValidator.Validate(document, out var errors))
{
    document.Save("dashboard.rdash");
}
else
{
    Console.WriteLine("Validation errors:");
    errors.ForEach(e => Console.WriteLine($"- {e}"));
}
```

## Performance

### Minimize Data Source Creation

```csharp
// Bad - Creates new instance each time
public DataSourceItem GetSalesData()
{
    var ds = new MicrosoftSqlServerDataSource { ... };
    return new TableDataSourceItem("Sales", ds);
}

// Good - Reuses data source
private static readonly MicrosoftSqlServerDataSource _sharedDataSource = 
    new MicrosoftSqlServerDataSource { ... };

public DataSourceItem GetSalesData()
{
    return new TableDataSourceItem("Sales", _sharedDataSource);
}
```

### Batch Operations

```csharp
// Create all visualizations before adding to document
var visualizations = new List<Visualization>
{
    CreateSalesChart(salesData),
    CreateRevenueKPI(salesData),
    CreateCustomerGrid(customerData),
    CreateProductChart(productData)
};

// Add all at once
foreach (var viz in visualizations)
{
    document.Visualizations.Add(viz);
}
```

## Testing

### Create Test Helpers

```csharp
public class DashboardTestHelper
{
    public static DataSourceItem CreateMockDataSource()
    {
        var restSource = new RestDataSource
        {
            Url = "https://example.com/test"
        };
        
        var item = new RestDataSourceItem("Test Data", restSource);
        item.Fields.Add(new TextField("Name"));
        item.Fields.Add(new NumberField("Value"));
        
        return item;
    }
    
    public static RdashDocument CreateTestDashboard()
    {
        var document = new RdashDocument("Test Dashboard");
        var data = CreateMockDataSource();
        
        var chart = new BarChartVisualization("Test Chart", data);
        chart.Labels.Add(new DimensionDataField("Name"));
        chart.Values.Add(new MeasureDataField("Value"));
        
        document.Visualizations.Add(chart);
        return document;
    }
}
```

### Verify Dashboard Creation

```csharp
[Test]
public void CreateDashboard_ShouldHaveCorrectTitle()
{
    var document = new RdashDocument("Test Dashboard");
    Assert.AreEqual("Test Dashboard", document.Title);
}

[Test]
public void AddVisualization_ShouldIncreaseCount()
{
    var document = new RdashDocument("Test");
    var data = DashboardTestHelper.CreateMockDataSource();
    var chart = new BarChartVisualization("Chart", data);
    
    document.Visualizations.Add(chart);
    
    Assert.AreEqual(1, document.Visualizations.Count);
}
```

## Documentation

### Add XML Comments

```csharp
/// <summary>
/// Creates a sales dashboard with KPIs and trend charts
/// </summary>
/// <param name="title">Dashboard title</param>
/// <param name="dataSource">SQL Server data source</param>
/// <returns>Configured RdashDocument ready to save</returns>
public RdashDocument CreateSalesDashboard(string title, 
    MicrosoftSqlServerDataSource dataSource)
{
    // Implementation
}
```

### Document Complex Logic

```csharp
public class DashboardBuilder
{
    // Creates a dashboard with auto-layout enabled and adds:
    // 1. KPI showing total sales
    // 2. Bar chart with sales by region
    // 3. Line chart with monthly trends
    // 4. Grid with detailed transactions
    public RdashDocument BuildStandardSalesDashboard()
    {
        // Implementation
    }
}
```

## Version Control

### Gitignore Generated Files

```gitignore
# .gitignore

# Ignore generated dashboard files
*.rdash

# Keep template files
!templates/*.rdash

# Ignore build outputs
bin/
obj/
```

### Track Templates

Commit template dashboards to version control:

```
/project
  /templates
    sales-template.rdash
    marketing-template.rdash
  /src
    DashboardBuilder.cs
```

## Security

### Never Hardcode Credentials

```csharp
// Bad
var ds = new MicrosoftSqlServerDataSource
{
    Host = "server.com",
    // Don't do this!
    UserId = "admin",
    Password = "password123"
};

// Good - Credentials configured in Reveal SDK at runtime
var ds = new MicrosoftSqlServerDataSource
{
    Host = Configuration["Database:Host"],
    Database = Configuration["Database:Name"]
    // Authentication handled by Reveal SDK
};
```

### Validate User Input

```csharp
public RdashDocument CreateDashboard(string title, string tableName)
{
    // Validate input
    if (string.IsNullOrWhiteSpace(title))
        throw new ArgumentException("Title cannot be empty");
    
    if (!IsValidTableName(tableName))
        throw new ArgumentException("Invalid table name");
    
    // Create dashboard
    var document = new RdashDocument(title);
    // ...
}

private bool IsValidTableName(string tableName)
{
    // Implement validation logic
    return !string.IsNullOrWhiteSpace(tableName) && 
           tableName.All(c => char.IsLetterOrDigit(c) || c == '_');
}
```

## Maintenance

### Keep Dependencies Updated

Regularly update Reveal.Sdk.Dom to get:
- Bug fixes
- New features
- Performance improvements
- Security patches

```bash
dotnet list package --outdated
dotnet add package Reveal.Sdk.Dom --version [latest]
```

### Review Breaking Changes

When upgrading:
1. Read release notes
2. Check for breaking changes
3. Test thoroughly
4. Update code as needed

### Monitor Beta Status

Since Reveal.Sdk.Dom is in BETA:
- Pin to specific versions in production
- Test new versions in development first
- Be prepared for API changes
- Provide feedback to maintainers

## Related Topics

- [Getting Started](getting-started/quick-start.md)
- [FAQ](faq.md)
- [Troubleshooting](troubleshooting.md)
- [Examples](examples/README.md)
