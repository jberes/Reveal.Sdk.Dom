using Reveal.Sdk.Dom.Filters;
using System;
using System.Linq;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ITabularDataDefinitionProviderExtensions
    {
        public static T AddDataFilter<T, TFilter>(this T visualization, string fieldName, TFilter filter)
            where T : ITabularDataDefinitionProvider
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
    }
}
