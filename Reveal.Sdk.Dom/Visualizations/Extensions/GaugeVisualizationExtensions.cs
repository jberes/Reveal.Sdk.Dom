using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class GaugeVisualizationExtensions
    {
        public static BulletGraphVisualization ConfigureSettings(this BulletGraphVisualization visualization, Action<GaugeVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }

        public static CircularGaugeVisualization ConfigureSettings(this CircularGaugeVisualization visualization, Action<GaugeVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }

        public static LinearGaugeVisualization ConfigureSettings(this LinearGaugeVisualization visualization, Action<GaugeVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }
    }
}
