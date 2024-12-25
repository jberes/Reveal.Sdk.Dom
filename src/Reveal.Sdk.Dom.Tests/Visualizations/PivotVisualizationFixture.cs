using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Tests.TestExtensions;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations
{
    public class PivotVisualizationFixture
    {
        [Fact]
        public void Constructor_InitializesDefaultValues_WhenInstanceIsCreated()
        {
            // Act
            var pivotVisualization = new PivotVisualization();

            // Assert
            Assert.NotNull(pivotVisualization);
            Assert.Equal(ChartType.Pivot, pivotVisualization.ChartType);
            Assert.NotNull(pivotVisualization.Columns);
            Assert.Empty(pivotVisualization.Columns);
            Assert.NotNull(pivotVisualization.Rows);
            Assert.Empty(pivotVisualization.Rows);
            Assert.NotNull(pivotVisualization.Values);
            Assert.Empty(pivotVisualization.Values);
            Assert.Null(pivotVisualization.Title);
            Assert.Null(pivotVisualization.DataDefinition);
        }

        [Theory]
        [InlineData("TestTitle", null)]
        [InlineData(null, null)]
        public void Constructor_SetsTitleAndDataSource_WhenArgumentsAreProvided(string title, DataSourceItem dataSourceItem)
        {
            // Act
            var pivotVisualization = new PivotVisualization(title, dataSourceItem);

            // Assert
            Assert.Equal(title, pivotVisualization.Title);
            Assert.Equal(ChartType.Pivot, pivotVisualization.ChartType);
            Assert.NotNull(pivotVisualization.Columns);
            Assert.Empty(pivotVisualization.Columns);
            Assert.NotNull(pivotVisualization.Rows);
            Assert.Empty(pivotVisualization.Rows);
            Assert.NotNull(pivotVisualization.Values);
            Assert.Empty(pivotVisualization.Values);
            Assert.Null(pivotVisualization.DataDefinition);
        }

        [Fact]
        public void Settings_HasCorrectDefaultValues_WhenInstanceIsCreated()
        {
            // Act
            var settings = new PivotVisualizationSettings();

            // Assert
            Assert.Equal(SchemaTypeNames.PivotVisualizationSettingsType, settings.SchemaTypeName);
            Assert.Equal(VisualizationTypes.PIVOT, settings.VisualizationType);
        }

        [Fact]
        public void VisualizationDataSpec_DefaultValue_IsPivotVisualizationDataSpec()
        {
            // Arrange
            var pivotVisualization = new PivotVisualization();

            var property = typeof(PivotVisualization).GetProperty("VisualizationDataSpec", BindingFlags.NonPublic | BindingFlags.Instance);
            var visualizationDataSpec = property.GetValue(pivotVisualization);

            // Assert
            Assert.NotNull(visualizationDataSpec);
            Assert.IsType<PivotVisualizationDataSpec>(visualizationDataSpec);
        }

        [Fact]
        public void Columns_ReturnsExpectedColumns_WhenInitialize()
        {
            // Arrange
            var expectedColumns = new List<DimensionColumn>
            {
                new DimensionColumn { DataField = new MockDimensionDataField("Column1") },
                new DimensionColumn { DataField = new MockDimensionDataField("Column2") }
            };

            var pivotVisualizationDataSpec = new PivotVisualizationDataSpec
            {
                Columns = expectedColumns
            };

            var pivotVisualization = new PivotVisualization();
            var property = typeof(PivotVisualization).GetProperty("VisualizationDataSpec", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            property.SetValue(pivotVisualization, pivotVisualizationDataSpec);

            // Act
            var columns = pivotVisualization.Columns;

            // Assert
            Assert.Equal(expectedColumns, columns);
        }

        [Fact]
        public void Rows_ReturnsExpectedRows_WhenInitialize()
        {
            // Arrange
            var expectedRows = new List<DimensionColumn>
        {
            new DimensionColumn { DataField = new MockDimensionDataField("Row1") },
            new DimensionColumn { DataField = new MockDimensionDataField("Row2") }
        };

            var pivotVisualizationDataSpec = new PivotVisualizationDataSpec
            {
                Rows = expectedRows
            };

            var pivotVisualization = new PivotVisualization();
            var property = typeof(PivotVisualization).GetProperty("VisualizationDataSpec", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            property.SetValue(pivotVisualization, pivotVisualizationDataSpec);

            // Act
            var rows = pivotVisualization.Rows;

            // Assert
            Assert.Equal(expectedRows, rows);
        }

        [Fact]
        public void Values_ReturnsExpectedValues_WhenInitialize()
        {
            // Arrange
            var expectedValues = new List<MeasureColumn>
        {
            new MeasureColumn { DataField = new NumberDataField("Value1") },
            new MeasureColumn { DataField = new NumberDataField("Value2") }
        };

            var pivotVisualizationDataSpec = new PivotVisualizationDataSpec
            {
                Values = expectedValues
            };

            var pivotVisualization = new PivotVisualization();
            var property = typeof(PivotVisualization).GetProperty("VisualizationDataSpec", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            property.SetValue(pivotVisualization, pivotVisualizationDataSpec);

            // Act
            var values = pivotVisualization.Values;

            // Assert
            Assert.Equal(expectedValues, values);
        }

        [Fact]
        public void Columns_AreSerializedCorrectly_WhenSerialize()
        {
            // Arrange
            var expectedColumns = new List<DimensionColumn>
        {
            new DimensionColumn { DataField = new MockDimensionDataField("Column1") },
            new DimensionColumn { DataField = new MockDimensionDataField("Column2") }
        };

            var pivotVisualization = new PivotVisualization();
            var pivotVisualizationDataSpec = new PivotVisualizationDataSpec
            {
                Columns = expectedColumns
            };

            var property = typeof(PivotVisualization).GetProperty("VisualizationDataSpec", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            property.SetValue(pivotVisualization, pivotVisualizationDataSpec);

            // Act
            var serializedJson = JsonConvert.SerializeObject(pivotVisualization);

            // Assert
            Assert.Contains("Column1", serializedJson);
            Assert.Contains("Column2", serializedJson);
        }

        [Fact]
        public void ToJsonString_GeneratesCorrectJson_WhenPivotVisualizationIsSerialized()
        {
            //Arrange
            var expectedJson = """
            [
              {
                "Description": "Create Grid Visualization",
                "Id": "60344a4a-d0ce-4364-9f8c-acfbb8caa32e",
                "Title": "Grid",
                "IsTitleVisible": true,
                "ColumnSpan": 0,
                "RowSpan": 0,
                "VisualizationSettings": {
                  "_type": "PivotVisualizationSettingsType",
                  "FontSize": "Large",
                  "Style": {
                    "FixedLeftColumns": false,
                    "TextAlignment": "Center",
                    "NumericAlignment": "Inherit",
                    "DateAlignment": "Center"
                  },
                  "VisualizationType": "PIVOT"
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
                    "Id": "080cc17d-4a0a-4837-aa3f-ef2571ea443a",
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
                      "Id": "d593dd79-7161-4929-afc9-c26393f5b650",
                      "Title": "Marketing Sheet",
                      "Subtitle": "Excel Data Source Item",
                      "DataSourceId": "33077d1e-19c5-44fe-b981-6765af3156a6",
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
                  "_type": "PivotVisualizationDataSpecType",
                  "Columns": [
                    {
                      "_type": "DimensionColumnSpecType",
                      "SummarizationField": {
                        "_type": "SummarizationRegularFieldType",
                        "DrillDownElements": [],
                        "ExpandedItems": [],
                        "FieldName": "Territory"
                      }
                    },
                    {
                      "_type": "DimensionColumnSpecType",
                      "SummarizationField": {
                        "_type": "SummarizationRegularFieldType",
                        "DrillDownElements": [],
                        "ExpandedItems": [],
                        "FieldName": "Conversions"
                      }
                    },
                    {
                      "_type": "DimensionColumnSpecType",
                      "SummarizationField": {
                        "_type": "SummarizationRegularFieldType",
                        "DrillDownElements": [],
                        "ExpandedItems": [],
                        "FieldName": "Spend"
                      }
                    }
                  ],
                  "Values": [],
                  "ShowGrandTotals": false,
                  "FormatVersion": 0,
                  "AdHocExpandedElements": [],
                  "Rows": []
                }
              }
            ]
            """;

            //Act
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

            document.Visualizations.Add(new PivotVisualization("Grid", excelDataSourceItem)
            {
                IsTitleVisible = true,
                Description = "Create Grid Visualization"
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

            //Assert
            var json = document.ToJsonString();
            var actualJson = JObject.Parse(json)["Widgets"];
            var expected = JArray.Parse(expectedJson);

            var removeProps = new[] { "Id", "DataSourceId" };
            var expectedStr = JsonConvert.SerializeObject(expected.RemoveProperties(removeProps));
            var actualStr = JsonConvert.SerializeObject(actualJson.RemoveProperties(removeProps));

            Assert.Equal(expectedStr, actualStr);
        }
    }

    public class MockDimensionDataField : IDimensionDataField
    {
        public MockDimensionDataField(string fieldName)
        {
            FieldName = fieldName;
        }

        public string FieldName { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public IDictionary<string, object> Properties { get; } = new Dictionary<string, object>();
    }
}