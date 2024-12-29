using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions.Visualizations
{
    public class SplineChartVisualizationExtensionsFixture
    {
        [Fact]
        public void ConfigureSettings_UpdateSplineChartVSSettings_WithoutConditions()
        {
            // Arrange
            var splineChartVS = new SplineChartVisualization();
            var expectedSettings = new SplineChartVisualizationSettings()
            {
                AutomaticLabelRotation = false,
                ChartType = RdashChartType.Area,
                SchemaTypeName = "Spline Chart Type Name",
                ShowLegend = false,
                ShowTotalsInTooltip = true,
                StartColorIndex = 2,
                SyncAxis = false,
                Trendline = TrendlineType.LogarithmicFit,
                VisualizationType = "SplineChart VS Type",
                YAxisIsLogarithmic = true,
                YAxisMaxValue = 100,
                YAxisMinValue = 2,
                ZoomLevel = 3,
                ZoomScaleHorizontal = 2,
                ZoomScaleVertical = 5
            };
            var action = (SplineChartVisualizationSettings settings) =>
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
            splineChartVS.ConfigureSettings(action);

            // Assert
            Assert.Equivalent(expectedSettings, splineChartVS.Settings);
        }
    }
}
