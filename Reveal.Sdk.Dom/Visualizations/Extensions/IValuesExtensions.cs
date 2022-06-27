
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IValuesExtensions
    {
        public static T AddValue<T>(this T visualization, string valueFied)
            where T : IValues
        {
            var value = new SummarizationValueField(valueFied);
            visualization.AddValue(value);
            return visualization;
        }

        public static T AddValue<T>(this T visualization, SummarizationValueField valueFied)
            where T : IValues
        {
            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = valueFied
            });
            return visualization;
        }

        public static T AddValues<T>(this T visualization, params string[] valueFieds)
            where T : IValues
        {
            foreach (var valueFied in valueFieds)
            {
                var value = new SummarizationValueField(valueFied);
                visualization.AddValue(value);
            }
            return visualization;
        }
    }
}
