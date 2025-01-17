using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class KpiTimeVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new KpiTimeVisualizationSettings();

        // Assert
        Assert.Equal(SchemaTypeNames.IndicatorVisualizationSettingsType, settings.SchemaTypeName);
        Assert.Equal(VisualizationTypes.INDICATOR, settings.VisualizationType);
        Assert.Null(settings.VisualizationDataSpec);
    }

    [Theory]
    [InlineData(KpiTimePeriod.MonthToDatePreviousMonth, IndicatorVisualizationType.MonthToDatePreviousMonth)]
    [InlineData(KpiTimePeriod.MonthToDatePreviousYear, IndicatorVisualizationType.MonthToDatePreviousYear)]
    [InlineData(KpiTimePeriod.QuarterToDatePreviousQuarter, IndicatorVisualizationType.QuarterToDatePreviousQuarter)]
    [InlineData(KpiTimePeriod.QuarterToDatePreviousYear, IndicatorVisualizationType.QuarterToDatePreviousYear)]
    [InlineData(KpiTimePeriod.YearToDatePreviousYear, IndicatorVisualizationType.YearToDatePreviousYear)]
    internal void TimePeriod_SetAndGet_UpdatesVisualizationDataSpec(
        KpiTimePeriod timePeriod,
        IndicatorVisualizationType expectedIndicatorType)
    {
        // Arrange
        var settings = new KpiTimeVisualizationSettings
        {
            VisualizationDataSpec = new IndicatorVisualizationDataSpec()
        };

        // Act
        settings.TimePeriod = timePeriod;

        // Assert
        Assert.Equal(timePeriod, settings.TimePeriod);
        Assert.Equal(expectedIndicatorType, settings.VisualizationDataSpec.IndicatorType);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "IndicatorVisualizationSettingsType",
              "DifferenceMode" : "ValueAndPercentage",
              "PositiveIsRed" : false,
              "IncludeToday" : true,
              "VisualizationType" : "INDICATOR"
            }
            """;

        var settings = new KpiTimeVisualizationSettings
        {
            VisualizationDataSpec = new IndicatorVisualizationDataSpec(),
            DifferenceMode = IndicatorDifferenceMode.ValueAndPercentage,
            PositiveIsRed = false,
            IncludeToday = true,
            TimePeriod = KpiTimePeriod.QuarterToDatePreviousYear
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}