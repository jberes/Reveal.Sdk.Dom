using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.VisualizationSpecs
{
    public class SingleValueVisualizationDataSpecFixture
    {
        [Fact]
        public void Constructor_FieldsObjHaveDefaultValue_WithoutParmeter()
        {
            // Act
            var singleValueVSDataSpec = new SingleValueVisualizationDataSpec();

            // Assert
            Assert.Equal(SchemaTypeNames.SingleValueVisualizationDataSpecType, singleValueVSDataSpec.SchemaTypeName);
            Assert.Empty(singleValueVSDataSpec.Value);
        }
    }
}
