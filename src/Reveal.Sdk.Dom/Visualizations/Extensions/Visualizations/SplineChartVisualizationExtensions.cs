using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class SplineChartVisualizationExtensions
    {
        public static SplineChartVisualization ConfigureSettings(this SplineChartVisualization visualization, Action<SplineChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<SplineChartVisualization, SplineChartVisualizationSettings>(settings);
        }
    }
}