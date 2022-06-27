using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class KpiTargetVisualizationExtensions
    {
        public static KpiTargetVisualization ConfigureSettings(this KpiTargetVisualization visualization, Action<KpiTargetVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }
    }
}
