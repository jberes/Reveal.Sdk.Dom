# Data Sources API Reference

Complete reference with code samples for all 30+ supported data sources in Reveal.Sdk.Dom.

## Quick Navigation

Jump directly to the data source you need:

### 🗄️ Database Data Sources
- [Microsoft SQL Server](#microsoft-sql-server) | [Azure SQL](#microsoft-azure-sql-server) | [MySQL](#mysql) | [PostgreSQL](#postgresql) | [Oracle](#oracle) | [MongoDB](#mongodb)
- [Amazon Redshift](#amazon-redshift) | [Snowflake](#snowflake)

### ☁️ Cloud Storage Data Sources  
- [Microsoft OneDrive](#microsoft-onedrive) | [SharePoint](#microsoft-sharepoint) | [Google Drive](#google-drive) | [Google Sheets](#google-sheets)
- [Dropbox](#dropbox) | [Box](#box) | [Amazon S3](#amazon-s3)

### 📊 Analytics Platform Data Sources
- [Analysis Services](#microsoft-analysis-services) | [Azure Analysis Services](#microsoft-azure-analysis-services) | [Azure Synapse](#microsoft-azure-synapse-analytics)
- [Google Analytics 4](#google-analytics-4) | [Google BigQuery](#google-bigquery) | [Amazon Athena](#amazon-athena)

### 🌐 Web Services & APIs
- [REST API](#rest-api) | [OData](#odata) | [Web Services (SOAP)](#web-service-soap)

### 📁 File-Based Data Sources
- [Excel Files](#excel-files) | [CSV Files](#csv-files) | [JSON Files](#json-files) | [Local Files](#local-files)

### 🔧 Reference Information
- [Data Source Item Types](#data-source-item-types) | [Field Types](#field-types) | [Authentication](#authentication) | [Common Properties](#common-properties)

---

## Database Data Sources

### Microsoft SQL Server

Connect to Microsoft SQL Server databases with full support for tables, views, stored procedures, and functions.

**Class:** `Microsoft.SqlServerDataSource`

**Key Properties:**
- `Host` (string) - Server address
- `Database` (string) - Database name
- `Port` (int) - Server port (default: 1433)

**Supported Items:**
- `TableDataSourceItem` - For tables and views
- `ProcedureDataSourceItem` - For stored procedures  
- `FunctionDataSourceItem` - For functions

**Complete Example:**

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;

// Create SQL Server data source
var sqlDataSource = new MicrosoftSqlServerDataSource()
{
    Id = "SqlServerDataSource",
    Title = "Sales Database",
    Host = "sql-server.company.com",
    Database = "SalesDB",
    Port = 1433
};

// Add table data source item
var salesTableItem = new TableDataSourceItem("Sales_Orders", sqlDataSource)
{
    Id = "SalesOrdersTable",
    Title = "Sales Orders"
};

// Add stored procedure item
var salesReportProc = new ProcedureDataSourceItem("sp_GetSalesReport", sqlDataSource)
{
    Id = "SalesReportProc",
    Title = "Monthly Sales Report",
    Parameters = new List<FunctionParameter>
    {
        new FunctionParameter { Name = "@StartDate", DataType = DataType.Date },
        new FunctionParameter { Name = "@EndDate", DataType = DataType.Date }
    }
};

// Create dashboard with SQL Server data
var document = new RdashDocument("Sales Dashboard");
document.DataSources.Add(sqlDataSource);

// Create visualization using the table
var chartVisualization = new ColumnChartVisualization("Sales by Month", salesTableItem)
{
    IsTitleVisible = true
};
chartVisualization.Values.Add(new MeasureColumn("OrderAmount"));
chartVisualization.Category = new DimensionColumn("OrderDate");

document.Visualizations.Add(chartVisualization);
```

### Microsoft Azure SQL Server

Connect to Azure SQL Database with enhanced security and authentication options.

**Class:** `Microsoft.AzureSqlDataSource`

**Key Properties:**
- `Host` (string) - Azure SQL server address (.database.windows.net)
- `Database` (string) - Database name
- `EncryptConnection` (bool) - Enable SSL encryption (recommended: true)

**Complete Example:**

```csharp
// Create Azure SQL data source
var azureSqlDataSource = new MicrosoftAzureSqlDataSource()
{
    Id = "AzureSqlDataSource",
    Title = "Cloud Analytics DB",
    Host = "mycompany-analytics.database.windows.net",
    Database = "AnalyticsDB",
    EncryptConnection = true
};

// Create table item with specific schema
var customerAnalyticsTable = new TableDataSourceItem("dbo.CustomerAnalytics", azureSqlDataSource)
{
    Id = "CustomerAnalyticsTable",
    Title = "Customer Analytics Data"
};

// Create dashboard
var document = new RdashDocument("Azure Analytics Dashboard");
document.DataSources.Add(azureSqlDataSource);

// Create pie chart for customer segments
var pieChart = new PieChartVisualization("Customer Segments", customerAnalyticsTable)
{
    IsTitleVisible = true
};
pieChart.Values.Add(new MeasureColumn("CustomerCount"));
pieChart.Category = new DimensionColumn("Segment");

document.Visualizations.Add(pieChart);
```

### MySQL

Connect to MySQL databases with support for all standard MySQL features.

**Class:** `MySQL.MySqlDataSource`

**Key Properties:**
- `Host` (string) - MySQL server address
- `Database` (string) - Database name  
- `Port` (int) - Server port (default: 3306)

**Complete Example:**

```csharp
// Create MySQL data source
var mysqlDataSource = new MySqlDataSource()
{
    Id = "MySqlDataSource", 
    Title = "Product Catalog DB",
    Host = "mysql.company.com",
    Database = "ProductCatalog",
    Port = 3306
};

// Add product table
var productsTable = new TableDataSourceItem("products", mysqlDataSource)
{
    Id = "ProductsTable",
    Title = "Products"
};

// Create dashboard
var document = new RdashDocument("Product Analytics");
document.DataSources.Add(mysqlDataSource);

// Create bar chart for product categories
var barChart = new BarChartVisualization("Products by Category", productsTable)
{
    IsTitleVisible = true
};
barChart.Values.Add(new MeasureColumn("ProductCount"));
barChart.Category = new DimensionColumn("CategoryName");

document.Visualizations.Add(barChart);
```

### PostgreSQL

Connect to PostgreSQL databases with full schema and advanced feature support.

**Class:** `PostgreSQL.PostgreSqlDataSource`

**Key Properties:**
- `Host` (string) - PostgreSQL server address
- `Database` (string) - Database name
- `Port` (int) - Server port (default: 5432)
- `Schema` (string) - Schema name (default: "public")

**Complete Example:**

```csharp
// Create PostgreSQL data source
var postgresDataSource = new PostgreSqlDataSource()
{
    Id = "PostgreSqlDataSource",
    Title = "Analytics Database",
    Host = "postgres.company.com", 
    Database = "analytics",
    Port = 5432,
    Schema = "reporting"
};

// Add view from specific schema
var monthlyStatsView = new TableDataSourceItem("monthly_stats", postgresDataSource)
{
    Id = "MonthlyStatsView",
    Title = "Monthly Statistics"
};

// Create dashboard
var document = new RdashDocument("PostgreSQL Analytics");
document.DataSources.Add(postgresDataSource);

// Create line chart for trends
var lineChart = new LineChartVisualization("Monthly Trends", monthlyStatsView)
{
    IsTitleVisible = true
};
lineChart.Values.Add(new MeasureColumn("Revenue"));
lineChart.Category = new DimensionColumn("Month");

document.Visualizations.Add(lineChart);
```

### Oracle

Connect to Oracle databases with comprehensive support for Oracle-specific features.

**Class:** `Oracle.OracleDataSource`

**Key Properties:**
- `Host` (string) - Oracle server address
- `Database` (string) - Database name/SID
- `Port` (int) - Server port (default: 1521)
- `ServiceName` (string) - Oracle service name

**Complete Example:**

```csharp
// Create Oracle data source
var oracleDataSource = new OracleDataSource()
{
    Id = "OracleDataSource",
    Title = "Enterprise Database",
    Host = "oracle.company.com",
    Database = "ORCL",
    Port = 1521,
    ServiceName = "ENTERPRISE"
};

// Add Oracle function
var salesFunction = new FunctionDataSourceItem("GET_SALES_DATA", oracleDataSource)
{
    Id = "SalesFunction", 
    Title = "Sales Data Function",
    Parameters = new List<FunctionParameter>
    {
        new FunctionParameter { Name = "p_year", DataType = DataType.Number },
        new FunctionParameter { Name = "p_region", DataType = DataType.String }
    }
};

// Create dashboard
var document = new RdashDocument("Oracle Enterprise Dashboard");
document.DataSources.Add(oracleDataSource);

// Create spline chart
var splineChart = new SplineChartVisualization("Sales Trend", salesFunction)
{
    IsTitleVisible = true
};
splineChart.Values.Add(new MeasureColumn("SalesAmount"));
splineChart.Category = new DimensionColumn("SalesDate");

document.Visualizations.Add(splineChart);
```

### MongoDB

Connect to MongoDB collections with document-based querying support.

**Class:** `MongoDB.MongoDbDataSource`

**Key Properties:**
- `ConnectionString` (string) - MongoDB connection string
- `Database` (string) - Database name

**Complete Example:**

```csharp
// Create MongoDB data source
var mongoDataSource = new MongoDbDataSource()
{
    Id = "MongoDataSource",
    Title = "User Activity DB",
    ConnectionString = "mongodb://mongo.company.com:27017",
    Database = "UserActivity"
};

// Add collection item
var userEventsCollection = new TableDataSourceItem("user_events", mongoDataSource)
{
    Id = "UserEventsCollection",
    Title = "User Events"
};

// Create dashboard
var document = new RdashDocument("MongoDB Analytics");
document.DataSources.Add(mongoDataSource);

// Create area chart for user activity
var areaChart = new AreaChartVisualization("User Activity Over Time", userEventsCollection)
{
    IsTitleVisible = true
};
areaChart.Values.Add(new MeasureColumn("EventCount"));
areaChart.Category = new DimensionColumn("EventDate"));

document.Visualizations.Add(areaChart);
```

### PostgreSQL

**Class**: `PostgreSQLDataSource`

**Properties**:
- `Host` (string) - Server address
- `Database` (string) - Database name
- `Port` (int) - Port (default: 5432)
- `Title` (string) - Display name

### Oracle

**Class**: `OracleDataSource`

**Properties**:
- `Host` (string) - Server address
- `Service` (string) - Service name or SID
- `Port` (int) - Port (default: 1521)
- `Title` (string) - Display name

### MongoDB

**Class**: `MongoDBDataSource`

**Properties**:
- `ConnectionString` (string) - MongoDB connection string
- `Database` (string) - Database name
- `Title` (string) - Display name

### Amazon Redshift

**Class**: `AmazonRedshiftDataSource`

**Properties**:
- `Host` (string) - Cluster endpoint
- `Database` (string) - Database name
- `Port` (int) - Port (default: 5439)
- `Title` (string) - Display name

### Snowflake

**Class**: `SnowflakeDataSource`

**Properties**:
- `Account` (string) - Snowflake account identifier
- `Database` (string) - Database name
- `Warehouse` (string) - Warehouse name
- `Title` (string) - Display name

## Cloud Storage Data Sources

### Microsoft OneDrive

**Class**: `MicrosoftOneDriveDataSource`

**Properties**:
- `Title` (string) - Display name

**Data Source Items**:
- `ExcelDataSourceItem` - For Excel files on OneDrive

**Example**:
```csharp
var oneDrive = new MicrosoftOneDriveDataSource
{
    Title = "OneDrive Files"
};

var excelItem = new ExcelDataSourceItem("Sales", oneDrive)
{
    ResourcePath = "/Documents/Sales.xlsx",
    Sheet = "Sheet1"
};
```

### Microsoft SharePoint

**Class**: `MicrosoftSharePointDataSource`

**Properties**:
- `SiteUrl` (string) - SharePoint site URL
- `Title` (string) - Display name

### Google Drive

**Class**: `GoogleDriveDataSource`

**Properties**:
- `Title` (string) - Display name

### Google Sheets

**Class**: `GoogleSheetsDataSource`

**Properties**:
- `Title` (string) - Display name

**Data Source Items**:
- `GoogleSheetsDataSourceItem` - For Google Sheets

### Dropbox

**Class**: `DropboxDataSource`

**Properties**:
- `Title` (string) - Display name

### Box

**Class**: `BoxDataSource`

**Properties**:
- `Title` (string) - Display name

### Amazon S3

**Class**: `AmazonS3DataSource`

**Properties**:
- `Region` (string) - AWS region
- `Bucket` (string) - S3 bucket name
- `Title` (string) - Display name

## Analytics Services

### Microsoft Analysis Services

**Class**: `MicrosoftAnalysisServicesDataSource`

**Properties**:
- `Host` (string) - Server address
- `Catalog` (string) - Catalog name
- `Title` (string) - Display name

### Microsoft Azure Analysis Services

**Class**: `MicrosoftAzureAnalysisServicesDataSource`

**Properties**:
- `ServerUrl` (string) - Azure AS server URL
- `Catalog` (string) - Catalog name
- `Title` (string) - Display name

### Microsoft Azure Synapse Analytics

**Class**: `MicrosoftAzureSynapseAnalyticsDataSource`

**Properties**:
- `Host` (string) - Synapse workspace URL
- `Database` (string) - Database name
- `Title` (string) - Display name

### Google Analytics 4

**Class**: `GoogleAnalytics4DataSource`

**Properties**:
- `PropertyId` (string) - GA4 property ID
- `Title` (string) - Display name

### Google BigQuery

**Class**: `GoogleBigQueryDataSource`

**Properties**:
- `ProjectId` (string) - GCP project ID
- `Dataset` (string) - BigQuery dataset
- `Title` (string) - Display name

### Amazon Athena

**Class**: `AmazonAthenaDataSource`

**Properties**:
- `Region` (string) - AWS region
- `Database` (string) - Athena database
- `WorkGroup` (string) - Athena work group
- `Title` (string) - Display name

## Web Services and APIs

### REST API

**Class**: `RestDataSource`

**Properties**:
- `Url` (string) - Base URL or endpoint
- `Title` (string) - Display name
- `Subtitle` (string) - Optional subtitle
- `UseAnonymousAuthentication` (bool) - Use anonymous access

**Data Source Items**:
- `RestDataSourceItem` - For REST endpoints

**Required**: Field definitions must be provided

**Example**:
```csharp
var restSource = new RestDataSource
{
    Url = "https://api.example.com/v1",
    Title = "Sales API"
};

var restItem = new RestDataSourceItem("Sales", restSource)
{
    Url = "https://api.example.com/v1/sales"
};

// Define fields (required)
restItem.Fields.Add(new TextField("ProductName"));
restItem.Fields.Add(new NumberField("Revenue"));
restItem.Fields.Add(new DateField("Date"));
```

### OData

**Class**: `ODataDataSource`

**Properties**:
- `Url` (string) - OData service URL
- `Title` (string) - Display name

### Web Service

**Class**: `WebServiceDataSource`

**Properties**:
- `Url` (string) - Web service URL
- `Title` (string) - Display name

## File-Based Data Sources

### Excel

**Class**: `ExcelDataSource`

**Properties**:
- `Title` (string) - Display name

**Data Source Items**:
- `ExcelDataSourceItem` - For Excel worksheets

**Example**:
```csharp
var excelSource = new ExcelDataSource
{
    Title = "Excel Files"
};

var excelItem = new ExcelDataSourceItem("Sales", excelSource)
{
    ResourcePath = "C:\\Data\\Sales.xlsx",
    Sheet = "Sheet1",
    FirstRowContainsLabels = true
};

// Define fields (required)
excelItem.Fields.Add(new TextField("Product"));
excelItem.Fields.Add(new NumberField("Quantity"));
```

### CSV

**Class**: `CsvDataSource`

**Properties**:
- `Title` (string) - Display name

**Data Source Items**:
- `CsvDataSourceItem` - For CSV files

**Example**:
```csharp
var csvSource = new CsvDataSource
{
    Title = "CSV Files"
};

var csvItem = new CsvDataSourceItem("Sales", csvSource)
{
    ResourcePath = "C:\\Data\\sales.csv",
    Separator = ",",
    FirstRowContainsLabels = true
};
```

### JSON

**Class**: `JsonDataSource`

**Properties**:
- `Title` (string) - Display name

**Data Source Items**:
- `JsonDataSourceItem` - For JSON files

**Example**:
```csharp
var jsonSource = new JsonDataSource
{
    Title = "JSON Data"
};

var jsonItem = new JsonDataSourceItem("Products", jsonSource)
{
    ResourcePath = "C:\\Data\\products.json"
};

// Define fields (required)
jsonItem.Fields.Add(new TextField("id"));
jsonItem.Fields.Add(new TextField("name"));
```

### Local File

**Class**: `LocalFileDataSource`

**Properties**:
- `Title` (string) - Display name

Generic file data source for local files.

## Data Source Item Types

### TableDataSourceItem

For database tables and views.

**Properties**:
- `Table` (string) - Table or view name
- `Database` (string) - Optional database name
- `Schema` (string) - Optional schema name

### ProcedureDataSourceItem

For stored procedures.

**Properties**:
- `Procedure` (string) - Procedure name
- `ProcedureParameters` (Dictionary<string, object>) - Parameters

### FunctionDataSourceItem

For database functions.

**Properties**:
- `Function` (string) - Function name
- `FunctionParameters` (Dictionary<string, object>) - Parameters

## Field Types

Define the schema for file and API-based sources:

### TextField
For string/text data
```csharp
new TextField("CustomerName")
```

### NumberField
For numeric data
```csharp
new NumberField("Revenue")
```

### DateField
For date/time data
```csharp
new DateField("OrderDate")
```

### BooleanField
For boolean data
```csharp
new BooleanField("IsActive")
```

## Authentication

Authentication is typically configured at runtime through the Reveal SDK. The data source definitions in Reveal.Sdk.Dom specify which authentication is required:

- `UseAnonymousAuthentication` - For anonymous access
- Other authentication is handled by Reveal SDK credential providers

## Builder Classes

Some data sources support builder patterns:

### RestServiceBuilder

```csharp
var item = new RestServiceBuilder("https://api.example.com/data")
    .SetTitle("API Data")
    .SetSubtitle("Sales")
    .SetFields(new List<Field> { ... })
    .Build();
```

## Common Properties

All data sources share these base properties:

- `Id` (string) - Unique identifier (auto-generated)
- `Title` (string) - Display name
- `Subtitle` (string) - Optional subtitle
- `Provider` (string) - Provider identifier (auto-set)

All data source items share:

- `Id` (string) - Unique identifier (auto-generated)
- `Title` (string) - Display name
- `Subtitle` (string) - Optional subtitle
- `DataSource` - Reference to parent data source
- `Fields` - Collection of field definitions (for certain types)

## See Also

- [Data Sources Core Concepts](../../core-concepts/data-sources.md)
- [How to Connect to SQL Server](../../how-to/data-sources/connect-to-sql-server.md)
- [How to Connect to REST APIs](../../how-to/data-sources/connect-to-rest-api.md)
- [How to Work with Excel Files](../../how-to/data-sources/work-with-excel.md)
