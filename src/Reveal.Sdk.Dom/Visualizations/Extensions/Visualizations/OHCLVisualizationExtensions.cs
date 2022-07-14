using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class OHCLVisualizationExtensions
    {
        public static OHLCVisualization ConfigureSettings(this OHLCVisualization visualization, Action<OHLCVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<OHLCVisualization, OHLCVisualizationSettings>(settings);
        }
    }
}
