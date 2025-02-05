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
            return visualization.SetColorByCategory(new TextDataField(field));
        }

        public static ScatterMapVisualization SetColorByCategory(this ScatterMapVisualization visualization, TextDataField field)
        {
            visualization.VisualizationDataSpec.IsColorByValue = false;
            visualization.VisualizationDataSpec.MapColorCategory = new DimensionColumn() { DataField = field };
            return visualization;
        }

        public static ScatterMapVisualization SetColorByValue(this ScatterMapVisualization visualization, string field)
        {
            return visualization.SetColorByValue(new NumberDataField(field));
        }

        public static ScatterMapVisualization SetRadius(this ScatterMapVisualization visualization, string field)
        {
            visualization.SetRadius(new NumberDataField(field));
            return visualization;
        }

        public static ScatterMapVisualization SetRadius(this ScatterMapVisualization visualization, NumberDataField field)
        {
            visualization.VisualizationDataSpec.Radius.Clear();
            visualization.VisualizationDataSpec.Radius.Add(new MeasureColumn()
            {
                DataField = field
            });
            return visualization;
        }

        public static ScatterMapVisualization SetColorByValue(this ScatterMapVisualization visualization, NumberDataField field)
        {
            visualization.VisualizationDataSpec.IsColorByValue = true;
            visualization.VisualizationDataSpec.MapColorCategory = null;
            visualization.VisualizationDataSpec.MapColor.Clear();
            visualization.VisualizationDataSpec.MapColor.Add(new MeasureColumn { DataField = field });
            return visualization;
        }

        public static ScatterMapVisualization SetLongitude(this ScatterMapVisualization visualization, string field)
        {
            return visualization.SetLongitude(new TextDataField(field));
        }

        public static ScatterMapVisualization SetLongitude(this ScatterMapVisualization visualization, DimensionDataField field)
        {
            visualization.Longitude = new DimensionColumn()
            {
                DataField = field
            };
            return visualization;
        }

        public static ScatterMapVisualization SetLatitude(this ScatterMapVisualization visualization, string field)
        {
            return visualization.SetLatitude(new TextDataField(field));
        }

        public static ScatterMapVisualization SetLatitude(this ScatterMapVisualization visualization, DimensionDataField field)
        {
            visualization.Latitude = new DimensionColumn()
            {
                DataField = field
            };
            return visualization;
        }
    }
}