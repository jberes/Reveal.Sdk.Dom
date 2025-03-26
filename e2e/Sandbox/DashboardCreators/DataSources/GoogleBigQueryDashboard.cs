using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.DashboardFactories
{
    internal class GoogleBigQueryDashboard : IDashboardCreator
    {
        public string Name => "Google Big Query Data Source";

        public RdashDocument CreateDashboard()
        {
            var document = new RdashDocument();

            var dataSource = new GoogleBigQueryDataSource()
            {
                Id = "BigQueryDSId",
                Title = "Google BigQuery DS",
                Subtitle = "Public Gg BigQuery",
                ProjectId = "bigquery-public-data"
            };
            var dataSourceItem = new GoogleBigQueryDataSourceItem("Google BigQuery DS Item", dataSource)
            {
                Id = "BigQueryDSItemId",
                Title = "Google",
                Subtitle = "Ameria Health rankings",
                DataSetId = "america_health_rankings",
                Table = "ahr",
                ProjectId = "bigquery-public-data",
                Fields = new List<IField> {
                    new NumberField("edition"),
                    new TextField("state_name")
                }
            };

            document.Visualizations.Add(new GridVisualization("List edition states", dataSourceItem).SetColumns("edition", "state_name"));

            return document;
        }
    }
}
