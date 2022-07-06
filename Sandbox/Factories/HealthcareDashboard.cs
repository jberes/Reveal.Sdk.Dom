using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.Helpers;

namespace Sandbox.Factories
{
    internal class HealthcareDashboard
    {
        internal static DashboardDocument CreateDashboard()
        {
            var excelDataSourceItem = DataSourceFactory.GetHealthcareDataSourceItem();

            var document = new DashboardDocument()
            {
                Title = "Healthcare",
                Theme = ThemeNames.Circus,
                Description = "I created this in code",
                UseAutoLayout = false,
            };

            document.Filters.Add(new DashboardDateFilter()
            {
                RuleType = DateRuleType.TrailingTwelveMonths
            });

            var globalDateFilterBinding = new DashboardDateFilterBinding("Date");

            document.Visualizations.Add(CreateIndicatorVisualization("Number of Inpatients", "Number of Inpatients", excelDataSourceItem));
            document.Visualizations.Add(CreateIndicatorVisualization("Number of Outpatients", "Number of Outpatients", excelDataSourceItem));
            document.Visualizations.Add(CreateIndicatorVisualization("Average ER Wait Time (Min)", "ER Wait Time", excelDataSourceItem, true));
            document.Visualizations.Add(CreateIndicatorVisualization("Average Days Stayed", "Length of Stay ", excelDataSourceItem, true));
            document.Visualizations.Add(CreateDoughnutChartVisualization(excelDataSourceItem));
            document.Visualizations.Add(CreateSplineAreaChartVisualization(excelDataSourceItem, globalDateFilterBinding));
            document.Visualizations.Add(CreateFunnelChartVisualization(excelDataSourceItem, globalDateFilterBinding));
            document.Visualizations.Add(CreateStackedColumnChartVisualization(excelDataSourceItem));
            document.Visualizations.Add(CreateLineChartVisualization(excelDataSourceItem, globalDateFilterBinding));

            return document;
        }

        private static Visualization CreateIndicatorVisualization(string title, string field, DataSourceItem excelDataSourceItem, bool avg = false)
        {
            var visualization = new KpiTimeVisualization(excelDataSourceItem)
            {
                Title = title,
                ColumnSpan = 15,
                RowSpan = 13,
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
                    DecimalDigits = 0,
                    ShowGroupingSeparator = true,
                };
            }

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = summarizationtionField
            });

            return visualization;
        }

        private static Visualization CreateDoughnutChartVisualization(DataSourceItem excelDataSourceItem)
        {
            var visualization = new DoughnutChartVisualization(excelDataSourceItem)
            {
                Title = "Current Patients by Division",
                ColumnSpan = 15,
                RowSpan = 23,
            };

            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Divison")
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Current Paitents")
            });

            return visualization;
        }

        private static Visualization CreateSplineAreaChartVisualization(DataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = new SplineAreaChartVisualization(excelDataSourceItem)
            {
                Title = "Treatment Costs vs Charges per MD",
                ColumnSpan = 30,
                RowSpan = 23,
            };

            visualization.FilterBindings.AddRange(filterBindings);

            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationDateField("Date")
                {
                    DateAggregationType = DateAggregationType.Month
                }
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Charges per MD")
            });
            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Treatment Costs ")
            });

            return visualization;
        }

        private static Visualization CreateFunnelChartVisualization(DataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = new FunnelChartVisualization(excelDataSourceItem)
            {
                Title = "Wait Time by Division",
                ColumnSpan = 15,
                RowSpan = 23,
            };

            visualization.FilterBindings.AddRange(filterBindings);

            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Divison")
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("ER Wait Time")
            });

            return visualization;
        }

        private static Visualization CreateStackedColumnChartVisualization(DataSourceItem excelDataSourceItem)
        {
            var visualization = new StackedColumnChartVisualization(excelDataSourceItem)
            {
                Title = "Satisfaction by Division",
                ColumnSpan = 30,
                RowSpan = 23,
            };

            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Divison")
            });

            visualization.Category = new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationRegularField("Satisfaction ")
            };

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Satisfaction ")
                {
                    AggregationType = AggregationType.CountRows,
                    Formatting = new NumberFormattingSpec()
                    {
                        DecimalDigits = 0,
                        ShowGroupingSeparator = true,
                    }
                }
            });

            return visualization;
        }

        private static Visualization CreateLineChartVisualization(DataSourceItem excelDataSourceItem, params Binding[] filterBindings)
        {
            var visualization = new LineChartVisualization(excelDataSourceItem)
            {
                Title = "Inpatients vs Outpatients",
                ColumnSpan = 30,
                RowSpan = 23,
            };

            visualization.FilterBindings.AddRange(filterBindings);

            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = new SummarizationDateField("Date")
                {
                    DateAggregationType = DateAggregationType.Month
                }
            });

            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Number of Inpatients")
            });
            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = new SummarizationValueField("Number of Outpatients")
            });

            return visualization;
        }
    }
}
