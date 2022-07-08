using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class AssetVisualizationSettings : VisualizationSettings
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ContentMode ContentMode { get; set; } = ContentMode.AspectFit;
        public bool ZoomEnabled { get; set; }
        public string UrlColumn { get; set; }

        public AssetVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.AssetVisualizationSettingsType;
            VisualizationType = VisualizationTypes.IMAGE;
        }
    }
}
