using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class CustomVisualizationSettings : VisualizationSettings
    {
        [JsonProperty]
        internal string Title { get; set; }

        [JsonProperty]
        internal string Url { get; set; }

        public CustomVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.DiyVisualizationSettingsType;
            VisualizationType = VisualizationTypes.JS_EXTENSION;
        }
    }
}
