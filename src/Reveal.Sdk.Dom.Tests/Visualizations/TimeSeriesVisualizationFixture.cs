using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Serialization;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations;

public class TimeSeriesVisualizationFixture
{
    [Fact]
    public void Constructor_InitializesDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var visualization = new TimeSeriesVisualization();

        // Assert
        Assert.NotNull(visualization);
        Assert.Equal(ChartType.TimeSeries, visualization.ChartType);
        Assert.Null(visualization.Title);
        Assert.NotNull(visualization.Values);
        Assert.Empty(visualization.Values);
        Assert.Null(visualization.Category);
        Assert.Null(visualization.Date);
    }

    [Theory]
    [InlineData("TestTitle", null)]
    [InlineData(null, null)]
    public void Constructor_SetsTitleAndDataSource_WhenArgumentsAreProvided(string title, DataSourceItem dataSourceItem)
    {
        // Act
        var visualization = new TimeSeriesVisualization(title, dataSourceItem);

        // Assert
        Assert.Equal(title, visualization.Title);
        Assert.Equal(ChartType.TimeSeries, visualization.ChartType);
        Assert.NotNull(visualization.Values);
        Assert.Empty(visualization.Values);
        Assert.Null(visualization.Category);
        Assert.Null(visualization.Date);
    }

    [Fact]
    public void Date_CanBeSetAndRetrieved()
    {
        // Arrange
        var dateColumn = new DimensionColumn { DataField = new MockDimensionDataField("DateField") };
        var visualization = new TimeSeriesVisualization();

        // Act
        visualization.Date = dateColumn;

        // Assert
        Assert.Equal(dateColumn, visualization.Date);
    }

    [Fact]
    public void Category_CanBeSetAndRetrieved()
    {
        // Arrange
        var categoryColumn = new DimensionColumn { DataField = new MockDimensionDataField("CategoryField") };
        var visualization = new TimeSeriesVisualization();

        // Act
        visualization.Category = categoryColumn;

        // Assert
        Assert.Equal(categoryColumn, visualization.Category);
    }

    [Fact]
    public void Values_CanBeRetrieved_WhenInitialized()
    {
        // Arrange
        var expectedValues = new List<MeasureColumn>
        {
            new() { DataField = new NumberDataField("Value1") },
            new() { DataField = new NumberDataField("Value2") }
        };

        var visualizationDataSpec = new TimeSeriesVisualizationDataSpec
        {
            Values = expectedValues
        };

        var visualization = new TimeSeriesVisualization();
        var property = typeof(TimeSeriesVisualization).GetProperty("VisualizationDataSpec",
            BindingFlags.NonPublic | BindingFlags.Instance);
        property.SetValue(visualization, visualizationDataSpec);

        // Act
        var values = visualization.Values;

        // Assert
        Assert.Equal(expectedValues, values);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenTimeSeriesVisualizationIsSerialized()
    {
        //Arrange
        var expectedJson =
            """
            [ {
              "Description" : "Create Time Series Visualization",
              "Id" : "60344a4a-d0ce-4364-9f8c-acfbb8caa32e",
              "Title" : "Time Series Visualization",
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

        document.Visualizations.Add(new PivotVisualization("Time Series Visualization", excelDataSourceItem)
            {
                Id = "60344a4a-d0ce-4364-9f8c-acfbb8caa32e",
                IsTitleVisible = true,
                Description = "Create Time Series Visualization"
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

internal class MockDimensionDataField : IDimensionDataField
{
    public MockDimensionDataField(string fieldName)
    {
        FieldName = fieldName;
    }

    public string Caption { get; set; }
    public IDictionary<string, object> Properties { get; } = new Dictionary<string, object>();

    public string FieldName { get; set; }
    public string Description { get; set; }
}