using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions.Visualizations
{
    public class TimeSeriesVisualizationExtensionsFixture
    {
        [Fact]
        public void ConfigureSettings_UpdateTimeSeriesVSSettings_WithoutConditions()
        {
            // Arrange
            var timeSeriesVS = new TimeSeriesVisualization();
            var expectedSettings = new TimeSeriesVisualizationSettings()
            {
                AutomaticLabelRotation = false,
                ChartType = RdashChartType.StepArea,
                SchemaTypeName = "Time Series Schema Type",
                ShowLegend = false,
                ShowTotalsInTooltip = true,
                StartColorIndex = 2,
                SyncAxis = false,
                Trendline = TrendlineType.QuadraticFit,
                VisualizationType = "Time Series VS Type",
                YAxisIsLogarithmic = true,
                YAxisMaxValue = 200,
                YAxisMinValue = 2,
                ZoomLevel = 3,
                ZoomScaleHorizontal = 5,
                ZoomScaleVertical = 6
            };
            var action = (TimeSeriesVisualizationSettings settings) =>
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
            timeSeriesVS.ConfigureSettings(action);

            // Assert
            Assert.Equivalent(expectedSettings, timeSeriesVS.Settings);
        }
    }
}
