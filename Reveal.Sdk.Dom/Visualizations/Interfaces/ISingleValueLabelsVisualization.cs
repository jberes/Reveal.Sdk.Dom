using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface ISingleValueLabelsVisualization : IVisualization
    {
        List<DimensionColumnSpec> Labels { get; }
        List<MeasureColumnSpec> Values { get; }
    }
}
