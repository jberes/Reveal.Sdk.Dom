using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System;
using System.Linq;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IVisualizationExtensions
    {
        public static T AddDataFilter<T, TFilter>(this T visualization, string fieldName, TFilter filter)
            where T : IVisualization<VisualizationSettings, TabularDataDefinition>
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

        public static T AddFilterBinding<T>(this T visualization, Binding filterBinding)
            where T : IVisualization<VisualizationSettings, TabularDataDefinition>
        {
            visualization.FilterBindings.Add(filterBinding);
            return visualization;
        }

        public static T AddFilterBindings<T>(this T visualization, params Binding[] filterBindings)
            where T : IVisualization<VisualizationSettings, TabularDataDefinition>
        {
            visualization.FilterBindings.AddRange(filterBindings);
            return visualization;
        }

        internal static T ConfigureSettings<T, TSettings>(this T visualization, Action<TSettings> setting)
            where T : IVisualization<TSettings, TabularDataDefinition>
            where TSettings : VisualizationSettings
        {
            setting.Invoke(visualization.Settings);
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
