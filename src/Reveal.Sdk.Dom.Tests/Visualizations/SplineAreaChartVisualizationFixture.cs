using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations
{
    public class SplineAreaChartVisualizationFixture
    {
        [Fact]
        public void Constructor_InitializesDefaultValues_WhenInstanceIsCreated()
        {
            // Act
            var visualization = new SplineAreaChartVisualization();

            // Assert
            Assert.NotNull(visualization);
            Assert.Equal(ChartType.SplineArea, visualization.ChartType);
            Assert.Null(visualization.Title);
            Assert.Null(visualization.DataDefinition);
        }

        [Theory]
        [InlineData("TestTitle", null)]
        [InlineData(null, null)]
        public void Constructor_SetsTitleAndDataSource_WhenArgumentsAreProvided(string title, DataSourceItem dataSourceItem)
        {
            // Act
            var visualization = new SplineAreaChartVisualization(title, dataSourceItem);

            // Assert
            Assert.Equal(title, visualization.Title);
            Assert.Equal(ChartType.SplineArea, visualization.ChartType);
            Assert.Null(visualization.DataDefinition);
        }

        [Fact]
        public void Constructor_InitializesSplineAreaChartVisualizationWithDataSource_WhenDataSourceItemIsProvided()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem { HasTabularData = true };

            // Act
            var gridVisualization = new SplineAreaChartVisualization(dataSourceItem);

            // Assert
            Assert.NotNull(gridVisualization);
            Assert.Equal(ChartType.Grid, gridVisualization.ChartType);
            Assert.Equal(dataSourceItem, gridVisualization.DataDefinition.DataSourceItem);
            Assert.Null(gridVisualization.Title);
        }

        [Fact]
        public void ToJsonString_GeneratesCorrectJson_WhenGridVisualizationIsSerialized()
        {
            var expectedJson = """
            [
              {
                "Description": "Create Grid Visualization",
                "Title": "Grid",
                "IsTitleVisible": true,
                "ColumnSpan": 0,
                "RowSpan": 0,
                "VisualizationSettings": {
                  "_type": "GridVisualizationSettingsType",
                  "PagedRows": true,
                  "PagedRowsSize": 50,
                  "FontSize": "Large",
                  "Style": {
                    "FixedLeftColumns": true,
                    "TextAlignment": "Center",
                    "NumericAlignment": "Inherit",
                    "DateAlignment": "Center"
                  },
                  "VisualizationType": "GRID"
                },
                "DataSpec": {
                  "_type": "TabularDataSpecType",
                  "IsTransposed": false,
                  "Fields": [
                    {
                      "FieldName": "Date",
                      "FieldLabel": "Date",
                      "UserCaption": "Date",
                      "IsCalculated": false,
                      "Properties": {},
                      "Sorting": "None",
                      "FieldType": "Date"
                    },
                    {
                      "FieldName": "Spend",
                      "FieldLabel": "Spend",
                      "UserCaption": "Spend",
                      "IsCalculated": false,
                      "Properties": {},
                      "Sorting": "None",
                      "FieldType": "Number"
                    },
                    {
                      "FieldName": "Conversions",
                      "FieldLabel": "Conversions",
                      "UserCaption": "Conversions",
                      "IsCalculated": false,
                      "Properties": {},
                      "Sorting": "None",
                      "FieldType": "Number"
                    },
                    {
                      "FieldName": "Territory",
                      "FieldLabel": "Territory",
                      "UserCaption": "Territory",
                      "IsCalculated": false,
                      "Properties": {},
                      "Sorting": "None",
                      "FieldType": "String"
                    }
                  ],
                  "TransposedFields": [],
                  "QuickFilters": [],
                  "AdditionalTables": [],
                  "ServiceAdditionalTables": [],
                  "DataSourceItem": {
                    "_type": "DataSourceItemType",
                    "Title": "Marketing Sheet",
                    "Subtitle": "Excel Data Source Item",
                    "HasTabularData": true,
                    "HasAsset": false,
                    "Properties": {
                      "Sheet": "Marketing"
                    },
                    "Parameters": {},
                    "ResourceItem": {
                      "_type": "DataSourceItemType",
                      "Title": "Marketing Sheet",
                      "Subtitle": "Excel Data Source Item",
                      "HasTabularData": true,
                      "HasAsset": false,
                      "Properties": {
                        "Url": "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx"
                      },
                      "Parameters": {}
                    }
                  },
                  "Expiration": 1440,
                  "Bindings": {
                    "Bindings": []
                  }
                },
                "VisualizationDataSpec": {
                  "_type": "GridVisualizationDataSpecType",
                  "Columns": [
                    {
                      "_type": "TabularColumnSpecType",
                      "FieldName": "Territory",
                      "Sorting": "None"
                    },
                    {
                      "_type": "TabularColumnSpecType",
                      "FieldName": "Conversions",
                      "Sorting": "None"
                    },
                    {
                      "_type": "TabularColumnSpecType",
                      "FieldName": "Spend",
                      "Sorting": "None"
                    }
                  ]
                }
              }
            ]
            """;

            var document = new RdashDocument("My Dashboard");

            var excelDataSourceItem = new RestDataSourceItem("Marketing Sheet")
            {
                Subtitle = "Excel Data Source Item",
                Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx",
                IsAnonymous = true,
                Fields = new List<IField>
                {
                    new DateField("Date"),
                    new NumberField("Spend"),
                    new NumberField("Budget"),
                }
            };
            excelDataSourceItem.UseExcel("Marketing");

            document.Visualizations.Add(new SplineAreaChartVisualization("SplineArea", excelDataSourceItem)
            {
                IsTitleVisible = true,
                Description = "Create Spline Area Visualization"
            }
            .SetLabel(new DateDataField("Date") { AggregationType = DateAggregationType.Month })
            .SetValues("Spend", "Budget")
            .ConfigureSettings(settings =>
            {
                settings.Trendline = TrendlineType.ExponentialFit;
                settings.AutomaticLabelRotation = true;
                settings.ShowTotalsInTooltip = true;
                settings.ShowLegend = true;
                settings.VisualizationType = "Area";
            }));

            document.Filters.Add(new DashboardDataFilter("Spend", excelDataSourceItem));
            document.Filters.Add(new DashboardDateFilter("My Date Filter"));

            var json = document.ToJsonString();
            var actualJson = JObject.Parse(json)["Widgets"];
            var expected = JArray.Parse(expectedJson);

            var removeProps = new[] { "Id", "DataSourceId" };
            var expectedStr = JsonConvert.SerializeObject(expected.RemoveProperties(removeProps));
            var actualStr = JsonConvert.SerializeObject(actualJson.RemoveProperties(removeProps));

            Assert.Equal(expectedStr, actualStr);
        }
    }
}
