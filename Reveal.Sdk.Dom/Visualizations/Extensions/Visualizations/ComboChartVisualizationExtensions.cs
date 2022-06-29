using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ComboChartVisualizationExtensions
    {
        //todo: chart1 and chart2 probably hae more properties that can be set
        //what's the best way to configure each chart? Maybe a single ConfigureChart1 and ConfigureChart2 methods?
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