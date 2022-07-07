
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ILabelsExtensions
    {
        public static T AddLabel<T>(this T visualization, string field)
            where T : ILabels
        {
            return visualization.AddLabel(new SummarizationRegularField(field));
        }

        public static T AddLabel<T>(this T visualization, SummarizationDimensionField field)
            where T : ILabels
        {
            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }
    }
}
