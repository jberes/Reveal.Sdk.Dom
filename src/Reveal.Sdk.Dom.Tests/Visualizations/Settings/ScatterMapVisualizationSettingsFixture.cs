using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class ScatterMapVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new ScatterMapVisualizationSettings();

        // Assert
        Assert.Equal(SchemaTypeNames.ScatterMapVisualizationSettingsType, settings.SchemaTypeName);
        Assert.Equal(VisualizationTypes.SCATTER_MAP, settings.VisualizationType);
        Assert.NotNull(settings.ConditionalFormatting);
        Assert.Equal(MapColorMode.RangeOfValues, settings.ColorMode);
        Assert.Equal(3, settings.ImageTileZoomLevel);
        Assert.True(settings.ShowImageTiles);
        Assert.False(settings.UseDifferentMarkers);
        Assert.NotNull(settings.Zoom);
        Assert.Equal(-1, settings.ColorIndex);
        Assert.Null(settings.Region);
        Assert.True(settings.ShowLegend);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "ScatterMapVisualizationSettingsType",
              "ConditionalFormatting" : {
                "Bands" : [ {
                  "_type" : "ConditionalFormattingBandType",
                  "Type" : "Percentage",
                  "Color" : "Green",
                  "Value" : 80.0
                }, {
                  "_type" : "ConditionalFormattingBandType",
                  "Type" : "Percentage",
                  "Color" : "Yellow",
                  "Value" : 50.0
                }, {
                  "_type" : "ConditionalFormattingBandType",
                  "Type" : "Percentage",
                  "Color" : "Red"
                } ]
              },
              "ColorizationMode" : "Range",
              "ZoomThreshold" : 3,
              "ShowTileSource" : true,
              "UseDifferentMarkers" : false,
              "ZoomRectangle" : {
                "X" : 0.0,
                "Y" : 0.0,
                "Width" : 0.0,
                "Height" : 0.0
              },
              "ShowLegends" : true,
              "ColorIndex" : -1,
              "VisualizationType" : "SCATTER_MAP"
            }
            """;

        var settings = new ScatterMapVisualizationSettings
        {
            ColorMode = MapColorMode.RangeOfValues,
            ImageTileZoomLevel = 3,
            ShowImageTiles = true
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}