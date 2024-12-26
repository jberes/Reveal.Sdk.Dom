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
    public class AreaChartVisualizationFixture
    {
        [Fact]
        public void Constructor_InitializesDefaultValues_WhenInstanceIsCreated()
        {
            // Act
            var areaChartVisualization = new AreaChartVisualization();

            // Assert
            Assert.NotNull(areaChartVisualization);
            Assert.Equal(ChartType.Area, areaChartVisualization.ChartType);
            Assert.Null(areaChartVisualization.Title);
            Assert.Null(areaChartVisualization.DataDefinition);
        }

        [Fact]
        public void Constructor_InitializesAreaChartVisualizationWithDataSource_WhenDataSourceItemIsProvided()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem { HasTabularData = true };

            // Act
            var areaChartVisualization = new AreaChartVisualization(dataSourceItem);

            // Assert
            Assert.NotNull(areaChartVisualization);
            Assert.Equal(ChartType.Area, areaChartVisualization.ChartType);
            Assert.Equal(dataSourceItem, areaChartVisualization.DataDefinition.DataSourceItem);
            Assert.Null(areaChartVisualization.Title);
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
            var areaChartVisualization = new AreaChartVisualization(title, dataSourceItem);

            // Assert
            Assert.Equal(title, areaChartVisualization.Title);
            Assert.Equal(ChartType.Area, areaChartVisualization.ChartType);
            Assert.Equal(dataSourceItem, areaChartVisualization.DataDefinition?.DataSourceItem);
        }

        [Fact]
        public void ToJsonString_GeneratesCorrectJson_WhenAreaChartVisualizationIsSerialized()
        {
            // Arrange
            var expectedJson =
                """
                [ {
                  "Description" : "Create Area Visualization",
                  "Id" : "1777ee80-cc7f-488f-b531-53ec92044f3c",
                  "Title" : "Area",
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
                    "ChartType" : "Area",
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
                      "FieldName" : "Spend",
                      "FieldLabel" : "Spend",
                      "UserCaption" : "Spend",
                      "IsCalculated" : false,
                      "Properties" : { },
                      "Sorting" : "None",
                      "FieldType" : "Number"
                    }, {
                      "FieldName" : "Conversions",
                      "FieldLabel" : "Conversions",
                      "UserCaption" : "Conversions",
                      "IsCalculated" : false,
                      "Properties" : { },
                      "Sorting" : "None",
                      "FieldType" : "Number"
                    }, {
                      "FieldName" : "Territory",
                      "FieldLabel" : "Territory",
                      "UserCaption" : "Territory",
                      "IsCalculated" : false,
                      "Properties" : { },
                      "Sorting" : "None",
                      "FieldType" : "String"
                    } ],
                    "TransposedFields" : [ ],
                    "QuickFilters" : [ ],
                    "AdditionalTables" : [ ],
                    "ServiceAdditionalTables" : [ ],
                    "DataSourceItem" : {
                      "_type" : "DataSourceItemType",
                      "Id" : "080cc17d-4a0a-4837-aa3f-ef2571ea443a",
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
                        "Id" : "d593dd79-7161-4929-afc9-c26393f5b650",
                        "Title" : "Marketing Sheet",
                        "Subtitle" : "Excel Data Source Item",
                        "DataSourceId" : "33077d1e-19c5-44fe-b981-6765af3156a6",
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
              Id = "080cc17d-4a0a-4837-aa3f-ef2571ea443a",
              Subtitle = "Excel Data Source Item",
              Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx",
              IsAnonymous = true,
              ResourceItem = new DataSourceItem()
              {
                Id = "d593dd79-7161-4929-afc9-c26393f5b650",
                DataSourceId = "33077d1e-19c5-44fe-b981-6765af3156a6",
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
                new NumberField("Spend"),
                new NumberField("Conversions"),
                new TextField("Territory")
              }
            };
            excelDataSourceItem.UseExcel("Marketing");

            document.Visualizations.Add(new AreaChartVisualization("Area", excelDataSourceItem)
            {
                Id = "1777ee80-cc7f-488f-b531-53ec92044f3c",
                IsTitleVisible = true,
                Description = "Create Area Visualization"
            }
            .SetLabel(new DateDataField("Date") { AggregationType = DateAggregationType.Month })
            .SetValues("Paid Traffic", "Organic Traffic", "Other Traffic")
            .ConfigureSettings(settings =>
            {
                settings.Trendline = TrendlineType.LinearFit;
                settings.ShowLegend = true;
            }));

            document.Filters.Add(new DashboardDataFilter("Spend", excelDataSourceItem));
            document.Filters.Add(new DashboardDateFilter("My Date Filter"));

            // Act
            RdashSerializer.SerializeObject(document);
            var json = document.ToJsonString();
            var actualJson = JObject.Parse(json)["Widgets"];
            var expected = JArray.Parse(expectedJson);

            // Assert
            var expectedStr = JsonConvert.SerializeObject(expected);
            var actualStr = JsonConvert.SerializeObject(actualJson);

            Assert.Equal(expectedStr, actualStr);
        }
    }
}
