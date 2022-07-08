using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class TreeMapVisualizationExtensions
    {
        public static TreeMapVisualization ConfigureSettings(this TreeMapVisualization visualization, Action<TreeMapVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<TreeMapVisualization, TreeMapVisualizationSettings>(settings);
        }
    }
}