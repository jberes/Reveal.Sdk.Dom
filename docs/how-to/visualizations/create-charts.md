# How to Create Charts

Learn how to create various chart types in Reveal.Sdk.Dom.

## Overview

Charts are the most common visualization type for displaying data trends, comparisons, and relationships. Reveal.Sdk.Dom supports 20+ chart types.

## Bar Charts

Horizontal bars for comparing categories.

```csharp
var barChart = new BarChartVisualization("Sales by Region", dataSourceItem);
barChart.Labels.Add(new DimensionDataField("Region"));
barChart.Values.Add(new MeasureDataField("Sales") 
{ 
    Aggregation = AggregationType.Sum,
    FieldLabel = "Total Sales"
});

document.Visualizations.Add(barChart);
```

### Multiple Values

```csharp
var barChart = new BarChartVisualization("Sales Comparison", dataSourceItem);
barChart.Labels.Add(new DimensionDataField("Region"));
barChart.Values.Add(new MeasureDataField("Sales") 
{ 
    Aggregation = AggregationType.Sum,
    FieldLabel = "Sales"
});
barChart.Values.Add(new MeasureDataField("Profit") 
{ 
    Aggregation = AggregationType.Sum,
    FieldLabel = "Profit"
});
```

## Column Charts

Vertical columns for comparing categories.

```csharp
var columnChart = new ColumnChartVisualization("Monthly Revenue", dataSourceItem);
columnChart.Labels.Add(new DimensionDataField("Month"));
columnChart.Values.Add(new MeasureDataField("Revenue") 
{ 
    Aggregation = AggregationType.Sum 
});

document.Visualizations.Add(columnChart);
```

## Line Charts

Lines for showing trends over time.

```csharp
var lineChart = new LineChartVisualization("Sales Trend", dataSourceItem);
lineChart.Labels.Add(new DateDataField("OrderDate"));
lineChart.Values.Add(new MeasureDataField("Sales") 
{ 
    Aggregation = AggregationType.Sum 
});

document.Visualizations.Add(lineChart);
```

### Multiple Lines

```csharp
var lineChart = new LineChartVisualization("Sales & Profit Trend", dataSourceItem);
lineChart.Labels.Add(new DateDataField("Date"));
lineChart.Values.Add(new MeasureDataField("Sales") { Aggregation = AggregationType.Sum });
lineChart.Values.Add(new MeasureDataField("Profit") { Aggregation = AggregationType.Sum });
```

## Area Charts

Filled areas under lines.

```csharp
var areaChart = new AreaChartVisualization("Revenue Over Time", dataSourceItem);
areaChart.Labels.Add(new DateDataField("Date"));
areaChart.Values.Add(new MeasureDataField("Revenue") 
{ 
    Aggregation = AggregationType.Sum 
});

document.Visualizations.Add(areaChart);
```

## Pie and Doughnut Charts

Circular charts for showing proportions.

### Pie Chart

```csharp
var pieChart = new PieChartVisualization("Market Share", dataSourceItem);
pieChart.Labels.Add(new DimensionDataField("Product"));
pieChart.Values.Add(new MeasureDataField("Sales") 
{ 
    Aggregation = AggregationType.Sum 
});

document.Visualizations.Add(pieChart);
```

### Doughnut Chart

```csharp
var doughnut = new DoughnutChartVisualization("Sales Distribution", dataSourceItem);
doughnut.Labels.Add(new DimensionDataField("Category"));
doughnut.Values.Add(new MeasureDataField("Revenue") 
{ 
    Aggregation = AggregationType.Sum 
});
```

**Best Practice**: Limit pie/doughnut charts to 5-7 segments for readability.

## Stacked Charts

### Stacked Column Chart

```csharp
var stackedColumn = new StackedColumnChartVisualization("Sales by Product & Region", dataSourceItem);
stackedColumn.Labels.Add(new DimensionDataField("Region"));
stackedColumn.Values.Add(new MeasureDataField("ProductA_Sales") { Aggregation = AggregationType.Sum });
stackedColumn.Values.Add(new MeasureDataField("ProductB_Sales") { Aggregation = AggregationType.Sum });
```

### Stacked Bar Chart

```csharp
var stackedBar = new StackedBarChartVisualization("Revenue Breakdown", dataSourceItem);
stackedBar.Labels.Add(new DimensionDataField("Quarter"));
stackedBar.Values.Add(new MeasureDataField("Direct_Sales") { Aggregation = AggregationType.Sum });
stackedBar.Values.Add(new MeasureDataField("Partner_Sales") { Aggregation = AggregationType.Sum });
```

### Stacked Area Chart

```csharp
var stackedArea = new StackedAreaChartVisualization("Revenue Sources", dataSourceItem);
stackedArea.Labels.Add(new DateDataField("Date"));
stackedArea.Values.Add(new MeasureDataField("Product_Revenue") { Aggregation = AggregationType.Sum });
stackedArea.Values.Add(new MeasureDataField("Service_Revenue") { Aggregation = AggregationType.Sum });
```

## Combo Chart

Combines columns and lines.

```csharp
var comboChart = new ComboChartVisualization("Sales & Growth", dataSourceItem);

// X-axis labels
comboChart.Labels.Add(new DimensionDataField("Month"));

// Columns
comboChart.Values.Add(new MeasureDataField("Sales") 
{ 
    Aggregation = AggregationType.Sum,
    FieldLabel = "Sales Amount"
});

// Lines
comboChart.Lines.Add(new MeasureDataField("GrowthPercentage") 
{ 
    Aggregation = AggregationType.Average,
    FieldLabel = "Growth %"
});

document.Visualizations.Add(comboChart);
```

## Scatter Chart

Shows relationship between two numeric variables.

```csharp
var scatterChart = new ScatterVisualization("Price vs Sales", dataSourceItem);
scatterChart.XAxis.Add(new MeasureDataField("Price"));
scatterChart.YAxis.Add(new MeasureDataField("UnitsSold"));
scatterChart.Details.Add(new DimensionDataField("Product"));  // For labeling points

document.Visualizations.Add(scatterChart);
```

## Bubble Chart

Scatter chart with bubble sizes.

```csharp
var bubbleChart = new BubbleVisualization("Product Performance", dataSourceItem);
bubbleChart.XAxis.Add(new MeasureDataField("Price"));
bubbleChart.YAxis.Add(new MeasureDataField("Sales"));
bubbleChart.Size.Add(new MeasureDataField("Profit") { Aggregation = AggregationType.Sum });
bubbleChart.Label.Add(new DimensionDataField("Product"));

document.Visualizations.Add(bubbleChart);
```

## Spline Charts

Smooth curved lines instead of straight.

### Spline Chart

```csharp
var splineChart = new SplineChartVisualization("Smooth Trend", dataSourceItem);
splineChart.Labels.Add(new DateDataField("Date"));
splineChart.Values.Add(new MeasureDataField("Value") { Aggregation = AggregationType.Average });
```

### Spline Area Chart

```csharp
var splineArea = new SplineAreaChartVisualization("Smooth Area", dataSourceItem);
splineArea.Labels.Add(new DateDataField("Date"));
splineArea.Values.Add(new MeasureDataField("Revenue") { Aggregation = AggregationType.Sum });
```

## Step Charts

Step-like progression instead of diagonal lines.

### Step Line Chart

```csharp
var stepLine = new StepLineChartVisualization("Inventory Levels", dataSourceItem);
stepLine.Labels.Add(new DateDataField("Date"));
stepLine.Values.Add(new MeasureDataField("StockLevel"));
```

### Step Area Chart

```csharp
var stepArea = new StepAreaChartVisualization("Status Over Time", dataSourceItem);
stepArea.Labels.Add(new DateDataField("Date"));
stepArea.Values.Add(new MeasureDataField("ActiveCount"));
```

## Complete Example: Multi-Chart Dashboard

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;

public RdashDocument CreateChartsDashboard()
{
    var document = new RdashDocument("Sales Analytics Dashboard")
    {
        UseAutoLayout = true
    };

    // Create data source
    var sqlSource = new MicrosoftSqlServerDataSource
    {
        Host = "server.database.windows.net",
        Database = "SalesDB"
    };

    var salesData = new TableDataSourceItem("Sales", sqlSource)
    {
        Table = "SalesData"
    };

    // 1. Bar Chart - Top Regions
    var topRegions = new BarChartVisualization("Top 10 Regions", salesData);
    topRegions.Labels.Add(new DimensionDataField("Region"));
    topRegions.Values.Add(new MeasureDataField("Revenue") 
    { 
        Aggregation = AggregationType.Sum,
        FieldLabel = "Total Revenue"
    });
    document.Visualizations.Add(topRegions);

    // 2. Line Chart - Monthly Trend
    var monthlyTrend = new LineChartVisualization("Monthly Sales Trend", salesData);
    monthlyTrend.Labels.Add(new DateDataField("OrderDate"));
    monthlyTrend.Values.Add(new MeasureDataField("Revenue") 
    { 
        Aggregation = AggregationType.Sum 
    });
    document.Visualizations.Add(monthlyTrend);

    // 3. Pie Chart - Sales by Category
    var categoryPie = new PieChartVisualization("Sales by Category", salesData);
    categoryPie.Labels.Add(new DimensionDataField("Category"));
    categoryPie.Values.Add(new MeasureDataField("Revenue") 
    { 
        Aggregation = AggregationType.Sum 
    });
    document.Visualizations.Add(categoryPie);

    // 4. Stacked Column - Product Comparison
    var productComparison = new StackedColumnChartVisualization("Product Sales by Quarter", salesData);
    productComparison.Labels.Add(new DimensionDataField("Quarter"));
    productComparison.Values.Add(new MeasureDataField("ProductA_Sales") 
    { 
        Aggregation = AggregationType.Sum,
        FieldLabel = "Product A"
    });
    productComparison.Values.Add(new MeasureDataField("ProductB_Sales") 
    { 
        Aggregation = AggregationType.Sum,
        FieldLabel = "Product B"
    });
    document.Visualizations.Add(productComparison);

    // 5. Combo Chart - Sales & Margin
    var salesAndMargin = new ComboChartVisualization("Sales & Margin Analysis", salesData);
    salesAndMargin.Labels.Add(new DimensionDataField("Month"));
    salesAndMargin.Values.Add(new MeasureDataField("Revenue") 
    { 
        Aggregation = AggregationType.Sum 
    });
    salesAndMargin.Lines.Add(new MeasureDataField("MarginPercent") 
    { 
        Aggregation = AggregationType.Average 
    });
    document.Visualizations.Add(salesAndMargin);

    return document;
}

// Usage
var dashboard = CreateChartsDashboard();
dashboard.Save("charts-dashboard.rdash");
```

## Chart Customization

### Show/Hide Elements

```csharp
var chart = new BarChartVisualization("Sales", dataSourceItem)
{
    IsTitleVisible = true,
    ShowLegend = true
};
```

### Sorting

```csharp
var sortedField = new MeasureDataField("Sales")
{
    Aggregation = AggregationType.Sum,
    Sorting = SortingType.Descending  // Show highest first
};
chart.Values.Add(sortedField);
```

### Number Formatting

```csharp
var formattedField = new MeasureDataField("Revenue")
{
    Aggregation = AggregationType.Sum,
    Formatting = new NumberFormatting
    {
        FormatType = NumberFormattingType.Currency,
        DecimalPlaces = 2,
        CurrencySymbol = "$"
    }
};
```

## Best Practices

### 1. Choose the Right Chart Type

| Use Case | Chart Type |
|----------|-----------|
| Compare categories | Bar or Column |
| Show trends | Line or Area |
| Show proportions | Pie or Doughnut |
| Multiple series | Stacked or Combo |
| Correlation | Scatter or Bubble |

### 2. Use Meaningful Labels

```csharp
var field = new MeasureDataField("total_revenue_ytd")
{
    FieldLabel = "Total Revenue (YTD)",  // User-friendly
    Aggregation = AggregationType.Sum
};
```

### 3. Limit Data Series

```csharp
// Good - 2-3 series
chart.Values.Add(new MeasureDataField("Sales"));
chart.Values.Add(new MeasureDataField("Profit"));

// Avoid - too many series makes chart unreadable
chart.Values.Add(field1);
chart.Values.Add(field2);
chart.Values.Add(field3);
chart.Values.Add(field4);
chart.Values.Add(field5);  // Too many!
```

### 4. Apply Consistent Styling

```csharp
public static class ChartHelper
{
    public static void ApplyStandardStyle(Visualization viz)
    {
        viz.IsTitleVisible = true;
        viz.IsDescriptionVisible = false;
    }
}

// Apply to all charts
ChartHelper.ApplyStandardStyle(barChart);
ChartHelper.ApplyStandardStyle(lineChart);
```

## Troubleshooting

### Chart Shows No Data

Check that:
1. Field names match data source
2. Aggregation is appropriate
3. Data source has data
4. Filters aren't excluding all data

### Wrong Aggregation

```csharp
// For totals
new MeasureDataField("Sales") { Aggregation = AggregationType.Sum }

// For averages
new MeasureDataField("Rating") { Aggregation = AggregationType.Average }

// For counts
new MeasureDataField("OrderID") { Aggregation = AggregationType.Count }
```

## Related Topics

- [Visualizations Overview](../../core-concepts/visualizations.md)
- [Create KPIs](create-kpis.md)
- [Create Grids](create-grids.md)
- [Visualizations API Reference](../../api-reference/visualizations/README.md)
