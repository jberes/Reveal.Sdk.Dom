using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.Helpers;
using System.Linq;

namespace Sandbox.Factories
{
    internal class ManufacturingDashboard
    {
        internal static DashboardDocument CreateDashboard()
        {
            var excelDataSourceItem = DataSourceFactory.GetManufacturingDataSourceItem();

            var document = new DashboardDocument("Manufacturing")
            {
                Title = "Manufacturing",
                Theme = ThemeNames.RockyMountain,
                Description = "I created this in code",
                UseAutoLayout = false,
            };

            document.Visualizations.Add(CreateIndicatorVisualization("Productivity", "Overall Plant Productivity ", excelDataSourceItem, true));
            document.Visualizations.Add(CreateIndicatorVisualization("Units Lost", "Units Lost", excelDataSourceItem));
            document.Visualizations.Add(CreateLineChartVisualization(excelDataSourceItem));
            document.Visualizations.Add(CreateColumnChartVisualization(excelDataSourceItem));
            document.Visualizations.Add(CreateDoughnutChartVisualization(excelDataSourceItem));
            document.Visualizations.Add(CreateCircularGaugeVisualization(excelDataSourceItem));
            document.Visualizations.Add(CreateCircularGaugeVisualization2(excelDataSourceItem));
            document.Visualizations.Add(CreateColumnChartVisualization2(excelDataSourceItem));

            return document;
        }

        private static Visualization CreateIndicatorVisualization(string title, string field, ExcelDataSourceItem excelDataSourceItem, bool avg = false)
        {
            var visualization = new KpiTimeVisualization(excelDataSourceItem)
            {
                Title = title,
                ColumnSpan = 10,
                RowSpan = 22,
            };

            visualization.Date = new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationDateField("Date")
            };

            SummarizationValueField summarizationtionField = new SummarizationValueField(field);
            if (avg)
            {
                summarizationtionField.AggregationType = AggregationType.Avg;
                summarizationtionField.Formatting = new NumberFormattingSpec()
                {
                    FormatType = NumberFormattingType.Percent,
                    DecimalDigits = 0,
                    ShowGroupingSeparator = true,
                    ApplyMkFormat = true
                };
            }

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = summarizationtionField
            });

            return visualization;
        }

        private static Visualization CreateLineChartVisualization(ExcelDataSourceItem excelDataSourceItem)
        {
            var visualization = new LineChartVisualization(excelDataSourceItem)
            {
                Title = "Cost of Labor vs Revenue",
                ColumnSpan = 40,
                RowSpan = 22,
            };

            var field = visualization.DataSpec.Fields.Where(x => x.FieldName == "Date").First();
            field.Filter = new DateTimeFilter() //in the UI these are referred to as a Data Fiter
            {
                FilterType = FilterType.FilterByRule,
                DateFiscalYearStartMonth = 0,
                DisplayInLocalTimeZone = false,
                RuleType = DateRuleType.LastYear
            };
            field.Formatting = new DateFormattingSpec()
            {
                DateFormat = "dd-MMM-yyyy"
            };
            field.Settings = new DateTimeFieldSettings()
            {
                DateFiscalYearStartMonth = 0,
                DisplayInLocalTimeZone = false
            };


            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationDateField("Date")
                {
                    DateAggregationType = DateAggregationType.Month
                }
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Cost of Labor ")
                {
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Currency,
                        DecimalDigits = 0,
                        ShowGroupingSeparator = true,
                    }
                }
            });
            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Revenue")
                {
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Currency,
                        DecimalDigits = 0,
                        ShowGroupingSeparator = true,
                    }
                }
            });

            return visualization;
        }

        private static Visualization CreateColumnChartVisualization(ExcelDataSourceItem excelDataSourceItem)
        {
            var visualization = new ColumnChartVisualization(excelDataSourceItem)
            {
                Title = "Units Produced By Line",
                ColumnSpan = 19,
                RowSpan = 38
            };

            var field = visualization.DataSpec.Fields.Where(x => x.FieldName == "Date").FirstOrDefault();
            field.Filter = new DateTimeFilter()
            {
                FilterType = FilterType.FilterByRule,
                DateFiscalYearStartMonth = 0,
                DisplayInLocalTimeZone = false,
                RuleType = DateRuleType.LastMonth
            };
            field.Settings = new DateTimeFieldSettings()
            {
                DateFiscalYearStartMonth = 0,
                DisplayInLocalTimeZone = false
            };            

            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Line")
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Units Produced")
                {
                    Sorting = SortingType.Desc,
                    Formatting = new NumberFormattingSpec()
                    {
                        DecimalDigits = 0,
                        ShowGroupingSeparator = true,
                    }
                }
            });

            return visualization;
        }

        private static Visualization CreateDoughnutChartVisualization(ExcelDataSourceItem excelDataSourceItem)
        {
            var visualization = new DoughnutChartVisualization(excelDataSourceItem)
            {
                Title = "Operators Available by Function",
                ColumnSpan = 21,
                RowSpan = 38,
            };

            var field = visualization.DataSpec.Fields.Where(x => x.FieldName == "Date").FirstOrDefault();
            field.Filter = new DateTimeFilter()
            {
                FilterType = FilterType.FilterByRule,
                DateFiscalYearStartMonth = 0,
                DisplayInLocalTimeZone = false,
                RuleType = DateRuleType.LastMonth
            };
            field.Settings = new DateTimeFieldSettings()
            {
                DateFiscalYearStartMonth = 0,
                DisplayInLocalTimeZone = false
            };

            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Operators by Function")
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Operators Available ")
                {
                    Sorting = SortingType.Asc,
                    Formatting = new NumberFormattingSpec()
                    {
                        DecimalDigits = 0,
                        ShowGroupingSeparator = true
                    }
                }
            });

            return visualization;
        }

        private static Visualization CreateCircularGaugeVisualization(ExcelDataSourceItem excelDataSourceItem)
        {
            var visualization = new CircularGaugeVisualization(excelDataSourceItem)
            {
                Title = "Line 2 Efficiency",
                ColumnSpan = 20,
                RowSpan = 19
            };

            var field = visualization.DataSpec.Fields.Where(x => x.FieldName == "Line").FirstOrDefault();
            field.Filter = new StringFilter()
            {
                FilterType = FilterType.SelectedValues,
                SelectedValues = new System.Collections.Generic.List<FilterValue>()
                {
                    new FilterValue() { Name = "Line 5", Value = "Line 5"},
                    new FilterValue() { Name = "Line 2", Value = "Line 2"}
                }
            };
            field.Settings = new DateTimeFieldSettings()
            {
                DateFiscalYearStartMonth = 0,
                DisplayInLocalTimeZone = false
            };

            visualization.Settings.Minimum = new Bound() { Value = 0.0, ValueType = BoundValueType.NumberValue };
            visualization.Settings.Maximum = new Bound() { Value = 1.0, ValueType = BoundValueType.NumberValue };
            visualization.Bands.Add(new GaugeBand()
            {
                Type = BandType.Percentage,
                Color = BandColorType.Green,
                Value = 100.0,
            });
            visualization.Bands.Add(new GaugeBand()
            {
                Type = BandType.Percentage,
                Color = BandColorType.Yellow,
                Value = 0.0
            });
            visualization.Bands.Add(new GaugeBand()
            {
                Type = BandType.Percentage,
                Color = BandColorType.Red,
                Shape = ShapeType.None
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Efficiency")
                {
                    AggregationType = AggregationType.Avg,
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Percent,
                        DecimalDigits = 2,
                        ShowGroupingSeparator = false,
                        ApplyMkFormat = true,
                    }
                }
            });

            visualization.Label = new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Line")
            };

            return visualization;
        }

        private static Visualization CreateCircularGaugeVisualization2(ExcelDataSourceItem excelDataSourceItem)
        {
            var visualization = new CircularGaugeVisualization(excelDataSourceItem)
            {
                Title = "Line 1 Efficiency",
                ColumnSpan = 20,
                RowSpan = 19
            };

            var field = visualization.DataSpec.Fields.Where(x => x.FieldName == "Line").FirstOrDefault();
            field.Filter = new StringFilter()
            {
                FilterType = FilterType.SelectedValues,
                SelectedValues = new System.Collections.Generic.List<FilterValue>()
                {
                    new FilterValue() { Name = "Line 1", Value = "Line 1"}
                }
            };

            visualization.Settings.Minimum = new Bound() { Value = 0.0, ValueType = BoundValueType.NumberValue };
            visualization.Settings.Maximum = new Bound() { Value = 1.0, ValueType = BoundValueType.NumberValue };
            visualization.Bands.Add(new GaugeBand()
            {
                Type = BandType.Percentage,
                Color = BandColorType.Green,
                Value = 1.0,
            });
            visualization.Bands.Add(new GaugeBand()
            {
                Type = BandType.Percentage,
                Color = BandColorType.Yellow,
                Value = 0.0
            });
            visualization.Bands.Add(new GaugeBand()
            {
                Type = BandType.Percentage,
                Color = BandColorType.Red,
                Shape = ShapeType.None
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Efficiency")
                {
                    AggregationType = AggregationType.Max,
                    Formatting = new NumberFormattingSpec()
                    {
                        FormatType = NumberFormattingType.Percent,
                        DecimalDigits = 2,
                        ShowGroupingSeparator = false,
                        ApplyMkFormat = true,
                    }
                }
            });

            visualization.Label = new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Line")
            };

            return visualization;
        }

        private static Visualization CreateColumnChartVisualization2(ExcelDataSourceItem excelDataSourceItem)
        {
            var visualization = new ColumnChartVisualization(excelDataSourceItem)
            {
                Title = "Orders In vs Orders Shipped",
                ColumnSpan = 60,
                RowSpan = 32
            };

            var field = visualization.DataSpec.Fields.Where(x => x.FieldName == "Date").First();
            field.Filter = new DateTimeFilter()
            {
                FilterType = FilterType.FilterByRule,
                DateFiscalYearStartMonth = 0,
                DisplayInLocalTimeZone = false,
                RuleType = DateRuleType.LastYear
            };
            field.Formatting = new DateFormattingSpec()
            {
                DateFormat = "dd-MMM-yyyy"
            };
            field.Settings = new DateTimeFieldSettings()
            {
                DateFiscalYearStartMonth = 0,
                DisplayInLocalTimeZone = false
            };

            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationDateField("Date")
                {
                    DateAggregationType = DateAggregationType.Month
                }
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Orders In")
            });
            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Orders Shipped ")
            });

            return visualization;
        }
    }
}
