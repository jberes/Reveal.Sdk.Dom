
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ITargetsExtensions
    {
        public static T AddTarget<T>(this T visualization, string field)
            where T : ITargets
        {
            return visualization.AddTarget(new SummarizationValueField(field));
        }

        public static T AddTarget<T>(this T visualization, SummarizationValueField field)
            where T : ITargets
        {
            visualization.Targets.Add(new MeasureColumnSpec() { SummarizationField = field });
            return visualization;
        }

        public static T AddTargets<T>(this T visualization, params string[] fields)
            where T : ITargets
        {
            foreach (var value in fields)
            {
                visualization.AddTarget(value);
            }
            return visualization;
        }

        public static T AddTargets<T>(this T visualization, params SummarizationValueField[] fields)
            where T : ITargets
        {
            foreach (var value in fields)
            {
                visualization.AddTarget(value);
            }
            return visualization;
        }
    }
}
