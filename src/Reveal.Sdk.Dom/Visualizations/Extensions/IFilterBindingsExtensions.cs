using Reveal.Sdk.Dom.Filters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IFilterBindingsExtensions
    {
        public static T ConnectDashboardFilter<T>(this T visualization, DashboardFilter dashboardFilter)
            where T : IFilterBindings
        {
            if (dashboardFilter is DashboardDateFilter)
            {
                visualization.FilterBindings.Add(new DashboardDateFilterBinding("Date"));
            }
            else
            {
                visualization.FilterBindings.Add(new DashboardDataFilterBinding(dashboardFilter as DashboardDataFilter));
            }
            return visualization;
        }

        public static T ConnectDashboardFilters<T>(this T visualization, params DashboardFilter[] dashboardFilter)
            where T : IFilterBindings
        {
            foreach (var filter in dashboardFilter)
            {
                visualization.ConnectDashboardFilter(filter);
            }
            return visualization;
        }
    }
}
