using Reveal.Sdk.Data.Excel;
using Reveal.Sdk.Dom;
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
    internal class KpiTargetVisualizationDashboard : IDashboardCreator
    {
        public string Name => "Kpi Target Visualization Dashboard";

        public RdashDocument CreateDashboard()
        {
            var document = new RdashDocument("My Grid Visualization Dashboard");

            var excelDSItem = DataSourceFactory.GetMarketingDataSourceItem();

            var visualization = new KpiTargetVisualization(excelDSItem)
            {
                Title = "Spend vs Budget",
                ColumnSpan = 15,
                RowSpan = 13,
            };

            //var campaignIdFilter = new DashboardDataFilter(excelDSItem)
            //{
            //    Title = "CampaignID",
            //    FieldName = "CampaignID",
            //    AllowMultipleSelection = true,
            //    AllowEmptySelection = true
            //};
            //document.Filters.Add(campaignIdFilter);

            //visualization.ConnectDashboardFilter(campaignIdFilter);

            visualization.Date = new DimensionColumn()
            {
                DataField = new DateDataField("Date")
                {
                    AggregationType = DateAggregationType.Year,
                }
            };

            visualization.Values.Add(new MeasureColumn()
            {
                DataField = new NumberDataField("Spend")
            });

            visualization.Targets.Add(new MeasureColumn()
            {
                DataField = new NumberDataField("Budget")
            });

            document.Visualizations.Add(visualization);

            return document;

        }
    }
}
