using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
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
    internal class TextVisualizationDashboard : IDashboardCreator
    {
        public string Name => "Text Visualization Dashboard";

        public RdashDocument CreateDashboard()
        {
            var document = new RdashDocument("My Text Visualization Dashboard");

            var excelDSItem = DataSourceFactory.GetMarketingDataSourceItem();

            var campaignIdFilter = new DashboardDataFilter(excelDSItem)
            {
                Title = "CampaignID",
                FieldName = "CampaignID",
                AllowMultipleSelection = true,
                AllowEmptySelection = true
            };
            document.Filters.Add(campaignIdFilter);

            var vis = CreateVisualization("Campaign Spend", "CampaignID", "Spend", excelDSItem);

            vis.ConnectDashboardFilter(campaignIdFilter);

            document.Visualizations.Add(vis);

            return document;
        }

        private TextVisualization CreateVisualization(string title, string label, string value, DataSourceItem dsItem)
        {
            var vis = new TextVisualization(title, dsItem)
            {
                ColumnSpan = 3,
                RowSpan = 4,
            }
            .SetLabel(label).SetValue(value);

            return vis;
        }
    }
}
