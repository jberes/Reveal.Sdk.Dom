using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ComboChartVisualizationExtensions
    {
        /// <summary>
        /// Adds a <see cref="SummarizationValueField"/> as a Chart1 Value.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="field">The name of the field to use as a Chart1 value.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization AddValueToChart1(this ComboChartVisualization visualization, string field)
        {
            return visualization.AddValueToChart1(new SummarizationValueField(field));
        }

        /// <summary>
        /// Adds a <see cref="SummarizationValueField"/> as a Chart1 Value.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="field">The <see cref="SummarizationValueField"/> to use as a Chart1 value.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization AddValueToChart1(this ComboChartVisualization visualization, SummarizationValueField field)
        {
            visualization.Chart1.Add(new MeasureColumnSpec() { SummarizationField = field });
            return visualization;
        }

        /// <summary>
        /// Adds a <see cref="SummarizationValueField"/> as a Chart2 Value.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="field">The name of the field to use as a Chart2 value.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization AddValueToChart2(this ComboChartVisualization visualization, string field)
        {
            return visualization.AddValueToChart2(new SummarizationValueField(field));
        }

        /// <summary>
        /// Adds a <see cref="SummarizationValueField"/> as a Chart2 Value.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="field">The <see cref="SummarizationValueField"/> to use as a Chart2 value.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization AddValueToChart2(this ComboChartVisualization visualization, SummarizationValueField field)
        {
            visualization.Chart2.Add(new MeasureColumnSpec() { SummarizationField = field });
            return visualization;
        }

        /// <summary>
        /// Configures the available settings for the <see cref="ComboChartVisualization"/>.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="settings">The <see cref="ComboChartVisualizationSettings"/> that will be applied to the <see cref="ComboChartVisualization"/>.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization ConfigureSettings(this ComboChartVisualization visualization, Action<ComboChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<ComboChartVisualization, ComboChartVisualizationSettings>(settings);
        }
    }
}