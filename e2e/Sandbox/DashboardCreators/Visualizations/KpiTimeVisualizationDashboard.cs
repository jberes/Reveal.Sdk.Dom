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
    internal class KpiTimeVisualizationDashboard : IDashboardCreator
    {
        public string Name => "Kpi Time Visualization Dashboard";

        public RdashDocument CreateDashboard()
        {
            var document = new RdashDocument("My Grid Visualization Dashboard");

            var excelDSItem = DataSourceFactory.GetMarketingDataSourceItem();

            var trafficVis = new KpiTimeVisualization(excelDSItem)
            {
                Title = "Avg Traffic",
                ColumnSpan = 15,
                RowSpan = 13,
                Date = new DimensionColumn()
                {
                    DataField = new DateDataField("Date")
                    {
                        AggregationType = DateAggregationType.Year,
                    }
                },
            };

            trafficVis.Values.Add(new MeasureColumn()
            {
                DataField = new NumberDataField("Traffic")
                {
                    AggregationType = AggregationType.Avg,
                }
            });

            var budgetVis = new KpiTimeVisualization(excelDSItem)
            {
                Title = "Avg Budget",
                ColumnSpan = 15,
                RowSpan = 13,
                Date = new DimensionColumn()
                {
                    DataField = new DateDataField("Date")
                    {
                        AggregationType = DateAggregationType.Year,
                    }
                },
            };

            budgetVis.Values.Add(new MeasureColumn()
            {
                DataField = new NumberDataField("Budget")
                {
                    AggregationType = AggregationType.Avg,
                }
            });

            document.Visualizations.Add(trafficVis);
            document.Visualizations.Add(budgetVis);

            return document;
        }
    }
}
