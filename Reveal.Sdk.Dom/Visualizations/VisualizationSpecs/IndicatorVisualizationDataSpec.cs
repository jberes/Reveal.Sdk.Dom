using Reveal.Sdk.Dom.Core.Constants;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    public class IndicatorVisualizationDataSpec : IndicatorBaseVisualizationDataSpec
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public IndicatorVisualizationType IndicatorType { get; set; } = IndicatorVisualizationType.YearToDatePreviousYear;

        public IndicatorVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.IndicatorVisualizationDataSpecType;
        }
    }
}
