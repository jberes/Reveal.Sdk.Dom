using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.Helpers;
using System;

namespace Sandbox.Factories
{
    internal class PostgresqlDashboard
    {
        internal static RdashDocument CreateDashboard()
        {
            var postgresDataSourceItem = PostgresDataSourceFactory.GetEmployeeDSItem();

            var document = new RdashDocument()
            {
                Title = "PostgreSQL",
                Description = "Example for Postgresql",
                UseAutoLayout = false,
            };

            var dateFilter = new DashboardDateFilter("My Date Filter");
            document.Filters.Add(dateFilter);

            var countryFilter = new DashboardDataFilter("Country", postgresDataSourceItem);
            document.Filters.Add(countryFilter);

            document.Visualizations.Add(CreateEmployeeReportColumnVisualization(postgresDataSourceItem, countryFilter));

            return document;
        }

        private static Visualization CreateEmployeeReportColumnVisualization(DataSourceItem postgresDSItem, params DashboardFilter[] filters)
        {
            return new ColumnChartVisualization("Employees report", postgresDSItem)
                .SetLabel("ReportsTo")
                .SetValue("EmployeeID")
                .ConnectDashboardFilters(filters)
                .SetPosition(20, 11);
        }
    }
}
