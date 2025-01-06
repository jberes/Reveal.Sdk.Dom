using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
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
    }
}
