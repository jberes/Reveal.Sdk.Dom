using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions.Visualizations
{
    public class CandleStickVisualizationExtensionsFixture
    {
        [Fact]
        public void ConfigureSettings_UpdateVSSettings_WithoutConditions()
        {
            // Arrange
            var candlestickVS = new CandleStickVisualization();
            var expectedSettings = new CandleStickVisualizationSettings()
            {
                ChartType = RdashChartType.Bar,
                LeftAxisIsLogarithmic = false,
                LeftAxisMaxValue = 25.5,
                LeftAxisMinValue = 1.5,
                SchemaTypeName = "Schema Type Name",
                VisualizationType = "Candlestick VS Type"
            };
            var action = (CandleStickVisualizationSettings settings) =>
            {
                settings.ChartType = expectedSettings.ChartType;
                settings.LeftAxisIsLogarithmic = expectedSettings.LeftAxisIsLogarithmic;
                settings.LeftAxisMaxValue = expectedSettings.LeftAxisMaxValue;
                settings.LeftAxisMinValue = expectedSettings.LeftAxisMinValue;
                settings.SchemaTypeName = expectedSettings.SchemaTypeName;
                settings.VisualizationType = expectedSettings.VisualizationType;
            };

            // Act
            candlestickVS.ConfigureSettings(action);

            // Assert
            Assert.Equivalent(expectedSettings, candlestickVS.Settings);
        }
    }
}
