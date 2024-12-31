using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.VisualizationSpecs
{
    public class PivotVisualizationDataSpecFixture
    {
        [Fact]
        public void Constructor_FieldsHaveDefaultValue_WithoutParameters()
        {
            // Act
            var pivotVSDataSpec = new PivotVisualizationDataSpec();

            // Assert
            Assert.Equal(SchemaTypeNames.PivotVisualizationDataSpecType, pivotVSDataSpec.SchemaTypeName);
            Assert.Empty(pivotVSDataSpec.Columns);
            Assert.Empty(pivotVSDataSpec.Values);
        }
    }
}
