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
            var sqlServerDS = new MicrosoftSqlServerDataSource()
            {
                Title = "Northwind",
                Subtitle = "Northwind Subtitle",
                Host = @"Brian-Desktop\SQLEXPRESS",
                Database = "Northwind",
            };

            var document = new RdashDocument("My Dashboard");

            var customersDsi = new MicrosoftSqlServerDataSourceItem("Customers Table", "Customers", sqlServerDS)
            {
                Subtitle = "SQL Server Data Source Item",
                Fields = new List<IField>
                {
                    new TextField("ContactName"),
                    new TextField("ContactTitle"),
                    new TextField("City")
                }
            };
            document.Visualizations.Add(new GridVisualization("Customer List", customersDsi).SetColumns("ContactName", "ContactTitle", "City"));

            var employeesDsi = new MicrosoftSqlServerDataSourceItem("Employees Table", sqlServerDS)
            {
                Subtitle = "SQL Server Data Source Item",
                Table = "Employees",
                Fields = new List<IField>
                {
                    new TextField("FirstName"),
                    new TextField("LastName"),
                }
            };
            document.Visualizations.Add(new GridVisualization("Employee List", employeesDsi).SetColumns("FirstName", "LastName"));

            return document;
        }
    }
}
