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
        public void ToJsonString_GeneratesCorrectJson_WhenPivotVisualizationIsSerialized()
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
                        ...
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
                    // Other fields omitted for brevity
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