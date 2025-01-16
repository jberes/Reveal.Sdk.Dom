using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Filters;
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
                ColumnSpan = 3,
                RowSpan = 3,
                Description = "Scatter Map VS Dashboard Created In Code",
                IsTitleVisible = false,
                Label = new DimensionColumn(),
                Latitude = new DimensionColumn(),
                Longitude = new DimensionColumn(),
                Linker = new VisualizationLinker(),
                Map = "Central America",
                MapColor = new List<MeasureColumn>(),
                Title = "Scatter Map VS Title",
            };

            scatterMapVS.ConfigureSettings((settings) =>
            {
                // Used to set Start Color setting
                settings.ColorIndex = 1;
                settings.ColorMode = MapColorMode.RangeOfValues;
                settings.UseDifferentMarkers = true;
                settings.ImageTileZoomLevel = 2;
                settings.ShowImageTiles = true;
                settings.ShowLegend = false;

                settings.Zoom.Longitude = -19;
                settings.Zoom.Latitude = 8.89;
                settings.Zoom.DegreesLongitude = 30.67;
                settings.Zoom.DegreesLatitude = 27.88;
            });

            // Data Specs
            scatterMapVS
                .SetLabel("id")
                .SetLongitude("longitude")
                .SetLatitude("latitude")
                .SetRadius("longitude")
                .SetColorByCategory("gender");
            //.SetColorByValue("gender");

            // Filters
            var genderFilter = new DashboardDataFilter(excelDSItem)
            {
                Title = "Gender Filter",
                FieldName = "gender",
                AllowMultipleSelection = true,
                AllowEmptySelection = true
            };
            var dateFilter = new DashboardDateFilter()
            {
                CustomDateRange = new DateRange()
                {
                    From = DateTime.Today.AddDays(-15),
                    To = DateTime.Today.AddDays(-2)
                },
                RuleType = DateRuleType.CustomRange,
                Title = "Custom Date Range Filter"
            };

            document.Filters.Add(genderFilter);
            document.Filters.Add(dateFilter);
            scatterMapVS.ConnectDashboardFilter(genderFilter).ConnectDashboardFilter(dateFilter);

            // Add quick filter
            scatterMapVS.AddFilters("first_name");

            document.Visualizations.Add(scatterMapVS);

            return document;
        }
    }
}
