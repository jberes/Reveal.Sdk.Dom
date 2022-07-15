using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class PieChartVisualizationExtensions
    {
        /// <summary>
        /// Configures the available settings for the <see cref="PieChartVisualization"/>.
        /// </summary>
        /// <param name="visualization">The <see cref="PieChartVisualization"/>.</param>
        /// <param name="settings">The <see cref="PieChartVisualizationSettings"/> that will be applied to the <see cref="PieChartVisualization"/>.</param>
        /// <returns>The <see cref="PieChartVisualization"/>.</returns>
        public static PieChartVisualization ConfigureSettings(this PieChartVisualization visualization, Action<PieChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<PieChartVisualization, PieChartVisualizationSettings>(settings);
        }
    }
}