using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class GaugeVisualizationExtensions
    {
        public static BulletGraphVisualization ConfigureSettings(this BulletGraphVisualization visualization, Action<BulletGraphVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }

        public static CircularGaugeVisualization ConfigureSettings(this CircularGaugeVisualization visualization, Action<CircularGaugeVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }

        public static LinearGaugeVisualization ConfigureSettings(this LinearGaugeVisualization visualization, Action<LinearGaugeVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }

        public static TextVisualization ConfigureSettings(this TextVisualization visualization, Action<TextVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }
    }
}
