using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ScatterMapVisualizationExtensions
    {
        public static ScatterMapVisualization ConfigureSettings(this ScatterMapVisualization visualization, Action<ScatterMapVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<ScatterMapVisualization, ScatterMapVisualizationSettings>(settings);
        }

        public static ScatterMapVisualization SetLongitude(this ScatterMapVisualization visualization, string field)
        {
            return visualization.SetLongitude(new SummarizationRegularField(field));
        }

        public static ScatterMapVisualization SetLongitude(this ScatterMapVisualization visualization, SummarizationDimensionField field)
        {
            visualization.Longitude = new DimensionColumnSpec()
            {
                SummarizationField = field
            };
            return visualization;
        }

        public static ScatterMapVisualization SetLatitude(this ScatterMapVisualization visualization, string field)
        {
            return visualization.SetLatitude(new SummarizationRegularField(field));
        }

        public static ScatterMapVisualization SetLatitude(this ScatterMapVisualization visualization, SummarizationDimensionField field)
        {
            visualization.Latitude = new DimensionColumnSpec()
            {
                SummarizationField = field
            };
            return visualization;
        }
    }
}