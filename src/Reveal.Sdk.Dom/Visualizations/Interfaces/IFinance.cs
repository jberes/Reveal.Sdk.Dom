using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IFinance
    {
        public List<MeasureColumnSpec> Opens { get; }
        public List<MeasureColumnSpec> Highs { get; }
        public List<MeasureColumnSpec> Lows { get; }
        public List<MeasureColumnSpec> Closes { get; }
    }
}
