using Newtonsoft.Json;
using System.Collections.Generic;
using Reveal.Sdk.Dom.Core.Serialization.Converters;

namespace Reveal.Sdk.Dom.Visualizations
{
    [JsonConverter(typeof(VisualizationLinkConverter))]
    public interface IVisualizationLink
    {
        /// <summary>
        /// The list of filters that will be applied to the target dashboard.
        /// </summary>
        List<LinkFilter> Filters { get; set; }

        /// <summary>
        /// The title of the link.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// The type of the link.
        /// </summary>
        LinkType Type { get; set; }
    }
}
