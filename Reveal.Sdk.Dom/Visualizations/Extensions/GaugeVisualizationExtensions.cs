using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System;
using System.Collections.Generic;

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

        public static CircularGaugeVisualization ConfigureBands(this CircularGaugeVisualization visualization, Action<IList<GaugeBand>> bands)
        {
            bands.Invoke(visualization.Bands);
            return visualization;
        }
    }
}
