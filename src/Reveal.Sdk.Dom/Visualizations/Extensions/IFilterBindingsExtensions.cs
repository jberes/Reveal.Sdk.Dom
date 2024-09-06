using Reveal.Sdk.Dom.Filters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IFilterBindingsExtensions
    {
        public static T ConnectDashboardFilter<T>(this T visualization, DashboardFilter dashboardFilter)
            where T : IFilterBindings
        {
            return visualization.ConnectDashboardFilter(dashboardFilter, null);
        }

        public static T ConnectDashboardFilter<T>(this T visualization, DashboardFilter dashboardFilter, string fieldName)
            where T : IFilterBindings
        {
            if (dashboardFilter is DashboardDateFilter)
            {
                visualization.FilterBindings.Add(new DashboardDateFilterBinding(fieldName ?? "Date"));
            }
            else if (dashboardFilter is DashboardDataFilter dataFilter)
            {
                var binding = fieldName == null ? new DashboardDataFilterBinding(dataFilter) : new DashboardDataFilterBinding(dataFilter, fieldName);
                visualization.FilterBindings.Add(binding);
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
