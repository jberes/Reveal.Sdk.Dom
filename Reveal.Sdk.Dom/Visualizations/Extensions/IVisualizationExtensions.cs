using Reveal.Sdk.Dom.Filters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IVisualizationExtensions
    {
        public static T AddFilter<T>(this T visualization, string filter)
            where T : IVisualization
        {
            visualization.Filters.Add(new VisualizationFilter(filter));
            return visualization;
        }

        public static T AddFilters<T>(this T visualization, params string[] filters)
            where T : IVisualization
        {
            foreach (var filter in filters)
            {
                visualization.AddFilter(filter);
            }
            return visualization;
        }

        public static T AddFilterBinding<T>(this T visualization, Binding filterBinding)
            where T : IVisualization
        {
            visualization.FilterBindings.Add(filterBinding);
            return visualization;
        }

        public static T AddFilterBindings<T>(this T visualization, params Binding[] filterBindings)
            where T : IVisualization
        {
            visualization.FilterBindings.AddRange(filterBindings);
            return visualization;
        }

        public static T SetPosition<T>(this T visualization, int rowSpan, int columnSpan)
            where T : IVisualization
        {
            visualization.RowSpan = rowSpan;
            visualization.ColumnSpan = columnSpan;
            return visualization;
        }
    }
}
