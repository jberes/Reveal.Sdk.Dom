using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class KpiTargetExtensions
    {
        public static KpiTargetVisualization AddDate(this KpiTargetVisualization visualization, string dateField)
        {
            visualization.AddDate(new SummarizationDateField(dateField));
            return visualization;
        }

        public static KpiTargetVisualization AddDate(this KpiTargetVisualization visualization, SummarizationDateField dateField)
        {
            visualization.Date = new DimensionColumnSpec() { SummarizationField = dateField };
            return visualization;
        }

        public static KpiTargetVisualization AddFilter(this KpiTargetVisualization visualization, string filter)
        {
            visualization.Filters.Add(new VisualizationFilter(filter));
            return visualization;
        }

        public static KpiTargetVisualization AddFilters(this KpiTargetVisualization visualization, params string[] filters)
        {
            foreach (var filter in filters)
            {
                visualization.AddFilter(filter);
            }
            return visualization;
        }

        public static KpiTargetVisualization AddFilterBinding(this KpiTargetVisualization visualization, Binding filterBinding)
        {
            visualization.FilterBindings.Add(filterBinding);
            return visualization;
        }

        public static KpiTargetVisualization AddFilterBindings(this KpiTargetVisualization visualization, params Binding[] filterBindings)
        {
            visualization.FilterBindings.AddRange(filterBindings);
            return visualization;
        }

        public static KpiTargetVisualization AddTarget(this KpiTargetVisualization visualization, string targeField)
        {
            visualization.Target.Add(new MeasureColumnSpec() { SummarizationField = new SummarizationValueField(targeField) });
            return visualization;
        }

        public static KpiTargetVisualization AddTarget(this KpiTargetVisualization visualization, SummarizationValueField targetField)
        {
            visualization.Target.Add(new MeasureColumnSpec() { SummarizationField = targetField });
            return visualization;
        }

        public static KpiTargetVisualization AddTargets(this KpiTargetVisualization visualization, params string[] targets)
        {
            foreach (var value in targets)
            {
                visualization.AddTarget(value);
            }
            return visualization;
        }

        public static KpiTargetVisualization AddTargets(this KpiTargetVisualization visualization, params SummarizationValueField[] targets)
        {
            foreach (var value in targets)
            {
                visualization.AddTarget(value);
            }
            return visualization;
        }

        public static KpiTargetVisualization AddValue(this KpiTargetVisualization visualization, string value)
        {
            visualization.Values.Add(new MeasureColumnSpec() { SummarizationField = new SummarizationValueField(value) });
            return visualization;
        }

        public static KpiTargetVisualization AddValue(this KpiTargetVisualization visualization, SummarizationValueField value)
        {
            visualization.Values.Add(new MeasureColumnSpec() { SummarizationField = value });
            return visualization;
        }

        public static KpiTargetVisualization AddValues(this KpiTargetVisualization visualization, params string[] values)
        {
            foreach (var value in values)
            {
                visualization.AddValue(value);
            }
            return visualization;
        }

        public static KpiTargetVisualization AddValues(this KpiTargetVisualization visualization, params SummarizationValueField[] values)
        {
            foreach (var value in values)
            {
                visualization.AddValue(value);
            }
            return visualization;
        }

        public static KpiTargetVisualization ConfigureSettings(this KpiTargetVisualization visualization, Action<KpiTargetVisualizationSettings> setting)
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }

        public static KpiTargetVisualization SetPosition(this KpiTargetVisualization visualization, int rowSpan, int columnSpan)
        {
            visualization.RowSpan = rowSpan;
            visualization.ColumnSpan = columnSpan;
            return visualization;
        }
    }
}
