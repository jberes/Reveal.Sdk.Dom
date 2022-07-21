
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ICategoriesExtensions
    {
        public static T SetCategory<T>(this T visualization, string field)
            where T : ICategories
        {
            return visualization.SetCategory(new TextDataField(field));
        }

        public static T SetCategory<T>(this T visualization, DimensionDataField field)
            where T : ICategories
        {
            visualization.Categories.Clear();
            visualization.Categories.Add(new DimensionColumn() { DataField = field });
            return visualization;
        }

        public static T SetCategories<T>(this T visualization, params string[] fields)
            where T : ICategories
        {
            visualization.Categories.Clear();
            foreach (var field in fields)
            {
                visualization.Categories.Add(new DimensionColumn()
                {
                    DataField = new TextDataField(field)
                });
            }
            return visualization;
        }
        
        public static T SetCategories<T>(this T visualization, params DimensionDataField[] fields)
            where T : ICategories
        {
            visualization.Categories.Clear();
            foreach (var field in fields)
            {
                visualization.Categories.Add(new DimensionColumn()
                {
                    DataField = field
                });
            }
            return visualization;
        }
    }
}
