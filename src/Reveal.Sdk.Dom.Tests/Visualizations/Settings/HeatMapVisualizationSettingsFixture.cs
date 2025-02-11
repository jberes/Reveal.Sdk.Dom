using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class HeatMapVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new HeatMapVisualizationSettings();

        // Assert
        Assert.Equal(SchemaTypeNames.HeatMapVisualizationSettingsType, settings.SchemaTypeName);
        Assert.Equal(DashboardHeatMapLocationType.LatitudeLongitudeSingleField, settings.LocationType);
        Assert.True(settings.Layers.PinsLayerEnabled);
        Assert.False(settings.Layers.HeatMapLayerEnabled);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "HeatMapVisualizationSettingsType",
              "LocationType" : 1,
              "Layers" : {
                "PinsLayerEnabled" : false,
                "HeatMapLayerEnabled" : true
              },
              "MapType" : 0
            }
            """;

        var settings = new HeatMapVisualizationSettings
        {
            LocationType = DashboardHeatMapLocationType.LatitudeLongitudeFields,
            Layers = new HeatMapLayersSettings
            {
                PinsLayerEnabled = false,
                HeatMapLayerEnabled = true
            }
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}