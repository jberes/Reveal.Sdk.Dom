using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.VisualizationSpecs
{
    public class IndicatorTargetVisualizationDataSpecFixture
    {
        [Fact]
        public void Constructor_FieldsHaveDefaultValue_WithoutParameters()
        {
            // Act
            var indicatorTargetVSDataSpec = new IndicatorTargetVisualizationDataSpec();

            // Assert
            Assert.Empty(indicatorTargetVSDataSpec.Target);
            Assert.Equal(KpiGoalPeriod.YearToDate, indicatorTargetVSDataSpec.DateFilterType);
            Assert.Equal(SchemaTypeNames.IndicatorTargetVisualizationDataSpecType, indicatorTargetVSDataSpec.SchemaTypeName);
        }
    }
}
