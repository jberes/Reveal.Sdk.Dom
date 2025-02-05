using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class FunnelChartVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new FunnelChartVisualizationSettings();

        // Assert
        Assert.Equal(RdashChartType.Funnel, settings.ChartType);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "ChartVisualizationSettingsType",
              "ShowLegends" : true,
              "LabelDisplayMode" : "Percentage",
              "OthersSliceThreshold" : 3.0,
              "ChartType" : "Funnel",
              "VisualizationType" : "CHART"
            }
            """;

        var settings = new FunnelChartVisualizationSettings
        {
            ShowLegend = true,
            OthersSliceThreshold = 3.0
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}