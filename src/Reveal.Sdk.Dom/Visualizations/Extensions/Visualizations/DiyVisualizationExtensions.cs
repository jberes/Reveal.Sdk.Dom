namespace Reveal.Sdk.Dom.Visualizations
{
    public static class DiyVisualizationExtensions
    {
        public static DiyVisualization SetUrl(this DiyVisualization visualization, string url)
        {
            visualization.Url = url;
            return visualization;
        }
    }
}
