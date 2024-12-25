using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Tests.TestExtensions;

namespace Reveal.Sdk.Dom.Tests.Visualizations
{
    public class StepAreaChartVisualizationFixture
    {
        [Fact]
        public void Constructor_InitializesDefaultValues_WhenInstanceIsCreated()
        {
            // Act
            var visualization = new StepAreaChartVisualization();

            // Assert
            Assert.NotNull(visualization);
            Assert.Equal(ChartType.StepArea, visualization.ChartType);
            Assert.Null(visualization.Title);
            Assert.Null(visualization.DataDefinition);
        }

        [Theory]
        [InlineData("TestTitle", null)]
        [InlineData(null, null)]
        public void Constructor_SetsTitleAndDataSource_WhenArgumentsAreProvided(string title, DataSourceItem dataSourceItem)
        {
            // Act
            var visualization = new StepAreaChartVisualization(title, dataSourceItem);

            // Assert
            Assert.Equal(title, visualization.Title);
            Assert.Equal(ChartType.StepArea, visualization.ChartType);
            Assert.Null(visualization.DataDefinition);
        }

        [Fact]
        public void Constructor_InitializesStepAreaChartVisualizationWithDataSource_WhenDataSourceItemIsProvided()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem { HasTabularData = true };

            // Act
            var gridVisualization = new StepAreaChartVisualization(dataSourceItem);

            // Assert
            Assert.NotNull(gridVisualization);
            Assert.Equal(ChartType.StepArea, gridVisualization.ChartType);
            Assert.Equal(dataSourceItem, gridVisualization.DataDefinition.DataSourceItem);
            Assert.Null(gridVisualization.Title);
        }

        [Fact]
        public void ToJsonString_GeneratesCorrectJson_WhenStepAreaChartVisualizationIsSerialized()
        {
            var expectedJson = """
            [
              {
                "Id": "48994fce-d0c9-4f64-b934-969da0330f93",
                "Title": "Step Area",
                "IsTitleVisible": true,
                "ColumnSpan": 0,
                "RowSpan": 0,
                "VisualizationSettings": {
                  "_type": "ChartVisualizationSettingsType",
                  "ShowTotalsInTooltip": false,
                  "TrendlineType": "ExponentialAverage",
                  "AutomaticLabelRotation": true,
                  "SyncAxisVisibleRange": false,
                  "ZoomScaleHorizontal": 1.0,
                  "ZoomScaleVertical": 1.0,
                  "LeftAxisLogarithmic": false,
                  "ShowLegends": true,
                  "ChartType": "StepArea",
                  "VisualizationType": "CHART"
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
                    "Id": "7e1a43d3-7696-422e-b2ef-581bdb878411",
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
                      "Id": "a9eba9ab-2fc1-43f7-8520-5e60744fc3f8",
                      "Title": "Marketing Sheet",
                      "Subtitle": "Excel Data Source Item",
                      "DataSourceId": "8814ec48-90df-4279-aee2-1ddef7c4dc7d",
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
                    new NumberField("Conversions"),
                    new TextField("Territory")
                }
            };
            excelDataSourceItem.UseExcel("Marketing");

            document.Visualizations.Add(new StepAreaChartVisualization("Step Area", excelDataSourceItem)
            .SetLabel(new DateDataField("Date") { AggregationType = DateAggregationType.Month })
            .SetValues("Spend", "Budget")
            .ConfigureSettings(settings =>
            {
                settings.Trendline = TrendlineType.ExponentialAverage;
                settings.ShowLegend = true;
                settings.AutomaticLabelRotation = true;
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
