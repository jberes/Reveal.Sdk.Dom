# Sales Dashboard Example

A comprehensive sales dashboard showing KPIs, trends, and performance metrics using real-world patterns from the Reveal.Sdk.Dom codebase.

## Overview

This example demonstrates how to create a complete sales dashboard with:
- KPI visualizations for key metrics
- Trend analysis with line and area charts
- Performance comparison with bar and column charts
- Interactive filters for date and territory
- Advanced visualizations like sparklines and bullet graphs

## Complete Example

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

namespace SalesAnalytics
{
    public class SalesDashboardCreator
    {
        public RdashDocument CreateSalesDashboard()
        {
            // Create the data source
            var excelDataSource = CreateExcelDataSource();
            var salesDataItem = CreateSalesDataSourceItem(excelDataSource);

            // Create dashboard with manual layout
            var document = new RdashDocument("Sales Performance Dashboard")
            {
                Description = "Comprehensive sales analytics and KPIs",
                UseAutoLayout = false,  // Manual positioning for precise layout
                Theme = Theme.Ocean
            };

            // Add dashboard-level filters
            var dateFilter = new DashboardDateFilter("Date Range");
            document.Filters.Add(dateFilter);

            var territoryFilter = new DashboardDataFilter("Territory", salesDataItem);
            territoryFilter.SelectedField = new DimensionDataField("Territory");
            document.Filters.Add(territoryFilter);

            // Add visualizations with specific positioning
            document.Visualizations.Add(CreateKpiTargetVisualization(salesDataItem, territoryFilter));
            document.Visualizations.Add(CreateSplineAreaChart(salesDataItem, dateFilter, territoryFilter));
            document.Visualizations.Add(CreateStackedColumnChart(salesDataItem, dateFilter, territoryFilter));
            document.Visualizations.Add(CreateIndicatorVisualization(salesDataItem, territoryFilter));
            document.Visualizations.Add(CreateSparklineVisualization(salesDataItem, dateFilter, territoryFilter));
            document.Visualizations.Add(CreateBarChartVisualization(salesDataItem, dateFilter, territoryFilter));
            document.Visualizations.Add(CreateColumnChartVisualization(salesDataItem, dateFilter, territoryFilter));
            document.Visualizations.Add(CreateBulletGraphVisualization(salesDataItem, dateFilter, territoryFilter));

            return document;
        }

        private DataSource CreateExcelDataSource()
        {
            return new RestDataSource
            {
                Id = "SalesExcel",
                Title = "Sales Data Source",
                Subtitle = "Excel data via REST API",
                Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx"
            };
        }

        private DataSourceItem CreateSalesDataSourceItem(DataSource dataSource)
        {
            var dataSourceItem = new RestDataSourceItem("Sales", dataSource)
            {
                Title = "Sales Data",
                Subtitle = "Sales performance metrics",
                Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx",
                IsAnonymous = true,
                Fields = GetSalesFields()
            };

            // Configure for Excel sheet
            dataSourceItem.UseExcel("Sales");

            return dataSourceItem;
        }

        private List<IField> GetSalesFields()
        {
            return new List<IField>
            {
                new TextField("Territory"),
                new DateField("Date"),
                new NumberField("Quota"),
                new NumberField("Leads"),
                new NumberField("Hot Leads"),
                new NumberField("New Seats"),
                new NumberField("New Sales"),
                new NumberField("Renewal Seats"),
                new NumberField("Renewal Sales"),
                new TextField("Employee"),
                new NumberField("Pipeline"),
                new NumberField("Forecasted"),
                new NumberField("Revenue"),
                new NumberField("Total Opportunities"),
                new TextField("Product")
            };
        }

        private Visualization CreateKpiTargetVisualization(DataSourceItem dataItem, params DashboardFilter[] filters)
        {
            var kpi = new KpiTargetVisualization("Sales Performance", dataItem)
            {
                IsTitleVisible = true,
                Column = 0,
                Row = 0,
                ColumnSpan = 20,
                RowSpan = 11
            };

            // Configure date field
            kpi.Date = new DimensionDataField("Date");

            // Configure value with formatting
            kpi.Value = new MeasureDataField("Pipeline")
            {
                FieldLabel = "Actual Sales",
                Aggregation = AggregationType.Sum,
                Formatting = new NumberFormatting
                {
                    FormatType = NumberFormattingType.Currency,
                    DecimalPlaces = 0,
                    ShowGroupingSeparator = true,
                    CurrencySymbol = "$",
                    NegativeFormat = NegativeFormatType.MinusSign,
                    LargeNumberFormat = LargeNumberFormat.Auto
                }
            };

            // Configure target
            kpi.Target = new MeasureDataField("Forecasted")
            {
                Aggregation = AggregationType.Sum
            };

            // Connect to dashboard filters
            foreach (var filter in filters)
            {
                if (filter is DashboardDateFilter)
                    kpi.FilterBindings.Add(new DashboardDateFilterBinding(filter.Id));
                else if (filter is DashboardDataFilter dataFilter)
                    kpi.FilterBindings.Add(new DashboardDataFilterBinding(filter.Id, dataFilter.SelectedField));
            }

            return kpi;
        }

        private Visualization CreateSplineAreaChart(DataSourceItem dataItem, params DashboardFilter[] filters)
        {
            var chart = new SplineAreaChartVisualization("New vs Renewal Sales", dataItem)
            {
                IsTitleVisible = true,
                Column = 0,
                Row = 31,
                ColumnSpan = 39,
                RowSpan = 31
            };

            // Configure labels (X-axis)
            chart.Labels.Add(new DimensionDataField("Date")
            {
                Aggregation = DateAggregationType.Month
            });

            // Configure values (Y-axis)
            chart.Values.Add(new MeasureDataField("New Sales")
            {
                Aggregation = AggregationType.Sum,
                FieldLabel = "New Sales"
            });
            chart.Values.Add(new MeasureDataField("Renewal Sales")
            {
                Aggregation = AggregationType.Sum,
                FieldLabel = "Renewal Sales"
            });

            // Connect filters
            ConnectFilters(chart, filters);

            return chart;
        }

        private Visualization CreateStackedColumnChart(DataSourceItem dataItem, params DashboardFilter[] filters)
        {
            var chart = new StackedColumnChartVisualization("Sales by Product", dataItem)
            {
                IsTitleVisible = true,
                Column = 0,
                Row = 18,
                ColumnSpan = 39,
                RowSpan = 18
            };

            chart.Labels.Add(new DimensionDataField("Product"));
            chart.Values.Add(new MeasureDataField("New Sales") { Aggregation = AggregationType.Sum });
            chart.Values.Add(new MeasureDataField("Renewal Sales") { Aggregation = AggregationType.Sum });

            ConnectFilters(chart, filters);
            return chart;
        }

        private Visualization CreateIndicatorVisualization(DataSourceItem dataItem, params DashboardFilter[] filters)
        {
            var indicator = new KpiTimeVisualization("Total Opportunities", dataItem)
            {
                IsTitleVisible = true,
                Column = 20,
                Row = 0,
                ColumnSpan = 19,
                RowSpan = 11
            };

            indicator.Date = new DimensionDataField("Date")
            {
                Aggregation = DateAggregationType.Year
            };

            indicator.Value = new MeasureDataField("Total Opportunities")
            {
                Aggregation = AggregationType.Sum
            };

            ConnectFilters(indicator, filters);
            return indicator;
        }

        private Visualization CreateSparklineVisualization(DataSourceItem dataItem, params DashboardFilter[] filters)
        {
            var sparkline = new SparklineVisualization("New Seats by Product", dataItem)
            {
                IsTitleVisible = true,
                Column = 39,
                Row = 31,
                ColumnSpan = 30,
                RowSpan = 31
            };

            sparkline.Date = new DimensionDataField("Date")
            {
                Aggregation = DateAggregationType.Month
            };

            sparkline.Value = new MeasureDataField("New Seats")
            {
                Formatting = new NumberFormatting
                {
                    FormatType = NumberFormattingType.Number,
                    DecimalPlaces = 0,
                    ShowGroupingSeparator = true,
                    LargeNumberFormat = LargeNumberFormat.Auto
                }
            };

            sparkline.Category = new DimensionDataField("Product");

            // Configure sparkline settings
            sparkline.Settings.TextFieldAlignment = Alignment.Left;
            sparkline.Settings.NumericFieldAlignment = Alignment.Left;
            sparkline.Settings.DateFieldAlignment = Alignment.Left;
            sparkline.Settings.AggregationType = SparklineAggregationType.Months;

            ConnectFilters(sparkline, filters);
            return sparkline;
        }

        private Visualization CreateBarChartVisualization(DataSourceItem dataItem, params DashboardFilter[] filters)
        {
            var chart = new BarChartVisualization("Sales by Employee", dataItem)
            {
                IsTitleVisible = true,
                Column = 39,
                Row = 0,
                ColumnSpan = 43,
                RowSpan = 29
            };

            chart.Labels.Add(new DimensionDataField("Employee"));
            chart.Values.Add(new MeasureDataField("Pipeline")
            {
                Sorting = SortingType.Asc,
                Formatting = new NumberFormatting
                {
                    FormatType = NumberFormattingType.Currency,
                    DecimalPlaces = 0,
                    ShowGroupingSeparator = true,
                    LargeNumberFormat = LargeNumberFormat.Auto
                }
            });

            ConnectFilters(chart, filters);
            return chart;
        }

        private Visualization CreateColumnChartVisualization(DataSourceItem dataItem, params DashboardFilter[] filters)
        {
            var chart = new ColumnChartVisualization("Leads Analysis", dataItem)
            {
                IsTitleVisible = true,
                Column = 39,
                Row = 31,
                ColumnSpan = 46,
                RowSpan = 31
            };

            chart.Labels.Add(new DimensionDataField("Date")
            {
                Aggregation = DateAggregationType.Month
            });

            chart.Values.Add(new MeasureDataField("Leads") { Aggregation = AggregationType.Sum });
            chart.Values.Add(new MeasureDataField("Hot Leads") { Aggregation = AggregationType.Sum });

            ConnectFilters(chart, filters);
            return chart;
        }

        private Visualization CreateBulletGraphVisualization(DataSourceItem dataItem, params DashboardFilter[] filters)
        {
            var bulletGraph = new BulletGraphVisualization("Quotas by Sales Rep", dataItem)
            {
                IsTitleVisible = true,
                Column = 69,
                Row = 0,
                ColumnSpan = 33,
                RowSpan = 29
            };

            bulletGraph.Labels.Add(new DimensionDataField("Employee"));
            bulletGraph.Values.Add(new MeasureDataField("Quota")
            {
                Formatting = new NumberFormatting
                {
                    FormatType = NumberFormattingType.Percent,
                    DecimalPlaces = 2,
                    ShowGroupingSeparator = false,
                    LargeNumberFormat = LargeNumberFormat.Auto
                }
            });

            // Configure bullet graph settings
            bulletGraph.Settings.Minimum = new Bound { Value = 0.8 };
            bulletGraph.Settings.Maximum = new Bound { Value = 2.0 };
            bulletGraph.Settings.ValueComparisonType = ValueComparisonType.Number;
            bulletGraph.Settings.UpperBand.Value = 100.0;
            bulletGraph.Settings.MiddleBand.Value = 80.0;

            // Add data filter to show top performers
            bulletGraph.Filters.Add(new VisualizationFilter("Quota")
            {
                FilterType = FilterType.FilterByRule,
                Rules = new List<FilterRule>
                {
                    new NumberFilterRule
                    {
                        RuleType = NumberRuleType.TopItems,
                        Value = 10.0
                    }
                }
            });

            ConnectFilters(bulletGraph, filters);
            return bulletGraph;
        }

        private void ConnectFilters(Visualization visualization, params DashboardFilter[] filters)
        {
            foreach (var filter in filters)
            {
                if (filter is DashboardDateFilter)
                {
                    visualization.FilterBindings.Add(new DashboardDateFilterBinding(filter.Id));
                }
                else if (filter is DashboardDataFilter dataFilter)
                {
                    visualization.FilterBindings.Add(new DashboardDataFilterBinding(filter.Id, dataFilter.SelectedField));
                }
            }
        }
    }
}
```

## Usage Example

```csharp
// Create the dashboard
var creator = new SalesDashboardCreator();
var dashboard = creator.CreateSalesDashboard();

// Save to file
dashboard.Save("sales-performance-dashboard.rdash");

// Or export to JSON for Reveal SDK
var json = dashboard.ToJsonString();
var revealDashboard = await RVDashboard.LoadFromJsonAsync(json);
```

## Key Features Demonstrated

### 1. Manual Layout Control

```csharp
document.UseAutoLayout = false;

var kpi = new KpiTargetVisualization("Sales", dataItem)
{
    Column = 0,        // X position
    Row = 0,           // Y position
    ColumnSpan = 20,   // Width
    RowSpan = 11       // Height
};
```

### 2. Advanced Number Formatting

```csharp
var currencyField = new MeasureDataField("Pipeline")
{
    Formatting = new NumberFormatting
    {
        FormatType = NumberFormattingType.Currency,
        DecimalPlaces = 0,
        ShowGroupingSeparator = true,
        CurrencySymbol = "$",
        LargeNumberFormat = LargeNumberFormat.Auto
    }
};
```

### 3. Dashboard Filter Integration

```csharp
// Create filters
var dateFilter = new DashboardDateFilter("Date Range");
var territoryFilter = new DashboardDataFilter("Territory", dataItem);

// Connect to visualizations
visualization.FilterBindings.Add(new DashboardDateFilterBinding(dateFilter.Id));
visualization.FilterBindings.Add(new DashboardDataFilterBinding(territoryFilter.Id, field));
```

### 4. Sparkline Configuration

```csharp
sparkline.Settings.TextFieldAlignment = Alignment.Left;
sparkline.Settings.AggregationType = SparklineAggregationType.Months;
```

### 5. Bullet Graph with Bands

```csharp
bulletGraph.Settings.Minimum = new Bound { Value = 0.8 };
bulletGraph.Settings.Maximum = new Bound { Value = 2.0 };
bulletGraph.Settings.UpperBand.Value = 100.0;
bulletGraph.Settings.MiddleBand.Value = 80.0;
```

## Best Practices Shown

1. **Factory Pattern**: Separate data source creation from visualization logic
2. **Consistent Formatting**: Apply consistent number and date formatting across visualizations
3. **Filter Integration**: Connect dashboard filters to relevant visualizations
4. **Manual Layout**: Use precise positioning for dashboard consistency
5. **Data Validation**: Define all fields for REST/Excel data sources
6. **Performance**: Reuse data source definitions across multiple visualizations

## Common Customizations

### Change Theme

```csharp
document.Theme = Theme.Mountain;        // Default
document.Theme = Theme.Ocean;           // Blue theme
document.Theme = Theme.TropicalIsland;  // Green theme
```

### Auto Layout

```csharp
// Switch to auto layout for responsive design
document.UseAutoLayout = true;

// Remove manual positioning
var chart = new BarChartVisualization("Sales", dataItem);
// No Column, Row, ColumnSpan, RowSpan needed
```

### Add More Filters

```csharp
// Product filter
var productFilter = new DashboardDataFilter("Product", dataItem);
productFilter.SelectedField = new DimensionDataField("Product");
document.Filters.Add(productFilter);

// Employee filter
var employeeFilter = new DashboardDataFilter("Employee", dataItem);
employeeFilter.SelectedField = new DimensionDataField("Employee");
document.Filters.Add(employeeFilter);
```

## Related Examples

- [Marketing Dashboard](marketing-dashboard.md) - Campaign analytics
- [Healthcare Dashboard](healthcare-dashboard.md) - Healthcare metrics
- [Manufacturing Dashboard](manufacturing-dashboard.md) - Production KPIs
- [KPI Dashboard](kpi-dashboard.md) - Focused KPI examples
- [Charts Gallery](charts-gallery.md) - Various chart types

## Next Steps

- Explore [data source connections](../how-to/data-sources/) for different data types
- Learn about [advanced visualizations](../how-to/visualizations/) 
- Check [best practices](../best-practices.md) for production dashboards