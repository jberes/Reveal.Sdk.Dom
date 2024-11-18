using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class GridVisualizationExtensions
    {
        public static GridVisualization ConfigureSettings(this GridVisualization visualization, Action<GridVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<GridVisualization, GridVisualizationSettings>(settings);
        }
    }
}