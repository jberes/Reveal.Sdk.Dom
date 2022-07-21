
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ITargetsExtensions
    {
        public static T SetTarget<T>(this T visualization, string field)
            where T : ITargets
        {
            return visualization.SetTarget(new NumberDataField(field));
        }

        public static T SetTarget<T>(this T visualization, NumberDataField field)
            where T : ITargets
        {
            visualization.Targets.Clear();
            visualization.Targets.Add(new MeasureColumn() { DataField = field });
            return visualization;
        }

        public static T SetTargets<T>(this T visualization, params string[] fields)
            where T : ITargets
        {
            visualization.Targets.Clear();
            foreach (var field in fields)
            {
                visualization.Targets.Add(new MeasureColumn() 
                { 
                    DataField = new NumberDataField(field) 
                });
            }
            return visualization;
        }

        public static T SetTargets<T>(this T visualization, params NumberDataField[] fields)
            where T : ITargets
        {
            visualization.Targets.Clear();
            foreach (var field in fields)
            {
                visualization.Targets.Add(new MeasureColumn()
                {
                    DataField = field
                }); 
            }
            return visualization;
        }
    }
}
