using Reveal.Sdk.Dom.Visualizations.Primitives;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ISingleValueLabelsVisualizationExtensions
    {
        public static T AddLabel<T>(this T visualization, string labelField)
            where T : ISingleValueLabelsVisualization
        {
            var field = new SummarizationRegularField(labelField);
            visualization.AddLabel(field);
            return visualization;
        }

        public static T AddLabel<T>(this T visualization, SummarizationDimensionField labelField)
            where T : ISingleValueLabelsVisualization
        {
            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = labelField
            });
            return visualization;
        }

        public static T AddValue<T>(this T visualization, string value)
            where T : ISingleValueLabelsVisualization
        {
            visualization.Values.Add(new MeasureColumnSpec() { SummarizationField = new SummarizationValueField(value) });
            return visualization;
        }

        public static T AddValue<T>(this T visualization, SummarizationValueField value)
            where T : ISingleValueLabelsVisualization
        {
            visualization.Values.Add(new MeasureColumnSpec() { SummarizationField = value });
            return visualization;
        }
    }
}
