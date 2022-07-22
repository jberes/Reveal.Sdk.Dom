namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ImageVisualizationExtensions
    {
        public static ImageVisualization SetUrl(this ImageVisualization visualization, string field)
        {
            visualization.Url = new TabularColumn(field);
            return visualization;
        }
    }
}