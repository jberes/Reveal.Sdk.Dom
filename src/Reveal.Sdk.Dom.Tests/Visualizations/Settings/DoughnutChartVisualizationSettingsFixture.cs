using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class DoughnutChartVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new DoughnutChartVisualizationSettings();

        // Assert
        Assert.Equal(RdashChartType.Doughnut, settings.ChartType);
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
              "ChartType" : "Doughnut",
              "VisualizationType" : "CHART"
            }
            """;

        var settings = new DoughnutChartVisualizationSettings
        {
            ShowLegend = true,
            StartColorIndex = null,
            OthersSliceThreshold = 3.0,
            StartPosition = null,
            ShowZeroValuesInLegend = false,
            SliceLabelDisplay = LabelDisplayMode.Percentage
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}