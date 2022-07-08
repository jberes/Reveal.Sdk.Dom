
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IValuesExtensions
    {
        public static T AddValue<T>(this T visualization, string field)
            where T : IValues
        {
            return visualization.AddValue(new SummarizationValueField(field));
        }

        public static T AddValue<T>(this T visualization, SummarizationValueField field)
            where T : IValues
        {
            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }

        public static T AddValues<T>(this T visualization, params string[] fields)
            where T : IValues
        {
            foreach (var valueFied in fields)
            {
                var value = new SummarizationValueField(valueFied);
                visualization.AddValue(value);
            }
            return visualization;
        }
    }
}
