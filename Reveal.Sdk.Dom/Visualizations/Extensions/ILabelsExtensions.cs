
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ILabelsExtensions
    {
        public static T AddLabel<T>(this T visualization, string labelField)
            where T : ILabels
        {
            var field = new SummarizationRegularField(labelField);
            visualization.AddLabel(field);
            return visualization;
        }

        public static T AddLabel<T>(this T visualization, SummarizationDimensionField labelField)
            where T : ILabels
        {
            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = labelField
            });
            return visualization;
        }
    }
}
