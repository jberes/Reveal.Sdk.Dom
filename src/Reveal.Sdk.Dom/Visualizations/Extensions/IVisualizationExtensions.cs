using Reveal.Sdk.Dom.Filters;
using System;
using System.Linq;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IVisualizationExtensions
    {
        public static T SetPosition<T>(this T visualization, int rowSpan, int columnSpan)
            where T : IVisualization
        {
            visualization.RowSpan = rowSpan;
            visualization.ColumnSpan = columnSpan;
            return visualization;
        }

        public static T AddDataFilter<T, TFilter>(this T visualization, string fieldName, TFilter filter)
            where T : IVisualization
            where TFilter : IFilter
        {
            try
            {
                if (visualization.DataDefinition is TabularDataDefinition tdd)
                {
                    var field = tdd.Fields.Where(x => x.FieldName == fieldName).First();
                    var filterField = (FieldBase<TFilter>)field;
                    filterField.DataFilter = filter;
                }
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
            where T : IVisualization
        {
            if (visualization.DataDefinition is TabularDataDefinition tdd)
            {
                tdd.QuickFilters.Add(new VisualizationFilter(field));
                //visualization.Filters.Add(new VisualizationFilter(field)); //todo: can we expose a Filters property on IVisualization? Can the filters property apply to both Tabular and Xmla?
            }                
            return visualization;
        }

        public static T AddFilters<T>(this T visualization, params string[] fields)
            where T : IVisualization
        {
            foreach (var filter in fields)
            {
                visualization.AddFilter(filter);
            }
            return visualization;
        }
    }
}
