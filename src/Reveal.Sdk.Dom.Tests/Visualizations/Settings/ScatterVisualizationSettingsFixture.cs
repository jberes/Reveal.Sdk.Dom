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
        Assert.Equal(SchemaTypeNames.ChartVisualizationSettingsType, settings.SchemaTypeName);
        Assert.True(settings.ShowLegend);
        Assert.False(settings.XAxisIsLogarithmic);
        Assert.False(settings.YAxisIsLogarithmic);
        Assert.Null(settings.XAxisMinValue);
        Assert.Null(settings.XAxisMaxValue);
        Assert.Null(settings.YAxisMinValue);
        Assert.Null(settings.YAxisMaxValue);
        Assert.Equal(VisualizationTypes.CHART, settings.VisualizationType);
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
              "RightAxisMinValue" : null,
              "RightAxisMaxValue" : null,
              "LeftAxisLogarithmic" : false,
              "LeftAxisMinValue" : null,
              "LeftAxisMaxValue" : null,
              "ShowLegends" : true,
              "BrushOffsetIndex" : null,
              "ChartType" : "Scatter",
              "VisualizationType" : "CHART"
            }
            """;

        var settings = new ScatterVisualizationSettings();

        // Act
        var actualJson = JsonConvert.SerializeObject(settings);
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}