using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Serialization;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations;

public class CandleStickVisualizationFixture
{
    [Fact]
    public void Constructor_InitializesDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var candleStickVisualization = new CandleStickVisualization();

        // Assert
        Assert.NotNull(candleStickVisualization);
        Assert.Equal(ChartType.Candlestick, candleStickVisualization.ChartType);
        Assert.Null(candleStickVisualization.Title);
        Assert.Null(candleStickVisualization.DataDefinition);
    }

    [Fact]
    public void Constructor_InitializesCandleStickVisualizationWithDataSource_WhenDataSourceItemIsProvided()
    {
        // Arrange
        var dataSourceItem = new DataSourceItem { HasTabularData = true };

        // Act
        var candleStickVisualization = new CandleStickVisualization(dataSourceItem);

        // Assert
        Assert.NotNull(candleStickVisualization);
        Assert.Equal(ChartType.Candlestick, candleStickVisualization.ChartType);
        Assert.Equal(dataSourceItem, candleStickVisualization.DataDefinition.DataSourceItem);
        Assert.Null(candleStickVisualization.Title);
    }

    [Theory]
    [InlineData("Stock Prices", null)]
    [InlineData(null, null)]
    public void Constructor_SetsTitleAndDataSource_WhenArgumentsAreProvided(string title, DataSourceItem dataSourceItem)
    {
        // Act
        var candleStickVisualization = new CandleStickVisualization(title, dataSourceItem);

        // Assert
        Assert.Equal(title, candleStickVisualization.Title);
        Assert.Equal(ChartType.Candlestick, candleStickVisualization.ChartType);
        Assert.Null(candleStickVisualization.DataDefinition);
    }

    [Fact]
    public void ChartType_HasCorrectValue_WhenInstanceIsCreated()
    {
        // Act
        var candleStickVisualization = new CandleStickVisualization();

        // Assert
        Assert.Equal(ChartType.Candlestick, candleStickVisualization.ChartType);
    }

    [Fact]
    public void DataDefinition_CanBeUpdated_WhenNewDataSourceItemIsSet()
    {
        // Arrange
        var dataSourceItem = new DataSourceItem { HasTabularData = true };
        var candleStickVisualization = new CandleStickVisualization("Stock Analysis", dataSourceItem);

        var newDataSourceItem = new DataSourceItem();

        // Act
        candleStickVisualization.UpdateDataSourceItem(newDataSourceItem);

        // Assert
        Assert.Equal(newDataSourceItem, candleStickVisualization.DataDefinition.DataSourceItem);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenCandleStickVisualizationIsSerialized()
    {
        //Arrange
        var expectedJson =
            """
            [ {
              "Description" : "Create Candle Stick Visualization",
              "Id" : "60344a4a-d0ce-4364-9f8c-acfbb8caa32e",
              "Title" : "Candle Stick Visualization",
              "IsTitleVisible" : true,
              "ColumnSpan" : 0,
              "RowSpan" : 0,
              "VisualizationSettings" : {
                "_type" : "SampleSchema",
                "FontSize" : "Large",
                "Style" : {
                  "FixedLeftColumns" : false,
                  "TextAlignment" : "Center",
                  "NumericAlignment" : "Inherit",
                  "DateAlignment" : "Center"
                },
                "VisualizationType" : "PivotVisualizationDataSpec"
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
                "_type" : "PivotVisualizationDataSpecType",
                "Columns" : [ {
                  "_type" : "DimensionColumnSpecType",
                  "SummarizationField" : {
                    "_type" : "SummarizationRegularFieldType",
                    "DrillDownElements" : [ ],
                    "ExpandedItems" : [ ],
                    "FieldName" : "Territory"
                  }
                }, {
                  "_type" : "DimensionColumnSpecType",
                  "SummarizationField" : {
                    "_type" : "SummarizationRegularFieldType",
                    "DrillDownElements" : [ ],
                    "ExpandedItems" : [ ],
                    "FieldName" : "Conversions"
                  }
                }, {
                  "_type" : "DimensionColumnSpecType",
                  "SummarizationField" : {
                    "_type" : "SummarizationRegularFieldType",
                    "DrillDownElements" : [ ],
                    "ExpandedItems" : [ ],
                    "FieldName" : "Spend"
                  }
                } ],
                "Values" : [ ],
                "ShowGrandTotals" : true,
                "FormatVersion" : 0,
                "AdHocExpandedElements" : [ ],
                "Rows" : [ ]
              }
            } ]
            """;

        //Act
        var document = new RdashDocument("My Dashboard");

        var excelDataSourceItem = new RestDataSourceItem("Marketing Sheet")
        {
            Id = "080cc17d-4a0a-4837-aa3f-ef2571ea443a",
            Subtitle = "Excel Data Source Item",
            Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx",
            IsAnonymous = true,
            ResourceItem = new DataSourceItem
            {
                Id = "d593dd79-7161-4929-afc9-c26393f5b650",
                DataSourceId = "33077d1e-19c5-44fe-b981-6765af3156a6",
                Title = "Marketing Sheet",
                Subtitle = "Excel Data Source Item",
                HasTabularData = true,
                HasAsset = false,
                Properties = new Dictionary<string, object>
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

        document.Visualizations.Add(new PivotVisualization("Candle Stick Visualization", excelDataSourceItem)
            {
                Id = "60344a4a-d0ce-4364-9f8c-acfbb8caa32e",
                IsTitleVisible = true,
                Description = "Create Candle Stick Visualization"
            }
            .SetColumns("Territory", "Conversions", "Spend")
            .ConfigureSettings(settings =>
            {
                settings.FontSize = FontSize.Large;
                settings.DateFieldAlignment = Alignment.Center;
                settings.TextFieldAlignment = Alignment.Center;
                settings.ShowGrandTotals = true;
                settings.VisualizationType = "PivotVisualizationDataSpec";
                settings.SchemaTypeName = "SampleSchema";
            }));

        document.Filters.Add(new DashboardDataFilter("Spend", excelDataSourceItem));
        document.Filters.Add(new DashboardDateFilter("My Date Filter"));

        //Act
        RdashSerializer.SerializeObject(document);
        var json = document.ToJsonString();
        var actualJson = JObject.Parse(json)["Widgets"];
        var expected = JArray.Parse(expectedJson);

        var expectedStr = JsonConvert.SerializeObject(expected);
        var actualStr = JsonConvert.SerializeObject(actualJson);

        //Assert
        Assert.Equal(expectedStr, actualStr);
    }
}