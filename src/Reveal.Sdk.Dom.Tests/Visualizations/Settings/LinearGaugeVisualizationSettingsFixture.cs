using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class LinearGaugeVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new LinearGaugeVisualizationSettings();

        // Assert
        Assert.Equal(GaugeViewType.Linear, settings.ViewType);
        Assert.Null(settings.Minimum);
        Assert.Null(settings.Maximum);
        Assert.Equal(default(ValueComparisonType), settings.ValueComparisonType);

        Assert.NotNull(settings.UpperBand);
        Assert.Equal(80.0, settings.UpperBand.Value);
        Assert.Equal(BandColor.Green, settings.UpperBand.Color);

        Assert.NotNull(settings.MiddleBand);
        Assert.Equal(50.0, settings.MiddleBand.Value);
        Assert.Equal(BandColor.Yellow, settings.MiddleBand.Color);

        Assert.NotNull(settings.LowerBand);
        Assert.Null(settings.LowerBand.Value);
        Assert.Equal(BandColor.Red, settings.LowerBand.Color);

        Assert.NotNull(settings.GaugeBands);
        Assert.Contains(settings.UpperBand, settings.GaugeBands);
        Assert.Contains(settings.MiddleBand, settings.GaugeBands);
        Assert.Contains(settings.LowerBand, settings.GaugeBands);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "GaugeVisualizationSettingsType",
              "ViewType" : "Linear",
              "GaugeBands" : [ {
                "_type" : "GaugeBandType",
                "Type" : "Percentage",
                "Color" : "Green",
                "Value" : 80.0
              }, {
                "_type" : "GaugeBandType",
                "Type" : "Percentage",
                "Color" : "Yellow",
                "Value" : 50.0
              }, {
                "_type" : "GaugeBandType",
                "Type" : "Percentage",
                "Color" : "Red"
              } ],
              "VisualizationType" : "GAUGE"
            }
            """;

        var settings = new LinearGaugeVisualizationSettings();

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}