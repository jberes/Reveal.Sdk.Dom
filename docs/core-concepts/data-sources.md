# Mastering Data Sources in Reveal.Sdk.Dom

Connect your dashboards to diverse data systems including databases, cloud services, APIs, and files through Reveal.Sdk.Dom's comprehensive data source architecture.

## What You'll Learn

By the end of this guide, you'll understand:

- **Data Source Architecture** - The two-tier model of connections and datasets
- **Supported Data Systems** - 30+ data sources across databases, cloud services, and files
- **Connection Patterns** - Best practices for each data source type
- **Field Schema Definition** - Structuring data for file-based and API sources
- **Multi-Source Integration** - Combining data from multiple systems in one dashboard
- **Authentication & Security** - Securing data connections appropriately
- **Advanced Scenarios** - Dynamic sources, parameterization, and error handling

## Why Data Sources Matter

Data sources are the foundation of every dashboard - they determine what data you can visualize and how efficiently your dashboards perform. Understanding the data source architecture enables you to:

- **Connect to Any System** - Database, cloud service, file, or API
- **Optimize Performance** - Choose the right connection pattern for your data
- **Enable Reusability** - Share connections across multiple visualizations
- **Ensure Security** - Implement proper authentication and access control
- **Scale Effectively** - Manage connections efficiently as dashboards grow

Whether you're building executive dashboards from SQL databases, operational reports from REST APIs, or financial analyses from Excel files, mastering data sources is essential for creating robust, performant BI solutions.

> 💡 **Prerequisites**: Familiarity with [Basic Concepts](../getting-started/basic-concepts.md) and [Installation](../getting-started/installation.md) is recommended.

## Understanding the Data Source Architecture

Reveal.Sdk.Dom uses a sophisticated two-tier architecture that separates connection management from data access, providing flexibility and reusability.

### The Two-Tier Model

Think of data connectivity as a two-step process:

```
1. DataSource (Connection) → "How do I connect?"
2. DataSourceItem (Dataset) → "What data do I get?"
```

This separation provides several critical advantages:

**Reusability**
```csharp
// Define connection once
var salesDB = new MicrosoftSqlServerDataSource
{
    Host = "sales.database.windows.net",
    Database = "SalesDB"
};

// Use for multiple datasets
var salesOrders = new TableDataSourceItem("Orders", salesDB) { Table = "Orders" };
var salesCustomers = new TableDataSourceItem("Customers", salesDB) { Table = "Customers" };
var salesProducts = new TableDataSourceItem("Products", salesDB) { Table = "Products" };
```

**Flexibility**
```csharp
// Easy to switch between datasets from same source
var q1Data = new TableDataSourceItem("Q1 Sales", salesDB) { Table = "Q1_Sales" };
var q2Data = new TableDataSourceItem("Q2 Sales", salesDB) { Table = "Q2_Sales" };
```

**Organization**
```csharp
// Clear separation of concerns
var productionDB = CreateProductionConnection();  // DataSource
var developmentDB = CreateDevelopmentConnection(); // DataSource

var productionSales = new TableDataSourceItem("Sales", productionDB);
var developmentSales = new TableDataSourceItem("Sales", developmentDB);
```

## Next Steps

Now that you understand data sources, continue your learning journey:

1. **[Create Visualizations](../how-to/visualizations/create-charts.md)** - Use your data sources to create charts and grids
2. **[Connect to SQL Server](../how-to/data-sources/connect-to-sql-server.md)** - Detailed SQL Server integration guide
3. **[Connect to REST APIs](../how-to/data-sources/connect-to-rest-api.md)** - Complete REST API integration tutorial

## Related Topics

- **[RDash Document Structure](rdash-document.md)** - Understanding dashboard architecture
- **[Field Types and Aggregations](types-and-enums.md)** - Data typing and aggregation patterns
- **[Best Practices](../best-practices.md)** - Professional development guidelines

> 💡 **Pro Tip**: Start with database sources (SQL Server, PostgreSQL) for learning, as they provide automatic schema discovery. Once comfortable, move to file and API sources that require explicit field definitions.
