using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Builder;
using Reveal.Sdk.Dom.Visualizations.Factories;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using Sandbox.Helpers;

namespace Sandbox.Factories
{
    internal class CustomDashboardBuilder
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

            document.Visualizations.Add(new KpiTargetVisualization("Spend vs Budget", excelDataSourceItem)
                .AddDate("Date").AddValue("Spend").AddTarget("Budget"));

            document.Visualizations.Add(VisualizationFactory.CreateKpiTime("Website Traffic", excelDataSourceItem, "Date", "Traffic"));
            document.Visualizations.Add(VisualizationFactory.CreateKpiTime("Conversions", excelDataSourceItem, "Date", "Conversions"));
            document.Visualizations.Add(VisualizationFactory.CreateKpiTime("New Seats", excelDataSourceItem, "Date", "New Seats"));



            document.Visualizations.Add(new SplineAreaChartBuilder("Actual Spend vs Budget", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget")
                .Build());

            document.Visualizations.Add(new StackedColumnChartBuilder("Website Traffic Breakdown", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Paid Traffic", "Organic Traffic", "Other Traffic")
                .Build());

            document.Visualizations.Add(new LineChartChartBuilder("Conversions", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValue("Conversions")
                .Build());

            document.Visualizations.Add(VisualizationFactory.CreateDoughnutChart("Conversions by Territory", excelDataSourceItem, "Territory", "Conversions"));

            return document;
        }

        void TestMethod(DataSourceItem dataSourceItem)
        {
            var visualization = new SplineAreaChartBuilder("Actual Spend vs Budget", dataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget")
                .ConfigureSettings(settings =>
                {
                    settings.LabelDisplayMode = LabelDisplayMode.Value;
                })
                .Build();
        }
    }
}