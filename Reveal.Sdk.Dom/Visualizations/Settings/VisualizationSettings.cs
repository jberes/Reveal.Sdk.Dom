using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class VisualizationSettings : SchemaType
    {
        [JsonProperty]
        internal string VisualizationType { get; set; }
    }
}
