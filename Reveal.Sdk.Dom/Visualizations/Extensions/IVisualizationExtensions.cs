using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.DataSpecs;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IVisualizationExtensions
    {
        public static T AddFilter<T>(this T visualization, string filter)
            where T : IFilter
        {
            visualization.Filters.Add(new VisualizationFilter(filter));
            return visualization;
        }

        public static T AddFilters<T>(this T visualization, params string[] filters)
            where T : IFilter
        {
            foreach (var filter in filters)
            {
                visualization.AddFilter(filter);
            }
            return visualization;
        }

        public static T AddFilterBinding<T>(this T visualization, Binding filterBinding)
            where T : IBindDashboardFilters
        {
            visualization.FilterBindings.Add(filterBinding);
            return visualization;
        }

        public static T AddFilterBindings<T>(this T visualization, params Binding[] filterBindings)
            where T : IBindDashboardFilters
        {
            visualization.FilterBindings.AddRange(filterBindings);
            return visualization;
        }

        public static T ConfigureFields<T>(this T visualization, Action<IEnumerable<Field>> fields)
            where T : IDataSpec<TabularDataSpec>
        {
            fields.Invoke(visualization.DataSpec.Fields);
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
