using Reveal.Sdk.Dom.Visualizations.Primitives;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IIndicatorExtensions
    {
        public static T AddDate<T>(this T visualization, string dateField)
            where T : IIndicatorVisualization
        {
            visualization.AddDate(new SummarizationDateField(dateField));
            return visualization;
        }

        public static T AddDate<T>(this T visualization, SummarizationDateField dateField)
            where T : IIndicatorVisualization
        {
            visualization.Date = new DimensionColumnSpec() { SummarizationField = dateField };
            return visualization;
        }

        public static T AddValue<T>(this T visualization, string value)
            where T : IIndicatorVisualization
        {
            visualization.Values.Add(new MeasureColumnSpec() { SummarizationField = new SummarizationValueField(value) });
            return visualization;
        }

        public static T AddValue<T>(this T visualization, SummarizationValueField value)
            where T : IIndicatorVisualization
        {
            visualization.Values.Add(new MeasureColumnSpec() { SummarizationField = value });
            return visualization;
        }

        public static T AddValues<T>(this T visualization, params string[] values)
            where T : IIndicatorVisualization
        {
            foreach (var value in values)
            {
                visualization.AddValue(value);
            }
            return visualization;
        }

        public static T AddValues<T>(this T visualization, params SummarizationValueField[] values)
            where T : IIndicatorVisualization
        {
            foreach (var value in values)
            {
                visualization.AddValue(value);
            }
            return visualization;
        }
    }
}
