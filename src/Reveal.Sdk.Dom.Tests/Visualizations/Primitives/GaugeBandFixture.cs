using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class GaugeBandFixture
    {
        [Fact]
        public void Constructor_SetDefaultSchemaTypeName_WithoutParameters()
        {
            // Act
            var gaugeBand = new GaugeBand();

            // Assert
            Assert.Equal(SchemaTypeNames.GaugeBandType, gaugeBand.SchemaTypeName);
        }
    }
}
