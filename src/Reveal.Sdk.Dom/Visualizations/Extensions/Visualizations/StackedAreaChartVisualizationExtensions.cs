using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class StackedAreaChartVisualizationExtensions
    {
        public static StackedAreaChartVisualization ConfigureSettings(this StackedAreaChartVisualization visualization, Action<StackedAreaChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<StackedAreaChartVisualization, StackedAreaChartVisualizationSettings>(settings);
        }
    }
}
