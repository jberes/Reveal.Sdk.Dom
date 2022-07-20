
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ITargetsExtensions
    {
        public static T SetTarget<T>(this T visualization, string field)
            where T : ITargets
        {
            return visualization.SetTarget(new SummarizationValueField(field));
        }

        public static T SetTarget<T>(this T visualization, SummarizationValueField field)
            where T : ITargets
        {
            visualization.Targets.Clear();
            visualization.Targets.Add(new MeasureColumnSpec() { SummarizationField = field });
            return visualization;
        }

        public static T SetTargets<T>(this T visualization, params string[] fields)
            where T : ITargets
        {
            visualization.Targets.Clear();
            foreach (var field in fields)
            {
                visualization.Targets.Add(new MeasureColumnSpec() 
                { 
                    SummarizationField = new SummarizationValueField(field) 
                });
            }
            return visualization;
        }

        public static T SetTargets<T>(this T visualization, params SummarizationValueField[] fields)
            where T : ITargets
        {
            visualization.Targets.Clear();
            foreach (var field in fields)
            {
                visualization.Targets.Add(new MeasureColumnSpec()
                {
                    SummarizationField = field
                }); 
            }
            return visualization;
        }
    }
}
