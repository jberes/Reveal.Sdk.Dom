using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Sandbox.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.DashboardFactories
{
    internal class ScatterMapVisualizationDashboard : IDashboardCreator
    {
        public string Name => "Scatter Map Visualization Dashboard";

        public RdashDocument CreateDashboard()
        {
            var document = new RdashDocument("My Grid Visualization Dashboard");

            var excelDSItem = DataSourceFactory.GetScatterMapDataSourceItem();

            var scatterMapVS = new ScatterMapVisualization("Scatter Map Visualization", excelDSItem)
            {
                Id = "ScatterMapVSDashBoard",
                BubbleRadius = new List<MeasureColumn>(),
                ColumnSpan = 3,
                RowSpan = 3,
                Description = "Scatter Map VS Dashboard Created In Code",
                IsTitleVisible = true,
                Label = new DimensionColumn(),
                Latitude = new DimensionColumn(),
                Longitude = new DimensionColumn(),
                Linker = new VisualizationLinker(),
                Map = "Central America",
                MapColor = new List<MeasureColumn>(),
                //MapColorCategory = new DimensionColumn(),
                Title = "Scatter Map VS Title",
            };

            scatterMapVS.ConfigureSettings((settings) =>
            {
                new ScatterMapVisualizationSettings()
                {
                    ColorIndex = 0,
                    ColorMode = MapColorMode.RangeOfValues,
                    UseDifferentMarkers = true,
                    ImageTileZoomLevel = 2,
                    ShowImageTiles = true,
                    ShowLegend = true,
                };
            });

            // Data Specs
            scatterMapVS
                //.SetLabel("id")
                .SetLongitude("longitude")
                .SetLatitude("latitude");
                //.SetColorByCategory("gender")
                //.SetColorByValue("gender");

            //// Filters
            //var spendFilter = new DashboardDataFilter(excelDSItem)
            //{
            //    Title = "Spend Filter",
            //    FieldName = "Spend",
            //    AllowMultipleSelection = true,
            //    AllowEmptySelection = true
            //};
            //var dateFilter = new DashboardDateFilter()
            //{
            //    CustomDateRange = new Reveal.Sdk.Dom.DateRange()
            //    {
            //        From = DateTime.Today.AddDays(-15),
            //        To = DateTime.Today.AddDays(-2)
            //    }
            //};

            //document.Filters.Add(spendFilter);
            //document.Filters.Add(dateFilter);
            //gridVS.ConnectDashboardFilter(spendFilter).ConnectDashboardFilter(dateFilter);

            //// Add quick filter
            //gridVS.AddFilters("Territory");

            document.Visualizations.Add(scatterMapVS);

            return document;
        }
    }
}
