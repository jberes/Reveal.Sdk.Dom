using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.Factories
{
    public static partial class VisualizationFactory
    {
        public static DoughnutChartVisualization CreateDoughnutChart(string title, DataSourceItem dataSourceItem,
            SummarizationDimensionField labelField, SummarizationValueField valueField,
            IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException($"'{nameof(title)}' cannot be null or empty.", nameof(title));
            if (dataSourceItem is null)
                throw new ArgumentNullException(nameof(dataSourceItem));
            if (labelField is null)
                throw new ArgumentNullException(nameof(labelField));
            if (valueField is null)
                throw new ArgumentNullException(nameof(valueField));

            var visualization = new DoughnutChartVisualization(dataSourceItem)
            {
                Title = title,
            };

            visualization.ApplyFilters(filters, filterBindings);

            visualization.Labels.Add(new DimensionColumnSpec() { SummarizationField = labelField });
            visualization.Values.Add(new MeasureColumnSpec() { SummarizationField = valueField });
            return visualization;
        }

        public static DoughnutChartVisualization CreateDoughnutChart(string title, DataSourceItem dataSourceItem,
        SummarizationDimensionField labelField, string valueField,
        IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
        {
            return CreateDoughnutChart(title, dataSourceItem, labelField, new SummarizationValueField(valueField), filterBindings, filters);
        }

        public static DoughnutChartVisualization CreateDoughnutChart(string title, DataSourceItem dataSourceItem,
            string labelField, string valueField,
            IEnumerable<Binding> filterBindings = null, IEnumerable<string> filters = null)
        {
            return CreateDoughnutChart(title, dataSourceItem, new SummarizationRegularField(labelField), new SummarizationValueField(valueField), filterBindings, filters);
        }
    }
}
