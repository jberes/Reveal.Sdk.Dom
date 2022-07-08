using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class IndicatorVisualizationSettings : VisualizationSettings
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public IndicatorDifferenceMode DifferenceMode { get; set; } = IndicatorDifferenceMode.Percentage;
        public bool PositiveIsRed { get; set; }
        public bool IncludeToday { get; set; } = true;

        public IndicatorVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.IndicatorVisualizationSettingsType;
            VisualizationType = VisualizationTypes.INDICATOR;
        }
    }
}
