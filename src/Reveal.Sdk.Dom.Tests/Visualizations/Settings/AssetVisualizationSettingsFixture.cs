using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class AssetVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new AssetVisualizationSettings();

        // Assert
        Assert.Equal(SchemaTypeNames.AssetVisualizationSettingsType, settings.SchemaTypeName);
        Assert.Equal(VisualizationTypes.IMAGE, settings.VisualizationType);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type": "AssetVisualizationSettingsType",
              "VisualizationType": "IMAGE"
            }
            """;

        var settings = new AssetVisualizationSettings();

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}