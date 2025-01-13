using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class TextVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new TextVisualizationSettings();

        // Assert
        Assert.Equal(3, settings.GaugeBands.Count);
        Assert.Contains(settings.UpperBand, settings.GaugeBands);
        Assert.Contains(settings.MiddleBand, settings.GaugeBands);
        Assert.Contains(settings.LowerBand, settings.GaugeBands);
        Assert.Equal(GaugeViewType.SingleValue, settings.ViewType);
        Assert.Equal(ValueComparisonType.Number, settings.UpperBand.ValueComparisonType);
        Assert.Equal(ValueComparisonType.Number, settings.MiddleBand.ValueComparisonType);
        Assert.Equal(ValueComparisonType.Number, settings.LowerBand.ValueComparisonType);
        Assert.False(settings.ConditionalFormattingEnabled);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "GaugeVisualizationSettingsType",
              "SingleValueFormattingEnabled" : true,
              "ViewType" : "SingleValue",
              "GaugeBands" : [ {
                "_type" : "GaugeBandType",
                "Shape" : "Circle",
                "Type" : "NumberValue",
                "Color" : "Green",
                "Value" : 80.0
              }, {
                "_type" : "GaugeBandType",
                "Shape" : "Circle",
                "Type" : "NumberValue",
                "Color" : "Yellow",
                "Value" : 50.0
              }, {
                "_type" : "GaugeBandType",
                "Shape" : "Circle",
                "Type" : "NumberValue",
                "Color" : "Red"
              } ],
              "VisualizationType" : "GAUGE"
            }
            """;

        var settings = new TextVisualizationSettings
        {
            ConditionalFormattingEnabled = true
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}