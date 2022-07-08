using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class CandleStickVisualizationExtensions
    {
        public static CandleStickVisualization ConfigureSettings(this CandleStickVisualization visualization, Action<CandleStickVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<CandleStickVisualization, CandleStickVisualizationSettings>(settings);
        }
    }
}
