using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class KpiTargetVisualizationExtensions
    {
        public static KpiTargetVisualization ConfigureSettings(this KpiTargetVisualization visualization, Action<KpiTargetVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<KpiTargetVisualization, KpiTargetVisualizationSettings>(settings);
        }
    }
}
