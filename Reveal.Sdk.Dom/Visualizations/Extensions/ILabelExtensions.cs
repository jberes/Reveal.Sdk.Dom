using Reveal.Sdk.Dom.Visualizations.Primitives;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ILabelExtensions
    {
        public static T AddLabel<T>(this T visualization, string labelField)
            where T : ILabel
        {
            var field = new SummarizationRegularField(labelField);
            visualization.AddLabel(field);
            return visualization;
        }

        public static T AddLabel<T>(this T visualization, SummarizationDimensionField labelField)
            where T : ILabel
        {
            visualization.Label = new DimensionColumnSpec()
            {
                SummarizationField = labelField
            };
            return visualization;
        }
    }
}
