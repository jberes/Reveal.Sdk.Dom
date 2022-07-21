
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ICategoryExtensions
    {
        public static T SetCategory<T>(this T visualization, string field)
            where T : ICategory
        {
            return visualization.SetCategory(new TextDataField(field));
        }

        public static T SetCategory<T>(this T visualization, DimensionDataField field)
            where T : ICategory
        {
            visualization.Category = new DimensionColumn() { DataField = field };
            return visualization;
        }
    }
}
