using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class OHCLVisualizationExtensions
    {
        public static OHCLVisualization ConfigureSettings(this OHCLVisualization visualization, Action<OHCLVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<OHCLVisualization, OHCLVisualizationSettings>(settings);
        }
    }
}
