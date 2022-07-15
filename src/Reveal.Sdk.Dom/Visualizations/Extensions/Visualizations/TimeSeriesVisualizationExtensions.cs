using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class TimeSeriesVisualizationExtensions
    {
        public static TimeSeriesVisualization ConfigureSettings(this TimeSeriesVisualization visualization, Action<TimeSeriesVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<TimeSeriesVisualization, TimeSeriesVisualizationSettings>(settings);
        }
    }
}
