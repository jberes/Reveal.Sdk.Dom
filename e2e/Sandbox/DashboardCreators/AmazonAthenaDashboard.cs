using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

namespace Sandbox.DashboardFactories
{
    public class AmazonAthenaDashboard : IDashboardCreator
    {
        public string Name => "Amazon Athena Data Source";

        public RdashDocument CreateDashboard()
        {
            var document = new RdashDocument("My Dashboard");

            var athenaDS = new AmazonAthenaDataSource()
            {
                Id = "athenaDSId",
                Region = "us-east-1",
                Title = "Athena",
                Database = "mydatabase",
                OutputLocation = "s3://infragistics-test-bucket1/Temp",
            };

            var athenaDSItem = new AmazonAthenaDataSourceItem("Athena DSItem", athenaDS)
            {
                Id = "athenaDSItemId",
                Subtitle = "Amazon Athena DS Item",
                Table = "northwindinvoicesparquet",
                Fields = new List<IField>
                {
                    new TextField("country"),
                    new TextField("customerid"),
                    new TextField("customername")
                }
            };

            document.Visualizations.Add(new GridVisualization("Customer and Countries", athenaDSItem)
                .SetColumns("customerid", "customername", "country"));

            return document;
        }
    }
}
