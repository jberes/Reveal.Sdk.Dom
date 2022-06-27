
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ICategoriesExtensions
    {
        public static T AddCategory<T>(this T visualization, string category)
            where T : ICategories
        {
            visualization.AddCategory(new SummarizationRegularField(category));
            return visualization;
        }

        public static T AddCategory<T>(this T visualization, SummarizationDimensionField category)
            where T : ICategories
        {
            visualization.Categories.Add(new DimensionColumnSpec() { SummarizationField = category });
            return visualization;
        }
    }
}
