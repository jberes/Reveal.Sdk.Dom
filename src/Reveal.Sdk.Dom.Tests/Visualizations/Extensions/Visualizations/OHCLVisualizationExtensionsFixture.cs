using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions.Visualizations
{
    public class OHLCVisualizationExtensionsFixture
    {
        [Fact]
        public void ConfigureSettings_UpdateOHLCVSSettings_WithoutConditions()
        {
            // Arrange
            var OHLCVS = new OHLCVisualization();
            var expectedSettings = new OHLCVisualizationSettings()
            {
                ChartType = RdashChartType.SplineArea,
                LeftAxisIsLogarithmic = false,
                LeftAxisMaxValue = 25,
                LeftAxisMinValue = 12,
                SchemaTypeName = "OHLC Schema Type",
                VisualizationType = "OHLC VS Type"
            };
            var action = (OHLCVisualizationSettings settings) =>
            {
                settings.ChartType = expectedSettings.ChartType;
                settings.LeftAxisIsLogarithmic = expectedSettings.LeftAxisIsLogarithmic;
                settings.LeftAxisMaxValue = expectedSettings.LeftAxisMaxValue;
                settings.LeftAxisMinValue = expectedSettings.LeftAxisMinValue;
                settings.SchemaTypeName = expectedSettings.SchemaTypeName;
                settings.VisualizationType = expectedSettings.VisualizationType;
            };

            // Act
            OHLCVS.ConfigureSettings(action);

            // Assert
            Assert.Equivalent(expectedSettings, OHLCVS.Settings);
        }
    }
}
