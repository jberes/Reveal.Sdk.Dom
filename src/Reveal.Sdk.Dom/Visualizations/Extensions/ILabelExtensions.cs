
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ILabelExtensions
    {
        public static T AddLabel<T>(this T visualization, string field)
            where T : ILabel
        {
            return visualization.AddLabel(new SummarizationRegularField(field));
        }

        public static T AddLabel<T>(this T visualization, SummarizationDimensionField field)
            where T : ILabel
        {
            visualization.Label = new DimensionColumnSpec()
            {
                SummarizationField = field
            };
            return visualization;
        }
    }
}
