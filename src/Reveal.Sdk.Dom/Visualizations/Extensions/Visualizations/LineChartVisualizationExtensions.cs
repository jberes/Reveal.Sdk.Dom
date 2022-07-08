using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class LineChartVisualizationExtensions
    {
        public static LineChartVisualization ConfigureSettings(this LineChartVisualization visualization, Action<LineChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<LineChartVisualization, LineChartVisualizationSettings>(settings);
        }
    }
}