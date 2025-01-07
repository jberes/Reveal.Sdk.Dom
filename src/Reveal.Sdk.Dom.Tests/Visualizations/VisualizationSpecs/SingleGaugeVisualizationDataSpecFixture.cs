using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.VisualizationSpecs
{
    public class SingleGaugeVisualizationDataSpecFixture
    {
        [Fact]
        public void Constructor_FieldsHaveDefaultValue_WithoutParameters()
        {
            // Act
            var singleGaugeVSDataSpec = new SingleGaugeVisualizationDataSpec();

            // Assert
            Assert.Equal(SchemaTypeNames.SingleGaugeVisualizationDataSpecType, singleGaugeVSDataSpec.SchemaTypeName);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var expectedJson = """
                {
                  "_type": "AssetVisualizationSettingsType",
                  "Label": {
                    "_type": "DimensionColumnSpecType"
                  },
                  "Value": []
                }
                """;
            var singleGaugeVSDataSpec = new SingleGaugeVisualizationDataSpec()
            {
                SchemaTypeName = SchemaTypeNames.AssetVisualizationSettingsType,
                Label = new DimensionColumn(),
                Value = new List<MeasureColumn>()
            };

            // Act
            var actualJson = singleGaugeVSDataSpec.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(actualJson);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}
