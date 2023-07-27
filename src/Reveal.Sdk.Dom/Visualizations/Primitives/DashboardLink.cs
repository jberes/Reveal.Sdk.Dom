using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class DashboardLink : VisualizationLinkBase
    {
        public DashboardLink()
        {
            Type = LinkType.OpenDashboard;
        }

        public DashboardLink(string title, string dashboard) : this()
        {
            Title = title;
            Dashboard = dashboard;
        }

        /// <summary>
        /// The dashboard id of the link.
        /// </summary>
        [JsonProperty("Url")]
        public string Dashboard { get; set; }
    }
}
