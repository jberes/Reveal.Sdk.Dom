using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions.Visualizations
{
    public class StackedColumnChartVisualizationExtensionsFixture
    {
        [Fact]
        public void ConfigureSettings_UpdateStackedColumnChartVSSettings_WithoutConditions()
        {
            // Arrange
            var stackedColumnChartVS = new StackedColumnChartVisualization();
            var expectedSettings = new StackedColumnChartVisualizationSettings()
            {
                AutomaticLabelRotation = false,
                ChartType = RdashChartType.Area,
                IsPercentageDistributed = true,
                SchemaTypeName = "Stacked Column Chart Schema Type Name",
                ShowLegend = false,
                ShowTotalsInTooltip = true,
                StartColorIndex = 2,
                SyncAxis = false,
                VisualizationType = "Stacked Column Chart VS Type",
                YAxisIsLogarithmic = true,
                YAxisMaxValue = 200,
                YAxisMinValue = 2,
                ZoomLevel = 3,
                ZoomScaleHorizontal = 5,
                ZoomScaleVertical = 2,
            };
            var action = (StackedColumnChartVisualizationSettings settings) =>
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
            stackedColumnChartVS.ConfigureSettings(action);

            // Assert
            Assert.Equivalent(expectedSettings, stackedColumnChartVS.Settings);
        }
    }
}
