using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions
{
    public class ColumnChartVisualizationExtensionsFixture
    {
        [Fact]
        public void ConfigureSettings_UpdateColumnVSSettings_WithoutConditions()
        {
            // Arrange
            var columnVS = new ColumnChartVisualization();
            var expectedSettings = new ColumnChartVisualizationSettings()
            {
                AutomaticLabelRotation = false,
                ChartType = RdashChartType.Area,
                SchemaTypeName = "Schema Type Name",
                ShowLegend = false,
                ShowTotalsInTooltip = true,
                StartColorIndex = 2,
                SyncAxis = false,
                Trendline = TrendlineType.QuadraticFit,
                VisualizationType = "Column VS Type",
                YAxisIsLogarithmic = false,
                YAxisMaxValue = 51.5,
                YAxisMinValue = 5.1,
                ZoomLevel = 2,
                ZoomScaleHorizontal = 2,
                ZoomScaleVertical = 3
            };
            var action = (ColumnChartVisualizationSettings settings) =>
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
            columnVS.ConfigureSettings(action);

            // Assert
            Assert.Equivalent(expectedSettings, columnVS.Settings);
        }
    }
}
