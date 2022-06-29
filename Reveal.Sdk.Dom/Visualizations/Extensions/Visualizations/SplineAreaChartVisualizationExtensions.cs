using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class SplineAreaChartVisualizationExtensions
    {
        public static SplineAreaChartVisualization ConfigureSettings(this SplineAreaChartVisualization visualization, Action<SplineAreaChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<SplineAreaChartVisualization, SplineAreaChartVisualizationSettings>(settings);
        }
    }
}