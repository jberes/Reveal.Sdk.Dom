using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class PivotVisualizationExtensions
    {
        public static PivotVisualization ConfigureSettings(this PivotVisualization visualization, Action<PivotVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<PivotVisualization, PivotVisualizationSettings>(settings);
        }
    }
}