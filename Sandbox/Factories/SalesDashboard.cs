using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Factories;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
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
            var visualization = VisualizationFactory.CreateKpiTarget("Sales", excelDataSourceItem, "Date",
                new SummarizationValueField("Pipepline")
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
                }, "Forecasted", filterBindings);

            visualization.ColumnSpan = 11;
            visualization.RowSpan = 20;

            return visualization;
        }

        private static Visualization CreateSplineAreaChartVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = VisualizationFactory.CreateSplineAreaChart("New vs Renewal Sales", excelDataSourceItem,
                new SummarizationDimensionField[] { new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month } },
                new SummarizationValueField[] { new SummarizationValueField("New Sales"), new SummarizationValueField("Renewal Sales ") }, filterBindings);

            visualization.ColumnSpan = 31;
            visualization.RowSpan = 39;

            return visualization;
        }

        private static Visualization CreateStackedColumnChartVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = VisualizationFactory.CreateStackedColumnChart("Sales by Product", excelDataSourceItem,
                new string[] { "Product" }, new string[] { "New Sales", "Renewal Sales " }, filterBindings);

            visualization.ColumnSpan = 18;
            visualization.RowSpan = 39;

            return visualization;
        }

        private static Visualization CreateIndicatorVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = VisualizationFactory.CreateKpiTime("Total Opportunities", excelDataSourceItem,
                new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Year },
                new SummarizationValueField("Total Opportunites"), filterBindings);

            visualization.ColumnSpan = 11;
            visualization.RowSpan = 19;

            return visualization;
        }

        private static Visualization CreateSparklineVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = VisualizationFactory.CreateSparkline("New Seats by Product", excelDataSourceItem,
                new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month },
                new SummarizationValueField("New Seats")
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
                },
                new SummarizationDimensionField[] { new SummarizationRegularField("Product") }, filterBindings);

            visualization.ColumnSpan = 31;
            visualization.RowSpan = 30;

            visualization.Settings.Style = new GridVisualizationStyle()
            {
                TextAlignment = TextAlignment.Left,
                NumericAlignment = TextAlignment.Right,
                DateAlignment = TextAlignment.Left
            };

            visualization.IndicatorType = IndicatorVisualizationType.LastMonths;

            return visualization;
        }

        private static Visualization CreateBarChartVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = VisualizationFactory.CreateBarChart("Sales", excelDataSourceItem,
                new SummarizationDimensionField[] { new SummarizationRegularField("Employee") },
                new SummarizationValueField[] 
                { 
                    new SummarizationValueField("Pipepline")
                    {
                        Sorting = SortingType.Asc,
                        Formatting = new NumberFormattingSpec()
                        {
                            FormatType = NumberFormattingType.Currency,
                            DecimalDigits = 0,
                            ShowGroupingSeparator = true,
                            ApplyMkFormat = true,
                        }
                    }
                }, filterBindings);

            visualization.ColumnSpan = 29;
            visualization.RowSpan = 43;

            return visualization;
        }

        private static Visualization CreateColumnChartVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = VisualizationFactory.CreateColumnChart("Total Leads vs Hot Leads", excelDataSourceItem,
                new SummarizationDimensionField[] { new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month } },
                new string[] { "Leads", "Hot Leads" }, filterBindings);

            visualization.ColumnSpan = 31;
            visualization.RowSpan = 46;

            return visualization;
        }

        private static Visualization CreateGaugeVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = new GaugeVisualization(excelDataSourceItem)
            {
                Title = "Quotas by Sales Rep",
                ColumnSpan = 29,
                RowSpan = 33
            };

            visualization.FilterBindings.AddRange(filterBindings);

            visualization.DataSpec.Fields = DataSourceFactory.GetSalesDataSourceFields();

            var quotaField = visualization.DataSpec.Fields.Where(x => x.FieldName == "Quota").First();
            quotaField.Filter = new NumberFilter()
            {
                FilterType = FilterType.FilterByRule,
                RuleType = NumberRuleType.TopItems,
                Value = 10.0
            };

            visualization.Settings.ViewType = GaugeViewType.BulletGraph;
            visualization.Settings.Minimum = new Bound() { Value = 0.8, ValueType = BoundValueType.NumberValue };
            visualization.Settings.Maximum = new Bound() { Value = 2.0, ValueType = BoundValueType.NumberValue };
            visualization.Settings.GaugeBands.Add(new GaugeBand()
            {
                Type = BandType.NumberValue,
                Color = BandColorType.Green,
                Value = 1.0,
                Shape = ShapeType.None
            });
            visualization.Settings.GaugeBands.Add(new GaugeBand()
            {
                Type = BandType.NumberValue,
                Color = BandColorType.Yellow,
                Value = 0.8,
                Shape = ShapeType.None
            });
            visualization.Settings.GaugeBands.Add(new GaugeBand()
            {
                Type = BandType.Percentage,
                Color = BandColorType.Red,
                Shape = ShapeType.None
            });

            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Employee")
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Quota")
                {
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Percent,
                        DecimalDigits = 2,
                        ShowGroupingSeparator = false,
                        ApplyMkFormat = true,
                    }
                }
            });

            return visualization;
        }
    }
}
