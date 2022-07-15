using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ScatterVisualizationExtensions
    {
        public static ScatterVisualization ConfigureSettings(this ScatterVisualization visualization, Action<ScatterVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<ScatterVisualization, ScatterVisualizationSettings>(settings);
        }
    }
}
