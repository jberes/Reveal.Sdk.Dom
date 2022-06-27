using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Sandbox.Helpers;

namespace Sandbox.Factories
{
    internal class MarketingDashboard
    {
        static Binding _globalDateFilterBinding = new DashboardDateFilterBinding("Date");

        internal static DashboardDocument CreateDashboard()
        {
            var document = new DashboardDocument()
            {
                Title = "Marketing",
                Description = "I created this in code",
                Theme = ThemeNames.TropicalIsland,
                UseAutoLayout = false,
            };

            document.Filters.Add(new DashboardDateFilter());

            var excelDataSourceItem = DataSourceFactory.GetMarketingDataSourceItem();

            document.Visualizations.Add(CreateKpiTargetVisualization(excelDataSourceItem));
            document.Visualizations.Add(CreateLineChartVisualization(excelDataSourceItem));
            document.Visualizations.Add(CreatePieChartVisualization(excelDataSourceItem));
            document.Visualizations.Add(CreateColumnChartVisualization(excelDataSourceItem));
            document.Visualizations.Add(CreateFunnelChartVisualization(excelDataSourceItem));
            document.Visualizations.Add(CreatePivotVisualization(excelDataSourceItem));

            return document;
        }

        internal static Visualization CreateKpiTargetVisualization(ExcelDataSourceItem excelDataSourceItem)
        {
            var visualization = new KpiTargetVisualization(excelDataSourceItem)
            {
                Title = "Spend vs Budget",
                ColumnSpan = 10,
                RowSpan = 24,
            };

            visualization.Date = new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationDateField("Date")
                {
                    DateAggregationType = DateAggregationType.Year,
                    DateFormatting = new DateFormattingSpec()
                    {
                        DateFormat = "dd-MMM-yyyy"
                    }
                }
            };

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Spend")
                {
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Number,
                        DecimalDigits = 0,
                        ShowGroupingSeparator = true,
                        CurrencySymbol = "$",
                        NegativeFormat = NegativeFormatType.MinusSign,
                        ApplyMkFormat = true,
                    }
                }
            });

            visualization.Targets.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Budget")
                {
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Number,
                        ShowGroupingSeparator = true,
                        CurrencySymbol = "$",
                        NegativeFormat = NegativeFormatType.MinusSign,
                    }
                }
            });

            return visualization;
        }

        internal static Visualization CreateLineChartVisualization(ExcelDataSourceItem excelDataSourceItem)
        {
            var visualization = new LineChartVisualization(excelDataSourceItem)
            {
                Title = "Actual Spend vs Budget",
                ColumnSpan = 30,
                RowSpan = 24,
            };

            visualization.FilterBindings.Add(_globalDateFilterBinding);

            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationDateField("Date")
                {
                    DateAggregationType = DateAggregationType.Month
                }
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Spend")
            });
            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Budget")
            });

            return visualization;
        }

        internal static Visualization CreatePieChartVisualization(ExcelDataSourceItem excelDataSourceItem)
        {
            var visualization = new PieChartVisualization(excelDataSourceItem)
            {
                Title = "Spend by Territory",
                ColumnSpan = 20,
                RowSpan = 24,
            };

            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Territory")
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Spend")
            });

            return visualization;
        }

        internal static Visualization CreateColumnChartVisualization(ExcelDataSourceItem excelDataSourceItem)
        {
            var visualization = new ColumnChartVisualization(excelDataSourceItem)
            {
                Title = "Spend by Territory",
                ColumnSpan = 27,
                RowSpan = 36,
            };

            visualization.FilterBindings.Add(_globalDateFilterBinding);

            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationDateField("Date")
                {
                    DateAggregationType = DateAggregationType.Month
                }
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Paid Traffic")
            });
            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Organic Traffic")
            });
            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Other Traffic")
            });

            return visualization;
        }

        internal static Visualization CreateFunnelChartVisualization(ExcelDataSourceItem excelDataSourceItem)
        {
            var visualization = new FunnelChartVisualization(excelDataSourceItem)
            {
                Title = "Conversions by Campaign",
                ColumnSpan = 13,
                RowSpan = 36,
            };

            visualization.FilterBindings.Add(_globalDateFilterBinding);

            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("CampaignID")
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Conversions")
            });

            return visualization;
        }

        internal static Visualization CreatePivotVisualization(ExcelDataSourceItem excelDataSourceItem)
        {
            var visualization = new PivotVisualization(excelDataSourceItem)
            {
                Title = "New Seats by Campaign ID",
                ColumnSpan = 20,
                RowSpan = 36,
            };

            visualization.Settings.Style.TextAlignment = TextAlignment.Left;
            visualization.Settings.Style.NumericAlignment = TextAlignment.Right;
            visualization.Settings.Style.DateAlignment = TextAlignment.Left;

            visualization.Settings.VisualizationColumns.Add(new VisualizationColumnStyle()
            {
                ColumnName = "CampaignID",
                Width = 144,
                TextAlignment = TextAlignment.Inherit
            });

            visualization.Rows.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("CampaignID")
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("CTR")
                {
                    AggregationType = AggregationType.Avg,
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Percent,
                        DecimalDigits = 2,
                        CurrencySymbol = "$",
                        NegativeFormat = NegativeFormatType.MinusSign,
                        ApplyMkFormat = true,
                    }
                }
            });
            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Avg. CPC")
                {
                    AggregationType = AggregationType.Avg,
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Currency,
                        DecimalDigits = 0,
                        CurrencySymbol = "$",
                        NegativeFormat = NegativeFormatType.MinusSign,
                        ShowGroupingSeparator = true,
                    }
                }
            });
            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("New Seats")
                {
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Currency,
                        DecimalDigits = 0,
                        CurrencySymbol = "$",
                        NegativeFormat = NegativeFormatType.MinusSign,
                        ShowGroupingSeparator = true,
                    }
                }
            });

            return visualization;
        }
    }
}
