using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class DIYVisualizationSettings : VisualizationSettings
    {
        //todo: this seems useless
        [JsonProperty]
        internal string Title { get; set; }

        [JsonProperty]
        internal string Url { get; set; }

        public DIYVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.DiyVisualizationSettingsType;
            VisualizationType = VisualizationTypes.JS_EXTENSION;
        }
    }
}
