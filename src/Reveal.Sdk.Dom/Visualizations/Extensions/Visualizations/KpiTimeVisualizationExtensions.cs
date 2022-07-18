using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class KpiTimeVisualizationExtensions
    {
        public static KpiTimeVisualization ConfigureSettings(this KpiTimeVisualization visualization, Action<KpiTimeVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<KpiTimeVisualization, KpiTimeVisualizationSettings>(settings);
        }
    }
}
