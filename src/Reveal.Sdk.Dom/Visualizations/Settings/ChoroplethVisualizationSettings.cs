using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class ChoroplethVisualizationSettings : MapVisualizationSettingsBase
    {
        public ChoroplethVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.ChoroplethMapVisualizationSettingsType;
            VisualizationType = VisualizationTypes.CHOROPLETH_MAP;
        }

        /// <summary>
        /// Gets or sets how the map color will be applied to regions that contain data.
        /// </summary>
        [JsonProperty("ColorizationStyle")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MapColorStyle ColorStyle { get; set; } = MapColorStyle.RangeOfValues;

        /// <summary>
        /// Gets or sets whether labels will be displayed on the regions.
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public MapLabelVisibility LabelVisibility { get; set; } = MapLabelVisibility.HasValues;

        /// <summary>
        /// Gets or sets whether the labels are displayed as abbrevaited geographical names, or as values.
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public MapLabelStyle LabelStyle { get; set; } = MapLabelStyle.LocationAbbreviation;
        
        /// <summary>
        /// Gets or sets the language locale to use for the map.
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public MapDataLocale DataLocale { get; set; } = MapDataLocale.English;
    }
}
