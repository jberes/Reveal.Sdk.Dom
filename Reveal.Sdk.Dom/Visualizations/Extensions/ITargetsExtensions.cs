using Reveal.Sdk.Dom.Visualizations.Primitives;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ITargetsExtensions
    {
        public static T AddTarget<T>(this T visualization, string targeField)
            where T : ITargets
        {
            visualization.Targets.Add(new MeasureColumnSpec() { SummarizationField = new SummarizationValueField(targeField) });
            return visualization;
        }

        public static T AddTarget<T>(this T visualization, SummarizationValueField targetField)
            where T : ITargets
        {
            visualization.Targets.Add(new MeasureColumnSpec() { SummarizationField = targetField });
            return visualization;
        }

        public static T AddTargets<T>(this T visualization, params string[] targets)
            where T : ITargets
        {
            foreach (var value in targets)
            {
                visualization.AddTarget(value);
            }
            return visualization;
        }

        public static T AddTargets<T>(this T visualization, params SummarizationValueField[] targets)
            where T : ITargets
        {
            foreach (var value in targets)
            {
                visualization.AddTarget(value);
            }
            return visualization;
        }
    }
}
