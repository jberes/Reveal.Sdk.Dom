using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class BarChartVisualizationExtensions
    {
        public static BarChartVisualization ConfigureSettings(this BarChartVisualization visualization, Action<BarChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<BarChartVisualization, BarChartVisualizationSettings>(settings);
        }
    }
}