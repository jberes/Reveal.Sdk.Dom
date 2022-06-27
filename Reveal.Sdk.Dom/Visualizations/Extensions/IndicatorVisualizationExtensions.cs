using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IndicatorVisualizationExtensions
    {
        public static IndicatorVisualization ConfigureSettings(this IndicatorVisualization visualization, Action<IndicatorVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }
    }
}
