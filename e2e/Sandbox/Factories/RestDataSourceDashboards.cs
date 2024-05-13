using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.Helpers;

namespace Sandbox.Factories
{
    internal class RestDataSourceDashboards
    {
        static IDataSourceItemFactory _factory = new DataSourceItemFactory();

        internal static RdashDocument CreateDashboard()
        {
            var document = new RdashDocument("My Dashboard");

            //json - default
            var jsonDataSourceItem = _factory.Create(DataSourceType.REST, "Sales by Category")
                .Subtitle("JSON Data Source Item")
                .Fields(DataSourceFactory.GetSalesByCategoryFields())
                .As<IRestBuilder>()
                .Uri("https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9")
                .IsAnonymous(true)
                .ConfigureDataSource(d =>
                {
                    d.Title = "JSON DS";
                    d.Subtitle = "JSON DS Subtitle";
                })
                .Build();

            document.Visualizations.Add(new PieChartVisualization("JSON", jsonDataSourceItem)
                .SetLabel("CategoryName").SetValue("ProductSales"));

            //excel
            var excelDataSourceItem = _factory.Create(DataSourceType.REST, "Marketing")
                .Subtitle("Excel Data Source Item")
                .Fields(DataSourceFactory.GetMarketingDataSourceFields())
                .As<IRestBuilder>()
                .Uri("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
                .IsAnonymous(true)
                .UseExcel("Marketing")
                .ConfigureDataSource(d =>
                {
                    d.Title = "Excel DS";
                    d.Subtitle = "Excel DS Subtitle";
                })
                .Build();

            document.Visualizations.Add(new PieChartVisualization("Excel", excelDataSourceItem)
                .SetLabel("Territory").SetValue("Conversions"));

            //csv
            var csvDataSourceItem = _factory.Create(DataSourceType.REST, "Illinois School Info")
                .Subtitle("CSV Data Source Item")
                .Fields(DataSourceFactory.GetCsvDataSourceFields())
                .As<IRestBuilder>()
                .Uri("https://query.data.world/s/y32gtgblzpemyyvtig47dz7tedgkto")
                .IsAnonymous(true)
                .UseCsv()
                .ConfigureDataSource(d =>
                {
                    d.Title = "CSV DS";
                    d.Subtitle = "CSV DS Subtitle";
                })
                .Build();

            document.Visualizations.Add(new ScatterMapVisualization("Scatter", csvDataSourceItem)
                .SetMap(Maps.NorthAmerica.UnitedStates.States.Illinois)
                .SetLongitude("X")
                .SetLatitude("Y")
                .SetLabel("School_Nm")
                .ConfigureSettings(settings =>
                {
                    settings.Zoom.Longitude = 1.38;
                    settings.Zoom.Latitude = 41.65;
                    settings.Zoom.DegreesLongitude = 1.04;
                    settings.Zoom.DegreesLatitude = 0.39;
                }));

            return document;
        }
    }
}
