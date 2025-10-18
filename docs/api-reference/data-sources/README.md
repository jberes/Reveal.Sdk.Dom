# Data Sources API Reference

Complete reference for all supported data sources in Reveal.Sdk.Dom.

## Overview

This section provides detailed information about all data source types supported by Reveal.Sdk.Dom. Each data source has specific properties and configuration options.

## Database Data Sources

### Microsoft SQL Server

**Class**: `MicrosoftSqlServerDataSource`

**Properties**:
- `Host` (string) - Server address
- `Database` (string) - Database name
- `Port` (int) - Optional port number
- `Title` (string) - Display name
- `Subtitle` (string) - Optional subtitle

**Data Source Items**:
- `TableDataSourceItem` - For tables and views
- `ProcedureDataSourceItem` - For stored procedures
- `FunctionDataSourceItem` - For functions

**Example**:
```csharp
var dataSource = new MicrosoftSqlServerDataSource
{
    Host = "server.database.windows.net",
    Database = "SalesDB",
    Title = "Sales Database"
};

var tableItem = new TableDataSourceItem("Sales", dataSource)
{
    Table = "SalesData"
};
```

### Microsoft Azure SQL Server

**Class**: `MicrosoftAzureSqlServerDataSource`

Same as `MicrosoftSqlServerDataSource` with Azure-specific optimizations.

### MySQL

**Class**: `MySQLDataSource`

**Properties**:
- `Host` (string) - Server address
- `Database` (string) - Database name
- `Port` (int) - Port (default: 3306)
- `Title` (string) - Display name

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
