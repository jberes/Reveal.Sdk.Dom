namespace Reveal.Sdk.Dom.Visualizations
{
    public static class CustomVisualizationExtensions
    {
        public static CustomVisualization SetUrl(this CustomVisualization visualization, string url)
        {
            visualization.Url = url;
            return visualization;
        }
    }
}
