using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Tests.TestExtensions;
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
        public void ToJsonString_GeneratesCorrectJson_WhenSplineAreaChartVisualizationIsSerialized()
        {
            var expectedJson = """
            [
              {
                "Description": "Create Spline Area Visualization",
                "Id": "ff37d2c3-62fd-4a8c-80f4-aeb0c087deea",
                "Title": "SplineArea",
                "IsTitleVisible": true,
                "ColumnSpan": 0,
                "RowSpan": 0,
                "VisualizationSettings": {
                  "_type": "ChartVisualizationSettingsType",
                  "ShowTotalsInTooltip": true,
                  "TrendlineType": "ExponentialFit",
                  "AutomaticLabelRotation": true,
                  "SyncAxisVisibleRange": false,
                  "ZoomScaleHorizontal": 1.0,
                  "ZoomScaleVertical": 1.0,
                  "LeftAxisLogarithmic": false,
                  "ShowLegends": true,
                  "ChartType": "SplineArea",
                  "VisualizationType": "Area"
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
                      "FieldName": "Budget",
                      "FieldLabel": "Budget",
                      "UserCaption": "Budget",
                      "IsCalculated": false,
                      "Properties": {},
                      "Sorting": "None",
                      "FieldType": "Number"
                    }
                  ],
                  "TransposedFields": [],
                  "QuickFilters": [],
                  "AdditionalTables": [],
                  "ServiceAdditionalTables": [],
                  "DataSourceItem": {
                    "_type": "DataSourceItemType",
                    "Id": "6ad41166-b8f5-4c4a-8440-48062ed2295b",
                    "Title": "Marketing Sheet",
                    "Subtitle": "Excel Data Source Item",
                    "DataSourceId": "__EXCEL",
                    "HasTabularData": true,
                    "HasAsset": false,
                    "Properties": {
                      "Sheet": "Marketing"
                    },
                    "Parameters": {},
                    "ResourceItem": {
                      "_type": "DataSourceItemType",
                      "Id": "82d63339-3119-4210-835b-6d77baae145c",
                      "Title": "Marketing Sheet",
                      "Subtitle": "Excel Data Source Item",
                      "DataSourceId": "5ef06a26-a355-43da-9410-34a034acb536",
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
                  "_type": "CategoryVisualizationDataSpecType",
                  "Values": [
                    {
                      "_type": "MeasureColumnSpecType",
                      "SummarizationField": {
                        "_type": "SummarizationValueFieldType",
                        "FieldLabel": "Spend",
                        "UserCaption": "Spend",
                        "IsHidden": false,
                        "AggregationType": "Sum",
                        "Sorting": "None",
                        "IsCalculated": false,
                        "FieldName": "Spend"
                      }
                    },
                    {
                      "_type": "MeasureColumnSpecType",
                      "SummarizationField": {
                        "_type": "SummarizationValueFieldType",
                        "FieldLabel": "Budget",
                        "UserCaption": "Budget",
                        "IsHidden": false,
                        "AggregationType": "Sum",
                        "Sorting": "None",
                        "IsCalculated": false,
                        "FieldName": "Budget"
                      }
                    }
                  ],
                  "FormatVersion": 0,
                  "AdHocExpandedElements": [],
                  "Rows": [
                    {
                      "_type": "DimensionColumnSpecType",
                      "SummarizationField": {
                        "_type": "SummarizationDateFieldType",
                        "DateAggregationType": "Month",
                        "DrillDownElements": [],
                        "ExpandedItems": [],
                        "FieldName": "Date"
                      }
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
