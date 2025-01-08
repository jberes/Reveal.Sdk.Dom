using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class GridVisualizationSettingsBaseFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInitializing()
    {
        // Act
        var settings = new TestGridVisualizationSettings();

        // Assert
        Assert.NotNull(settings);
        Assert.Equal(default(FontSize), settings.FontSize);
        Assert.NotNull(settings.Style);
        Assert.Equal(default(Alignment), settings.DateFieldAlignment);
        Assert.Equal(default(Alignment), settings.NumericFieldAlignment);
        Assert.Equal(default(Alignment), settings.TextFieldAlignment);
        Assert.Null(settings.SchemaTypeName);
        Assert.Null(settings.VisualizationType);
    }


    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson = 
            """
            {
              "_type" : null,
              "FontSize" : "Large",
              "Style" : {
                "FixedLeftColumns" : false,
                "TextAlignment" : "Left",
                "NumericAlignment" : "Right",
                "DateAlignment" : "Center"
              },
              "VisualizationType" : null
            }
            """;

        var settings = new TestGridVisualizationSettings
        {
            FontSize = FontSize.Large,
            DateFieldAlignment = Alignment.Center,
            NumericFieldAlignment = Alignment.Right,
            TextFieldAlignment = Alignment.Left
        };

        // Act
        var actualJson = JsonConvert.SerializeObject(settings);
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
    
    private class TestGridVisualizationSettings : GridVisualizationSettingsBase
    {
        public TestGridVisualizationSettings() : base() { }
    }
}