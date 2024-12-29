using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions.Visualizations
{
    public class LineChartVisualizationExtensionsFixture
    {
        [Fact]
        public void ConfigureSettings_UpdateLineChartVSSettings_WithoutConditions()
        {
            // Arrange
            var lineChartVS = new LineChartVisualization();
            var expectedSettings = new LineChartVisualizationSettings()
            {
                AutomaticLabelRotation = false,
                ChartType = RdashChartType.Area,
                SchemaTypeName = "Line Chart Schema",
                ShowLegend = false,
                ShowTotalsInTooltip = true,
                StartColorIndex = 1,
                SyncAxis = false,
                Trendline = TrendlineType.QuarticFit,
                VisualizationType = "Line Chart VS Type",
                YAxisIsLogarithmic = true,
                YAxisMaxValue = 51.5,
                YAxisMinValue = 10.2,
                ZoomLevel = 2,
                ZoomScaleHorizontal = 3,
                ZoomScaleVertical = 5,
            };
            var action = (LineChartVisualizationSettings settings) =>
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
            lineChartVS.ConfigureSettings(action);

            // Assert
            Assert.Equivalent(expectedSettings, lineChartVS.Settings);
        }
    }
}
