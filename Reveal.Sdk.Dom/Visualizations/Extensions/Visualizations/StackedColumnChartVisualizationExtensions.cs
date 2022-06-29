using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class StackedColumnChartVisualizationExtensions
    {
        public static StackedColumnChartVisualization ConfigureSettings(this StackedColumnChartVisualization visualization, Action<StackedColumnChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<StackedColumnChartVisualization, StackedColumnChartVisualizationSettings>(settings);
        }
    }
}
