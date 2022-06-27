using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Sandbox.Helpers;

namespace Sandbox.Factories
{
    internal class CustomDashboard
    {
        internal static DashboardDocument CreateDashboard()
        {
            var excelDataSourceItem = DataSourceFactory.GetMarketingDataSourceItem();

            var document = new DashboardDocument()
            {
                Title = "Custom Dashboard",
                Description = "Playing with the VisualizationFactory",
                Theme = ThemeNames.TropicalIsland
            };

            document.Visualizations.Add(new KpiTargetVisualization("Spend vs Budget", excelDataSourceItem).AddDate("Date").AddValue("Spend").AddTarget("Budget"));
            document.Visualizations.Add(new IndicatorVisualization("Website Traffic", excelDataSourceItem).AddDate("Date").AddValue("Traffic"));
            document.Visualizations.Add(new IndicatorVisualization("Conversions", excelDataSourceItem).AddDate("Date").AddValue("Conversions"));
            document.Visualizations.Add(new IndicatorVisualization("Website Traffic", excelDataSourceItem).AddDate("Date").AddValue("New Seats"));

            document.Visualizations.Add(new SplineAreaChartVisualization("Actual Spend vs Budget", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget"));

            document.Visualizations.Add(new StackedColumnChartVisualization("Website Traffic Breakdown", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            document.Visualizations.Add(new LineChartVisualization("Conversions", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValue("Conversions"));

            document.Visualizations.Add(new DoughnutChartVisualization("Conversions by Territory", excelDataSourceItem)
                .AddLabel("Territory")
                .AddValue("Conversions"));

            return document;
        }
    }
}