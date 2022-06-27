
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IDateExtensions
    {
        public static T AddDate<T>(this T visualization, string dateField)
            where T : IDate
        {
            visualization.AddDate(new SummarizationDateField(dateField));
            return visualization;
        }

        public static T AddDate<T>(this T visualization, SummarizationDateField dateField)
            where T : IDate
        {
            visualization.Date = new DimensionColumnSpec() { SummarizationField = dateField };
            return visualization;
        }
    }
}
