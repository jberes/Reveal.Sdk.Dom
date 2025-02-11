using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class MapVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new MapVisualizationSettings();

        // Assert
        Assert.Equal(SchemaTypeNames.MapVisualizationSettingsType, settings.SchemaTypeName);
        Assert.Equal(DashboardMapLocationType.Geocoding, settings.LocationType);
        Assert.Null(settings.GeolocationColumnName);
    }
    
    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "MapVisualizationSettingsType",
              "LocationType" : 2,
              "GeolocationColumnName" : "LocationColumn",
              "MapType" : 0
            }
            """;

        var settings = new MapVisualizationSettings
        {
            LocationType = DashboardMapLocationType.LatitudeLongitudeFields,
            GeolocationColumnName = "LocationColumn",
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}