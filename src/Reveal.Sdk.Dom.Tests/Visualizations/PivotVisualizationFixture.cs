using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Core.Serialization;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations
{
    public class PivotVisualizationFixture
    {
        [Fact]
        public void PivotVisualization_DefaultConstructor_ShouldInitializeWithDefaultValues()
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
        }

        [Theory]
        [InlineData("TestTitle", null)]
        [InlineData(null, null)]
        public void PivotVisualization_ConstructorWithTitleAndDataSource_ShouldSetValues(string title, DataSourceItem dataSourceItem)
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
        }

        [Fact]
        public void PivotVisualizationSettings_DefaultValues_ShouldBeCorrect()
        {
            // Act
            var settings = new PivotVisualizationSettings();

            // Assert
            Assert.Equal(SchemaTypeNames.PivotVisualizationSettingsType, settings.SchemaTypeName);
            Assert.Equal(VisualizationTypes.PIVOT, settings.VisualizationType);
        }

        [Fact]
        public void ToJsonString_CreatesFormattedJson_ForPivotVisualization()
        {
            // Arrange
            var expectedJson =
                """
                [
                  {
                    "Description": "Create Grid Visualization",
                    "Id": "f8026c55-ce1b-4d20-9bad-4de6cf394df2",
                    "Title": "Pivot",
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
                          "FieldName": "Budget",
                          "FieldLabel": "Budget",
                          "UserCaption": "Budget",
                          "IsCalculated": false,
                          "Properties": {},
                          "Sorting": "None",
                          "FieldType": "Number"
                        },
                        {
                          "FieldName": "CTR",
                          "FieldLabel": "CTR",
                          "UserCaption": "CTR",
                          "IsCalculated": false,
                          "Properties": {},
                          "Sorting": "None",
                          "FieldType": "Number"
                        },
                        {
                          "FieldName": "Avg. CPC",
                          "FieldLabel": "Avg. CPC",
                          "UserCaption": "Avg. CPC",
                          "IsCalculated": false,
                          "Properties": {},
                          "Sorting": "None",
                          "FieldType": "Number"
                        },
                        {
                          "FieldName": "Traffic",
                          "FieldLabel": "Traffic",
                          "UserCaption": "Traffic",
                          "IsCalculated": false,
                          "Properties": {},
                          "Sorting": "None",
                          "FieldType": "Number"
                        },
                        {
                          "FieldName": "Paid Traffic",
                          "FieldLabel": "Paid Traffic",
                          "UserCaption": "Paid Traffic",
                          "IsCalculated": false,
                          "Properties": {},
                          "Sorting": "None",
                          "FieldType": "Number"
                        },
                        {
                          "FieldName": "Other Traffic",
                          "FieldLabel": "Other Traffic",
                          "UserCaption": "Other Traffic",
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
                        },
                        {
                          "FieldName": "CampaignID",
                          "FieldLabel": "CampaignID",
                          "UserCaption": "CampaignID",
                          "IsCalculated": false,
                          "Properties": {},
                          "Sorting": "None",
                          "FieldType": "String"
                        },
                        {
                          "FieldName": "New Seats",
                          "FieldLabel": "New Seats",
                          "UserCaption": "New Seats",
                          "IsCalculated": false,
                          "Properties": {},
                          "Sorting": "None",
                          "FieldType": "Number"
                        },
                        {
                          "FieldName": "Paid %",
                          "FieldLabel": "Paid %",
                          "UserCaption": "Paid %",
                          "IsCalculated": false,
                          "Properties": {},
                          "Sorting": "None",
                          "FieldType": "Number"
                        },
                        {
                          "FieldName": "Organic %",
                          "FieldLabel": "Organic %",
                          "UserCaption": "Organic %",
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
                        "Id": "94fa2dde-0804-4109-ae14-99a8ce2d76fa",
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
                          "Id": "5fab2b6c-4352-43b8-924f-b3edf95ffb63",
                          "Title": "Marketing Sheet",
                          "Subtitle": "Excel Data Source Item",
                          "DataSourceId": "43c080ac-0f0b-4bac-a1b0-dbeb8ef4d67a",
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
                            "FieldName": "CampaignID"
                          }
                        }
                      ],
                      "Values": [
                        {
                          "_type": "MeasureColumnSpecType",
                          "SummarizationField": {
                            "_type": "SummarizationValueFieldType",
                            "FieldLabel": "New Seats",
                            "UserCaption": "New Seats",
                            "IsHidden": false,
                            "AggregationType": "Sum",
                            "Sorting": "None",
                            "IsCalculated": false,
                            "FieldName": "New Seats"
                          }
                        }
                      ],
                      "ShowGrandTotals": true,
                      "FormatVersion": 0,
                      "AdHocExpandedElements": [],
                      "Rows": [
                        {
                          "_type": "DimensionColumnSpecType",
                          "SummarizationField": {
                            "_type": "SummarizationRegularFieldType",
                            "DrillDownElements": [],
                            "ExpandedItems": [],
                            "FieldName": "Territory"
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
                    new NumberField("CTR"),
                    new NumberField("Avg. CPC"),
                    new NumberField("Traffic"),
                    new NumberField("Paid Traffic"),
                    new NumberField("Other Traffic"),
                    new NumberField("Conversions"),
                    new TextField("Territory"),
                    new TextField("CampaignID"),
                    new NumberField("New Seats"),
                    new NumberField("Paid %"),
                    new NumberField("Organic %")
                }
            };
            excelDataSourceItem.UseExcel("Marketing");

            document.Visualizations.Add(new PivotVisualization("Pivot", excelDataSourceItem)
            {
                IsTitleVisible = true,
                Description = "Create Grid Visualization"
            }
            .SetRow("Territory")
            .SetValue("New Seats")
            .SetColumn("CampaignID")
            .ConfigureSettings(settings =>
            {
                settings.FontSize = FontSize.Large;
                settings.DateFieldAlignment = Alignment.Center;
                settings.TextFieldAlignment = Alignment.Center;
                settings.ShowGrandTotals = true;
            }));

            document.Filters.Add(new DashboardDateFilter("My Date Filter"));

            // Act
            RdashSerializer.SerializeObject(document);
            var json = document.ToJsonString();
            var jObject = JObject.Parse(json);
            var actualJArray = (JArray)jObject["Widgets"];
            var expectedJArray = JArray.Parse(expectedJson);

            // Assert
            Assert.Equal(expectedJArray.Count, actualJArray.Count);

            for (int i = 0; i < expectedJArray.Count; i++)
            {
                Assert.Equal(expectedJArray[i], actualJArray[i]);
            }
        }
    }
}
