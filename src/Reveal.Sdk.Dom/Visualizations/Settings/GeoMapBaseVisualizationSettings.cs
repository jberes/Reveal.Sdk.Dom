using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class GeoMapBaseVisualizationSettings : VisualizationSettings
    {
        [JsonProperty]
        public bool ShowLegends { get; set; } = true;

        [JsonProperty]
        internal string Region { get; set; }

        [JsonProperty]
        internal int? ColorIndex { get; set; } = -1;

        public GeoMapBaseVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.GeoMapBaseVisualizationSettingsType;
        }
    }
}
