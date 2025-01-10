using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class TextBandFixture
    {
        [Fact]
        public void Constructor_SetsSchemaTypeName_WhenConstructed()
        {
            // Act
            var band = new TextBand();

            // Assert
            Assert.Equal(SchemaTypeNames.GaugeBandType, band.SchemaTypeName);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var expectedJson = """
            {
              "_type": "GaugeBandType",
              "Shape": "Circle",
              "Type": "Percentage",
              "Color": "Green"
            }
            """;

            // Act
            var band = new TextBand();

            // Act
            var actualJson = band.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(actualJson);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}
