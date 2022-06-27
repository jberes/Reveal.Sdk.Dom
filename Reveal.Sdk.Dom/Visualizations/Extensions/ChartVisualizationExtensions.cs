using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ChartVisualizationExtensions
    {
        public static BarChartVisualization ConfigureSettings(this BarChartVisualization visualization, Action<BarChartVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }

        public static ColumnChartVisualization ConfigureSettings(this ColumnChartVisualization visualization, Action<ColumnChartVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }

        public static LineChartVisualization ConfigureSettings(this LineChartVisualization visualization, Action<LineChartVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }

        public static SplineAreaChartVisualization ConfigureSettings(this SplineAreaChartVisualization visualization, Action<SplineAreaChartVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }

        public static StackedColumnChartVisualization ConfigureSettings(this StackedColumnChartVisualization visualization, Action<StackedColumnChartVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }
    }
}
