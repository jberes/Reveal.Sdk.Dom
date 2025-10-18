# Types and Enums Reference

This guide provides a comprehensive reference for all the key types and enums used in Reveal.Sdk.Dom. Understanding these types is essential for creating effective dashboards and visualizations.

## Field Types

Field types define the data schema for your data sources. Use these when defining fields in data source items.

### TextField
Used for string/text data, categories, and labels.

```csharp
var nameField = new TextField("CustomerName")
{
    FieldLabel = "Customer Name"
};
```

**Use Cases:**
- Names, descriptions, categories
- IDs and codes
- Text-based lookup values

### NumberField  
Used for numeric data that can be used in calculations and aggregations.

```csharp
var salesField = new NumberField("SalesAmount")
{
    FieldLabel = "Sales ($)"
};
```

**Use Cases:**
- Revenue, prices, quantities
- Measurements and metrics
- Calculated values

### DateField
Used for date and time data, including timestamps.

```csharp
var orderDateField = new DateField("OrderDate")
{
    FieldLabel = "Order Date"
};
```

**Use Cases:**
- Transaction dates
- Created/modified timestamps  
- Scheduling and planning dates

### BooleanField
Used for true/false data and binary states.

```csharp
var activeField = new BooleanField("IsActive")
{
    FieldLabel = "Active Status"
};
```

**Use Cases:**
- Status flags (active/inactive, enabled/disabled)
- Yes/No responses
- Binary conditions

## Data Field Types

Data field types are used when mapping fields to visualization properties (labels, values, etc.).

### DimensionDataField
Used for categorical data that provides context and grouping.

```csharp
var categoryField = new DimensionDataField("ProductCategory")
{
    FieldLabel = "Product Category"
};

// Use in visualizations
chart.Labels.Add(categoryField);
```

**Characteristics:**
- Non-numeric (typically)
- Used for grouping and categorization
- Appears on axes, legends, and labels
- Examples: Product names, regions, categories

### MeasureDataField
Used for numeric data that can be aggregated and calculated.

```csharp
var revenueField = new MeasureDataField("Revenue")
{
    FieldLabel = "Total Revenue",
    Aggregation = AggregationType.Sum
};

// Use in visualizations
chart.Values.Add(revenueField);
```

**Characteristics:**
- Numeric data
- Can be aggregated (sum, average, count, etc.)
- Used for values, sizes, and metrics
- Examples: Sales amounts, quantities, percentages

### DateDataField
Used for date/time data in visualizations, especially for time-based analysis.

```csharp
var dateField = new DateDataField("OrderDate")
{
    FieldLabel = "Order Date"
};

// Use in time-based charts
lineChart.Labels.Add(dateField);
```

**Characteristics:**
- Date and time values
- Supports time-based grouping (by year, month, day)
- Used in trend analysis and time series
- Automatically provides date hierarchies

## Aggregation Types

Aggregation types determine how numeric data is combined when grouping by dimensions.

### Sum
Adds all values together.

```csharp
var totalSales = new MeasureDataField("Sales")
{
    Aggregation = AggregationType.Sum
};
```

**Use Cases:** Revenue, quantities, totals

### Average
Calculates the arithmetic mean.

```csharp
var avgPrice = new MeasureDataField("Price")
{
    Aggregation = AggregationType.Average
};
```

**Use Cases:** Average price, mean score, typical values

### Count
Counts the number of records.

```csharp
var orderCount = new MeasureDataField("OrderID")
{
    Aggregation = AggregationType.Count
};
```

**Use Cases:** Number of transactions, record counts

### DistinctCount
Counts the number of unique values.

```csharp
var uniqueCustomers = new MeasureDataField("CustomerID")
{
    Aggregation = AggregationType.DistinctCount
};
```

**Use Cases:** Unique customers, distinct products

### Min
Finds the minimum value.

```csharp
var minPrice = new MeasureDataField("Price")
{
    Aggregation = AggregationType.Min
};
```

**Use Cases:** Lowest price, earliest date, minimum score

### Max
Finds the maximum value.

```csharp
var maxSales = new MeasureDataField("Sales")
{
    Aggregation = AggregationType.Max
};
```

**Use Cases:** Highest value, latest date, peak performance

### Median
Finds the middle value when sorted.

```csharp
var medianIncome = new MeasureDataField("Income")
{
    Aggregation = AggregationType.Median
};
```

**Use Cases:** Typical values, reducing outlier impact

### StdDev
Calculates standard deviation.

```csharp
var salesVariability = new MeasureDataField("Sales")
{
    Aggregation = AggregationType.StdDev
};
```

**Use Cases:** Measuring variability, quality control

### Variance
Calculates variance.

```csharp
var priceVariance = new MeasureDataField("Price")
{
    Aggregation = AggregationType.Variance
};
```

**Use Cases:** Statistical analysis, risk measurement

## Visualization Types

### Chart Visualizations

#### BarChartVisualization
Horizontal bar chart for comparing categories.

```csharp
var barChart = new BarChartVisualization("Sales by Region", dataSourceItem);
```

**Best For:** Category comparisons, ranking data

#### ColumnChartVisualization  
Vertical column chart for comparing categories.

```csharp
var columnChart = new ColumnChartVisualization("Monthly Sales", dataSourceItem);
```

**Best For:** Time series, category comparisons

#### LineChartVisualization
Connected line segments showing trends over time.

```csharp
var lineChart = new LineChartVisualization("Sales Trend", dataSourceItem);
```

**Best For:** Trends over time, continuous data

#### AreaChartVisualization
Filled area under a line, showing cumulative values.

```csharp
var areaChart = new AreaChartVisualization("Cumulative Sales", dataSourceItem);
```

**Best For:** Showing parts of a whole over time

#### PieChartVisualization
Circular sectors showing parts of a whole.

```csharp
var pieChart = new PieChartVisualization("Market Share", dataSourceItem);
```

**Best For:** Showing proportions, parts of a whole

#### DoughnutChartVisualization
Pie chart with a hollow center.

```csharp
var doughnutChart = new DoughnutChartVisualization("Sales Distribution", dataSourceItem);
```

**Best For:** Proportions with additional center content

#### ScatterChartVisualization
Points plotted on X/Y axes showing relationships.

```csharp
var scatterChart = new ScatterChartVisualization("Price vs Quantity", dataSourceItem);
```

**Best For:** Correlations, relationships between variables

#### BubbleChartVisualization
Scatter plot with sized bubbles for a third dimension.

```csharp
var bubbleChart = new BubbleChartVisualization("Sales Analysis", dataSourceItem);
```

**Best For:** Three-dimensional comparisons

### Gauge Visualizations

#### LinearGaugeVisualization
Progress indicator on a linear scale.

```csharp
var linearGauge = new LinearGaugeVisualization("Progress", dataSourceItem);
```

**Best For:** Progress tracking, target achievement

#### CircularGaugeVisualization
Progress indicator on a circular scale.

```csharp
var circularGauge = new CircularGaugeVisualization("Performance", dataSourceItem);
```

**Best For:** KPIs, performance metrics

#### BulletGraphVisualization
Linear gauge with target and performance ranges.

```csharp
var bulletGraph = new BulletGraphVisualization("Sales Target", dataSourceItem);
```

**Best For:** Performance vs target comparison

#### RadialGaugeVisualization
Segmented circular gauge.

```csharp
var radialGauge = new RadialGaugeVisualization("Score", dataSourceItem);
```

**Best For:** Categorical performance levels

### Data Visualizations

#### GridVisualization
Standard data table with rows and columns.

```csharp
var grid = new GridVisualization("Data Details", dataSourceItem);
```

**Best For:** Detailed data inspection, raw data display

#### PivotVisualization
Interactive pivot table for data analysis.

```csharp
var pivot = new PivotVisualization("Sales Analysis", dataSourceItem);
```

**Best For:** Data exploration, cross-tabulation

### KPI Visualizations

#### KpiTargetVisualization
Key performance indicator with target comparison.

```csharp
var kpi = new KpiTargetVisualization("Revenue KPI", dataSourceItem);
```

**Best For:** Single metric tracking, goal monitoring

#### SparklineVisualization
Compact trend line visualization.

```csharp
var sparkline = new SparklineVisualization("Mini Trend", dataSourceItem);
```

**Best For:** Inline trends, dashboard overviews

### Map Visualizations

#### ChoroplethVisualization
Map with colored regions based on data values.

```csharp
var map = new ChoroplethVisualization("Sales by State", dataSourceItem);
```

**Best For:** Geographic data, regional comparisons

#### ScatterMapVisualization
Map with plotted points.

```csharp
var scatterMap = new ScatterMapVisualization("Store Locations", dataSourceItem);
```

**Best For:** Location-based data, point mapping

### Other Visualizations

#### TextBoxVisualization
Static text content and labels.

```csharp
var textBox = new TextBoxVisualization("Dashboard Title");
```

**Best For:** Titles, descriptions, instructions

#### ImageVisualization
Display images and logos.

```csharp
var image = new ImageVisualization("Company Logo");
```

**Best For:** Branding, visual elements

## Theme Types

Control the overall appearance of your dashboard.

### Theme.MountainLight
Light theme with mountain-inspired colors.

```csharp
document.Theme = Theme.MountainLight;
```

### Theme.MountainDark
Dark theme with mountain-inspired colors.

```csharp
document.Theme = Theme.MountainDark;
```

### Theme.OceanLight
Light theme with ocean-inspired colors.

```csharp
document.Theme = Theme.OceanLight;
```

### Theme.OceanDark
Dark theme with ocean-inspired colors.

```csharp
document.Theme = Theme.OceanDark;
```

## Data Source Types

### Database Sources

#### MicrosoftSqlServerDataSource
Connect to SQL Server databases.

```csharp
var sqlSource = new MicrosoftSqlServerDataSource
{
    Host = "server.database.windows.net",
    Database = "SalesDB",
    Title = "Sales Database"
};
```

#### PostgreSQLDataSource
Connect to PostgreSQL databases.

```csharp
var pgSource = new PostgreSQLDataSource
{
    Host = "localhost",
    Database = "analytics",
    Title = "Analytics DB"
};
```

#### MySqlDataSource
Connect to MySQL databases.

```csharp
var mysqlSource = new MySqlDataSource
{
    Host = "mysql.example.com",
    Database = "inventory",
    Title = "Inventory DB"
};
```

#### OracleDataSource
Connect to Oracle databases.

```csharp
var oracleSource = new OracleDataSource
{
    Host = "oracle.company.com",
    ServiceName = "ORCL",
    Title = "Oracle DB"
};
```

### File Sources

#### ExcelDataSource
Read data from Excel files.

```csharp
var excelSource = new ExcelDataSource
{
    Title = "Sales Data"
};
```

#### CsvDataSource
Read data from CSV files.

```csharp
var csvSource = new CsvDataSource
{
    Title = "Customer Data"
};
```

### Web Sources

#### RestDataSource
Connect to REST APIs.

```csharp
var restSource = new RestDataSource
{
    Url = "https://api.example.com/sales",
    Title = "Sales API"
};
```

#### ODataDataSource
Connect to OData services.

```csharp
var odataSource = new ODataDataSource
{
    Url = "https://services.odata.org/Northwind",
    Title = "Northwind OData"
};
```

## Data Source Item Types

### TableDataSourceItem
Represents a database table or view.

```csharp
var tableItem = new TableDataSourceItem("Sales Data", "Sales", dataSource)
{
    Subtitle = "Historical sales transactions"
};
```

### ProcedureDataSourceItem
Represents a stored procedure.

```csharp
var procItem = new ProcedureDataSourceItem("Monthly Sales", "GetMonthlySales", dataSource);
```

### FunctionDataSourceItem
Represents a database function.

```csharp
var funcItem = new FunctionDataSourceItem("Sales Calc", "CalculateSales", dataSource);
```

### RestDataSourceItem
Represents a REST API endpoint.

```csharp
var restItem = new RestDataSourceItem("Products", restDataSource)
{
    Subtitle = "Product catalog from API"
};
```

## Quick Reference Guide

### When to Use Each Field Type

| Data Type | Field Type | Example | Use Case |
|-----------|------------|---------|----------|
| Text/String | `TextField` | Customer Name | Labels, categories |
| Numbers | `NumberField` | Sales Amount | Calculations, metrics |
| Dates | `DateField` | Order Date | Time analysis |
| True/False | `BooleanField` | Is Active | Status flags |

### When to Use Each Data Field Type

| Purpose | Data Field Type | Example |
|---------|-----------------|---------|
| Grouping/Labels | `DimensionDataField` | Product Category |
| Values/Metrics | `MeasureDataField` | Total Sales |
| Time Analysis | `DateDataField` | Transaction Date |

### Common Aggregation Patterns

| Goal | Aggregation | Example |
|------|-------------|---------|
| Total amount | `Sum` | Total Revenue |
| Typical value | `Average` | Average Price |
| Record count | `Count` | Number of Orders |
| Unique count | `DistinctCount` | Unique Customers |
| Range analysis | `Min`/`Max` | Price Range |

### Visualization Selection Guide

| Data Pattern | Recommended Visualization |
|--------------|---------------------------|
| Categories comparison | `BarChart` or `ColumnChart` |
| Trends over time | `LineChart` or `AreaChart` |
| Parts of whole | `PieChart` or `DoughnutChart` |
| Correlation | `ScatterChart` |
| Single metric | `KpiTargetVisualization` |
| Detailed data | `GridVisualization` |
| Geographic data | `ChoroplethVisualization` |

## Examples by Scenario

### E-commerce Dashboard

```csharp
// Revenue trend over time
var revenueTrend = new LineChartVisualization("Revenue Trend", salesData);
revenueTrend.Labels.Add(new DateDataField("OrderDate"));
revenueTrend.Values.Add(new MeasureDataField("Revenue") { Aggregation = AggregationType.Sum });

// Top products
var topProducts = new BarChartVisualization("Top Products", salesData);
topProducts.Labels.Add(new DimensionDataField("ProductName"));
topProducts.Values.Add(new MeasureDataField("Quantity") { Aggregation = AggregationType.Sum });

// Customer count KPI
var customerKPI = new KpiTargetVisualization("Customer Count", customerData);
customerKPI.Value = new MeasureDataField("CustomerID") { Aggregation = AggregationType.DistinctCount };
```

### Financial Dashboard

```csharp
// Portfolio performance gauge
var performance = new CircularGaugeVisualization("Portfolio Performance", portfolioData);
performance.Value = new MeasureDataField("ROI") { Aggregation = AggregationType.Average };

// Risk vs return scatter
var riskReturn = new ScatterChartVisualization("Risk vs Return", investmentData);
riskReturn.XAxis = new MeasureDataField("Risk") { Aggregation = AggregationType.Average };
riskReturn.YAxis = new MeasureDataField("Return") { Aggregation = AggregationType.Average };
```

### Operations Dashboard

```csharp
// Production efficiency over time
var efficiency = new AreaChartVisualization("Production Efficiency", productionData);
efficiency.Labels.Add(new DateDataField("ProductionDate"));
efficiency.Values.Add(new MeasureDataField("EfficiencyPercent") { Aggregation = AggregationType.Average });

// Equipment status
var status = new PieChartVisualization("Equipment Status", equipmentData);
status.Labels.Add(new DimensionDataField("Status"));
status.Values.Add(new MeasureDataField("EquipmentID") { Aggregation = AggregationType.Count });
```

This reference guide provides the foundation for understanding and working with types and enums in Reveal.Sdk.Dom. Refer back to this guide when choosing the appropriate types for your specific dashboard requirements.