using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    //todo: rename/refactor - many gauges have bands
    public interface IGaugeVisualization : ILinearGaugeVisualization
    {
        List<GaugeBand> Bands { get; }
    }
}
