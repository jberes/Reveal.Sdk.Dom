using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.VisualizationSpecs
{
    public class ScatterMapVisualizationDataSpecFixture
    {
        [Fact]
        public void Constructor_CreateObjWithDefaultValue_WithoutParameters()
        {
            // Act
            var scatterMapVSDataSpec = new ScatterMapVisualizationDataSpec();

            // Assert
            Assert.Equal(SchemaTypeNames.ScatterMapVisualizationDataSpecType, scatterMapVSDataSpec.SchemaTypeName);
            Assert.True(scatterMapVSDataSpec.IsColorByValue);
            Assert.Empty(scatterMapVSDataSpec.MapColor);
            Assert.Empty(scatterMapVSDataSpec.Radius);
        }
    }
}
