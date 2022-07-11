using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

namespace Sandbox.Factories
{
    internal class SqlServerDataSourceDashboards
    {
        internal static RdashDocument CreateDashboard()
        {
            var document = new RdashDocument("My Dashboard");

            var sqlServerDataSourceItem = new SqlServerBuilder("***REMOVED***", "devtest", "Orders Qry")
                .SetTitle("SQL Server")
                .SetSubtitle("Orders")
                .SetFields(new List<Field>()
                {
                    new TextField("CustomerID"),
                    new NumberField("OrderID"),
                })
                .Build();

            document.Visualizations.Add(new BarChartVisualization("SQL Server Bar Chart", sqlServerDataSourceItem)
                .AddLabel("CustomerID").AddValue(new SummarizationValueField("OrderID") { AggregationType = AggregationType.CountRows }));

            return document;
        }
    }
}
