
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ICategoryExtensions
    {
        public static T SetCategory<T>(this T visualization, string field)
            where T : ICategory
        {
            return visualization.SetCategory(new SummarizationRegularField(field));
        }

        public static T SetCategory<T>(this T visualization, SummarizationDimensionField field)
            where T : ICategory
        {
            visualization.Category = new DimensionColumnSpec() { SummarizationField = field };
            return visualization;
        }
    }
}
