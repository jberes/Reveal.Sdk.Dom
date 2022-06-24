using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Visualizations.Factories
{
    public static partial class VisualizationFactory
    {
        static T CreateChartVisualization<T>(string title, DataSourceItem dataSourceItem,
            IEnumerable<SummarizationDimensionField> labels, IEnumerable<SummarizationValueField> values,
            IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
            where T : Visualization, IVisualizationDataSpec<CategoryVisualizationDataSpec>
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException($"'{nameof(title)}' cannot be null or empty.", nameof(title));
            if (dataSourceItem is null)
                throw new ArgumentNullException(nameof(dataSourceItem));
            if (labels is null)
                throw new ArgumentNullException(nameof(labels));
            if (values is null)
                throw new ArgumentNullException(nameof(values));

            var visualization = (T)Activator.CreateInstance(typeof(T), args: dataSourceItem);
            visualization.Title = title;

            visualization.ApplyFilters(filters, filterBindings);

            foreach (var label in labels)
            {
                visualization.VisualizationDataSpec.Rows.Add(new DimensionColumnSpec()
                {
                    SummarizationField = label
                });
            }

            foreach (var value in values)
            {
                visualization.VisualizationDataSpec.Values.Add(new MeasureColumnSpec()
                {
                    SummarizationField = value
                });
            }

            return visualization;
        }

        public static T CreateChartVisualization<T>(string title, DataSourceItem dataSourceItem,
            IEnumerable<SummarizationDimensionField> labels, IEnumerable<string> values,
            IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
            where T : Visualization, IVisualizationDataSpec<CategoryVisualizationDataSpec>
        {
            var valueObjects = values.Select(x => new SummarizationValueField(x)).ToArray();
            return CreateChartVisualization<T>(title, dataSourceItem, labels, valueObjects, filterBindings, filters);
        }

        public static T CreateChartVisualization<T>(string title, DataSourceItem dataSourceItem,
            IEnumerable<string> labels, IEnumerable<string> values,
            IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
            where T : Visualization, IVisualizationDataSpec<CategoryVisualizationDataSpec>
        {
            //todo: can we make assumptions about the default "simple chart" creation experience?
            var labelObjects = labels.Select(x => new SummarizationRegularField(x)).ToArray();
            return CreateChartVisualization<T>(title, dataSourceItem, labelObjects, values, filterBindings, filters);
        }


        internal static void ApplyFilters(this Visualization visualization, IEnumerable<string> filters = null, IEnumerable<Binding> filterBindings = null)
        {
            if (filterBindings != null)
                visualization.FilterBindings.AddRange(filterBindings);

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    visualization.Filters.Add(new VisualizationFilter(filter));
                }
            }
        }
    }
}
