
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ICategoriesExtensions
    {
        public static T SetCategory<T>(this T visualization, string field)
            where T : ICategories
        {
            return visualization.SetCategory(new SummarizationRegularField(field));
        }

        public static T SetCategory<T>(this T visualization, SummarizationDimensionField field)
            where T : ICategories
        {
            visualization.Categories.Clear();
            visualization.Categories.Add(new DimensionColumnSpec() { SummarizationField = field });
            return visualization;
        }

        public static T SetCategories<T>(this T visualization, params string[] fields)
            where T : ICategories
        {
            visualization.Categories.Clear();
            foreach (var field in fields)
            {
                visualization.Categories.Add(new DimensionColumnSpec()
                {
                    SummarizationField = new SummarizationRegularField(field)
                });
            }
            return visualization;
        }
        
        public static T SetCategories<T>(this T visualization, params SummarizationDimensionField[] fields)
            where T : ICategories
        {
            visualization.Categories.Clear();
            foreach (var field in fields)
            {
                visualization.Categories.Add(new DimensionColumnSpec()
                {
                    SummarizationField = field
                });
            }
            return visualization;
        }
    }
}
