using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ComboChartVisualizationExtensions
    {
        public static ComboChartVisualization AddChart1Value(this ComboChartVisualization visualization, string field)
        {
            visualization.AddChart1Value(new SummarizationValueField(field));
            return visualization;
        }

        public static ComboChartVisualization AddChart1Value(this ComboChartVisualization visualization, SummarizationValueField field)
        {
            visualization.Chart1.Add(new MeasureColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }

        public static ComboChartVisualization AddChart1Values(this ComboChartVisualization visualization, params string[] fields)
        {
            foreach (var field in fields)
            {
                visualization.AddChart1Value(new SummarizationValueField(field));
            }
            return visualization;
        }

        public static ComboChartVisualization AddChart2Value(this ComboChartVisualization visualization, string field)
        {
            visualization.AddChart2Value(new SummarizationValueField(field));
            return visualization;
        }

        public static ComboChartVisualization AddChart2Value(this ComboChartVisualization visualization, SummarizationValueField field)
        {
            visualization.Chart2.Add(new MeasureColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }

        public static ComboChartVisualization AddChart2Values(this ComboChartVisualization visualization, params string[] fields)
        {
            foreach (var field in fields)
            {
                visualization.AddChart2Value(new SummarizationValueField(field));
            }
            return visualization;
        }

        public static ComboChartVisualization ConfigureSettings(this ComboChartVisualization visualization, Action<ComboChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<ComboChartVisualization, ComboChartVisualizationSettings>(settings);
        }
    }
}