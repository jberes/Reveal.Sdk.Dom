using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class GaugeVisualizationExtensions
    {
        public static BulletGraphVisualization ConfigureSettings(this BulletGraphVisualization visualization, Action<BulletGraphVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<BulletGraphVisualization, BulletGraphVisualizationSettings>(settings);
        }

        public static CircularGaugeVisualization ConfigureSettings(this CircularGaugeVisualization visualization, Action<CircularGaugeVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<CircularGaugeVisualization, CircularGaugeVisualizationSettings>(settings);
        }

        public static LinearGaugeVisualization ConfigureSettings(this LinearGaugeVisualization visualization, Action<LinearGaugeVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<LinearGaugeVisualization, LinearGaugeVisualizationSettings>(settings);
        }

        public static TextVisualization ConfigureSettings(this TextVisualization visualization, Action<TextVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<TextVisualization, TextVisualizationSettings>(settings);
        }
    }
}
