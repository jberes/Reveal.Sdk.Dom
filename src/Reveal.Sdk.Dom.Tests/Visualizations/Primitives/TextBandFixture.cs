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
    }
}
