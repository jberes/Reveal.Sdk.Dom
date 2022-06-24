using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Factories;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
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

            document.Visualizations.Add(VisualizationFactory.CreateKpiTarget("Spend vs Budget", excelDataSourceItem, "Date", "Spend", "Budget"));
            document.Visualizations.Add(VisualizationFactory.CreateKpiTime("Website Traffic", excelDataSourceItem, "Date", "Traffic"));
            document.Visualizations.Add(VisualizationFactory.CreateKpiTime("Conversions", excelDataSourceItem, "Date", "Conversions"));
            document.Visualizations.Add(VisualizationFactory.CreateKpiTime("New Seats", excelDataSourceItem, "Date", "New Seats"));
            document.Visualizations.Add(VisualizationFactory.CreateSplineAreaChart("Actual Spend vs Budget", excelDataSourceItem, 
                new SummarizationDimensionField[] { new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month } },
                new string[] { "Spend", "Budget" }));
            document.Visualizations.Add(VisualizationFactory.CreateStackedColumnChart("Website Traffic Breakdown", excelDataSourceItem, 
                new SummarizationDimensionField[] { new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month } },
                new string[] { "Paid Traffic", "Organic Traffic", "Other Traffic" }));
            document.Visualizations.Add(VisualizationFactory.CreateLineChart("Conversions", excelDataSourceItem,
                new SummarizationDimensionField[] { new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month } },
                new string[] { "Conversions" }));
            document.Visualizations.Add(VisualizationFactory.CreateDoughnutChart("Conversions by Territory", excelDataSourceItem, "Territory", "Conversions"));

            return document;
        }
    }
}
