# Glossary

Terms and definitions used in Reveal.Sdk.Dom documentation.

## A

### Aggregation
The process of combining multiple data values into a single result. Common types include Sum, Average, Count, Min, and Max.

**Example**: Summing individual sales transactions to get total sales.

### API (Application Programming Interface)
A set of functions and procedures that allow applications to access features or data. In this context, REST APIs provide data over HTTP.

## B

### Builder Pattern
A design pattern that provides a fluent interface for constructing objects step by step.

**Example**: `new RestServiceBuilder(url).SetTitle("API").Build()`

## C

### Choropleth Map
A map visualization where regions are colored based on data values.

**Example**: US states colored by sales volume.

### Column Span
The width of a visualization in a dashboard grid, measured in columns (out of 12 total columns).

### Connection String
A string containing parameters for connecting to a data source, such as server address and database name.

## D

### Dashboard
A visual display of key information and data, organized for quick reference and analysis.

### Data Source
The definition of where data comes from (server, API, file) and how to connect to it.

**Example**: SQL Server connection, REST API endpoint.

### Data Source Item
A specific dataset from a data source (table, query, API endpoint, Excel sheet).

**Example**: The "Sales" table from SQL Server, the "/products" endpoint from an API.

### Dimension
A categorical attribute that provides context for measures. Used for grouping and filtering data.

**Example**: Product names, regions, categories, dates.

### Dimension Data Field
A field containing categorical data (non-numeric) used for labels and grouping in visualizations.

## E

### Excel Data Source
A data source that reads data from Microsoft Excel files (.xlsx, .xls).

## F

### Field
A column or property in a dataset. Can be a dimension (categorical) or measure (numeric).

### Filter
A component that allows users to narrow down data displayed in a dashboard or visualization.

## G

### Gauge
A visualization type that displays a single value on a scale, often showing progress toward a goal.

### Grid
A table-style visualization that displays data in rows and columns.

## J

### JSON (JavaScript Object Notation)
A text-based data format commonly used for storing and transmitting data, especially in APIs.

## K

### KPI (Key Performance Indicator)
A measurable value that demonstrates how effectively objectives are being achieved.

**Example**: Total sales, customer satisfaction score, conversion rate.

## L

### Label
A dimension field used to identify categories or items in a visualization.

**Example**: Product names on the x-axis of a bar chart.

## M

### Measure
A numeric value that can be aggregated (summed, averaged, counted, etc.).

**Example**: Sales amount, quantity sold, price.

### Measure Data Field
A field containing numeric data that can be aggregated in visualizations.

## O

### OHLC Chart
A financial chart showing Open, High, Low, and Close values, typically for stock prices.

## P

### Pivot Table
An interactive table that can group and aggregate data dynamically.

### Procedure (Stored Procedure)
A prepared SQL statement stored in a database that can be executed with parameters.

## R

### RdashDocument
The root object representing a complete Reveal dashboard, containing all visualizations, data sources, and settings.

### REST (Representational State Transfer)
An architectural style for APIs that uses HTTP requests to access and manipulate data.

### REST Data Source
A data source that connects to REST APIs to retrieve JSON or XML data.

### Row Span
The height of a visualization in a dashboard grid, measured in rows.

## S

### Schema
The structure of a database or data source, defining tables, columns, and their types.

### Scatter Chart
A visualization that plots points based on two numeric values, showing relationships or correlations.

### SDK (Software Development Kit)
A collection of tools, libraries, and documentation for developing applications.

### SQL (Structured Query Language)
A language for managing and querying relational databases.

### Stacked Chart
A chart where multiple data series are stacked on top of each other, showing both individual and total values.

## T

### Table Data Source Item
A data source item that represents a database table or view.

### Target Framework
The version of .NET that your application is built for.

**Example**: .NET 6.0, .NET 8.0, .NET Framework 4.6.2.

## U

### URL (Uniform Resource Locator)
The address of a resource on the internet.

**Example**: `https://api.example.com/v1/sales`

## V

### Variable
A named value that can be used throughout a dashboard to provide dynamic parameters or filters.

### Visualization
A graphical representation of data, such as a chart, grid, or map.

## Common Abbreviations

- **API** - Application Programming Interface
- **CSV** - Comma-Separated Values
- **DOM** - Document Object Model
- **HTTP** - Hypertext Transfer Protocol
- **JSON** - JavaScript Object Notation
- **KPI** - Key Performance Indicator
- **OHLC** - Open-High-Low-Close
- **REST** - Representational State Transfer
- **SDK** - Software Development Kit
- **SQL** - Structured Query Language
- **URL** - Uniform Resource Locator
- **XML** - eXtensible Markup Language

## Data Types

### Field Types in Reveal.Sdk.Dom

- **TextField** - String/text data
- **NumberField** - Numeric data (integers and decimals)
- **DateField** - Date and time data
- **BooleanField** - True/false data

### Aggregation Types

- **Sum** - Add all values together
- **Average** - Calculate the mean
- **Count** - Count number of items
- **DistinctCount** - Count unique items
- **Min** - Find minimum value
- **Max** - Find maximum value
- **Median** - Find middle value
- **StdDev** - Calculate standard deviation
- **Variance** - Calculate variance

## Visualization Types

### Chart Types
- **Bar Chart** - Horizontal bars
- **Column Chart** - Vertical columns
- **Line Chart** - Connected line segments
- **Area Chart** - Filled area under a line
- **Pie Chart** - Circular sectors
- **Doughnut Chart** - Pie chart with center hole
- **Scatter Chart** - Points on X/Y axes
- **Bubble Chart** - Scatter with sized bubbles

### Gauge Types
- **Linear Gauge** - Progress on a line
- **Circular Gauge** - Progress on a circle
- **Bullet Graph** - Linear gauge with target
- **Radial Gauge** - Segmented circular gauge

### Grid Types
- **Grid** - Standard table
- **Pivot Table** - Interactive crosstab table

### Map Types
- **Choropleth Map** - Colored regions
- **Scatter Map** - Points on a map

### Other Types
- **KPI** - Key metrics with targets
- **Sparkline** - Compact trend line
- **Text Box** - Static text content
- **Image** - Display images

## File Formats

### .rdash
The Reveal dashboard file format. A JSON-based format containing the complete dashboard definition including visualizations, data sources, and settings.

### .xlsx / .xls
Microsoft Excel file formats.

### .csv
Comma-Separated Values file format for tabular data.

### .json
JavaScript Object Notation file format.

## Related Concepts

### Authentication Provider
A component in Reveal SDK that provides credentials for connecting to data sources. Note: This is configured in Reveal SDK, not Reveal.Sdk.Dom.

### Reveal SDK
The full Reveal BI platform including UI components for displaying dashboards in applications.

### NuGet
The package manager for .NET, used to distribute and consume .NET libraries.

### Namespace
A container for organizing code and preventing naming conflicts.

**Example**: `Reveal.Sdk.Dom`, `Reveal.Sdk.Dom.Data`

## Usage Examples

### Dashboard Document
```csharp
var document = new RdashDocument("My Dashboard");
```

### Data Source
```csharp
var sqlSource = new MicrosoftSqlServerDataSource
{
    Host = "server.database.windows.net",
    Database = "SalesDB"
};
```

### Visualization
```csharp
var chart = new BarChartVisualization("Sales", dataSourceItem);
```

### Field
```csharp
var salesField = new MeasureDataField("Sales")
{
    Aggregation = AggregationType.Sum
};
```

## Need More Information?

- [Getting Started](getting-started/quick-start.md) - Begin using Reveal.Sdk.Dom
- [Core Concepts](core-concepts/rdash-document.md) - Understand key concepts
- [API Reference](api-reference/) - Detailed API documentation
- [FAQ](faq.md) - Common questions
