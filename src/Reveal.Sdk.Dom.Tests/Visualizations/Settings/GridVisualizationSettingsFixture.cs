using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class GridVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new GridVisualizationSettings();

        // Assert
        Assert.Equal(SchemaTypeNames.GridVisualizationSettingsType, settings.SchemaTypeName);
        Assert.Equal(VisualizationTypes.GRID, settings.VisualizationType);
        Assert.False(settings.IsPagingEnabled);
        Assert.Equal(50, settings.PageSize);
        Assert.False(settings.IsFirstColumnFixed);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "GridVisualizationSettingsType",
              "PagedRows" : true,
              "PagedRowsSize" : 25,
              "FontSize" : "Small",
              "Style" : {
                "FixedLeftColumns" : false,
                "TextAlignment" : "Left",
                "NumericAlignment" : "Right",
                "DateAlignment" : "Center"
              },
              "VisualizationType" : "GRID"
            }
            """;

        var settings = new GridVisualizationSettings
        {
            IsPagingEnabled = true,
            PageSize = 25,
            FontSize = FontSize.Small,
            DateFieldAlignment = Alignment.Center,
            NumericFieldAlignment = Alignment.Right,
            TextFieldAlignment = Alignment.Left,
            IsFirstColumnFixed = false
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }

    [Fact]
    public void IsFirstColumnFixed_SetAndGet_UpdatesValues()
    {
        // Arrange
        var settings = new GridVisualizationSettings();

        // Act
        settings.IsFirstColumnFixed = true;

        // Assert
        Assert.True(settings.IsFirstColumnFixed);
        Assert.True(settings.Style.FixedLeftColumns);
    }
}