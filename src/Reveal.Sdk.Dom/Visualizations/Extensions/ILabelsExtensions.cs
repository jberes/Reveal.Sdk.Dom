
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ILabelsExtensions
    {
        public static T SetLabel<T>(this T visualization, string field)
            where T : ILabels
        {
            return visualization.SetLabel(new TextDataField(field));
        }

        public static T SetLabel<T>(this T visualization, DimensionDataField field)
            where T : ILabels
        {
            visualization.Labels.Clear();
            visualization.Labels.Add(new DimensionColumn()
            {
                DataField = field
            });
            return visualization;
        }

        public static T SetLabels<T>(this T visualization, params string[] fields)
            where T : ILabels
        {
            visualization.Labels.Clear();
            foreach (var field in fields)
            {
                visualization.Labels.Add(new DimensionColumn()
                {
                    DataField = new TextDataField(field)
                });
            }
            return visualization;
        }

        public static T SetLabels<T>(this T visualization, params DimensionDataField[] fields)
            where T : ILabels
        {
            visualization.Labels.Clear();
            foreach (var field in fields)
            {
                visualization.Labels.Add(new DimensionColumn()
                {
                    DataField = field
                });
            }
            return visualization;
        }
    }
}
