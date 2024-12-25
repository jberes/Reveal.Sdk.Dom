using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions.Visualizations
{
    public class BarChartVisualizationExtensionsFixture
    {
        [Fact]
        public void ConfigureSettings_UpdateBarChartVSSettings_WithoutConditions()
        {
            // Arrange
            var barchartVS = new BarChartVisualization();
            var expectedSettings = new BarChartVisualizationSettings()
            {
                AutomaticLabelRotation = false,
                ChartType = RdashChartType.Area,
                SchemaTypeName = "Bar Chart Schema Type",
                ShowLegend = false,
                ShowTotalsInTooltip = true,
                StartColorIndex = 5,
                SyncAxis = false,
                Trendline = TrendlineType.QuarticFit,
                VisualizationType = "VS Bar Chart Type",
                YAxisIsLogarithmic = true,
                YAxisMaxValue = 25,
                YAxisMinValue = 10,
                ZoomLevel = 2,
                ZoomScaleHorizontal = 2.5,
                ZoomScaleVertical = 10.5
            };
            var action = (BarChartVisualizationSettings settings) =>
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
            barchartVS.ConfigureSettings(action);

            // Assert
            Assert.Equivalent(expectedSettings, barchartVS.Settings);
        }
    }
}
