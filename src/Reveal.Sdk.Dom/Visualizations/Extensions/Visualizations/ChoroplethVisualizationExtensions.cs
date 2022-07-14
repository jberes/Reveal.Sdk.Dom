using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ChoroplethVisualizationExtensions
    {
        public static ChoroplethVisualization AddLocation(this ChoroplethVisualization visualization, string field)
        {
            return visualization.AddLocation(new SummarizationRegularField(field));
        }
        
        public static ChoroplethVisualization AddLocation(this ChoroplethVisualization visualization, SummarizationDimensionField field)
        {
            visualization.Locations.Add(new DimensionColumnSpec()
            {
                SummarizationField = field
            });
            return visualization;
        }

        public static ChoroplethVisualization ConfigureSettings(this ChoroplethVisualization visualization, Action<ChoroplethVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<ChoroplethVisualization, ChoroplethVisualizationSettings>(settings);
        }
    }
}
