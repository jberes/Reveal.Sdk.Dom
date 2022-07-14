using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class NumberFormattingSpec : FormattingSpec
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public NumberFormattingType FormatType { get; set; } = NumberFormattingType.Number;
        public int DecimalDigits { get; set; } = 2;
        public bool ShowGroupingSeparator { get; set; }
        public string CurrencySymbol { get; set; } = "$";
        [JsonConverter(typeof(StringEnumConverter))]
        public NegativeFormatType NegativeFormat { get; set; } = NegativeFormatType.MinusSign;
        public bool ApplyMkFormat { get; set; }

        public NumberFormattingSpec()
        {
            SchemaTypeName = SchemaTypeNames.NumberFormattingSpecType;
        }
    }
}
