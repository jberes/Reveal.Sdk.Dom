using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class StepAreaChartVisualizationExtensions
    {
        public static StepAreaChartVisualization ConfigureSettings(this StepAreaChartVisualization visualization, Action<StepAreaChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<StepAreaChartVisualization, StepAreaChartVisualizationSettings>(settings);
        }
    }
}
