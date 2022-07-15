using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class BubbleVisualizationExtensions
    {
        public static BubbleVisualization AddRadius(this BubbleVisualization visualization, string radiusField)
        {
            visualization.AddRadius(new SummarizationValueField(radiusField));
            return visualization;
        }

        public static BubbleVisualization AddRadius(this BubbleVisualization visualization, SummarizationValueField radiusField)
        {
            visualization.Radius.Add(new MeasureColumnSpec()
            {
                SummarizationField = radiusField
            });
            return visualization;
        }

        public static BubbleVisualization ConfigureSettings(this BubbleVisualization visualization, Action<BubbleVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<BubbleVisualization, BubbleVisualizationSettings>(settings);
        }
    }
}
