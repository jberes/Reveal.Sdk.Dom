using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IAxis
    {
        List<MeasureColumnSpec> XAxis { get; }
        List<MeasureColumnSpec> YAxis { get; }
    }
}
