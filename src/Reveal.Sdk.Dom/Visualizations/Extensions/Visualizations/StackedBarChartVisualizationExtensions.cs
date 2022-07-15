using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class StackedBarChartVisualizationExtensions
    {
        public static StackedBarChartVisualization ConfigureSettings(this StackedBarChartVisualization visualization, Action<StackedBarChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<StackedBarChartVisualization, StackedBarChartVisualizationSettings>(settings);
        }
    }
}
