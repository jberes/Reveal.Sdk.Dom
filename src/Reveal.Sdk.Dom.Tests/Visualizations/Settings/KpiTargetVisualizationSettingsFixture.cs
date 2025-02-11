using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class KpiTargetVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new KpiTargetVisualizationSettings();

        // Assert
        Assert.Equal(SchemaTypeNames.IndicatorTargetVisualizationSettingsType, settings.SchemaTypeName);
        Assert.Equal(VisualizationTypes.INDICATOR_TARGET, settings.VisualizationType);
        Assert.Null(settings.VisualizationDataSpec);
    }

    [Fact]
    public void GoalPeriod_SetAndGet_UpdatesVisualizationDataSpec()
    {
        // Arrange
        var settings = new KpiTargetVisualizationSettings
        {
            VisualizationDataSpec = new IndicatorTargetVisualizationDataSpec()
        };

        // Act
        settings.GoalPeriod = KpiGoalPeriod.ThisQuarter;

        // Assert
        Assert.Equal(KpiGoalPeriod.ThisQuarter, settings.GoalPeriod);
        Assert.Equal(KpiGoalPeriod.ThisQuarter, settings.VisualizationDataSpec.DateFilterType);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "IndicatorTargetVisualizationSettingsType",
              "DifferenceMode" : "Percentage",
              "PositiveIsRed" : false,
              "IncludeToday" : true,
              "VisualizationType" : "INDICATOR_TARGET"
            }
            """;

        var settings = new KpiTargetVisualizationSettings
        {
            VisualizationDataSpec = new IndicatorTargetVisualizationDataSpec(),
            DifferenceMode = IndicatorDifferenceMode.Percentage,
            PositiveIsRed = false,
            IncludeToday = true,
            GoalPeriod = KpiGoalPeriod.PreviousQuarter,
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}