using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class VisualizationLinker
    {
        /// <summary>
        /// The type of trigger that will activate the link.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LinkTriggerType Trigger { get; set; } = LinkTriggerType.SelectRow;

        /// <summary>
        /// The list of actions that represent links.
        /// </summary>
        [JsonProperty("Actions")]
        public List<IVisualizationLink> Links { get; set; } = new List<IVisualizationLink>();

        /// <summary>
        /// Adds a URL as a link.
        /// </summary>
        /// <param name="title">The title of the link</param>
        /// <param name="url">The URL to open</param>
        /// <returns>The VisualizationLinker instance</returns>
        public VisualizationLinker AddUrl(string title, string url)
        {
            Links.Add(new UrlLink
            {
                Type = LinkType.OpenUrl,
                Title = title,
                Url = url
            });

            return this;
        }

        /// <summary>
        /// Adds a dashboard as a link.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="dashboardId"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public VisualizationLinker AddDashboard(string title, string dashboardId, params LinkFilter[] filters)
        {
            Links.Add(new DashboardLink
            {
                Type = LinkType.OpenDashboard,
                Title = title,
                Dashboard = dashboardId,
                Filters = filters.ToList()
            });

            return this;
        }
    }
}
