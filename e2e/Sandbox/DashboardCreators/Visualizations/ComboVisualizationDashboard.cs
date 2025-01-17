using Reveal.Sdk.Data.Excel;
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.DashboardFactories;
using Sandbox.Helpers;

namespace Sandbox.DashboardCreators
{
    internal class ComboVisualizationDashboard : IDashboardCreator
    {
        public string Name => "Combo Visualization Dashboard";

        public RdashDocument CreateDashboard()
        {
            var document = new RdashDocument("My Grid Visualization Dashboard");

            var excelDSItem = DataSourceFactory.GetMarketingDataSourceItem();

            var vs = new ComboChartVisualization("Paid Traffic", excelDSItem)
                .SetLabel(new DateDataField("Date") { AggregationType = DateAggregationType.Month })
                .SetChart1Value("Paid Traffic")
                .SetChart2Value("Paid %")
                .ConfigureSettings(settings =>
                {
                    settings.Chart1Type = ComboChartType.Column;
                    settings.Chart2Type = ComboChartType.Area;
                    settings.ShowRightAxis = true;
                    settings.StartColorIndex = 10;
                });

            document.Visualizations.Add(vs);

            return document;
        }
    }
}
