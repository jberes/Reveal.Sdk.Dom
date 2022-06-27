using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IValues
    {
        List<MeasureColumnSpec> Values { get; }
    }
}
