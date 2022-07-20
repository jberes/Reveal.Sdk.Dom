
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IDateExtensions
    {
        public static T SetDate<T>(this T visualization, string field)
            where T : IDate
        {
            return visualization.SetDate(new SummarizationDateField(field));
        }

        public static T SetDate<T>(this T visualization, SummarizationDateField field)
            where T : IDate
        {
            visualization.Date = new DimensionColumnSpec() { SummarizationField = field };
            return visualization;
        }
    }
}
