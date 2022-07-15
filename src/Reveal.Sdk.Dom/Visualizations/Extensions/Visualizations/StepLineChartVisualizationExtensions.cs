using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class StepLineChartVisualizationExtensions
    {
        public static StepLineChartVisualization ConfigureSettings(this StepLineChartVisualization visualization, Action<StepLineChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<StepLineChartVisualization, StepLineChartVisualizationSettings>(settings);
        }
    }
}
