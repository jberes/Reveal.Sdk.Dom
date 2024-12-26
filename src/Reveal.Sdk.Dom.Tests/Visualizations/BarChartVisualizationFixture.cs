using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Serialization;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations
{
    public class BarChartVisualizationFixture
    {
        [Fact]
        public void Constructor_InitializesDefaultValues_WhenInstanceIsCreated()
        {
            // Act
            var barChartVisualization = new BarChartVisualization();

            // Assert
            Assert.NotNull(barChartVisualization);
            Assert.Equal(ChartType.Bar, barChartVisualization.ChartType);
            Assert.Null(barChartVisualization.Title);
            Assert.Null(barChartVisualization.DataDefinition);
        }

        [Fact]
        public void Constructor_InitializesBarChartVisualizationWithDataSource_WhenDataSourceItemIsProvided()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem { HasTabularData = true };

            // Act
            var barChartVisualization = new BarChartVisualization(dataSourceItem);

            // Assert
            Assert.NotNull(barChartVisualization);
            Assert.Equal(ChartType.Bar, barChartVisualization.ChartType);
            Assert.Equal(dataSourceItem, barChartVisualization.DataDefinition.DataSourceItem);
            Assert.Null(barChartVisualization.Title);
        }

        [Theory]
        [InlineData("TestTitle", null)]
        [InlineData(null, null)]
        [InlineData("TestTitle", "DataSource")]
        public void Constructor_SetsTitleAndDataSource_WhenArgumentsAreProvided(string title, string dataSourceName)
        {
            // Arrange
            var dataSourceItem = string.IsNullOrEmpty(dataSourceName) ? null : new DataSourceItem { Title = dataSourceName };

            // Act
            var barChartVisualization = new BarChartVisualization(title, dataSourceItem);

            // Assert
            Assert.Equal(title, barChartVisualization.Title);
            Assert.Equal(ChartType.Bar, barChartVisualization.ChartType);
            Assert.Equal(dataSourceItem, barChartVisualization.DataDefinition?.DataSourceItem);
        }

        [Fact]
        public void ToJsonString_GeneratesCorrectJson_WhenBarChartVisualizationIsSerialized()
        {
            // Arrange
            var expectedJson =
                """
                [ {
                  "Description" : "Create Bar Visualization",
                  "Id" : "c24cc878-6032-48ce-a94f-de00467e47dc",
                  "Title" : "Bar",
                  "IsTitleVisible" : true,
                  "ColumnSpan" : 0,
                  "RowSpan" : 0,
                  "VisualizationSettings" : {
                    "_type" : "ChartVisualizationSettingsType",
                    "ShowTotalsInTooltip" : false,
                    "TrendlineType" : "LinearFit",
                    "AutomaticLabelRotation" : true,
                    "SyncAxisVisibleRange" : false,
                    "ZoomScaleHorizontal" : 1.0,
                    "ZoomScaleVertical" : 1.0,
                    "LeftAxisLogarithmic" : false,
                    "ShowLegends" : true,
                    "ChartType" : "Bar",
                    "VisualizationType" : "CHART"
                  },
                  "DataSpec" : {
                    "_type" : "TabularDataSpecType",
                    "IsTransposed" : false,
                    "Fields" : [ {
                      "FieldName" : "Date",
                      "FieldLabel" : "Date",
                      "UserCaption" : "Date",
                      "IsCalculated" : false,
                      "Properties" : { },
                      "Sorting" : "None",
                      "FieldType" : "Date"
                    }, {
                      "FieldName" : "Paid Traffic",
                      "FieldLabel" : "Paid Traffic",
                      "UserCaption" : "Paid Traffic",
                      "IsCalculated" : false,
                      "Properties" : { },
                      "Sorting" : "None",
                      "FieldType" : "Number"
                    }, {
                      "FieldName" : "Organic Traffic",
                      "FieldLabel" : "Organic Traffic",
                      "UserCaption" : "Organic Traffic",
                      "IsCalculated" : false,
                      "Properties" : { },
                      "Sorting" : "None",
                      "FieldType" : "Number"
                    }, {
                      "FieldName" : "Other Traffic",
                      "FieldLabel" : "Other Traffic",
                      "UserCaption" : "Other Traffic",
                      "IsCalculated" : false,
                      "Properties" : { },
                      "Sorting" : "None",
                      "FieldType" : "Number"
                    } ],
                    "TransposedFields" : [ ],
                    "QuickFilters" : [ ],
                    "AdditionalTables" : [ ],
                    "ServiceAdditionalTables" : [ ],
                    "DataSourceItem" : {
                      "_type" : "DataSourceItemType",
                      "Id" : "c3ba024b-0f56-4b12-9918-389534b34fec",
                      "Title" : "Marketing Sheet",
                      "Subtitle" : "Excel Data Source Item",
                      "DataSourceId" : "__EXCEL",
                      "HasTabularData" : true,
                      "HasAsset" : false,
                      "Properties" : {
                        "Sheet" : "Marketing"
                      },
                      "Parameters" : { },
                      "ResourceItem" : {
                        "_type" : "DataSourceItemType",
                        "Id" : "b4d0cc44-97ea-4ee9-8b46-76cb352f9919",
                        "Title" : "Marketing Sheet",
                        "Subtitle" : "Excel Data Source Item",
                        "DataSourceId" : "60478f89-b37d-40c5-845b-e330dff7e1b1",
                        "HasTabularData" : true,
                        "HasAsset" : false,
                        "Properties" : {
                          "Url" : "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx"
                        },
                        "Parameters" : { }
                      }
                    },
                    "Expiration" : 1440,
                    "Bindings" : {
                      "Bindings" : [ ]
                    }
                  },
                  "VisualizationDataSpec" : {
                    "_type" : "CategoryVisualizationDataSpecType",
                    "Values" : [ {
                      "_type" : "MeasureColumnSpecType",
                      "SummarizationField" : {
                        "_type" : "SummarizationValueFieldType",
                        "FieldLabel" : "Paid Traffic",
                        "UserCaption" : "Paid Traffic",
                        "IsHidden" : false,
                        "AggregationType" : "Sum",
                        "Sorting" : "None",
                        "IsCalculated" : false,
                        "FieldName" : "Paid Traffic"
                      }
                    }, {
                      "_type" : "MeasureColumnSpecType",
                      "SummarizationField" : {
                        "_type" : "SummarizationValueFieldType",
                        "FieldLabel" : "Organic Traffic",
                        "UserCaption" : "Organic Traffic",
                        "IsHidden" : false,
                        "AggregationType" : "Sum",
                        "Sorting" : "None",
                        "IsCalculated" : false,
                        "FieldName" : "Organic Traffic"
                      }
                    }, {
                      "_type" : "MeasureColumnSpecType",
                      "SummarizationField" : {
                        "_type" : "SummarizationValueFieldType",
                        "FieldLabel" : "Other Traffic",
                        "UserCaption" : "Other Traffic",
                        "IsHidden" : false,
                        "AggregationType" : "Sum",
                        "Sorting" : "None",
                        "IsCalculated" : false,
                        "FieldName" : "Other Traffic"
                      }
                    } ],
                    "FormatVersion" : 0,
                    "AdHocExpandedElements" : [ ],
                    "Rows" : [ {
                      "_type" : "DimensionColumnSpecType",
                      "SummarizationField" : {
                        "_type" : "SummarizationDateFieldType",
                        "DateAggregationType" : "Month",
                        "DrillDownElements" : [ ],
                        "ExpandedItems" : [ ],
                        "FieldName" : "Date"
                      }
                    } ]
                  }
                } ]
                """;
            var document = new RdashDocument("My Dashboard");

            var excelDataSourceItem = new RestDataSourceItem("Marketing Sheet")
            {
                Id = "c3ba024b-0f56-4b12-9918-389534b34fec",
                Subtitle = "Excel Data Source Item",
                Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx",
                IsAnonymous = true,
                ResourceItem = new DataSourceItem()
                {
                    Id = "b4d0cc44-97ea-4ee9-8b46-76cb352f9919",
                    DataSourceId = "60478f89-b37d-40c5-845b-e330dff7e1b1",
                    Title = "Marketing Sheet",
                    Subtitle = "Excel Data Source Item",
                    HasTabularData = true,
                    HasAsset = false,
                    Properties = new Dictionary<string, object>()
                    {
                        { "Url", "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx" }
                    }
                },
                Fields = new List<IField>
                {
                    new DateField("Date"),
                    new NumberField("Paid Traffic"),
                    new NumberField("Organic Traffic"),
                    new NumberField("Other Traffic"),
                }
            };
            excelDataSourceItem.UseExcel("Marketing");

            document.Visualizations.Add(new BarChartVisualization("Bar", excelDataSourceItem)
            {
                Id = "c24cc878-6032-48ce-a94f-de00467e47dc",
                IsTitleVisible = true,
                Description = "Create Bar Visualization"
            }
            .SetLabel(new DateDataField("Date") { AggregationType = DateAggregationType.Month })
            .SetValues("Paid Traffic", "Organic Traffic", "Other Traffic")
            .ConfigureSettings(settings =>
            {
                settings.Trendline = TrendlineType.LinearFit;
                settings.ShowLegend = true;
                settings.ZoomLevel = 1;
                settings.AutomaticLabelRotation = true;
            }));

            document.Filters.Add(new DashboardDateFilter("My Date Filter"));

            // Act
            RdashSerializer.SerializeObject(document);
            var json = document.ToJsonString();
            var actualJson = JObject.Parse(json)["Widgets"];
            var expected = JArray.Parse(expectedJson);

            var expectedStr = JsonConvert.SerializeObject(expected);
            var actualStr = JsonConvert.SerializeObject(actualJson);

            // Assert
            Assert.Equal(expectedStr, actualStr);
        }
    }
}
