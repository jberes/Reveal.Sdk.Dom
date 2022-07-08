using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ColumnChartVisualizationExtensions
    {
        public static ColumnChartVisualization ConfigureSettings(this ColumnChartVisualization visualization, Action<ColumnChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<ColumnChartVisualization, ColumnChartVisualizationSettings>(settings);
        }
    }
}