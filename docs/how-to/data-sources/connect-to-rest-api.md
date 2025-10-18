# How to Connect to REST APIs

Learn how to connect to REST APIs and create visualizations from API data.

## Overview

REST APIs are one of the most common data sources for modern applications. Reveal.Sdk.Dom makes it easy to consume REST API data in your dashboards.

## Basic REST API Connection

### Step 1: Create the REST Data Source

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;

var restDataSource = new RestDataSource
{
    Url = "https://api.example.com/v1",
    Title = "Sales API",
    Subtitle = "Production Endpoint",
    UseAnonymousAuthentication = true  // If no auth required
};
```

### Step 2: Create Data Source Item with Fields

**Important**: For REST APIs, you must define all expected fields:

```csharp
var apiData = new RestDataSourceItem("Sales Data", restDataSource)
{
    Title = "Sales Data",
    Subtitle = "Current Month",
    Url = "https://api.example.com/v1/sales"
};

// Define all fields returned by the API (required!)
apiData.Fields.Add(new TextField("productName"));
apiData.Fields.Add(new TextField("category"));
apiData.Fields.Add(new NumberField("revenue"));
apiData.Fields.Add(new NumberField("quantity"));
apiData.Fields.Add(new DateField("orderDate"));
apiData.Fields.Add(new TextField("region"));
```

### Step 3: Create Visualization

```csharp
var document = new RdashDocument("API Dashboard");

var chart = new BarChartVisualization("Revenue by Product", apiData);
chart.Labels.Add(new DimensionDataField("productName"));
chart.Values.Add(new MeasureDataField("revenue") 
{ 
    Aggregation = AggregationType.Sum 
});

document.Visualizations.Add(chart);
document.Save("api-dashboard.rdash");
```

## Using the Builder Pattern

For REST APIs, you can use the builder for a more fluent API:

```csharp
var apiData = new RestServiceBuilder("https://api.example.com/v1/sales")
    .SetTitle("Sales Data")
    .SetSubtitle("Production API")
    .SetFields(new List<Field>
    {
        new TextField("productName"),
        new TextField("category"),
        new NumberField("revenue"),
        new NumberField("quantity"),
        new DateField("orderDate")
    })
    .Build();

// Use in visualization
var chart = new PieChartVisualization("Sales by Category", apiData);
chart.Labels.Add(new DimensionDataField("category"));
chart.Values.Add(new MeasureDataField("revenue"));
```

## Working with JSON APIs

### Simple JSON Array

For APIs that return a simple JSON array:

```json
[
  {
    "product": "Widget A",
    "sales": 1000,
    "date": "2024-01-15"
  },
  {
    "product": "Widget B",
    "sales": 1500,
    "date": "2024-01-16"
  }
]
```

Define fields matching the JSON structure:

```csharp
var apiData = new RestDataSourceItem("Products", restSource)
{
    Url = "https://api.example.com/products"
};

apiData.Fields.Add(new TextField("product"));
apiData.Fields.Add(new NumberField("sales"));
apiData.Fields.Add(new DateField("date"));
```

### Nested JSON

For nested structures, use dot notation:

```json
{
  "data": [
    {
      "product": {
        "name": "Widget A",
        "category": "Tools"
      },
      "metrics": {
        "sales": 1000,
        "profit": 200
      }
    }
  ]
}
```

```csharp
apiData.Fields.Add(new TextField("product.name"));
apiData.Fields.Add(new TextField("product.category"));
apiData.Fields.Add(new NumberField("metrics.sales"));
apiData.Fields.Add(new NumberField("metrics.profit"));
```

## Common API Patterns

### Paginated APIs

For APIs with pagination, use the first page URL:

```csharp
var restSource = new RestDataSource
{
    Url = "https://api.example.com/v1/sales?page=1&limit=100"
};
```

### APIs with Query Parameters

Include query parameters in the URL:

```csharp
var restSource = new RestDataSource
{
    Url = "https://api.example.com/v1/sales?year=2024&region=north"
};
```

### Multiple Endpoints

Create separate data source items for different endpoints:

```csharp
var baseSource = new RestDataSource
{
    Url = "https://api.example.com/v1",
    Title = "Company API"
};

// Sales endpoint
var salesData = new RestDataSourceItem("Sales", baseSource)
{
    Url = "https://api.example.com/v1/sales"
};
salesData.Fields.Add(new NumberField("revenue"));
salesData.Fields.Add(new DateField("date"));

// Products endpoint
var productsData = new RestDataSourceItem("Products", baseSource)
{
    Url = "https://api.example.com/v1/products"
};
productsData.Fields.Add(new TextField("name"));
productsData.Fields.Add(new NumberField("price"));

// Use in separate visualizations
var salesChart = new LineChartVisualization("Sales Trend", salesData);
var productsGrid = new GridVisualization("Products", productsData);
```

## Real-World Example: Public API

Using a public JSON API:

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;

public class PublicAPIDashboard
{
    public RdashDocument CreateDashboard()
    {
        // Excel2JSON sample API
        var restSource = new RestDataSource
        {
            Url = "https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9",
            Title = "Sample Sales API",
            UseAnonymousAuthentication = true
        };

        var apiData = new RestDataSourceItem("Sales", restSource);
        apiData.Fields.Add(new NumberField("CategoryID"));
        apiData.Fields.Add(new TextField("CategoryName"));
        apiData.Fields.Add(new TextField("ProductName"));
        apiData.Fields.Add(new NumberField("ProductSales"));

        var document = new RdashDocument("API Sales Dashboard")
        {
            UseAutoLayout = true
        };

        // Pie chart by category
        var pieChart = new PieChartVisualization("Sales by Category", apiData);
        pieChart.Labels.Add(new DimensionDataField("CategoryName"));
        pieChart.Values.Add(new MeasureDataField("ProductSales") 
        { 
            Aggregation = AggregationType.Sum 
        });
        document.Visualizations.Add(pieChart);

        // Bar chart by product
        var barChart = new BarChartVisualization("Top Products", apiData);
        barChart.Labels.Add(new DimensionDataField("ProductName"));
        barChart.Values.Add(new MeasureDataField("ProductSales") 
        { 
            Aggregation = AggregationType.Sum 
        });
        document.Visualizations.Add(barChart);

        // Detail grid
        var grid = new GridVisualization("Product Details", apiData);
        grid.Columns.Add(new DimensionDataField("CategoryName"));
        grid.Columns.Add(new DimensionDataField("ProductName"));
        grid.Columns.Add(new MeasureDataField("ProductSales"));
        document.Visualizations.Add(grid);

        return document;
    }
}

// Usage
var creator = new PublicAPIDashboard();
var dashboard = creator.CreateDashboard();
dashboard.Save("api-dashboard.rdash");
```

## Authentication

REST API authentication is configured in the Reveal SDK at runtime, not in Reveal.Sdk.Dom:

```csharp
// In Reveal.Sdk.Dom - just indicate auth is needed
var restSource = new RestDataSource
{
    Url = "https://api.example.com/v1",
    UseAnonymousAuthentication = false  // Requires authentication
};

// In Reveal SDK - configure authentication
public class ApiAuthProvider : IRVAuthenticationProvider
{
    public Task<IRVDataSourceCredential> ResolveCredentialsAsync(
        RVDashboardDataSource dataSource)
    {
        if (dataSource is RVRESTDataSource)
        {
            return Task.FromResult<IRVDataSourceCredential>(
                new RVBearerTokenDataSourceCredential("your-api-token")
            );
        }
        return Task.FromResult<IRVDataSourceCredential>(null);
    }
}
```

## Field Type Mapping

Map JSON data types to field types:

| JSON Type | Field Type | Example |
|-----------|-----------|---------|
| String | `TextField` | `"name": "Product"` |
| Number | `NumberField` | `"price": 29.99` |
| Integer | `NumberField` | `"quantity": 100` |
| Boolean | `BooleanField` | `"active": true` |
| Date String | `DateField` | `"date": "2024-01-15"` |

```csharp
// String values
apiData.Fields.Add(new TextField("name"));
apiData.Fields.Add(new TextField("description"));

// Numeric values
apiData.Fields.Add(new NumberField("price"));
apiData.Fields.Add(new NumberField("quantity"));
apiData.Fields.Add(new NumberField("rating"));

// Boolean values
apiData.Fields.Add(new BooleanField("active"));
apiData.Fields.Add(new BooleanField("featured"));

// Date values
apiData.Fields.Add(new DateField("createdDate"));
apiData.Fields.Add(new DateField("lastModified"));
```

## Best Practices

### 1. Test API First

Before creating the dashboard, test the API:

```bash
# Test with curl
curl https://api.example.com/v1/sales

# Or use Postman, Insomnia, etc.
```

### 2. Document Expected Schema

```csharp
/// <summary>
/// Expected API response schema:
/// {
///   "productName": "string",
///   "revenue": number,
///   "orderDate": "2024-01-15"
/// }
/// </summary>
public DataSourceItem CreateSalesDataSource()
{
    var apiData = new RestDataSourceItem("Sales", restSource);
    apiData.Fields.Add(new TextField("productName"));
    apiData.Fields.Add(new NumberField("revenue"));
    apiData.Fields.Add(new DateField("orderDate"));
    return apiData;
}
```

### 3. Handle API Changes

Create a factory that can adapt to API changes:

```csharp
public class ApiDataSourceFactory
{
    private const string API_VERSION = "v1";
    
    public static DataSourceItem CreateSalesData(string apiVersion = API_VERSION)
    {
        var url = $"https://api.example.com/{apiVersion}/sales";
        var restSource = new RestDataSource { Url = url };
        var data = new RestDataSourceItem("Sales", restSource);
        
        // Add version-specific fields
        if (apiVersion == "v1")
        {
            data.Fields.Add(new TextField("productName"));
            data.Fields.Add(new NumberField("revenue"));
        }
        else if (apiVersion == "v2")
        {
            data.Fields.Add(new TextField("product_name"));
            data.Fields.Add(new NumberField("total_revenue"));
        }
        
        return data;
    }
}
```

### 4. Use Configuration

Store API URLs in configuration:

```csharp
public class ApiConfiguration
{
    public string BaseUrl { get; set; }
    public string SalesEndpoint { get; set; }
    public bool UseAnonymousAuth { get; set; }
}

public DataSourceItem CreateDataSource(ApiConfiguration config)
{
    var restSource = new RestDataSource
    {
        Url = $"{config.BaseUrl}/{config.SalesEndpoint}",
        UseAnonymousAuthentication = config.UseAnonymousAuth
    };
    
    return new RestDataSourceItem("Sales", restSource);
}
```

## Troubleshooting

### Issue: No Data Showing

**Solution**: Verify all field names match the API response exactly (case-sensitive):

```csharp
// If API returns { "ProductName": "Widget" }
apiData.Fields.Add(new TextField("ProductName"));  // Correct

// NOT
apiData.Fields.Add(new TextField("productname"));  // Won't work
```

### Issue: Fields Missing

**Solution**: Ensure all fields are defined:

```csharp
// API returns: { "id": 1, "name": "Product", "price": 99.99 }

// Define all fields
apiData.Fields.Add(new NumberField("id"));
apiData.Fields.Add(new TextField("name"));
apiData.Fields.Add(new NumberField("price"));
```

### Issue: Date Format Errors

**Solution**: Ensure dates are in ISO 8601 format or adjust in the API:

```csharp
// ISO 8601 format works best
apiData.Fields.Add(new DateField("orderDate"));
// API should return: "2024-01-15T10:30:00Z"
```

## Related Topics

- [Data Sources Overview](../../core-concepts/data-sources.md)
- [Connect to SQL Server](connect-to-sql-server.md)
- [Work with Excel Files](work-with-excel.md)
- [Data Sources API Reference](../../api-reference/data-sources/README.md)

## Examples

- [Marketing Dashboard (REST API)](../../examples/marketing-dashboard.md)
- [Public API Examples](../../examples/README.md)
