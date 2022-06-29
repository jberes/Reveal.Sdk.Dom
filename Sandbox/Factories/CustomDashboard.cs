using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Visualizations;
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

            document.Visualizations.Add(new KpiTargetVisualization("KPI vs Target", excelDataSourceItem).AddDate("Date").AddValue("Spend").AddTarget("Budget"));
            document.Visualizations.Add(new KpiTimeVisualization("KPI vs Time", excelDataSourceItem).AddDate("Date").AddValue("Traffic"));

            document.Visualizations.Add(new SplineAreaChartVisualization("Spline Area", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Spend", "Budget"));

            document.Visualizations.Add(new StackedColumnChartVisualization("Column", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValues("Paid Traffic", "Organic Traffic", "Other Traffic"));

            document.Visualizations.Add(new LineChartVisualization("Line", excelDataSourceItem)
                .AddLabel(new SummarizationDateField("Date") { DateAggregationType = DateAggregationType.Month })
                .AddValue("Conversions"));

            document.Visualizations.Add(new DoughnutChartVisualization("Doughnut", excelDataSourceItem)
                .AddLabel("Territory")
                .AddValue("Conversions"));

            document.Visualizations.Add(new TextBoxVisualization("TextBox")
                .SetText("This is some text").SetFontSize(FontSize.Large));

            document.Visualizations.Add(new TextViewVisualization("TextView", excelDataSourceItem)
                .AddColumn("Territory").AddColumn("Conversions").AddColumn("Spend"));

            document.Visualizations.Add(new GridVisualization("Grid", excelDataSourceItem)
                .AddColumn("Territory").AddColumn("Conversions").AddColumn("Spend"));

            document.Visualizations.Add(new ImageVisualization("Image", excelDataSourceItem)
                .SetUrlColumn("Territory"));

            return document;
        }
    }
}