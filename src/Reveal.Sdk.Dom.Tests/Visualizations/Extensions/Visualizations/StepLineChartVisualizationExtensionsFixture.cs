using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions.Visualizations
{
    public class StepLineChartVisualizationExtensionsFixture
    {
        [Fact]
        public void ConfigureSettings_UpdateStepLineChartVSSettings_WithoutConditions()
        {
            // Arrange
            var steplineChartVS = new StepLineChartVisualization();
            var expectedSettings = new StepLineChartVisualizationSettings()
            {
                AutomaticLabelRotation = false,
                ChartType = RdashChartType.Area,
                SchemaTypeName = "Step Line Schema Type",
                ShowLegend = false,
                ShowTotalsInTooltip = true,
                StartColorIndex = 2,
                SyncAxis = false,
                Trendline = TrendlineType.LinearFit,
                VisualizationType = "Step Line VS Type",
                YAxisIsLogarithmic = true,
                YAxisMaxValue = 200,
                YAxisMinValue = 10,
                ZoomLevel = 2,
                ZoomScaleHorizontal = 3,
                ZoomScaleVertical = 5
            };
            var action = (StepLineChartVisualizationSettings settings) =>
            {
                settings.AutomaticLabelRotation = expectedSettings.AutomaticLabelRotation;
                settings.ChartType = expectedSettings.ChartType;
                settings.SchemaTypeName = expectedSettings.SchemaTypeName;
                settings.ShowLegend = expectedSettings.ShowLegend;
                settings.ShowTotalsInTooltip = expectedSettings.ShowTotalsInTooltip;
                settings.StartColorIndex = expectedSettings.StartColorIndex;
                settings.SyncAxis = expectedSettings.SyncAxis;
                settings.Trendline = expectedSettings.Trendline;
                settings.VisualizationType = expectedSettings.VisualizationType;
                settings.YAxisIsLogarithmic = expectedSettings.YAxisIsLogarithmic;
                settings.YAxisMaxValue = expectedSettings.YAxisMaxValue;
                settings.YAxisMinValue = expectedSettings.YAxisMinValue;
                settings.ZoomLevel = expectedSettings.ZoomLevel;
                settings.ZoomScaleHorizontal = expectedSettings.ZoomScaleHorizontal;
                settings.ZoomScaleVertical = expectedSettings.ZoomScaleVertical;
            };

            // Act
            steplineChartVS.ConfigureSettings(action);

            // Assert
            Assert.Equivalent(expectedSettings, steplineChartVS.Settings);
        }
    }
}
