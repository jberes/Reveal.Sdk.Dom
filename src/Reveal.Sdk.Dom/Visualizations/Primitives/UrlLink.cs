namespace Reveal.Sdk.Dom.Visualizations
{
    public class UrlLink : VisualizationLinkBase
    {
        public UrlLink()
        {
            Type = LinkType.OpenUrl;
        }

        public UrlLink(string title, string url) : this()
        {
            Title = title;
            Url = url;
        }

        /// <summary>
        /// The URL of the link.
        /// </summary>
        public string Url { get; set; }
    }
}
