using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ICategoryVisualizationExtensions
    {
        public static T AddLabel<T>(this T visualization, string labelField)
            where T : ICategoryVisualization
        {
            var field = new SummarizationRegularField(labelField);
            visualization.AddLabel(field);
            return visualization;
        }

        public static T AddLabel<T>(this T visualization, SummarizationDimensionField labelField)
            where T : ICategoryVisualization
        {
            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = labelField
            });
            return visualization;
        }

        public static T AddValue<T>(this T visualization, string valueFied)
            where T : ICategoryVisualization
        {
            var value = new SummarizationValueField(valueFied);
            visualization.AddValue(value);
            return visualization;
        }

        public static T AddValue<T>(this T visualization, SummarizationValueField valueFied)
            where T : ICategoryVisualization
        {
            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = valueFied
            });
            return visualization;
        }

        public static T AddValues<T>(this T visualization, params string[] valueFieds)
            where T : ICategoryVisualization
        {
            foreach (var valueFied in valueFieds)
            {
                var value = new SummarizationValueField(valueFied);
                visualization.AddValue(value);
            }
            return visualization;
        }

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
