using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.DataSpecs;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IVisualizationExtensions
    {
        public static T AddFilterBinding<T>(this T visualization, Binding filterBinding)
            where T : IVisualization<VisualizationSettings, TabularDataSpec>
        {
            visualization.FilterBindings.Add(filterBinding);
            return visualization;
        }

        public static T AddFilterBindings<T>(this T visualization, params Binding[] filterBindings)
            where T : IVisualization<VisualizationSettings, TabularDataSpec>
        {
            visualization.FilterBindings.AddRange(filterBindings);
            return visualization;
        }

        public static T ConfigureFields<T>(this T visualization, Action<IEnumerable<Field>> fields)
            where T : IVisualization<VisualizationSettings, TabularDataSpec>
        {
            fields.Invoke(visualization.DataSpec.Fields);
            return visualization;
        }

        internal static T ConfigureSettings<T, TSettings>(this T visualization, Action<TSettings> setting)
            where T : IVisualization<TSettings, TabularDataSpec>
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
