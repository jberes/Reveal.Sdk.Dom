using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class SparklineVisualizationExtensions
    {
        public static SparklineVisualization ConfigureSettings(this SparklineVisualization visualization, Action<SparklineVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<SparklineVisualization, SparklineVisualizationSettings>(settings);
        }
    }
}
