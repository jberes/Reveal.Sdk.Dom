# Data Sources

Learn how to connect to and work with various data sources in Reveal.Sdk.Dom.

## Overview

Data sources in Reveal.Sdk.Dom follow a two-tier model:

1. **DataSource** - Defines the connection (server, credentials, file location)
2. **DataSourceItem** - Represents a specific dataset (table, query, sheet, API endpoint)

This separation allows you to:
- Reuse connection definitions across multiple datasets
- Switch between datasets from the same source easily
- Organize and manage data connections efficiently

## Understanding Data Sources vs. Data Source Items

### DataSource (Connection)

Think of this as the "how to connect" part:

```csharp
var sqlServer = new MicrosoftSqlServerDataSource
{
    Host = "server.database.windows.net",
    Database = "SalesDB",
    Title = "Sales Database"
};
```

This defines:
- Where the server is located
- Which database to connect to
- How to authenticate (if needed)

### DataSourceItem (Dataset)

Think of this as the "what data to get" part:

```csharp
var salesTable = new TableDataSourceItem("Sales", sqlServer)
{
    Table = "SalesData"
};
```

This defines:
- Which table/view/query to use
- What fields are available
- How to identify this specific dataset

## Supported Data Sources

Reveal.Sdk.Dom supports 30+ data source types across multiple categories:

### Databases

- **Microsoft SQL Server** - `MicrosoftSqlServerDataSource`
- **Microsoft Azure SQL Server** - `MicrosoftAzureSqlServerDataSource`
- **MySQL** - `MySQLDataSource`
- **PostgreSQL** - `PostgreSQLDataSource`
- **Oracle** - `OracleDataSource`
- **MongoDB** - `MongoDBDataSource`
- **Amazon Redshift** - `AmazonRedshiftDataSource`
- **Snowflake** - `SnowflakeDataSource`

### Cloud Services

- **Microsoft OneDrive** - `MicrosoftOneDriveDataSource`
- **Microsoft SharePoint** - `MicrosoftSharePointDataSource`
- **Google Drive** - `GoogleDriveDataSource`
- **Google Sheets** - `GoogleSheetsDataSource`
- **Dropbox** - `DropboxDataSource`
- **Box** - `BoxDataSource`
- **Amazon S3** - `AmazonS3DataSource`

### Analytics Services

- **Microsoft Analysis Services** - `MicrosoftAnalysisServicesDataSource`
- **Microsoft Azure Analysis Services** - `MicrosoftAzureAnalysisServicesDataSource`
- **Microsoft Azure Synapse Analytics** - `MicrosoftAzureSynapseAnalyticsDataSource`
- **Google Analytics 4** - `GoogleAnalytics4DataSource`
- **Google BigQuery** - `GoogleBigQueryDataSource`
- **Amazon Athena** - `AmazonAthenaDataSource`

### Files and APIs

- **REST API** - `RestDataSource`
- **OData** - `ODataDataSource`
- **Web Service** - `WebServiceDataSource`
- **JSON** - `JsonDataSource`
- **CSV** - `CsvDataSource`
- **Excel** - `ExcelDataSource`
- **Local File** - `LocalFileDataSource`

## Common Data Source Patterns

### SQL Server

```csharp
// Create data source
var sqlDataSource = new MicrosoftSqlServerDataSource
{
    Host = "myserver.database.windows.net",
    Database = "SalesDB",
    Title = "Sales Database",
    Subtitle = "Production"
};

// Create data source item for a table
var salesTable = new TableDataSourceItem("Sales Data", sqlDataSource)
{
    Title = "Sales Data",
    Subtitle = "Transaction Records",
    Table = "Sales"
};

// Create data source item for a stored procedure
var salesProc = new ProcedureDataSourceItem("Monthly Sales", sqlDataSource)
{
    Procedure = "GetMonthlySales",
    ProcedureParameters = new Dictionary<string, object>
    {
        { "Year", 2024 },
        { "Month", 3 }
    }
};
```

### REST API

```csharp
// Create REST data source
var restDataSource = new RestDataSource
{
    Url = "https://api.example.com/v1",
    Title = "Sales API",
    Subtitle = "Production Endpoint"
};

// Create data source item with field definitions
var apiData = new RestDataSourceItem("Sales", restDataSource)
{
    Title = "Sales Data",
    Url = "https://api.example.com/v1/sales"  // Full URL
};

// Define the fields (required for REST)
apiData.Fields.Add(new TextField("ProductName"));
apiData.Fields.Add(new NumberField("Revenue"));
apiData.Fields.Add(new DateField("SaleDate"));
apiData.Fields.Add(new TextField("Region"));
```

### Excel Files

```csharp
// Local Excel file
var excelDataSource = new ExcelDataSource
{
    Title = "Sales Report",
    Subtitle = "Q4 2024"
};

var excelData = new ExcelDataSourceItem("Sales", excelDataSource)
{
    ResourcePath = "C:\\Data\\Sales.xlsx",
    Sheet = "Sheet1",
    FirstRowContainsLabels = true
};

// Define fields
excelData.Fields.Add(new TextField("Product"));
excelData.Fields.Add(new NumberField("Quantity"));
excelData.Fields.Add(new NumberField("Price"));
```

### Cloud Excel (OneDrive, SharePoint)

```csharp
// OneDrive Excel file
var oneDriveSource = new MicrosoftOneDriveDataSource
{
    Title = "OneDrive Files"
};

var oneDriveExcel = new ExcelDataSourceItem("Sales", oneDriveSource)
{
    ResourcePath = "/Documents/Sales.xlsx",
    Sheet = "Data"
};
```

### Google Sheets

```csharp
var googleSheetsSource = new GoogleSheetsDataSource
{
    Title = "Company Google Sheets"
};

var sheetData = new GoogleSheetsDataSourceItem("Sales", googleSheetsSource)
{
    ResourcePath = "spreadsheet-id",
    Sheet = "Sheet1"
};
```

### JSON Files

```csharp
var jsonDataSource = new JsonDataSource
{
    Title = "JSON Data"
};

var jsonData = new JsonDataSourceItem("Products", jsonDataSource)
{
    ResourcePath = "C:\\Data\\products.json"
};

// Define structure
jsonData.Fields.Add(new TextField("id"));
jsonData.Fields.Add(new TextField("name"));
jsonData.Fields.Add(new NumberField("price"));
```

### CSV Files

```csharp
var csvDataSource = new CsvDataSource
{
    Title = "CSV Data"
};

var csvData = new CsvDataSourceItem("Sales", csvDataSource)
{
    ResourcePath = "C:\\Data\\sales.csv",
    FirstRowContainsLabels = true,
    Separator = ","
};
```

## Field Definitions

For file-based and API data sources, you must define the schema:

### Field Types

```csharp
// Text/String fields
apiData.Fields.Add(new TextField("CustomerName"));
apiData.Fields.Add(new TextField("Email"));

// Numeric fields
apiData.Fields.Add(new NumberField("Quantity"));
apiData.Fields.Add(new NumberField("Price"));
apiData.Fields.Add(new NumberField("Revenue"));

// Date fields
apiData.Fields.Add(new DateField("OrderDate"));
apiData.Fields.Add(new DateField("ShipDate"));

// Boolean fields
apiData.Fields.Add(new BooleanField("IsActive"));
apiData.Fields.Add(new BooleanField("IsPaid"));
```

### Field Properties

```csharp
var revenueField = new NumberField("total_revenue")
{
    FieldLabel = "Total Revenue",  // User-friendly name
    Description = "Sum of all sales"
};
```

## Working with Multiple Data Sources

### Reusing Connections

```csharp
// Define connection once
var sqlServer = new MicrosoftSqlServerDataSource
{
    Host = "server.database.windows.net",
    Database = "CompanyDB"
};

// Use for multiple tables
var salesData = new TableDataSourceItem("Sales", sqlServer) { Table = "Sales" };
var customersData = new TableDataSourceItem("Customers", sqlServer) { Table = "Customers" };
var productsData = new TableDataSourceItem("Products", sqlServer) { Table = "Products" };

// Create visualizations with different data
var salesChart = new BarChartVisualization("Sales", salesData);
var customerGrid = new GridVisualization("Customers", customersData);
var productList = new GridVisualization("Products", productsData);
```

### Multiple Data Sources

```csharp
var document = new RdashDocument("Multi-Source Dashboard");

// SQL Server data
var sqlSource = new MicrosoftSqlServerDataSource { ... };
var sqlData = new TableDataSourceItem("Sales", sqlSource);

// REST API data
var restSource = new RestDataSource { ... };
var apiData = new RestDataSourceItem("Marketing", restSource);

// Excel data
var excelSource = new ExcelDataSource { ... };
var excelData = new ExcelDataSourceItem("Budget", excelSource);

// Create visualizations from different sources
document.Visualizations.Add(new BarChartVisualization("Sales", sqlData));
document.Visualizations.Add(new LineChartVisualization("Campaigns", apiData));
document.Visualizations.Add(new GridVisualization("Budget", excelData));
```

## Builder Pattern

For REST APIs and some other sources, you can use builders:

```csharp
var dataSourceItem = new RestServiceBuilder("https://api.example.com/data")
    .SetTitle("API Data")
    .SetSubtitle("Sales Information")
    .SetFields(new List<Field>
    {
        new TextField("ProductName"),
        new NumberField("Revenue"),
        new DateField("Date")
    })
    .Build();
```

## Authentication

Some data sources require authentication:

### SQL Server Authentication

```csharp
var sqlDataSource = new MicrosoftSqlServerDataSource
{
    Host = "server.database.windows.net",
    Database = "SalesDB",
    // Authentication is typically handled by Reveal SDK at runtime
};
```

### API Authentication

```csharp
var restDataSource = new RestDataSource
{
    Url = "https://api.example.com",
    // Authentication typically configured in Reveal SDK
    UseAnonymousAuthentication = false
};
```

## Best Practices

### 1. Use Descriptive Titles

```csharp
// Good
var dataSource = new MicrosoftSqlServerDataSource
{
    Title = "Production SQL Server",
    Subtitle = "Sales Database"
};

// Avoid
var dataSource = new MicrosoftSqlServerDataSource
{
    Title = "DB1"
};
```

### 2. Organize Connection Management

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
            Table = "Sales",
            Title = "Sales Data"
        };
    }
}
```

### 3. Define Field Schemas

For REST APIs, Excel, JSON, and CSV, always define fields:

```csharp
var dataSourceItem = new RestDataSourceItem("API Data", restSource);

// Define all expected fields
dataSourceItem.Fields.Add(new TextField("id"));
dataSourceItem.Fields.Add(new TextField("name"));
dataSourceItem.Fields.Add(new NumberField("value"));
dataSourceItem.Fields.Add(new DateField("date"));
```

### 4. Handle Connection Errors

```csharp
try
{
    var document = new RdashDocument("Dashboard");
    var data = CreateDataSource();
    var viz = new GridVisualization("Data", data);
    document.Visualizations.Add(viz);
    document.Save("dashboard.rdash");
}
catch (Exception ex)
{
    Console.WriteLine($"Error creating dashboard: {ex.Message}");
}
```

## Advanced Scenarios

### Dynamic Data Sources

```csharp
public DataSourceItem CreateDataSource(string sourceType, string config)
{
    switch (sourceType)
    {
        case "sql":
            var sqlSource = new MicrosoftSqlServerDataSource { ... };
            return new TableDataSourceItem("Data", sqlSource);
            
        case "rest":
            var restSource = new RestDataSource { ... };
            return new RestDataSourceItem("Data", restSource);
            
        case "excel":
            var excelSource = new ExcelDataSource { ... };
            return new ExcelDataSourceItem("Data", excelSource);
            
        default:
            throw new ArgumentException("Unknown source type");
    }
}
```

### Parameterized Data Sources

```csharp
public DataSourceItem CreateFilteredData(int year, string region)
{
    var sqlSource = new MicrosoftSqlServerDataSource { ... };
    
    return new ProcedureDataSourceItem("Filtered Sales", sqlSource)
    {
        Procedure = "GetSalesByYearAndRegion",
        ProcedureParameters = new Dictionary<string, object>
        {
            { "Year", year },
            { "Region", region }
        }
    };
}
```

## Related Topics

- [RdashDocument](rdash-document.md) - Working with dashboards
- [Visualizations](visualizations.md) - Creating visualizations
- [How-To: Connect to SQL Server](../how-to/data-sources/connect-to-sql-server.md)
- [How-To: Connect to REST APIs](../how-to/data-sources/connect-to-rest-api.md)
- [API Reference: Data Sources](../api-reference/data-sources/README.md)

## Examples

See complete examples:
- [Sales Dashboard with SQL Server](../examples/sales-dashboard.md)
- [Marketing Dashboard with REST API](../examples/marketing-dashboard.md)
