using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class PivotVisualizationExtensions
    {
        public static PivotVisualization ConfigureSettings(this PivotVisualization visualization, Action<PivotVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<PivotVisualization, PivotVisualizationSettings>(settings);
        }

        public static PivotVisualization AddColumn(this PivotVisualization visualization, string field)
        {
            visualization.AddColumn(new SummarizationRegularField(field));
            return visualization;
        }

        public static PivotVisualization AddColumn(this PivotVisualization visualization, SummarizationDimensionField field)
        {
            visualization.Columns.Add(new DimensionColumnSpec()
            {
                SummarizationField = field,
            });
            return visualization;
        }

        public static PivotVisualization AddRow(this PivotVisualization visualization, string field)
        {
            visualization.AddRow(new SummarizationRegularField(field));
            return visualization;
        }

        public static PivotVisualization AddRow(this PivotVisualization visualization, SummarizationDimensionField field)
        {
            visualization.Rows.Add(new DimensionColumnSpec()
            {
                SummarizationField = field,
            });
            return visualization;
        }
    }
}