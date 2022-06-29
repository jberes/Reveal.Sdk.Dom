using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class AreaChartVisualizationExtensions
    {
        public static AreaChartVisualization ConfigureSettings(this AreaChartVisualization visualization, Action<AreaChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<AreaChartVisualization, AreaChartVisualizationSettings>(settings);
        }
    }
}