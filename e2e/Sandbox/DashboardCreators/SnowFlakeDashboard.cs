using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

namespace Sandbox.DashboardFactories
{
    internal class SnowflakeDashboard : IDashboardCreator
    {
        public string Name => "Snowflake Data Source";

        public RdashDocument CreateDashboard()
        {
            var snowflakeDS = new SnowflakeDataSource()
            {
                Id = "SnowflakeDSId",
                Title = "Snowflake Data source",
                Subtitle = "Snowflake Subtitle",
                Account = "pqwkobs-xb90908",
                DefaultRefreshRate = "120",
                Host = "gpiskyj-al16914.snowflakecomputing.com",
                Database = "SNOWFLAKE_SAMPLE_DATA",
                Warehouse = "COMPUTE_WH",
                Schema = "TPCDS_SF100TCL"
            };

            var snowflakeDSI = new SnowflakeDataSourceItem("Snowflake DSI Title", snowflakeDS)
            {
                Id = "SnowflakeDSItemId",
                Title = "Snowflake data source Item",
                Subtitle = "Snowflake data source Item Subtitle",
                Schema = "TPCH_SF10",
                Table = "ORDERS",
                Database = "SNOWFLAKE_SAMPLE_DATA",
                Fields = new List<IField>
                {
                    new NumberField("O_ORDERKEY"),
                    new NumberField("O_CUSTKEY"),
                    new TextField("O_ORDERPRIORITY"),
                }
            };

            var document = new RdashDocument("Snowflake Dashboard");

            document.Visualizations.Add(new PieChartVisualization("Snowflake Order Priorities", snowflakeDSI)
                .SetLabel("O_ORDERPRIORITY").SetValues("O_CUSTKEY"));
            return document;
        }
    }
}
