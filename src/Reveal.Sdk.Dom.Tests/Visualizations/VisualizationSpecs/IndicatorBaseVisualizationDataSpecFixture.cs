using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.VisualizationSpecs
{
    public class IndicatorBaseVisualizationDataSpecFixture
    {
        [Fact]
        public void Constructor_FieldsHaveDefaultValue_WithoutParameters()
        {
            // Act
            var indicator = new IndicatorBaseVisualizationDataSpec();

            // Assert
            Assert.Empty(indicator.Value);
            Assert.Equal(SchemaTypeNames.IndicatorBaseVisualizationDataSpecType, indicator.SchemaTypeName);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var expectedJson = """
                {
                  "_type": "AssetVisualizationSettingsType",
                  "Date": {
                    "_type": "DimensionColumnSpecType"
                  },
                  "Value": [],
                  "AdHocFields": 11,
                  "FormatVersion": 3,
                  "AdHocExpandedElements": [],
                  "Rows": []
                }
                """;
            var baseIndicator = new IndicatorBaseVisualizationDataSpec()
            {
                AdHocExpandedElements = new List<Dom.Visualizations.AdHocExpandedElement>(),
                AdHocFields = 11,
                Date = new Dom.Visualizations.DimensionColumn(),
                FormatVersion = 3,
                Rows = new List<Dom.Visualizations.DimensionColumn>(),
                SchemaTypeName = SchemaTypeNames.AssetVisualizationSettingsType,
                Value = new List<Dom.Visualizations.MeasureColumn>()
            };

            // Act
            var actualJson = baseIndicator.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(actualJson);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}
