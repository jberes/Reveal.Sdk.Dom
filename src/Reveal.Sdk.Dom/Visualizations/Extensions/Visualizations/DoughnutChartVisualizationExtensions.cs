using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class DoughnutChartVisualizationExtensions
    {
        /// <summary>
        /// Configures the available settings for the <see cref="DoughnutChartVisualization"/>.
        /// </summary>
        /// <param name="visualization">The <see cref="DoughnutChartVisualization"/>.</param>
        /// <param name="settings">The <see cref="DoughnutChartVisualizationSettings"/> that will be applied to the <see cref="DoughnutChartVisualization"/>.</param>
        /// <returns>The <see cref="DoughnutChartVisualization"/>.</returns>
        public static DoughnutChartVisualization ConfigureSettings(this DoughnutChartVisualization visualization, Action<DoughnutChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<DoughnutChartVisualization, DoughnutChartVisualizationSettings>(settings);
        }
    }
}