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

        public static SparklineVisualization SetIndicatorType(this SparklineVisualization visualization, IndicatorVisualizationType indicatorVisualizationType)
        {
            visualization.IndicatorType = indicatorVisualizationType;
            return visualization;
        }

        public static SparklineVisualization SetNumberOfPeriods(this SparklineVisualization visualization, int numberOfPeriods)
        {
            visualization.NumberOfPeriods = numberOfPeriods;
            return visualization;
        }

        public static SparklineVisualization SetShowIndicator(this SparklineVisualization visualization, bool showIndicator)
        {
            visualization.ShowIndicator = showIndicator;
            return visualization;
        }
    }
}
