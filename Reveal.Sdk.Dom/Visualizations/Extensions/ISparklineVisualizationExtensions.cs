using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ISparklineVisualizationExtensions
    {
        public static T AddCategory<T>(this T visualization, string category)
            where T : ISparklineVisualization
        {
            visualization.AddCategory(new SummarizationRegularField(category));
            return visualization;
        }

        public static T AddCategory<T>(this T visualization, SummarizationDimensionField category)
            where T : ISparklineVisualization
        {
            visualization.Categories.Add(new DimensionColumnSpec() { SummarizationField = category });
            return visualization;
        }

        public static T AddDate<T>(this T visualization, string dateField)
            where T : ISparklineVisualization
        {
            visualization.AddDate(new SummarizationDateField(dateField));
            return visualization;
        }

        public static T AddDate<T>(this T visualization, SummarizationDateField dateField)
            where T : ISparklineVisualization
        {
            visualization.Date = new DimensionColumnSpec() { SummarizationField = dateField };
            return visualization;
        }

        public static T AddValue<T>(this T visualization, string value)
            where T : ISparklineVisualization
        {
            visualization.Values.Add(new MeasureColumnSpec() { SummarizationField = new SummarizationValueField(value) });
            return visualization;
        }

        public static T AddValue<T>(this T visualization, SummarizationValueField value)
            where T : ISparklineVisualization
        {
            visualization.Values.Add(new MeasureColumnSpec() { SummarizationField = value });
            return visualization;
        }

        public static T AddValues<T>(this T visualization, params string[] values)
            where T : ISparklineVisualization
        {
            foreach (var value in values)
            {
                visualization.AddValue(value);
            }
            return visualization;
        }

        public static T AddValues<T>(this T visualization, params SummarizationValueField[] values)
            where T : ISparklineVisualization
        {
            foreach (var value in values)
            {
                visualization.AddValue(value);
            }
            return visualization;
        }

        public static SparklineVisualization ConfigureSettings(this SparklineVisualization visualization, Action<SparklineVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
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
