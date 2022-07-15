using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class FunnelChartVisualizationExtensions
    {
        /// <summary>
        /// Configures the available settings for the <see cref="FunnelChartVisualization"/>.
        /// </summary>
        /// <param name="visualization">The <see cref="FunnelChartVisualization"/>.</param>
        /// <param name="settings">The <see cref="FunnelChartVisualizationSettings"/> that will be applied to the <see cref="FunnelChartVisualization"/>.</param>
        /// <returns>The <see cref="FunnelChartVisualization"/>.</returns>
        public static FunnelChartVisualization ConfigureSettings(this FunnelChartVisualization visualization, Action<FunnelChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<FunnelChartVisualization, FunnelChartVisualizationSettings>(settings);
        }
    }
}