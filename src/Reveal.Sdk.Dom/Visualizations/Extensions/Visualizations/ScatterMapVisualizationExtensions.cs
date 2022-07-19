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

        public static ScatterMapVisualization SetColorByCategory(this ScatterMapVisualization visualization, string field)
        {
            return visualization.SetColorByCategory(new SummarizationRegularField(field));
        }

        public static ScatterMapVisualization SetColorByCategory(this ScatterMapVisualization visualization, SummarizationRegularField field)
        {
            visualization.VisualizationDataSpec.IsColorByValue = false;
            visualization.VisualizationDataSpec.MapColorCategory = new DimensionColumnSpec() { SummarizationField = field };
            return visualization;
        }

        public static ScatterMapVisualization SetColorByValue(this ScatterMapVisualization visualization, string field)
        {
            return visualization.SetColorByValue(new SummarizationValueField(field));
        }
        
        public static ScatterMapVisualization SetColorByValue(this ScatterMapVisualization visualization, SummarizationValueField field)
        {
            visualization.VisualizationDataSpec.IsColorByValue = true;
            visualization.VisualizationDataSpec.MapColorCategory = null;
            visualization.VisualizationDataSpec.MapColor.Clear();
            visualization.VisualizationDataSpec.MapColor.Add(new MeasureColumnSpec { SummarizationField = field });
            return visualization;
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