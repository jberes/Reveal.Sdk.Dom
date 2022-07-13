using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IFinance
    {
        public List<MeasureColumnSpec> Open { get; }
        public List<MeasureColumnSpec> High { get; }
        public List<MeasureColumnSpec> Low { get; }
        public List<MeasureColumnSpec> Close { get; }
    }
}
