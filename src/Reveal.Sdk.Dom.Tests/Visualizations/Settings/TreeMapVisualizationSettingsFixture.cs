using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class TreeMapVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new TreeMapVisualizationSettings();

        // Assert
        Assert.Equal(SchemaTypeNames.TreeMapVisualizationSettingsType, settings.SchemaTypeName);
        Assert.Equal(VisualizationTypes.TREE_MAP, settings.VisualizationType);
        Assert.Null(settings.StartColorIndex);
        Assert.True(settings.ShowValues);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type": "TreeMapVisualizationSettingsType",
              "VisualizationType": "TREE_MAP",
              "BrushOffsetIndex": 3,
              "ShowValues": false
            }
            """;

        var settings = new TreeMapVisualizationSettings
        {
            StartColorIndex = 3,
            ShowValues = false
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}