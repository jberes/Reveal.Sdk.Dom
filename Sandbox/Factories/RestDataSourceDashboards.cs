using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.Helpers;

namespace Sandbox.Factories
{
    internal class RestDataSourceDashboards
    {
        internal static RdashDocument CreateDashboard()
        {
            var document = new RdashDocument("My Dashboard");

            //json - default
            var jsonDataSourceItem = new RestBuilder("https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9")
                .SetTitle("JSON Data Source")
                .SetSubtitle("Sales by Category")
                .SetFields(DataSourceFactory.GetSalesByCategoryFields())
                .Build();

            document.Visualizations.Add(new PieChartVisualization("JSON", jsonDataSourceItem)
                .AddLabel("CategoryName").AddValue("ProductSales"));

            //excel
            var excelDataSourceItem = new RestBuilder("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
                .UseExcel()
                .SetTitle("Excel Data Source")
                .SetSubtitle("Marketing")
                .SetFields(DataSourceFactory.GetMarketingDataSourceFields())
                .Build();

            document.Visualizations.Add(new PieChartVisualization("Excel", excelDataSourceItem)
                .AddLabel("Territory").AddValue("Conversions"));

            //csv
            var csvDataSourceItem = new RestBuilder("https://query.data.world/s/y32gtgblzpemyyvtig47dz7tedgkto")
                .UseCsv()
                .SetTitle("CSV Data Source")
                .SetSubtitle("Illinois School Info")
                .SetFields(DataSourceFactory.GetCsvDataSourceFields())
                .Build();

            document.Visualizations.Add(new ScatterMapVisualization("Scatter", csvDataSourceItem)
                .SetMap("Illinois")
                .SetLongitude("X")
                .SetLatitude("Y")
                .AddLabel("School_Nm")
                .ConfigureSettings(settings =>
                {
                    settings.ZoomRectangle.X = 1.38;
                    settings.ZoomRectangle.Y = 41.65;
                    settings.ZoomRectangle.Width = 1.04;
                    settings.ZoomRectangle.Height = 0.39;
                }));

            return document;
        }
    }
}
