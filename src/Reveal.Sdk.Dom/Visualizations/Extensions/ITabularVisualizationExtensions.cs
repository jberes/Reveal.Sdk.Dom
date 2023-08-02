using Reveal.Sdk.Dom.Filters;
using System.Linq;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ITabularVisualizationExtensions
    {
        public static T AddDataFilter<T, TFilter>(this T visualization, string fieldName, TFilter filter)
            where T : ITabularVisualization
            where TFilter : IFilter
        {
            try
            {
                var field = visualization.DataDefinition.Fields.Where(x => x.FieldName == fieldName).First();
                var filterField = (FieldBase<TFilter>)field;
                filterField.DataFilter = filter;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception($"AddDataFilter: Field {fieldName} cannot be found.");
            }
            catch
            {
                throw new Exception($"AddDataFilter: Field {fieldName} is not compatible with {filter.GetType()}.");
            }

            return visualization;
        }

        public static T AddFilter<T>(this T visualization, string field)
            where T : ITabularVisualization
        {
            visualization.Filters.Add(new VisualizationFilter(field));
            return visualization;
        }

        public static T AddFilters<T>(this T visualization, params string[] fields)
            where T : ITabularVisualization
        {
            foreach (var filter in fields)
            {
                visualization.AddFilter(filter);
            }
            return visualization;
        }
    }
}
