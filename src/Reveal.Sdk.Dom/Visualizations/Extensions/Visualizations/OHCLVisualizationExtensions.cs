using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class OHCLVisualizationExtensions
    {
        public static OHLCVisualization ConfigureSettings(this OHLCVisualization visualization, Action<OHCLVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<OHLCVisualization, OHCLVisualizationSettings>(settings);
        }
    }
}
