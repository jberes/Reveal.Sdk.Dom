using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.Helpers;
using System.Linq;

namespace Sandbox.Factories
{
    internal class SalesDashboard
    {
        internal static DashboardDocument CreateDashboard()
        {
            var excelDataSourceItem = DataSourceFactory.GetSalesDataSourceItem();

            var document = new DashboardDocument()
            {
                Title = "Sales",
                Description = "I created this in code",
                UseAutoLayout = false,
            };

            document.Filters.Add(new DashboardDateFilter()
            {
                Title = "My Date Filter"
            });

            var territoryFilter = new DashboardDataFilter(excelDataSourceItem)
            {
                Title = "Territory",
                SelectedFieldName = "Territory",
                AllowMultipleSelection = true,
                AllowEmptySelection = true
            };
            document.Filters.Add(territoryFilter);

            var globalDateFilterBinding = new DashboardDateFilterBinding("Date");
            var territoryFilterBinding = new DashboardDataFilterBinding(territoryFilter);

            document.Visualizations.Add(CreateKpiTargetVisualization(excelDataSourceItem, territoryFilterBinding));
            document.Visualizations.Add(CreateSplineAreaChartVisualization(excelDataSourceItem, globalDateFilterBinding, territoryFilterBinding));
            document.Visualizations.Add(CreateStackedColumnChartVisualization(excelDataSourceItem, globalDateFilterBinding, territoryFilterBinding));
            document.Visualizations.Add(CreateIndicatorVisualization(excelDataSourceItem, territoryFilterBinding));
            document.Visualizations.Add(CreateSparklineVisualization(excelDataSourceItem, globalDateFilterBinding, territoryFilterBinding));
            document.Visualizations.Add(CreateBarChartVisualization(excelDataSourceItem, globalDateFilterBinding, territoryFilterBinding));
            document.Visualizations.Add(CreateColumnChartVisualization(excelDataSourceItem, globalDateFilterBinding, territoryFilterBinding));
            document.Visualizations.Add(CreateGaugeVisualization(excelDataSourceItem, globalDateFilterBinding, territoryFilterBinding));

            return document;
        }

        private static Visualization CreateKpiTargetVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            return new KpiTargetVisualization("Sales", excelDataSourceItem)
                .AddDate("Date")
                .AddValue(new SummarizationValueField("Pipepline")
                {
                    FieldLabel = "Actual Sales",
                    AggregationType = AggregationType.Sum,
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Currency,
                        DecimalDigits = 0,
                        ShowGroupingSeparator = true,
                        CurrencySymbol = "$",
                        NegativeFormat = NegativeFormatType.MinusSign,
                        ApplyMkFormat = true,
                    }
                })
                .AddTarget("Forecasted")
                .AddFilterBindings(filterBindings)
                .SetPosition(20, 11);
        }

        private static Visualization CreateSplineAreaChartVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            return new SplineAreaChartVisualization("New vs Renewal Sales", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("New Sales", "Renewal Sales ")
                .AddFilterBindings(filterBindings)
                .SetPosition(39, 31);
        }

        private static Visualization CreateStackedColumnChartVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            return new StackedColumnChartVisualization("Sales by Product", excelDataSourceItem)
                .AddLabel("Product")
                .AddValues("New Sales", "Renewal Sales ")
                .AddFilterBindings(filterBindings)
                .SetPosition(39, 18);
        }

        private static Visualization CreateIndicatorVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            return new KpiTimeVisualization("Total Opportunities", excelDataSourceItem)
                .AddDate(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Year })
                .AddValue("Total Opportunites")
                .AddFilterBindings(filterBindings)
                .SetPosition(19, 11);
        }

        private static Visualization CreateSparklineVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            return new SparklineVisualization("New Seats by Product", excelDataSourceItem)
                .AddDate(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValue(new SummarizationValueField("New Seats")
                {
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Number,
                        DecimalDigits = 0,
                        ShowGroupingSeparator = true,
                        CurrencySymbol = "$",
                        NegativeFormat = NegativeFormatType.MinusSign,
                        ApplyMkFormat = false,
                    }
                })
                .AddCategory("Product")
                .ConfigureSettings(settings =>
                {
                    settings.Style.TextAlignment = TextAlignment.Left;
                    settings.Style.NumericAlignment = TextAlignment.Left;
                    settings.Style.DateAlignment = TextAlignment.Left;
                })
                .AddFilterBindings(filterBindings)
                .SetIndicatorType(IndicatorVisualizationType.LastMonths)
                .SetPosition(30, 31);
        }

        private static Visualization CreateBarChartVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            return new BarChartVisualization("Sales", excelDataSourceItem)
                .AddLabel("Employee")
                .AddValue(new SummarizationValueField("Pipepline")
                {
                    Sorting = SortingType.Asc,
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Currency,
                        DecimalDigits = 0,
                        ShowGroupingSeparator = true,
                        ApplyMkFormat = true,
                    }
                })
                .AddFilterBindings(filterBindings)
                .SetPosition(43, 29);
        }

        private static Visualization CreateColumnChartVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            return new ColumnChartVisualization("", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Leads", "Hot Leads")
                .AddFilterBindings(filterBindings)
                .SetPosition(46, 31);
        }

        private static Visualization CreateGaugeVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = new BulletGraphVisualization("Quotas by Sales Rep", excelDataSourceItem)
                .AddLabel("Employee")
                .AddValue(new SummarizationValueField("Quota")
                {
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Percent,
                        DecimalDigits = 2,
                        ShowGroupingSeparator = false,
                        ApplyMkFormat = true,
                    }
                })
                .ConfigureBands((greenBand, yellowBand, redBand) =>
                {
                    greenBand.Type = BandType.NumberValue;
                    greenBand.Value = 1.0;

                    yellowBand.Type = BandType.NumberValue;
                    yellowBand.Value = 0.8;
                })
                .ConfigureSettings(settings => 
                {
                    settings.Minimum = new Bound() { Value = 0.8, ValueType = BoundValueType.NumberValue };
                    settings.Maximum = new Bound() { Value = 2.0, ValueType = BoundValueType.NumberValue };
                })
                .ConfigureFields(fields =>
                {
                    var quotaField = fields.Where(x => x.FieldName == "Quota").First();
                    quotaField.Filter = new NumberFilter()
                    {
                        FilterType = FilterType.FilterByRule,
                        RuleType = NumberRuleType.TopItems,
                        Value = 10.0
                    };
                })
                .AddFilterBindings(filterBindings)
                .SetPosition(33, 29);

            return visualization;
        }
    }
}