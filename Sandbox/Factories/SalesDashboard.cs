using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
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

        private static Visualization CreateKpiTargetVisualization(ExcelDataSourceItem excelDataSourceItem, Binding territoryFilterBinding)
        {
            var visualization = new KpiTargetVisualization(excelDataSourceItem)
            {
                Title = "Sales",
                ColumnSpan = 11,
                RowSpan = 20,
            };

            visualization.FilterBindings.Add(territoryFilterBinding);

            visualization.VisualizationDataSpec.DateFilterType = IndicatorTargetDateFilterType.YearToDate;

            visualization.VisualizationDataSpec.Date = new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationDateField("Date")
                {
                    DateAggregationType = DateAggregationType.Year,
                }
            };

            visualization.VisualizationDataSpec.Value.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Pipepline")
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
                }
            });

            visualization.VisualizationDataSpec.Target.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Forecasted")
            });

            return visualization;
        }

        private static Visualization CreateSplineAreaChartVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = new SplineAreaChartVisualization(excelDataSourceItem)
            {
                Title = "New vs Renewal Sales",
                ColumnSpan = 31,
                RowSpan = 39,
            };

            visualization.FilterBindings.AddRange(filterBindings);

            visualization.VisualizationDataSpec.Rows.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationDateField("Date")
                {
                    DateAggregationType = DateAggregationType.Month
                }
            });

            visualization.VisualizationDataSpec.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("New Sales")
            });
            visualization.VisualizationDataSpec.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Renewal Sales ")
            });

            return visualization;
        }

        private static Visualization CreateStackedColumnChartVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = new StackedColumnChartVisualization(excelDataSourceItem)
            {
                Title = "Sales by Product",
                ColumnSpan = 18,
                RowSpan = 39,
            };

            visualization.FilterBindings.AddRange(filterBindings);

            visualization.VisualizationDataSpec.Rows.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Product")
            });

            visualization.VisualizationDataSpec.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("New Sales")
            });
            visualization.VisualizationDataSpec.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Renewal Sales ")
            });

            return visualization;
        }

        private static Visualization CreateIndicatorVisualization(ExcelDataSourceItem excelDataSourceItem, Binding territoryFilterBinding)
        {
            var visualization = new IndicatorVisualization(excelDataSourceItem)
            {
                Title = "Total Opportunities",
                ColumnSpan = 11,
                RowSpan = 19
            };

            visualization.FilterBindings.Add(territoryFilterBinding);

            visualization.VisualizationDataSpec.Date = new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationDateField("Date")
                {
                    DateAggregationType = DateAggregationType.Year,
                }
            };

            visualization.VisualizationDataSpec.Value.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Total Opportunites")
            });

            return visualization;
        }

        private static Visualization CreateSparklineVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = new SparklineVisualization(excelDataSourceItem)
            {
                Title = "New Seats by Product",
                ColumnSpan = 31,
                RowSpan = 30
            };

            visualization.Settings.Style = new GridVisualizationStyle()
            {
                TextAlignment = TextAlignment.Left,
                NumericAlignment = TextAlignment.Right,
                DateAlignment = TextAlignment.Left
            };

            visualization.FilterBindings.AddRange(filterBindings);

            visualization.VisualizationDataSpec.IndicatorType = IndicatorVisualizationType.LastMonths;
            visualization.VisualizationDataSpec.Rows.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Product")
            });

            visualization.VisualizationDataSpec.Date = new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationDateField("Date")
                {
                    DateAggregationType = DateAggregationType.Month,
                }
            };

            visualization.VisualizationDataSpec.Value.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("New Seats")
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
                }
            });

            return visualization;
        }

        private static Visualization CreateBarChartVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = new BarChartVisualization(excelDataSourceItem)
            {
                Title = "Sales",
                ColumnSpan = 29,
                RowSpan = 43
            };

            visualization.FilterBindings.AddRange(filterBindings);

            visualization.VisualizationDataSpec.Rows.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Employee")
            });

            visualization.VisualizationDataSpec.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Pipepline")
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
            });

            return visualization;
        }

        private static Visualization CreateColumnChartVisualization(ExcelDataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = new ColumnChartVisualization(excelDataSourceItem)
            {
                Title = "Total Leads vs Hot Leads",
                ColumnSpan = 31,
                RowSpan = 46
            };

            visualization.FilterBindings.AddRange(filterBindings);

            visualization.VisualizationDataSpec.Rows.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationDateField("Date")
                {
                    DateAggregationType = DateAggregationType.Month,
                }
            });

            visualization.VisualizationDataSpec.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Leads")
            });
            visualization.VisualizationDataSpec.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Hot Leads")
            });

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

            visualization.VisualizationDataSpec.Rows.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Employee")
            });

            visualization.VisualizationDataSpec.Value.Add(new MeasureColumnSpec()
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
