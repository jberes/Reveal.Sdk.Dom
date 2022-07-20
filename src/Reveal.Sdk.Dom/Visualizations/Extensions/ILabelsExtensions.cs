
namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ILabelsExtensions
    {
        public static T SetLabel<T>(this T visualization, string field)
            where T : ILabels
        {
            return visualization.SetLabel(new SummarizationRegularField(field));
        }

        public static T SetLabel<T>(this T visualization, SummarizationDimensionField field)
            where T : ILabels
        {
            visualization.Labels.Clear();
            visualization.Labels.Add(new DimensionColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }

        public static T SetLabels<T>(this T visualization, params string[] fields)
            where T : ILabels
        {
            visualization.Labels.Clear();
            foreach (var field in fields)
            {
                visualization.Labels.Add(new DimensionColumnSpec()
                {
                    SummarizationField = new SummarizationRegularField(field)
                });
            }
            return visualization;
        }

        public static T SetLabels<T>(this T visualization, params SummarizationDimensionField[] fields)
            where T : ILabels
        {
            visualization.Labels.Clear();
            foreach (var field in fields)
            {
                visualization.Labels.Add(new DimensionColumnSpec()
                {
                    SummarizationField = field
                });
            }
            return visualization;
        }
    }
}
