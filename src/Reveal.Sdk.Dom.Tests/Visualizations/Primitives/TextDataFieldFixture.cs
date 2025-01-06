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
    }
}
