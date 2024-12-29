using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions.Visualizations
{
    public class StackedBarChartVisualizationExtensionsFixture
    {
        [Fact]
        public void ConfigureSettings_UpdateStackedBarChartVSSettings_WithoutConditions()
        {
            // Arrange
            var stackedBarChartVS = new StackedBarChartVisualization();
            var expectedSettings = new StackedBarChartVisualizationSettings()
            {
                AutomaticLabelRotation = false,
                ChartType = RdashChartType.Area,
                IsPercentageDistributed = true,
                SchemaTypeName = "Stacked Bar Chart Schema Type Name",
                ShowLegend = false,
                ShowTotalsInTooltip = true,
                StartColorIndex = 2,
                SyncAxis = false,
                VisualizationType = "Stacked Bar Chart VS Type",
                YAxisIsLogarithmic = true,
                YAxisMaxValue = 101,
                YAxisMinValue = 2,
                ZoomLevel = 3,
                ZoomScaleHorizontal = 4,
                ZoomScaleVertical = 5,
            };
            var action = (StackedBarChartVisualizationSettings settings) =>
            {
                settings.AutomaticLabelRotation = expectedSettings.AutomaticLabelRotation;
                settings.ChartType = expectedSettings.ChartType;
                settings.IsPercentageDistributed = expectedSettings.IsPercentageDistributed;
                settings.SchemaTypeName = expectedSettings.SchemaTypeName;
                settings.ShowLegend = expectedSettings.ShowLegend;
                settings.ShowTotalsInTooltip = expectedSettings.ShowTotalsInTooltip;
                settings.StartColorIndex = expectedSettings.StartColorIndex;
                settings.SyncAxis = expectedSettings.SyncAxis;
                settings.VisualizationType = expectedSettings.VisualizationType;
                settings.YAxisIsLogarithmic = expectedSettings.YAxisIsLogarithmic;
                settings.YAxisMaxValue = expectedSettings.YAxisMaxValue;
                settings.YAxisMinValue = expectedSettings.YAxisMinValue;
                settings.ZoomLevel = expectedSettings.ZoomLevel;
                settings.ZoomScaleHorizontal = expectedSettings.ZoomScaleHorizontal;
                settings.ZoomScaleVertical = expectedSettings.ZoomScaleVertical;
            };

            // Act
            stackedBarChartVS.ConfigureSettings(action);

            // Assert
            Assert.Equivalent(expectedSettings, stackedBarChartVS.Settings);
        }
    }
}
