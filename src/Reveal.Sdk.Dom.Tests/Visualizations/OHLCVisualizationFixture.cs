using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Serialization;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations;

public class OHLCVisualizationFixture
{
    [Fact]
    public void Constructor_InitializesDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var ohlcVisualization = new OHLCVisualization();

        // Assert
        Assert.NotNull(ohlcVisualization);
        Assert.Equal(ChartType.OHLC, ohlcVisualization.ChartType);
        Assert.Null(ohlcVisualization.Title);
        Assert.Null(ohlcVisualization.DataDefinition);
    }

    [Fact]
    public void Constructor_InitializesOHLCVisualizationWithDataSource_WhenDataSourceItemIsProvided()
    {
        // Arrange
        var dataSourceItem = new DataSourceItem { HasTabularData = true };

        // Act
        var ohlcVisualization = new OHLCVisualization(dataSourceItem);

        // Assert
        Assert.NotNull(ohlcVisualization);
        Assert.Equal(ChartType.OHLC, ohlcVisualization.ChartType);
        Assert.Equal(dataSourceItem, ohlcVisualization.DataDefinition.DataSourceItem);
        Assert.Null(ohlcVisualization.Title);
    }

    [Theory]
    [InlineData("Stock Analysis", null)]
    [InlineData(null, null)]
    public void Constructor_SetsTitleAndDataSource_WhenArgumentsAreProvided(string title, DataSourceItem dataSourceItem)
    {
        // Act
        var ohlcVisualization = new OHLCVisualization(title, dataSourceItem);

        // Assert
        Assert.Equal(title, ohlcVisualization.Title);
        Assert.Equal(ChartType.OHLC, ohlcVisualization.ChartType);
        Assert.Null(ohlcVisualization.DataDefinition);
    }

    [Fact]
    public void ChartType_HasCorrectValue_WhenInstanceIsCreated()
    {
        // Act
        var ohlcVisualization = new OHLCVisualization();

        // Assert
        Assert.Equal(ChartType.OHLC, ohlcVisualization.ChartType);
    }

    [Fact]
    public void DataDefinition_CanBeUpdated_WhenNewDataSourceItemIsSet()
    {
        // Arrange
        var dataSourceItem = new DataSourceItem { HasTabularData = true };
        var ohlcVisualization = new OHLCVisualization("Stock Analysis", dataSourceItem);

        var newDataSourceItem = new DataSourceItem();

        // Act
        ohlcVisualization.UpdateDataSourceItem(newDataSourceItem);

        // Assert
        Assert.Equal(newDataSourceItem, ohlcVisualization.DataDefinition.DataSourceItem);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenOHLCVisualizationIsSerialized()
    {
        //Arrange
        var expectedJson =
            """
            [ {
              "Description" : "Create OHLC Visualization",
              "Id" : "60344a4a-d0ce-4364-9f8c-acfbb8caa32e",
              "Title" : "OHLC Visualization",
              "IsTitleVisible" : true,
              "ColumnSpan" : 0,
              "RowSpan" : 0,
              "VisualizationSettings" : {
                "_type" : "PivotVisualizationSettingsType",
                "FontSize" : "Large",
                "Style" : {
                  "FixedLeftColumns" : false,
                  "TextAlignment" : "Center",
                  "NumericAlignment" : "Inherit",
                  "DateAlignment" : "Center"
                },
                "VisualizationType" : "PIVOT"
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
                "ShowGrandTotals" : false,
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

        document.Visualizations.Add(new PivotVisualization("OHLC Visualization", excelDataSourceItem)
            {
                Id = "60344a4a-d0ce-4364-9f8c-acfbb8caa32e",
                IsTitleVisible = true,
                Description = "Create OHLC Visualization"
            }
            .SetColumns("Territory", "Conversions", "Spend")
            .ConfigureSettings(settings =>
            {
                settings.FontSize = FontSize.Large;
                settings.DateFieldAlignment = Alignment.Center;
                settings.TextFieldAlignment = Alignment.Center;
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