using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ITabularVisualizationExtensions
    {
        public static T AddFilter<T>(this T visualization, string field)
            where T : ITabularVisualization<VisualizationSettings>
        {
            visualization.Filters.Add(new VisualizationFilter(field));
            return visualization;
        }

        public static T AddFilters<T>(this T visualization, params string[] fields)
            where T : ITabularVisualization<VisualizationSettings>
        {
            foreach (var filter in fields)
            {
                visualization.AddFilter(filter);
            }
            return visualization;
        }
    }
}
