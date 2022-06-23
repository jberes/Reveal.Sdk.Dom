using Reveal.Sdk.Dom.Core;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class VisualizationSettings : SchemaType
    {
        [JsonInclude]
        public string VisualizationType { get; internal set; }
    }
}
