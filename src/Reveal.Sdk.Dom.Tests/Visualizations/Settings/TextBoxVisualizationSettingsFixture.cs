using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class TextBoxVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new TextBoxVisualizationSettings();

        // Assert
        Assert.Equal(SchemaTypeNames.TextBoxVisualizationSettingsType, settings.SchemaTypeName);
        Assert.Equal(VisualizationTypes.TEXT_BOX, settings.VisualizationType);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type": "TextBoxVisualizationSettingsType",
              "VisualizationType": "TEXT_BOX"
            }
            """;

        var settings = new TextBoxVisualizationSettings();

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}