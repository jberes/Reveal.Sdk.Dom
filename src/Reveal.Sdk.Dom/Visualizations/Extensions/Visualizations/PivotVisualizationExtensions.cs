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

        public static PivotVisualization SetColumn(this PivotVisualization visualization, string field)
        {
            visualization.SetColumn(new TextDataField(field));
            return visualization;
        }

        public static PivotVisualization SetColumn(this PivotVisualization visualization, DimensionDataField field)
        {
            visualization.Columns.Clear();
            visualization.Columns.Add(new DimensionColumn()
            {
                DataField = field,
            });
            return visualization;
        }

        public static PivotVisualization SetColumns(this PivotVisualization visualization, params string[] fields)
        {
            visualization.Columns.Clear();
            foreach (var field in fields)
            {
                visualization.Columns.Add(new DimensionColumn()
                {
                    DataField = new TextDataField(field),
                });
            }
            return visualization;
        }

        public static PivotVisualization SetColumns(this PivotVisualization visualization, params DimensionDataField[] fields)
        {
            visualization.Columns.Clear();
            foreach (var field in fields)
            {
                visualization.Columns.Add(new DimensionColumn()
                {
                    DataField = field,
                });
            }
            return visualization;
        }
    }
}