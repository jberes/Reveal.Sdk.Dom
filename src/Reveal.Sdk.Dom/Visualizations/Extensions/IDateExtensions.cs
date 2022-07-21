
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IDateExtensions
    {
        public static T SetDate<T>(this T visualization, string field)
            where T : IDate
        {
            return visualization.SetDate(new DateDataField(field));
        }

        public static T SetDate<T>(this T visualization, DateDataField field)
            where T : IDate
        {
            visualization.Date = new DimensionColumn() { DataField = field };
            return visualization;
        }
    }
}
