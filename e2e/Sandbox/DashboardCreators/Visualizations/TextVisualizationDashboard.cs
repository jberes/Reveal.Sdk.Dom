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

            var vis = new TextVisualization("Campaign Spend", excelDSItem)
            {
                ColumnSpan = 3,
                RowSpan = 4,
            }
            .SetLabel("CampaignID").SetValue("Spend");

            vis.ConnectDashboardFilter(campaignIdFilter);

            vis.ConfigureSettings((settings) =>
            {
                settings.ConditionalFormattingEnabled = true;
                settings.UpperBand.Shape = ShapeType.ArrowUp;
                settings.MiddleBand.Shape = ShapeType.Dash;
                settings.LowerBand.Shape = ShapeType.ArrowDown;
            });

            document.Visualizations.Add(vis);

            return document;
        }
    }
}
