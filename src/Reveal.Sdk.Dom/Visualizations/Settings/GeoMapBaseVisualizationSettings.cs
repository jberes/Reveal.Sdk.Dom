using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public abstract class MapVisualizationSettingsBase : VisualizationSettings
    {
        /// <summary>
        /// Gets or sets if the map legend is displayed.
        /// </summary>
        [JsonProperty("ShowLegends")]
        public bool ShowLegend { get; set; } = true;

        //this property is part of the JSON schema, but wrapped by the Visualization as it's not set in the settings
        [JsonProperty]
        internal string Region { get; set; }

        /// <summary>
        /// Gets or sets the color index as a base of the map's color scheme. A zero-based index is used to set colors instead of a color name.
        /// For example, an index of 5 would be the 6th color in the color scheme regardless of the theme colors being used.
        /// </summary>
        [JsonProperty]
        public int ColorIndex { get; set; } = -1;

        public MapVisualizationSettingsBase()
        {
            SchemaTypeName = SchemaTypeNames.GeoMapBaseVisualizationSettingsType;
        }
    }
}
