# Understanding Types and Enums in Reveal.Sdk.Dom

Master the fundamental building blocks of Reveal.Sdk.Dom by understanding field types, data mappings, aggregations, and visualization types that power effective dashboard development.

## What You'll Learn

By the end of this guide, you'll understand:

- **Field Types** - How to define data schemas for your data sources
- **Data Field Types** - How to map data to visualization components
- **Aggregation Types** - How to transform raw data into meaningful insights
- **Visualization Types** - How to choose the right visual representation
- **Data Source Types** - How to connect to various data systems
- **Integration Patterns** - How these types work together in real scenarios

## Why This Matters

Understanding types and enums is crucial because they form the foundation of every dashboard you create. These building blocks determine:

- **Data Accuracy** - Proper field typing ensures correct data interpretation
- **Visual Effectiveness** - Right visualization types convey insights clearly  
- **Performance** - Appropriate aggregations optimize data processing
- **Maintainability** - Consistent type usage makes dashboards easier to update
- **User Experience** - Well-structured data creates intuitive, actionable dashboards

Whether you're building sales analytics, operational dashboards, or executive reporting, mastering these fundamentals will enable you to create compelling, accurate visualizations that drive business decisions.

> 💡 **Learning Path**: This guide builds on concepts from [Basic Concepts](../getting-started/basic-concepts.md) and prepares you for [Creating Visualizations](../how-to/visualizations/create-charts.md).

## Data Foundation: Field Types

Field types define the data schema for your data sources, establishing how Reveal.Sdk.Dom interprets your raw data. Think of them as the "blueprint" that describes what each column contains.

### Understanding the Type System

Reveal.Sdk.Dom uses a strongly-typed system where each data column must be explicitly defined. This ensures data integrity and enables the platform to provide appropriate visualization options and aggregation methods.

```csharp
// Example: Defining a complete data schema
var customerSchema = new List<IField>
{
    new TextField("CustomerName") { FieldLabel = "Customer Name" },
    new NumberField("Revenue") { FieldLabel = "Annual Revenue" },
    new DateField("FirstPurchase") { FieldLabel = "First Purchase Date" },
    new BooleanField("IsActive") { FieldLabel = "Active Customer" }
};
```

### TextField: Working with Categorical Data

`TextField` represents textual information that typically serves as categories, labels, or identifiers.

#### When to Use TextField

- **Names and Identifiers** - Customer names, product codes, transaction IDs
- **Categories** - Product categories, regions, departments, status values
- **Descriptions** - Product descriptions, comments, notes
- **Lookup Values** - Country codes, currency symbols, classification codes

#### TextField Properties and Usage

```csharp
// Basic text field
var productName = new TextField("ProductName")
{
    FieldLabel = "Product Name",        // User-friendly display name
    Description = "Product identifier"   // Optional description
};

// Text field for categories
var region = new TextField("SalesRegion")
{
    FieldLabel = "Sales Region",
    Description = "Geographic sales territory"
};

// Text field for codes/IDs
var customerCode = new TextField("CustomerCode")
{
    FieldLabel = "Customer ID",
    Description = "Unique customer identifier"
};
```

#### Best Practices for TextField

```csharp
// ✅ Good: Clear, descriptive labels
var category = new TextField("ProductCategory")
{
    FieldLabel = "Product Category"  // Clear for end users
};

// ❌ Avoid: Technical field names as labels
var badField = new TextField("prod_cat_cd")
{
    FieldLabel = "prod_cat_cd"  // Confusing for users
};

// ✅ Better: User-friendly labels for technical fields
var goodField = new TextField("prod_cat_cd")
{
    FieldLabel = "Product Category"  // Technical name mapped to friendly label
};
```

### NumberField: Handling Quantitative Data

`NumberField` represents numeric data that can be used in mathematical operations and aggregations.

#### When to Use NumberField

- **Financial Data** - Revenue, costs, prices, profit margins
- **Quantities** - Inventory levels, order quantities, employee counts
- **Measurements** - Distances, weights, temperatures, scores
- **Calculated Values** - Ratios, percentages, growth rates

#### NumberField Properties and Configuration

```csharp
// Basic numeric field
var revenue = new NumberField("TotalRevenue")
{
    FieldLabel = "Total Revenue"
};

// Numeric field with formatting hints
var price = new NumberField("UnitPrice")
{
    FieldLabel = "Unit Price ($)",
    Description = "Price per unit in USD"
};

// Percentage field
var growthRate = new NumberField("GrowthPercentage")
{
    FieldLabel = "Growth Rate (%)",
    Description = "Year-over-year growth percentage"
};

// Count/quantity field
var orderQuantity = new NumberField("Quantity")
{
    FieldLabel = "Order Quantity",
    Description = "Number of units ordered"
};
```

### DateField: Managing Time-Based Data

`DateField` represents date and time information, enabling time-based analysis and temporal grouping.

#### When to Use DateField

- **Transaction Dates** - Order dates, payment dates, delivery dates
- **Timeline Events** - Created dates, modified dates, milestone dates
- **Scheduling Data** - Start dates, end dates, deadline dates
- **Historical Analysis** - Comparative time periods, trend analysis

### BooleanField: Representing Binary States

`BooleanField` represents true/false data and binary conditions.

#### When to Use BooleanField

- **Status Flags** - Active/inactive, enabled/disabled, published/draft
- **Binary Conditions** - Pass/fail, approved/rejected, completed/pending
- **Feature Flags** - Premium customer, international, first-time buyer
- **Compliance States** - Compliant/non-compliant, verified/unverified

## Visualization Mapping: Data Field Types

Data field types bridge the gap between your raw data (defined by Field Types) and visualization components. They determine how data appears in charts, tables, and other visual elements.

### DimensionDataField: Creating Context and Categories

`DimensionDataField` transforms categorical data into visual groupings, labels, and context.

#### Understanding Dimensions

Dimensions provide the "who, what, where, when" context for your data. They create the structure around which your measures are organized and compared.

#### When to Use DimensionDataField

- **Chart Axes** - X-axis labels, legend categories
- **Grouping** - Organizing data by categories
- **Filtering Context** - Drill-down hierarchies
- **Row/Column Headers** - In grids and pivot tables

```csharp
// Product analysis dimensions
var productCategory = new DimensionDataField("ProductCategory")
{
    FieldLabel = "Product Category",
    Description = "Product classification for analysis"
};

var salesRegion = new DimensionDataField("SalesRegion")
{
    FieldLabel = "Sales Region",
    Description = "Geographic sales territory"
};
```

### MeasureDataField: Quantifying Performance and Metrics

`MeasureDataField` transforms numeric data into aggregated metrics that provide quantitative insights.

#### Understanding Measures

Measures answer "how much" or "how many" questions. They're the numeric values that get calculated, aggregated, and compared across your dimensions.

#### When to Use MeasureDataField

- **Chart Values** - Bar heights, line values, pie slice sizes
- **KPI Metrics** - Target values, actual values, variance calculations
- **Aggregated Results** - Totals, averages, counts, ratios
- **Calculated Fields** - Derived metrics, percentages, growth rates

```csharp
// Revenue measures with different aggregations
var totalRevenue = new MeasureDataField("Revenue")
{
    Aggregation = AggregationType.Sum,
    FieldLabel = "Total Revenue",
    Description = "Sum of all revenue transactions"
};

var averageOrderValue = new MeasureDataField("OrderValue")
{
    Aggregation = AggregationType.Average,
    FieldLabel = "Average Order Value",
    Description = "Mean value per order"
};
```

### DateDataField: Enabling Time-Based Analysis

`DateDataField` specializes in temporal data, providing time-based grouping, trending, and chronological analysis capabilities.

#### Understanding Time Dimensions

Time is often the most important dimension in business analysis, enabling trend identification, seasonal pattern recognition, and performance comparison across periods.

#### When to Use DateDataField

- **Trend Analysis** - Line charts showing changes over time
- **Time Series** - Sequential data points with temporal relationships  
- **Period Comparisons** - Year-over-year, month-over-month analysis
- **Seasonal Patterns** - Identifying cyclical behaviors and trends

```csharp
// Monthly sales trend
var monthlyDate = new DateDataField("OrderDate")
{
    Aggregation = DateAggregationType.Month,
    FieldLabel = "Month",
    Description = "Orders grouped by month"
};
```

## Data Aggregation: Transforming Raw Data into Insights

Aggregation types determine how multiple data values are combined to create meaningful summary information. Understanding aggregations is crucial for accurate data interpretation and effective visualizations.

### Numeric Aggregations (AggregationType)

#### Sum: Total Accumulation

`Sum` adds all values together, providing total quantities, amounts, or cumulative measures.

**When to Use Sum:**
- Financial Totals - Total revenue, total cost, total profit
- Quantity Totals - Total units sold, total inventory
- Cumulative Metrics - Total hours worked, total distance traveled

```csharp
// Financial summation
var totalRevenue = new MeasureDataField("Revenue")
{
    Aggregation = AggregationType.Sum,
    FieldLabel = "Total Revenue ($)",
    Formatting = new NumberFormatting
    {
        FormatType = NumberFormattingType.Currency,
        CurrencySymbol = "$",
        DecimalPlaces = 2
    }
};
```

#### Average: Central Tendency

`Average` calculates the arithmetic mean, providing typical or representative values.

**When to Use Average:**
- Performance Metrics - Average response time, average score
- Financial Ratios - Average order value, average price
- Quality Indicators - Average rating, average satisfaction score

```csharp
// Performance averages
var avgResponseTime = new MeasureDataField("ResponseTimeMs")
{
    Aggregation = AggregationType.Average,
    FieldLabel = "Avg Response Time (ms)",
    Formatting = new NumberFormatting
    {
        FormatType = NumberFormattingType.Number,
        DecimalPlaces = 2
    }
};
```

#### Count: Frequency and Volume

`Count` calculates the number of records, providing frequency and volume metrics.

**When to Use Count:**
- Activity Volume - Number of orders, transactions, visits
- Participation Metrics - Number of participants, attendees, users
- Frequency Analysis - Number of occurrences, events, incidents

```csharp
// Transaction counting
var orderCount = new MeasureDataField("OrderID")
{
    Aggregation = AggregationType.Count,
    FieldLabel = "Number of Orders",
    Formatting = new NumberFormatting
    {
        FormatType = NumberFormattingType.Number,
        DecimalPlaces = 0,
        ShowThousandsSeparator = true
    }
};
```

#### DistinctCount: Unique Value Analysis

`DistinctCount` counts unique values, providing insights into diversity and uniqueness.

**When to Use DistinctCount:**
- Customer Analysis - Unique customers, distinct buyers
- Product Diversity - Unique products sold, distinct categories
- Geographic Reach - Unique locations, distinct regions

```csharp
// Customer uniqueness
var uniqueCustomers = new MeasureDataField("CustomerID")
{
    Aggregation = AggregationType.DistinctCount,
    FieldLabel = "Unique Customers",
    Formatting = new NumberFormatting
    {
        FormatType = NumberFormattingType.Number,
        DecimalPlaces = 0,
        ShowThousandsSeparator = true
    }
};
```

#### Min/Max: Range and Extremes

`Min` and `Max` identify the smallest and largest values, revealing ranges and extreme points.

**When to Use Min/Max:**
- Price Analysis - Lowest/highest prices, price ranges
- Performance Bounds - Best/worst performance, limits
- Time Boundaries - Earliest/latest dates, time spans

```csharp
// Price range analysis
var minPrice = new MeasureDataField("Price")
{
    Aggregation = AggregationType.Min,
    FieldLabel = "Minimum Price ($)",
    Formatting = new NumberFormatting
    {
        FormatType = NumberFormattingType.Currency,
        CurrencySymbol = "$",
        DecimalPlaces = 2
    }
};
```

### Date Aggregations (DateAggregationType)

Date aggregations group temporal data into meaningful time periods for trend analysis and pattern recognition.

#### Year: Annual Analysis

```csharp
var yearlyDate = new DateDataField("TransactionDate")
{
    Aggregation = DateAggregationType.Year,
    FieldLabel = "Year",
    Description = "Annual grouping for year-over-year analysis"
};
```

#### Quarter: Seasonal Analysis

```csharp
var quarterlyDate = new DateDataField("OrderDate")
{
    Aggregation = DateAggregationType.Quarter,
    FieldLabel = "Quarter",
    Description = "Quarterly grouping for seasonal pattern analysis"
};
```

#### Month: Monthly Trends

```csharp
var monthlyDate = new DateDataField("ActivityDate")
{
    Aggregation = DateAggregationType.Month,
    FieldLabel = "Month",
    Description = "Monthly grouping for trend identification"
};
```

### Aggregation Decision Matrix

| Business Question | Recommended Aggregation | Example Use Case |
|-------------------|------------------------|------------------|
| "What's the total?" | `Sum` | Total revenue, total quantity |
| "What's typical?" | `Average` or `Median` | Average order value, typical response time |
| "How many occurred?" | `Count` | Number of orders, transaction volume |
| "How many different?" | `DistinctCount` | Unique customers, distinct products |
| "What's the range?" | `Min` and `Max` | Price range, performance bounds |
| "How consistent?" | `StdDev` or `Variance` | Quality consistency, sales predictability |

## Visualization Types Reference

### Chart Visualizations

- **BarChartVisualization** - Horizontal bars for comparing categories
- **ColumnChartVisualization** - Vertical columns for comparing categories  
- **LineChartVisualization** - Connected lines showing trends over time
- **AreaChartVisualization** - Filled areas under lines
- **PieChartVisualization** - Circular sectors showing proportions
- **ScatterChartVisualization** - Points showing relationships between variables

### Gauge Visualizations

- **LinearGaugeVisualization** - Progress indicator on linear scale
- **CircularGaugeVisualization** - Progress indicator on circular scale
- **BulletGraphVisualization** - Linear gauge with target ranges

### Data Visualizations

- **GridVisualization** - Standard data table
- **PivotVisualization** - Interactive pivot table for analysis

### KPI Visualizations

- **KpiTargetVisualization** - Key performance indicator with target
- **SparklineVisualization** - Compact trend line visualization

## Field Type Selection Guide

| Field Type | Chart Labels | Chart Values | Filters | Grouping |
|------------|--------------|--------------|---------|----------|
| `TextField` | ✅ Excellent | ❌ No | ✅ Yes | ✅ Yes |
| `NumberField` | ⚠️ Limited | ✅ Excellent | ✅ Yes | ⚠️ Limited |
| `DateField` | ✅ Excellent | ❌ No | ✅ Yes | ✅ Yes |
| `BooleanField` | ✅ Good | ❌ No | ✅ Yes | ✅ Yes |

## Practical Integration Example

```csharp
// Complete example showing type integration
public RdashDocument CreateSalesDashboard()
{
    var document = new RdashDocument("Sales Analytics Dashboard");
    
    // Define data source with field types
    var sqlSource = new MicrosoftSqlServerDataSource
    {
        Host = "server.database.windows.net",
        Database = "SalesDB"
    };
    
    var salesData = new TableDataSourceItem("Sales", sqlSource)
    {
        Fields = new List<IField>
        {
            new TextField("Region") { FieldLabel = "Sales Region" },
            new TextField("Product") { FieldLabel = "Product Name" },
            new NumberField("Revenue") { FieldLabel = "Revenue Amount" },
            new NumberField("Quantity") { FieldLabel = "Units Sold" },
            new DateField("OrderDate") { FieldLabel = "Order Date" },
            new BooleanField("IsReturned") { FieldLabel = "Returned" }
        }
    };
    
    // Create visualization using data field types
    var regionalSales = new ColumnChartVisualization("Sales by Region", salesData);
    
    // Dimension for grouping
    regionalSales.Labels.Add(new DimensionDataField("Region")
    {
        FieldLabel = "Sales Region"
    });
    
    // Measure with aggregation
    regionalSales.Values.Add(new MeasureDataField("Revenue")
    {
        Aggregation = AggregationType.Sum,
        FieldLabel = "Total Revenue",
        Formatting = new NumberFormatting
        {
            FormatType = NumberFormattingType.Currency,
            CurrencySymbol = "$"
        }
    });
    
    document.Visualizations.Add(regionalSales);
    return document;
}
```

## Next Steps

Now that you understand the fundamental types and enums, you're ready to:

1. **[Create Your First Dashboard](../getting-started/quick-start.md)** - Apply these concepts in practice
2. **[Explore Visualization Types](../how-to/visualizations/create-charts.md)** - Learn specific chart implementations  
3. **[Connect Data Sources](../how-to/data-sources/connect-to-sql-server.md)** - Link to real data systems
4. **[Advanced Formatting](../how-to/visualizations/customize-settings.md)** - Polish your visualizations

## Related Topics

- **[RDash Document Structure](rdash-document.md)** - Understanding dashboard architecture
- **[Data Sources Overview](data-sources.md)** - Connecting to data systems
- **[Visualizations API Reference](../api-reference/visualizations/README.md)** - Complete type reference
- **[Best Practices Guide](../best-practices.md)** - Professional dashboard development

> 💡 **Deep Dive**: For comprehensive aggregation examples and advanced patterns, see [Creating Charts Guide](../how-to/visualizations/create-charts.md#aggregation-types).