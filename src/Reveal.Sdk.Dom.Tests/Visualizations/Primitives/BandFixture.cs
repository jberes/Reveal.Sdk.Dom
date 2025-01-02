using Moq;
using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class BandFixture
    {
        [Fact]
        public void Constructor_FieldsHaveDefaultValue_WithoutParameters()
        {
            // Arrange
            var mockBand = new Mock<Band>();

            // Act
            var band = mockBand.Object;

            // Assert
            Assert.Equal(ValueComparisonType.Percentage, band.ValueComparisonType);
            Assert.Equal(BandColor.Green, band.Color);
        }
    }
}
