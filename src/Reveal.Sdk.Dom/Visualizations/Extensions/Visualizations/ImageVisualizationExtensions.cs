using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ImageVisualizationExtensions
    {
        public static ImageVisualization ConfigureSettings(this ImageVisualization visualization, Action<AssetVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<ImageVisualization, AssetVisualizationSettings>(settings);
        }

        public static ImageVisualization SetUrlColumn(this ImageVisualization visualization, string field)
        {
            visualization.UrlColumn = new TabularColumn(field);
            return visualization;
        }
    }
}