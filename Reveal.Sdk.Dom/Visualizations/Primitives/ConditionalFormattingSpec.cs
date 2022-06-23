using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class ConditionalFormattingSpec
    {
        public Bound Minimum { get; set; }
        public Bound Maximum { get; set; }
        public List<ConditionalFormattingBand> Bands { get; set; }

        public ConditionalFormattingSpec()
        {
            Bands = new List<ConditionalFormattingBand>();
        }
    }
}
