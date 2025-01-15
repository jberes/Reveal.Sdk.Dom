using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class BubbleVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new BubbleVisualizationSettings();

        // Assert
        Assert.Equal(RdashChartType.Bubble, settings.ChartType);
        Assert.Equal(SchemaTypeNames.ChartVisualizationSettingsType, settings.SchemaTypeName);
        Assert.Equal(VisualizationTypes.CHART, settings.VisualizationType);
        Assert.False(settings.XAxisIsLogarithmic);
        Assert.False(settings.YAxisIsLogarithmic);
        Assert.Null(settings.XAxisMinValue);
        Assert.Null(settings.XAxisMaxValue);
        Assert.Null(settings.YAxisMinValue);
        Assert.Null(settings.YAxisMaxValue);
        Assert.True(settings.ShowLegend);
    }
    
    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "ChartVisualizationSettingsType",
              "RightAxisLogarithmic" : false,
              "LeftAxisLogarithmic" : false,
              "ShowLegends" : true,
              "ChartType" : "Bubble",
              "VisualizationType" : "CHART"
            }
            """;

        var settings = new BubbleVisualizationSettings();

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }

}