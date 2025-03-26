using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

namespace Sandbox.DashboardFactories
{
    internal class SqlServerDataSourceDashboards
        : IDashboardCreator
    {
        public string Name => "Sql Server Data Source";

        public RdashDocument CreateDashboard()
        {
            var sqlServerDS = new MicrosoftSqlServerDataSource()
            {
                Title = "Northwind",
                Subtitle = "Northwind Subtitle",
                Host = @"Brian-Desktop\SQLEXPRESS",
                Database = "Northwind",
            };

            var customers = new MicrosoftSqlServerDataSourceItem("Customers Table", "Customers", sqlServerDS)
            {
                Subtitle = "SQL Server Data Source Item",
                Fields = new List<IField>
                {
                    new TextField("CustomerID"),
                    new TextField("ContactName") { FieldLabel = "Customer Name" },
                    new TextField("ContactTitle") { FieldLabel = "Customer Title" },
                    new TextField("City") { FieldLabel = "Customer City" }
                }
            };

            var employees = new MicrosoftSqlServerDataSourceItem("Employees Table", sqlServerDS)
            {
                Subtitle = "SQL Server Data Source Item",
                Table = "Employees",
                Fields = new List<IField>
                {
                    new NumberField("EmployeeID"),
                    new TextField("FirstName") { FieldLabel = "Employee First Name" },
                    new TextField("LastName") { FieldLabel = "Employee Last Name" },
                }
            };

            var orders = new MicrosoftSqlServerDataSourceItem("Orders Table", "Orders", sqlServerDS)
            {
                Fields = new List<IField>
                {
                    new TextField("CustomerID"),
                    new NumberField("EmployeeID") { FieldLabel = "Order Employee ID" },
                    new DateField("OrderDate") { FieldLabel = "Oder Date" },
                    new TextField("ShipName") { FieldLabel = "Order Ship Name" },
                },
            };

            customers.Join("A", "CustomerID", "CustomerID", orders);
            customers.Join("B", "A.EmployeeID", "EmployeeID", employees);

            var document = new RdashDocument("My Dashboard");

            document.Visualizations.Add(new GridVisualization("Customer List", customers).SetColumns("ContactName", "ContactTitle", "City"));
            document.Visualizations.Add(new GridVisualization("Employee List", employees).SetColumns("FirstName", "LastName"));
            document.Visualizations.Add(new GridVisualization("Joined Tables", customers).SetColumns("ContactName", "ContactTitle", "City",
                "A.EmployeeID", "A.OrderDate", "A.ShipName", "B.FirstName", "B.LastName"));

            return document;
        }
    }
}
