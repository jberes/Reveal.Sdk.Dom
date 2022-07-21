using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ConditionalFormatting : ConditionalFormattingBase<ConditionalFormattingBand>
    {
        [JsonProperty]
        public Bound Minimum { get; internal set; } = new Bound() { ValueType = BoundValueType.LowestValue };

        [JsonProperty]
        public Bound Maximum { get; internal set; } = new Bound() { ValueType = BoundValueType.HighestValue };
    }
}
