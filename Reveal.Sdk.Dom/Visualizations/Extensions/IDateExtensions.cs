
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IDateExtensions
    {
        public static T AddDate<T>(this T visualization, string field)
            where T : IDate
        {
            return visualization.AddDate(new SummarizationDateField(field));
        }

        public static T AddDate<T>(this T visualization, SummarizationDateField field)
            where T : IDate
        {
            visualization.Date = new DimensionColumnSpec() { SummarizationField = field };
            return visualization;
        }
    }
}
