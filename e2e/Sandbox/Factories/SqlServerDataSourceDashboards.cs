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

            var sqlServerDataSourceItem = new DataSourceItemFactory().Create(DataSourceType.MicrosoftSqlServer, "Customers")
                .Subtitle("SQL Server Data Source Item")
                .Fields(new List<IField>
                {
                    new TextField("ContactName"),
                    new TextField("ContactTitle"),
                    new TextField("City")
                })
                .As<ISqlDataSourceItemBuilder>()
                .Host(@"Brian-Desktop\SQLEXPRESS")
                .Database("Northwind")
                .Table("Customers")
                .Build();

            document.Visualizations.Add(new GridVisualization("Customer List", sqlServerDataSourceItem).SetColumns("ContactName", "ContactTitle", "City"));

            return document;
        }
    }
}
