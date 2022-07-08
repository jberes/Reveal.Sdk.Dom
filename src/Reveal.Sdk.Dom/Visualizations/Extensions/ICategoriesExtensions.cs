
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ICategoriesExtensions
    {
        public static T AddCategory<T>(this T visualization, string field)
            where T : ICategories
        {
            return visualization.AddCategory(new SummarizationRegularField(field));
        }

        public static T AddCategory<T>(this T visualization, SummarizationDimensionField field)
            where T : ICategories
        {
            visualization.Categories.Add(new DimensionColumnSpec() { SummarizationField = field });
            return visualization;
        }
    }
}
