
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IValuesExtensions
    {
        public static T SetValue<T>(this T visualization, string field)
            where T : IValues
        {
            return visualization.SetValue(new SummarizationValueField(field));
        }

        public static T SetValue<T>(this T visualization, SummarizationValueField field)
            where T : IValues
        {
            visualization.Values.Clear();
            visualization.Values.Add(new MeasureColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }

        public static T SetValues<T>(this T visualization, params string[] fields)
            where T : IValues
        {
            visualization.Values.Clear();
            foreach (var field in fields)
            {
                visualization.Values.Add(new MeasureColumnSpec()
                {
                    SummarizationField = new SummarizationValueField(field)
                });
            }
            return visualization;
        }

        public static T SetValues<T>(this T visualization, params SummarizationValueField[] fields)
            where T : IValues
        {
            visualization.Values.Clear();
            foreach (var field in fields)
            {
                visualization.Values.Add(new MeasureColumnSpec()
                {
                    SummarizationField = field
                });
            }
            return visualization;
        }
    }
}
