using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class ChoroplethMapVisualizationSettings : GeoMapBaseVisualizationSettings
    {
        [JsonProperty]
        internal string ColorizationStyle { get; set; }

        [JsonProperty]
        internal bool IncludeAdjacentShapes { get; set; } = true;

        [JsonProperty]
        internal string LabelVisibility { get; set; } = "VALUES ONLY"; //todo: enum or constant here?

        [JsonProperty]
        internal string LabelStyle { get; set; } = "ABBREVIATION"; //todo: enum or constant here?

        [JsonProperty]
        internal ChoroplethMapColorType ColorBasedOn { get; set; } = ChoroplethMapColorType.Highest;

        [JsonProperty]
        internal string DataLocale { get; set; }

        [JsonProperty]
        internal List<string> Regions { get; set; } = new List<string>();

        public ChoroplethMapVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.ChoroplethMapVisualizationSettingsType;
        }
    }
}
