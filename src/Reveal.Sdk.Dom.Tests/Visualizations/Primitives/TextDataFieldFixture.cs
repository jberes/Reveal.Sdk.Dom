using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class TextDataFieldFixture
    {
        [Fact]
        public void Constructor_SetsDefaultValues_WhenConstructedWithNoFieldName()
        {
            // Act
            var band = new TextDataField();

            // Assert
            Assert.Equal(SchemaTypeNames.SummarizationRegularFieldType, band.SchemaTypeName);
            Assert.Equal(string.Empty, band.FieldName);
        }

        [Fact]
        public void Constructor_SetsDefaultValues_WhenConstructedWithFieldName()
        {
            // Arrange
            var fieldName = "TestFieldName";

            // Act
            var band = new TextDataField(fieldName);

            // Assert
            Assert.Equal(SchemaTypeNames.SummarizationRegularFieldType, band.SchemaTypeName);
            Assert.Equal(fieldName, band.FieldName);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var expectedJson = """
            {
              "_type": "SummarizationRegularFieldType",
              "DrillDownElements": [],
              "ExpandedItems": [],
              "FieldName": "FieldName"
            }
            """;
            var fieldName = "FieldName";

            // Act
            var field = new TextDataField(fieldName);

            // Act
            var actualJson = field.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(actualJson);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}
