using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class RadialVisualizationExtensions
    {
        public static RadialVisualization ConfigureSettings(this RadialVisualization visualization, Action<RadialVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<RadialVisualization, RadialVisualizationSettings>(settings);
        }
    }
}
