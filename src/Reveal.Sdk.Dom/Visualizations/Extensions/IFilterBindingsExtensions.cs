using Reveal.Sdk.Dom.Filters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IFilterBindingsExtensions
    {
        public static T AddFilterBinding<T>(this T visualization, Binding filterBinding)
            where T : IFilterBindings
        {
            visualization.FilterBindings.Add(filterBinding);
            return visualization;
        }

        public static T AddFilterBindings<T>(this T visualization, params Binding[] filterBindings)
            where T : IFilterBindings
        {
            visualization.FilterBindings.AddRange(filterBindings);
            return visualization;
        }
    }
}
