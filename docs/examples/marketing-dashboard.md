# Marketing Dashboard Example

A comprehensive marketing analytics dashboard demonstrating campaign performance tracking, conversion analysis, and spend optimization using real-world patterns.

## Overview

This example shows how to create a marketing dashboard with:

- KPI target visualizations for spend vs budget tracking
- Line charts for trend analysis
- Pie charts for territorial distribution
- Column charts for traffic analysis
- Funnel charts for conversion tracking
- Pivot tables for detailed campaign metrics

## Complete Example

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System.Collections.Generic;

namespace MarketingAnalytics
{
    public class MarketingDashboardCreator
    {
        private static Binding _globalDateFilterBinding = new DashboardDateFilterBinding("Date");

        public RdashDocument CreateMarketingDashboard()
        {
            // Create the data source
            var excelDataSource = CreateMarketingDataSource();
            var marketingDataItem = CreateMarketingDataSourceItem(excelDataSource);

            // Create dashboard with tropical island theme
            var document = new RdashDocument("Marketing Analytics Dashboard")
            {
                Description = "Campaign performance and marketing metrics",
                Theme = Theme.TropicalIsland,
                UseAutoLayout = false  // Manual positioning for precise layout
            };

            // Add global date filter
            document.Filters.Add(new DashboardDateFilter("Campaign Period"));

            // Add all visualizations
            document.Visualizations.Add(CreateKpiTargetVisualization(marketingDataItem));
            document.Visualizations.Add(CreateLineChartVisualization(marketingDataItem));
            document.Visualizations.Add(CreatePieChartVisualization(marketingDataItem));
            document.Visualizations.Add(CreateColumnChartVisualization(marketingDataItem));
            document.Visualizations.Add(CreateFunnelChartVisualization(marketingDataItem));
            document.Visualizations.Add(CreatePivotVisualization(marketingDataItem));

            return document;
        }

        private DataSource CreateMarketingDataSource()
        {
            return new RestDataSource
            {
                Id = "MarketingExcel",
                Title = "Marketing Data Source",
                Subtitle = "Campaign and performance data via REST",
                Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx"
            };
        }

        private DataSourceItem CreateMarketingDataSourceItem(DataSource dataSource)
        {
            var dataSourceItem = new RestDataSourceItem("Marketing", dataSource)
            {
                Title = "Marketing Data",
                Subtitle = "Campaign performance metrics",
                Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx",
                IsAnonymous = true,
                Fields = GetMarketingFields()
            };

            // Configure for Excel sheet
            dataSourceItem.UseExcel("Marketing");

            return dataSourceItem;
        }

        private List<IField> GetMarketingFields()
        {
            return new List<IField>
            {
                new DateField("Date"),
                new NumberField("Spend"),
                new NumberField("Budget"),
                new NumberField("CTR"),
                new NumberField("Avg. CPC"),
                new NumberField("Traffic"),
                new NumberField("Paid Traffic"),
                new NumberField("Organic Traffic"),
                new NumberField("Other Traffic"),
                new NumberField("Conversions"),
                new TextField("Territory"),
                new TextField("CampaignID"),
                new NumberField("New Seats"),
                new NumberField("Paid %"),
                new NumberField("Organic %")
            };
        }

        private Visualization CreateKpiTargetVisualization(DataSourceItem dataItem)
        {
            var kpi = new KpiTargetVisualization("Spend vs Budget", dataItem)
            {
                IsTitleVisible = true,
                Column = 0,
                Row = 0,
                ColumnSpan = 10,
                RowSpan = 24
            };

            // Configure date field with custom formatting
            kpi.Date = new DimensionDataField("Date")
            {
                Aggregation = DateAggregationType.Year,
                Formatting = new DateFormatting("dd-MMM-yyyy")
            };

            // Configure spend value with currency formatting
            kpi.Value = new MeasureDataField("Spend")
            {
                Aggregation = AggregationType.Sum,
                FieldLabel = "Total Spend",
                Formatting = new NumberFormatting
                {
                    FormatType = NumberFormattingType.Number,
                    DecimalPlaces = 0,
                    ShowGroupingSeparator = true,
                    CurrencySymbol = "$",
                    NegativeFormat = NegativeFormatType.MinusSign,
                    LargeNumberFormat = LargeNumberFormat.Auto
                }
            };

            // Configure budget target
            kpi.Target = new MeasureDataField("Budget")
            {
                Aggregation = AggregationType.Sum,
                FieldLabel = "Budget Target",
                Formatting = new NumberFormatting
                {
                    FormatType = NumberFormattingType.Number,
                    ShowGroupingSeparator = true,
                    CurrencySymbol = "$",
                    NegativeFormat = NegativeFormatType.MinusSign
                }
            };

            return kpi;
        }

        private Visualization CreateLineChartVisualization(DataSourceItem dataItem)
        {
            var lineChart = new LineChartVisualization("Actual Spend vs Budget Trend", dataItem)
            {
                IsTitleVisible = true,
                Column = 10,
                Row = 0,
                ColumnSpan = 30,
                RowSpan = 24
            };

            // Connect to global date filter
            lineChart.FilterBindings.Add(_globalDateFilterBinding);

            // Configure X-axis (labels)
            lineChart.Labels.Add(new DimensionDataField("Date")
            {
                Aggregation = DateAggregationType.Month
            });

            // Configure Y-axis (values) - multiple series
            lineChart.Values.Add(new MeasureDataField("Spend")
            {
                Aggregation = AggregationType.Sum,
                FieldLabel = "Actual Spend"
            });

            lineChart.Values.Add(new MeasureDataField("Budget")
            {
                Aggregation = AggregationType.Sum,
                FieldLabel = "Budget"
            });

            return lineChart;
        }

        private Visualization CreatePieChartVisualization(DataSourceItem dataItem)
        {
            var pieChart = new PieChartVisualization("Spend by Territory", dataItem)
            {
                IsTitleVisible = true,
                Column = 40,
                Row = 0,
                ColumnSpan = 20,
                RowSpan = 24
            };

            // Configure segments
            pieChart.Labels.Add(new DimensionDataField("Territory"));

            // Configure values
            pieChart.Values.Add(new MeasureDataField("Spend")
            {
                Aggregation = AggregationType.Sum
            });

            return pieChart;
        }

        private Visualization CreateColumnChartVisualization(DataSourceItem dataItem)
        {
            var columnChart = new ColumnChartVisualization("Traffic Sources Over Time", dataItem)
            {
                IsTitleVisible = true,
                Column = 0,
                Row = 24,
                ColumnSpan = 27,
                RowSpan = 36
            };

            // Connect to global date filter
            columnChart.FilterBindings.Add(_globalDateFilterBinding);

            // Configure X-axis
            columnChart.Labels.Add(new DimensionDataField("Date")
            {
                Aggregation = DateAggregationType.Month
            });

            // Configure multiple traffic sources
            columnChart.Values.Add(new MeasureDataField("Paid Traffic")
            {
                Aggregation = AggregationType.Sum,
                FieldLabel = "Paid Traffic"
            });

            columnChart.Values.Add(new MeasureDataField("Organic Traffic")
            {
                Aggregation = AggregationType.Sum,
                FieldLabel = "Organic Traffic"
            });

            columnChart.Values.Add(new MeasureDataField("Other Traffic")
            {
                Aggregation = AggregationType.Sum,
                FieldLabel = "Other Traffic"
            });

            return columnChart;
        }

        private Visualization CreateFunnelChartVisualization(DataSourceItem dataItem)
        {
            var funnelChart = new FunnelChartVisualization("Conversions by Campaign", dataItem)
            {
                IsTitleVisible = true,
                Column = 27,
                Row = 24,
                ColumnSpan = 13,
                RowSpan = 36
            };

            // Connect to global date filter
            funnelChart.FilterBindings.Add(_globalDateFilterBinding);

            // Configure funnel segments
            funnelChart.Labels.Add(new DimensionDataField("CampaignID"));

            // Configure values
            funnelChart.Values.Add(new MeasureDataField("Conversions")
            {
                Aggregation = AggregationType.Sum
            });

            return funnelChart;
        }

        private Visualization CreatePivotVisualization(DataSourceItem dataItem)
        {
            var pivot = new PivotVisualization("Campaign Performance Metrics", dataItem)
            {
                IsTitleVisible = true,
                Column = 40,
                Row = 24,
                ColumnSpan = 20,
                RowSpan = 36
            };

            // Configure alignment settings
            pivot.Settings.TextFieldAlignment = Alignment.Left;
            pivot.Settings.NumericFieldAlignment = Alignment.Right;
            pivot.Settings.DateFieldAlignment = Alignment.Left;

            // Configure rows
            pivot.Rows.Add(new DimensionDataField("CampaignID"));

            // Configure values with specific formatting
            pivot.Values.Add(new MeasureDataField("CTR")
            {
                Aggregation = AggregationType.Average,
                FieldLabel = "Click-Through Rate",
                Formatting = new NumberFormatting
                {
                    FormatType = NumberFormattingType.Percent,
                    DecimalPlaces = 2,
                    CurrencySymbol = "$",
                    NegativeFormat = NegativeFormatType.MinusSign,
                    LargeNumberFormat = LargeNumberFormat.Auto
                }
            });

            pivot.Values.Add(new MeasureDataField("Avg. CPC")
            {
                Aggregation = AggregationType.Average,
                FieldLabel = "Average Cost Per Click",
                Formatting = new NumberFormatting
                {
                    FormatType = NumberFormattingType.Currency,
                    DecimalPlaces = 0,
                    CurrencySymbol = "$",
                    NegativeFormat = NegativeFormatType.MinusSign,
                    ShowGroupingSeparator = true
                }
            });

            pivot.Values.Add(new MeasureDataField("New Seats")
            {
                Aggregation = AggregationType.Sum,
                FieldLabel = "New Seats Acquired",
                Formatting = new NumberFormatting
                {
                    FormatType = NumberFormattingType.Currency,
                    DecimalPlaces = 0,
                    CurrencySymbol = "$",
                    NegativeFormat = NegativeFormatType.MinusSign,
                    ShowGroupingSeparator = true
                }
            });

            return pivot;
        }
    }
}
```

## Usage Example

```csharp
// Create the marketing dashboard
var creator = new MarketingDashboardCreator();
var dashboard = creator.CreateMarketingDashboard();

// Save to file
dashboard.Save("marketing-analytics-dashboard.rdash");

// Export for Reveal SDK
var json = dashboard.ToJsonString();
```

## Advanced Features Demonstrated

### 1. Global Date Filter with Binding

```csharp
// Create a reusable binding for date filter
private static Binding _globalDateFilterBinding = new DashboardDateFilterBinding("Date");

// Apply to multiple visualizations
lineChart.FilterBindings.Add(_globalDateFilterBinding);
columnChart.FilterBindings.Add(_globalDateFilterBinding);
funnelChart.FilterBindings.Add(_globalDateFilterBinding);
```

### 2. Custom Date Formatting

```csharp
kpi.Date = new DimensionDataField("Date")
{
    Aggregation = DateAggregationType.Year,
    Formatting = new DateFormatting("dd-MMM-yyyy")  // Custom format
};
```

### 3. Pivot Table Configuration

```csharp
// Configure alignment for different data types
pivot.Settings.TextFieldAlignment = Alignment.Left;
pivot.Settings.NumericFieldAlignment = Alignment.Right;
pivot.Settings.DateFieldAlignment = Alignment.Left;
```

### 4. Multiple Value Series

```csharp
// Add multiple traffic sources to column chart
columnChart.Values.Add(new MeasureDataField("Paid Traffic"));
columnChart.Values.Add(new MeasureDataField("Organic Traffic"));
columnChart.Values.Add(new MeasureDataField("Other Traffic"));
```

### 5. Currency vs Percentage Formatting

```csharp
// Currency formatting
var spendField = new MeasureDataField("Spend")
{
    Formatting = new NumberFormatting
    {
        FormatType = NumberFormattingType.Currency,
        CurrencySymbol = "$",
        ShowGroupingSeparator = true
    }
};

// Percentage formatting
var ctrField = new MeasureDataField("CTR")
{
    Formatting = new NumberFormatting
    {
        FormatType = NumberFormattingType.Percent,
        DecimalPlaces = 2
    }
};
```

## Dashboard Layout Strategy

This example demonstrates a strategic layout approach:

```text
┌─────────────┬──────────────────────────────┬────────────────┐
│ KPI         │ Trend Line Chart             │ Territory Pie  │
│ Spend vs    │ Spend vs Budget Over Time    │ Spend by       │
│ Budget      │                              │ Territory      │
├─────────────┴──────────────────────────────┼────────────────┤
│ Traffic Sources Column Chart               │ Campaign       │
│ Paid/Organic/Other by Month                │ Performance    │
├────────────────────────────┬───────────────┤ Pivot Table    │
│ Conversion Funnel          │               │                │
│ by Campaign                │               │                │
└────────────────────────────┴───────────────┴────────────────┘
```

## Key Marketing KPIs Tracked

1. **Spend vs Budget** - Budget adherence monitoring
2. **Click-Through Rate (CTR)** - Campaign effectiveness
3. **Cost Per Click (CPC)** - Cost efficiency
4. **Conversions** - Campaign success
5. **Traffic Sources** - Channel performance
6. **New Seats** - Business impact

## Customization Options

### Change Theme

```csharp
document.Theme = Theme.Mountain;        // Default blue/gray
document.Theme = Theme.Ocean;           // Blue theme
document.Theme = Theme.TropicalIsland;  // Green theme (used in example)
```

### Add Campaign Filter

```csharp
var campaignFilter = new DashboardDataFilter("Campaign", dataItem);
campaignFilter.SelectedField = new DimensionDataField("CampaignID");
document.Filters.Add(campaignFilter);

// Connect to visualizations
visualization.FilterBindings.Add(new DashboardDataFilterBinding(campaignFilter.Id, campaignFilter.SelectedField));
```

### Auto Layout Alternative

```csharp
// Switch to responsive auto layout
document.UseAutoLayout = true;

// Remove manual positioning from all visualizations
var kpi = new KpiTargetVisualization("Spend vs Budget", dataItem);
// No Column, Row, ColumnSpan, RowSpan properties needed
```

## Best Practices Shown

1. **Global Filters**: Use consistent date filtering across time-based visualizations
2. **Proper Formatting**: Apply appropriate currency and percentage formatting
3. **Visual Hierarchy**: KPIs at top, detailed analysis below
4. **Color Consistency**: Use themes for consistent color schemes
5. **Data Alignment**: Right-align numbers, left-align text in pivot tables
6. **Field Labels**: Provide user-friendly labels for all fields

## Common Marketing Scenarios

### A/B Testing Dashboard

```csharp
// Add campaign comparison charts
var campaignComparison = new ColumnChartVisualization("A/B Test Results", dataItem);
campaignComparison.Labels.Add(new DimensionDataField("CampaignID"));
campaignComparison.Values.Add(new MeasureDataField("CTR"));
campaignComparison.Values.Add(new MeasureDataField("Conversions"));
```

### ROI Analysis

```csharp
// Calculate ROI in visualization
var roiChart = new BarChartVisualization("Campaign ROI", dataItem);
roiChart.Labels.Add(new DimensionDataField("CampaignID"));
roiChart.Values.Add(new CalculatedField("ROI")
{
    Expression = "([New Seats] - [Spend]) / [Spend] * 100",
    Formatting = new NumberFormatting { FormatType = NumberFormattingType.Percent }
});
```

### Attribution Analysis

```csharp
// Multi-touch attribution
var attributionChart = new StackedColumnChartVisualization("Attribution Analysis", dataItem);
attributionChart.Labels.Add(new DimensionDataField("Date"));
attributionChart.Values.Add(new MeasureDataField("First Touch"));
attributionChart.Values.Add(new MeasureDataField("Last Touch"));
attributionChart.Values.Add(new MeasureDataField("Multi Touch"));
```

## Related Examples

- [Sales Dashboard](sales-dashboard.md) - Sales performance tracking
- [Healthcare Dashboard](healthcare-dashboard.md) - Healthcare metrics
- [Campaigns Dashboard](campaigns-dashboard.md) - Detailed campaign analysis
- [KPI Dashboard](kpi-dashboard.md) - KPI-focused examples

## Next Steps

- Explore [funnel visualizations](../how-to/visualizations/create-funnels.md) for conversion tracking
- Learn about [calculated fields](../how-to/advanced/calculations-aggregations.md) for ROI calculations
- Check [filter patterns](../how-to/dashboard-management/work-with-filters.md) for advanced filtering