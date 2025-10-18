# Visualizations API Reference

Complete reference for all visualization types supported by Reveal.Sdk.Dom.

## Overview

Reveal.Sdk.Dom supports 40+ visualization types for displaying data in various formats. Each visualization type has specific properties and requirements for data fields.

## Chart Visualizations

### Bar Chart

**Class**: `BarChartVisualization`

Displays data as horizontal bars.

**Required Fields**:
- `Labels` - Dimension field(s) for categories
- `Values` - Measure field(s) for bar lengths

**Example**:
```csharp
var chart = new BarChartVisualization("Sales by Region", dataSourceItem);
chart.Labels.Add(new DimensionDataField("Region"));
chart.Values.Add(new MeasureDataField("Sales") 
{ 
    Aggregation = AggregationType.Sum 
});
```

### Column Chart

**Class**: `ColumnChartVisualization`

Displays data as vertical columns.

**Required Fields**:
- `Labels` - Dimension field(s)
- `Values` - Measure field(s)

### Line Chart

**Class**: `LineChartVisualization`

Displays data as connected lines.

**Required Fields**:
- `Labels` - Dimension field(s) (typically dates)
- `Values` - Measure field(s)

### Area Chart

**Class**: `AreaChartVisualization`

Displays data as filled areas under lines.

**Required Fields**:
- `Labels` - Dimension field(s)
- `Values` - Measure field(s)

### Pie Chart

**Class**: `PieChartVisualization`

Displays data as circular sectors.

**Required Fields**:
- `Labels` - Dimension field for segments
- `Values` - Single measure field

**Example**:
```csharp
var pie = new PieChartVisualization("Market Share", dataSourceItem);
pie.Labels.Add(new DimensionDataField("Product"));
pie.Values.Add(new MeasureDataField("Revenue") 
{ 
    Aggregation = AggregationType.Sum 
});
```

### Doughnut Chart

**Class**: `DoughnutChartVisualization`

Similar to pie chart with a center hole.

**Required Fields**:
- `Labels` - Dimension field
- `Values` - Single measure field

### Funnel Chart

**Class**: `FunnelChartVisualization`

Displays data as tapering stages.

**Required Fields**:
- `Labels` - Dimension field for stages
- `Values` - Measure field for stage values

### Combo Chart

**Class**: `ComboChartVisualization`

Combines columns and lines in one chart.

**Required Fields**:
- `Labels` - Dimension field(s)
- `Values` - Measure field(s) for columns
- `Lines` - Measure field(s) for lines

**Example**:
```csharp
var combo = new ComboChartVisualization("Sales and Profit", dataSourceItem);
combo.Labels.Add(new DimensionDataField("Month"));
combo.Values.Add(new MeasureDataField("Sales"));
combo.Lines.Add(new MeasureDataField("Profit"));
```

## Stacked Charts

### Stacked Column Chart

**Class**: `StackedColumnChartVisualization`

Columns stacked on top of each other.

### Stacked Bar Chart

**Class**: `StackedBarChartVisualization`

Bars stacked horizontally.

### Stacked Area Chart

**Class**: `StackedAreaChartVisualization`

Areas stacked on top of each other.

## Advanced Charts

### Scatter Chart

**Class**: `ScatterVisualization`

Plots points on X and Y axes.

**Required Fields**:
- `X` - Measure field for X-axis
- `Y` - Measure field for Y-axis
- `Details` - Optional dimension for grouping

**Example**:
```csharp
var scatter = new ScatterVisualization("Price vs Sales", dataSourceItem);
scatter.XAxis.Add(new MeasureDataField("Price"));
scatter.YAxis.Add(new MeasureDataField("Sales"));
scatter.Details.Add(new DimensionDataField("Product"));
```

### Bubble Chart

**Class**: `BubbleVisualization`

Scatter plot with bubble sizes.

**Required Fields**:
- `X` - Measure field for X-axis
- `Y` - Measure field for Y-axis
- `Size` - Measure field for bubble size
- `Label` - Dimension field for identification

### Tree Map

**Class**: `TreeMapVisualization`

Displays hierarchical data as nested rectangles.

**Required Fields**:
- `Label` - Dimension field for rectangles
- `Value` - Measure field for sizes

### Sparkline

**Class**: `SparklineVisualization`

Compact line chart for trends.

**Required Fields**:
- `Date` - Date field
- `Value` - Measure field
- `Category` - Dimension field

## Spline Charts

### Spline Chart

**Class**: `SplineChartVisualization`

Line chart with smooth curves.

### Spline Area Chart

**Class**: `SplineAreaChartVisualization`

Area chart with smooth curves.

### Step Line Chart

**Class**: `StepLineChartVisualization`

Line chart with step-like progression.

### Step Area Chart

**Class**: `StepAreaChartVisualization`

Area chart with step-like progression.

## Financial Charts

### Candlestick Chart

**Class**: `CandleStickVisualization`

Displays OHLC (Open-High-Low-Close) data.

**Required Fields**:
- `Label` - Date field
- `Open` - Opening value
- `High` - Highest value
- `Low` - Lowest value
- `Close` - Closing value

**Example**:
```csharp
var candle = new CandleStickVisualization("Stock Prices", dataSourceItem);
candle.Label = new DateDataField("Date");
candle.Open = new MeasureDataField("Open");
candle.High = new MeasureDataField("High");
candle.Low = new MeasureDataField("Low");
candle.Close = new MeasureDataField("Close");
```

### OHLC Chart

**Class**: `OHLCVisualization`

Similar to candlestick with different visual style.

## Gauge Visualizations

### Linear Gauge

**Class**: `LinearGaugeVisualization`

Displays value on a linear scale.

**Required Fields**:
- `Label` - Dimension field
- `Value` - Measure field

**Example**:
```csharp
var gauge = new LinearGaugeVisualization("Sales Target", dataSourceItem);
gauge.Labels.Add(new DimensionDataField("Region"));
gauge.Values.Add(new MeasureDataField("Sales"));
```

### Circular Gauge

**Class**: `CircularGaugeVisualization`

Displays value on a circular dial.

**Required Fields**:
- `Label` - Dimension field
- `Value` - Measure field

### Bullet Graph

**Class**: `BulletGraphVisualization`

Linear gauge with target indicators.

**Required Fields**:
- `Label` - Dimension field
- `Value` - Measure field
- `Target` - Optional target value

### Radial Gauge

**Class**: `RadialVisualization`

Circular gauge with segments.

## KPI Visualizations

### KPI Target

**Class**: `KpiTargetVisualization`

Shows progress toward a target.

**Required Fields**:
- `Value` - Measure field for actual value
- `Target` - Measure field for target
- `Date` - Date field

**Example**:
```csharp
var kpi = new KpiTargetVisualization("Sales Goal", dataSourceItem);
kpi.Value = new MeasureDataField("ActualSales") 
{ 
    Aggregation = AggregationType.Sum 
};
kpi.Target = new MeasureDataField("TargetSales") 
{ 
    Aggregation = AggregationType.Sum 
};
kpi.Date = new DateDataField("Date");
```

### KPI Time

**Class**: `KpiTimeVisualization`

Shows value changes over time.

**Required Fields**:
- `Value` - Measure field
- `Date` - Date field

## Grid Visualizations

### Grid

**Class**: `GridVisualization`

Displays data in a table format.

**Required Fields**:
- `Columns` - Field(s) to display as columns

**Example**:
```csharp
var grid = new GridVisualization("Sales Data", dataSourceItem);
grid.Columns.Add(new DimensionDataField("Product"));
grid.Columns.Add(new MeasureDataField("Quantity"));
grid.Columns.Add(new MeasureDataField("Revenue"));
```

### Pivot Table

**Class**: `PivotVisualization`

Interactive pivot table with rows, columns, and values.

**Required Fields**:
- `Rows` - Dimension field(s) for rows
- `Columns` - Dimension field(s) for columns
- `Values` - Measure field(s) for aggregated values

**Example**:
```csharp
var pivot = new PivotVisualization("Sales Analysis", dataSourceItem);
pivot.Rows.Add(new DimensionDataField("Product"));
pivot.Columns.Add(new DimensionDataField("Region"));
pivot.Values.Add(new MeasureDataField("Sales") 
{ 
    Aggregation = AggregationType.Sum 
});
```

## Map Visualizations

### Choropleth Map

**Class**: `ChoroplethVisualization`

Colored geographic regions based on values.

**Required Fields**:
- `Location` - Location field (country, state, etc.)
- `Color` - Measure field for coloring

**Example**:
```csharp
var map = new ChoroplethVisualization("Sales by State", dataSourceItem);
map.Location = new DimensionDataField("State");
map.Color = new MeasureDataField("Sales") 
{ 
    Aggregation = AggregationType.Sum 
};
```

### Scatter Map

**Class**: `ScatterMapVisualization`

Points on a geographic map.

**Required Fields**:
- `Latitude` - Latitude coordinate
- `Longitude` - Longitude coordinate
- `Value` - Optional measure for sizing

## Text Visualizations

### Text Box

**Class**: `TextBoxVisualization`

Static text content.

**Properties**:
- `Text` - The text content to display

**Example**:
```csharp
var textBox = new TextBoxVisualization("Title", dataSourceItem)
{
    Text = "Dashboard Overview"
};
```

### Text View

**Class**: `TextViewVisualization`

Dynamic text from data.

**Required Fields**:
- `Value` - Field to display

### Image

**Class**: `ImageVisualization`

Displays an image.

**Properties**:
- `Url` - Image URL
- `Title` - Image title

## Time Series

**Class**: `TimeSeriesVisualization`

Advanced time-based analysis with trend lines.

**Required Fields**:
- `Date` - Date field
- `Value` - Measure field

## Custom Visualizations

**Class**: `CustomVisualization`

For custom visualization types created with Reveal SDK.

**Properties**:
- `CustomVisualizationType` - Type identifier
- Additional custom properties

## Common Properties

All visualizations share these base properties:

### Identification
- `Id` (string) - Unique identifier
- `Title` (string) - Display title
- `Description` (string) - Optional description

### Display
- `IsTitleVisible` (bool) - Show/hide title
- `IsDescriptionVisible` (bool) - Show/hide description

### Layout (when UseAutoLayout = false)
- `Column` (int) - X position
- `Row` (int) - Y position
- `ColumnSpan` (int) - Width (out of 12)
- `RowSpan` (int) - Height

### Data
- `DataDefinition` - Contains data source item and field mappings
- `Filters` - Visualization-specific filters

## Field Types

### DimensionDataField

For categorical data (labels, categories).

```csharp
var field = new DimensionDataField("CategoryName")
{
    FieldLabel = "Category"
};
```

### MeasureDataField

For numeric data with aggregation.

```csharp
var field = new MeasureDataField("Sales")
{
    Aggregation = AggregationType.Sum,
    FieldLabel = "Total Sales"
};
```

### DateDataField

For date/time data.

```csharp
var field = new DateDataField("OrderDate")
{
    FieldLabel = "Order Date"
};
```

## Aggregation Types

Available for `MeasureDataField`:

- `Sum` - Add all values
- `Average` - Calculate average
- `Count` - Count records
- `DistinctCount` - Count unique values
- `Min` - Minimum value
- `Max` - Maximum value
- `Median` - Median value
- `StdDev` - Standard deviation
- `Variance` - Variance

## Sorting

Configure field sorting:

```csharp
var field = new MeasureDataField("Sales")
{
    Sorting = SortingType.Descending
};
```

## Formatting

### Number Formatting

```csharp
var field = new MeasureDataField("Revenue")
{
    Formatting = new NumberFormatting
    {
        FormatType = NumberFormattingType.Currency,
        DecimalPlaces = 2,
        CurrencySymbol = "$"
    }
};
```

### Date Formatting

```csharp
var field = new DateDataField("OrderDate")
{
    Formatting = new DateFormatting
    {
        DateFormat = "MM/dd/yyyy"
    }
};
```

## Visualization Settings

Each visualization type has specific settings:

```csharp
var chart = new BarChartVisualization("Sales", dataSourceItem)
{
    ShowLegend = true,
    StartColorIndex = 0,
    ChartType = ChartType.Stacked
};
```

## Best Practices

### 1. Choose Appropriate Visualization Types

- **Bar/Column Charts** - Compare categories
- **Line/Area Charts** - Show trends over time
- **Pie/Doughnut Charts** - Show proportions (max 7-10 segments)
- **Grids** - Display detailed data
- **KPIs** - Highlight key metrics
- **Maps** - Show geographic data

### 2. Set Clear Titles

```csharp
var chart = new BarChartVisualization("Q4 2024 Sales by Region", dataSourceItem);
```

### 3. Apply Appropriate Aggregations

```csharp
// Sum for totals
new MeasureDataField("Sales") { Aggregation = AggregationType.Sum }

// Average for metrics
new MeasureDataField("Rating") { Aggregation = AggregationType.Average }

// Count for quantities
new MeasureDataField("Orders") { Aggregation = AggregationType.Count }
```

### 4. Use Field Labels

```csharp
var field = new MeasureDataField("total_revenue_2024")
{
    FieldLabel = "Total Revenue",  // User-friendly name
    Aggregation = AggregationType.Sum
};
```

## See Also

- [Visualizations Core Concepts](../../core-concepts/visualizations.md)
- [How to Create Charts](../../how-to/visualizations/create-charts.md)
- [How to Create KPIs](../../how-to/visualizations/create-kpis.md)
- [How to Customize Settings](../../how-to/visualizations/customize-settings.md)
