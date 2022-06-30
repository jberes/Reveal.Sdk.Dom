using Reveal.Sdk.Dom.Visualizations.Settings;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ComboChartVisualizationExtensions
    {
        public static ComboChartVisualization ConfigureSettings(this ComboChartVisualization visualization, Action<ComboChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<ComboChartVisualization, ComboChartVisualizationSettings>(settings);
        }

        public static ComboChartVisualization ConfigureChart1(this ComboChartVisualization visualization, Action<ChartConfiguration> config)
        {
            ChartConfiguration chartConfig = new ChartConfiguration();
            config.Invoke(chartConfig);

            visualization.Chart1.AddRange(chartConfig.Values);
            visualization.Settings.CompositeChartType1 = chartConfig.ChartType;
            return visualization;
        }

        public static ComboChartVisualization ConfigureChart2(this ComboChartVisualization visualization, Action<ChartConfiguration> config)
        {
            ChartConfiguration chartConfig = new ChartConfiguration();
            config.Invoke(chartConfig);

            visualization.Chart2.AddRange(chartConfig.Values);
            visualization.Settings.CompositeChartType2 = chartConfig.ChartType;
            return visualization;
        }
    }

    public static class IListExtensions
    {
        public static IList<MeasureColumnSpec> Add(this IList<MeasureColumnSpec> list, string field)
        {
            list.Add(new MeasureColumnSpec() { SummarizationField = new SummarizationValueField(field) });
            return list;
        }
    }

    public class ChartConfiguration
    {
        public List<MeasureColumnSpec> Values { get; set; } = new List<MeasureColumnSpec>();
        public ChartType ChartType { get; set; }
    }
}