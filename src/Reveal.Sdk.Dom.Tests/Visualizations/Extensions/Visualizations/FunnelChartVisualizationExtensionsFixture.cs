using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions.Visualizations
{
    public class FunnelChartVisualizationExtensionsFixture
    {
        [Fact]
        public void ConfigureSettings_UpdateFunnelVSSettings_WithoutConditions()
        {
            // Arrange
            var funnelVS = new FunnelChartVisualization();
            var expectedSettings = new FunnelChartVisualizationSettings()
            {
                ChartType = RdashChartType.Bar,
                OthersSliceThreshold = 2,
                SchemaTypeName = "Funnel Schema Type Name",
                ShowLegend = false,
                SliceLabelDisplay = LabelDisplayMode.ValueAndPercentage,
                StartColorIndex = 3,
                VisualizationType = "Funnel VS Type"
            };
            var action = (FunnelChartVisualizationSettings settings) =>
            {
                settings.ChartType = expectedSettings.ChartType;
                settings.OthersSliceThreshold = expectedSettings.OthersSliceThreshold;
                settings.SchemaTypeName = expectedSettings.SchemaTypeName;
                settings.ShowLegend = expectedSettings.ShowLegend;
                settings.SliceLabelDisplay = expectedSettings.SliceLabelDisplay;
                settings.StartColorIndex = expectedSettings.StartColorIndex;
                settings.VisualizationType = expectedSettings.VisualizationType;
            };

            // Act
            funnelVS.ConfigureSettings(action);

            // Assert
            Assert.Equivalent(expectedSettings, funnelVS.Settings);
        }
    }
}
