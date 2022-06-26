using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IKpiTargetVisualization : IIndicatorVisualization
    {
        List<MeasureColumnSpec> Target { get; }
    }
}