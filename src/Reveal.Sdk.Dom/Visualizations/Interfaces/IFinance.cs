using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IFinance
    {
        public List<MeasureColumn> Opens { get; }
        public List<MeasureColumn> Highs { get; }
        public List<MeasureColumn> Lows { get; }
        public List<MeasureColumn> Closes { get; }
    }
}
