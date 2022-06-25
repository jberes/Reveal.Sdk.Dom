using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.Factories
{
    public static partial class VisualizationFactory
    {
        public static KpiTargetVisualization CreateKpiTarget(string title, DataSourceItem dataSourceItem,
            SummarizationDateField dateField, SummarizationValueField valueField, SummarizationValueField targetField,
            IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException($"'{nameof(title)}' cannot be null or empty.", nameof(title));
            if (dataSourceItem is null)
                throw new ArgumentNullException(nameof(dataSourceItem));
            if (dateField is null)
                throw new ArgumentNullException(nameof(dateField));
            if (valueField is null)
                throw new ArgumentNullException(nameof(valueField));
            if (targetField is null)
                throw new ArgumentNullException(nameof(targetField));

            var visualization = new KpiTargetVisualization(dataSourceItem)
            {
                Title = title,
            };

            visualization.ApplyFilters(filters, filterBindings);

            visualization.Date = new DimensionColumnSpec() { SummarizationField = dateField };
            visualization.Values.Add(new MeasureColumnSpec() { SummarizationField = valueField });
            visualization.Target.Add(new MeasureColumnSpec() { SummarizationField = targetField });

            return visualization;
        }

        public static KpiTargetVisualization CreateKpiTarget(string title, DataSourceItem dataSourceItem,
                   string dateField, SummarizationValueField valueField, SummarizationValueField targetField,
                   IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
        {
            return CreateKpiTarget(title, dataSourceItem, new SummarizationDateField(dateField), valueField, targetField, filterBindings, filters);
        }

        public static KpiTargetVisualization CreateKpiTarget(string title, DataSourceItem dataSourceItem,
            string dateField, string valueField, SummarizationValueField targetField,
            IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
        {
            return CreateKpiTarget(title, dataSourceItem, new SummarizationDateField(dateField), new SummarizationValueField(valueField), targetField, filterBindings, filters);
        }

        public static KpiTargetVisualization CreateKpiTarget(string title, DataSourceItem dataSourceItem,
            string dateField, string valueField, string targetField,
            IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
        {
            return CreateKpiTarget(title, dataSourceItem, new SummarizationDateField(dateField), new SummarizationValueField(valueField), new SummarizationValueField(targetField), filterBindings, filters);
        }

        public static KpiTargetVisualization CreateKpiTarget(string title, DataSourceItem dataSourceItem,
           string dateField, SummarizationValueField valueField, string targetField,
           IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
        {
            return CreateKpiTarget(title, dataSourceItem, new SummarizationDateField(dateField), valueField, new SummarizationValueField(targetField), filterBindings, filters);
        }

        public static KpiTargetVisualization CreateKpiTarget(string title, DataSourceItem dataSourceItem,
           SummarizationDateField dateField, SummarizationValueField valueField, string targetField,
           IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
        {
            return CreateKpiTarget(title, dataSourceItem, dateField, valueField, new SummarizationValueField(targetField), filterBindings, filters);
        }

        public static KpiTargetVisualization CreateKpiTarget(string title, DataSourceItem dataSourceItem,
           SummarizationDateField dateField, string valueField, string targetField,
           IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
        {
            return CreateKpiTarget(title, dataSourceItem, dateField, new SummarizationValueField(valueField), new SummarizationValueField(targetField), filterBindings, filters);
        }

        public static KpiTargetVisualization CreateKpiTarget(string title, DataSourceItem dataSourceItem,
           SummarizationDateField dateField, string valueField, SummarizationValueField targetField,
           IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
        {
            return CreateKpiTarget(title, dataSourceItem, dateField, new SummarizationValueField(valueField), targetField, filterBindings, filters);
        }
    }
}
