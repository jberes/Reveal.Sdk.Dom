using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.VisualizationSpecs
{
    public class IndicatorVisualizationDataSpecFixture
    {
        [Fact]
        public void Constructor_FieldsHaveDefaultValue_WithoutParameters()
        {
            // Act
            var indicatorVSDataSpec = new IndicatorVisualizationDataSpec();

            // Assert
            Assert.Equal(IndicatorVisualizationType.YearToDatePreviousYear, indicatorVSDataSpec.IndicatorType);
            Assert.Equal(SchemaTypeNames.IndicatorVisualizationDataSpecType, indicatorVSDataSpec.SchemaTypeName);
        }
    }
}
