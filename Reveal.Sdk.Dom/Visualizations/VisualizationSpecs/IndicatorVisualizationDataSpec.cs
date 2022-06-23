using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    public class IndicatorVisualizationDataSpec : IndicatorBaseVisualizationDataSpec
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public IndicatorVisualizationType IndicatorType { get; set; } = IndicatorVisualizationType.YearToDatePreviousYear;

        public IndicatorVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.IndicatorVisualizationDataSpecType;
        }
    }
}
