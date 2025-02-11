using Reveal.Sdk.Data.Excel;
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.DashboardFactories;
using Sandbox.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.DashboardCreators
{
    internal class CustomVisualizationDashboard : IDashboardCreator
    {
        public string Name => "Custom Visualization Dashboard";

        public RdashDocument CreateDashboard()
        {
            var document = new RdashDocument("My Custom Visualization Dashboard");

            var excelDSItem = DataSourceFactory.GetMarketingDataSourceItem();

            var vsWebPage = new CustomVisualization("Wikipedia Custom View", excelDSItem)
            {
                RowSpan = 2,
                ColumnSpan = 2
            }
                .SetUrl("https://en.wikipedia.org/wiki/Main_Page");

            var vsGrid = new CustomVisualization("Custom", excelDSItem)
            {
                RowSpan = 5,
                ColumnSpan = 5
            }
                .SetUrl("https://dl.infragistics.com/reportplus/diy/HelloWorld-Desktop-EN.html")
                .SetRows("Territory", "CampaignID")
                .SetValues("Spend", "Budget");

            document.Visualizations.Add(vsWebPage);
            document.Visualizations.Add(vsGrid);

            return document;
        }
    }
}
