using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class ScatterVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new ScatterVisualizationSettings();

        // Assert
        Assert.Equal(RdashChartType.Scatter, settings.ChartType);
        Assert.False(settings.XAxisIsLogarithmic);
        Assert.Null(settings.XAxisMinValue);
        Assert.Null(settings.XAxisMaxValue);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "ChartVisualizationSettingsType",
              "RightAxisLogarithmic" : true,
              "RightAxisMinValue" : 1.0,
              "LeftAxisLogarithmic" : false,
              "LeftAxisMaxValue" : 90.0,
              "ShowLegends" : true,
              "ChartType" : "Scatter",
              "VisualizationType" : "CHART"
            }
            """;

        var settings = new ScatterVisualizationSettings()
        {
            XAxisIsLogarithmic = true,
            XAxisMinValue = 1,
            YAxisMaxValue = 90,
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}
