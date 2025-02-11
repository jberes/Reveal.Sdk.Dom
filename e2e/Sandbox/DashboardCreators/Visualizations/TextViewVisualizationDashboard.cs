using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.DashboardFactories;
using Sandbox.Helpers;

namespace Sandbox.DashboardCreators.Visualizations
{
    internal class TextViewVisualizationDashboard : IDashboardCreator
    {
        public string Name => "Text View Visualization Dashboard";

        public RdashDocument CreateDashboard()
        {
            var document = new RdashDocument("My Visualization Dashboard");

            var excelDSItem = DataSourceFactory.GetMarketingDataSourceItem();

            var vis = new TextViewVisualization("Text View Visualization", excelDSItem)
            {
                ColumnSpan = 3,
                RowSpan = 4,
                Description = "Testing Text View visualization",
                Title = "Text View Visualization",
            };

            vis.SetColumns("Date", "Spend", "Territory", "Budget", "Conversions");

            document.Visualizations.Add(vis);

            return document;
        }
    }
}
