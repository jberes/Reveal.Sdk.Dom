
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ILabelExtensions
    {
        public static T SetLabel<T>(this T visualization, string field)
            where T : ILabel
        {
            return visualization.SetLabel(new SummarizationRegularField(field));
        }

        public static T SetLabel<T>(this T visualization, SummarizationDimensionField field)
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
