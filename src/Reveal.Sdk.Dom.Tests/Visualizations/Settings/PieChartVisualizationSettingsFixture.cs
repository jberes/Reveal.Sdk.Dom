using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class PieChartVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new PieChartVisualizationSettings();

        // Assert
        Assert.Equal(RdashChartType.Pie, settings.ChartType);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "ChartVisualizationSettingsType",
              "ShowZeroValuesInLegend" : false,
              "ShowLegends" : true,
              "LabelDisplayMode" : "Percentage",
              "OthersSliceThreshold" : 3.0,
              "ChartType" : "Pie",
              "VisualizationType" : "CHART"
            }
            """;

        var settings = new PieChartVisualizationSettings
        {
            ShowLegend = true,
            StartColorIndex = null,
            OthersSliceThreshold = 3.0,
            StartPosition = null,
            ShowZeroValuesInLegend = false
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}