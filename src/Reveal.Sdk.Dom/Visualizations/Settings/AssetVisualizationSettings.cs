using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class AssetVisualizationSettings : VisualizationSettings
    {
        public AssetVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.AssetVisualizationSettingsType;
            VisualizationType = VisualizationTypes.IMAGE;
        }
        
        //todo: not sure if this is used. doesn't appear to be, but needs confirmation
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        internal ContentMode ContentMode { get; set; } = ContentMode.AspectFit;

        //todo: not sure if this is used. doesn't appear to be, but needs confirmation
        [JsonProperty]
        internal bool ZoomEnabled { get; set; }
    }
}
