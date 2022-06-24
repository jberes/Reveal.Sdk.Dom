using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.Factories
{
    public static partial class VisualizationFactory
    {
        public static IndicatorVisualization CreateKpiTime(string title, DataSourceItem dataSourceItem,
            SummarizationDateField dateField, SummarizationValueField valueField,
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

            var visualization = new IndicatorVisualization(dataSourceItem)
            {
                Title = title,
            };

            visualization.ApplyFilters(filters, filterBindings);

            visualization.VisualizationDataSpec.Date = new DimensionColumnSpec() { SummarizationField = dateField };
            visualization.VisualizationDataSpec.Value.Add(new MeasureColumnSpec() { SummarizationField = valueField });

            return visualization;
        }

        public static IndicatorVisualization CreateKpiTime(string title, DataSourceItem dataSourceItem,
            string dateField, string valueField,
            IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
        {
            return CreateKpiTime(title, dataSourceItem, new SummarizationDateField(dateField), new SummarizationValueField(valueField), filterBindings, filters);
        }
    }
}
