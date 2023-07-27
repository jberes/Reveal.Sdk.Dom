using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class VisualizationLinkBase : IVisualizationLink
    {
        ///<inheritdoc/>
        [JsonProperty("Parameters")]
        public List<LinkFilter> Filters { get; set; } = new List<LinkFilter>();

        ///<inheritdoc/>
        public string Title { get; set; }

        ///<inheritdoc/>
        [JsonConverter(typeof(StringEnumConverter))]
        public LinkType Type { get; set; } = LinkType.OpenDashboard;
    }
}
