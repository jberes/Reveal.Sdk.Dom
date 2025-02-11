using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class MapVisualizationSettingsBaseFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new TestMapVisualizationSettings();

        // Assert
        Assert.True(settings.ShowLegend);
        Assert.Equal(-1, settings.ColorIndex);
        Assert.Null(settings.Region);
        Assert.Equal(SchemaTypeNames.GeoMapBaseVisualizationSettingsType, settings.SchemaTypeName);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "GeoMapBaseVisualizationSettingsType",
              "ShowLegends" : false,
              "ColorIndex" : 1,
              "Region" : "Asia",
            }
            """;

        var settings = new TestMapVisualizationSettings()
        {
            ShowLegend = false,
            ColorIndex = 1,
            Region = "Asia"
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
    
    private class TestMapVisualizationSettings : MapVisualizationSettingsBase { }
}