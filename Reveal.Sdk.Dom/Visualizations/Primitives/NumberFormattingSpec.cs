using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class NumberFormattingSpec : FormattingSpec
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public NumberFormattingType FormatType { get; set; }
        public int DecimalDigits { get; set; }
        public bool ShowGroupingSeparator { get; set; }
        public string CurrencySymbol { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public NegativeFormatType NegativeFormat { get; set; }
        public bool ApplyMkFormat { get; set; }

        public NumberFormattingSpec()
        {
            SchemaTypeName = SchemaTypeNames.NumberFormattingSpecType;
            FormatType = NumberFormattingType.Number;
            DecimalDigits = 2;
            CurrencySymbol = "$";
            NegativeFormat = NegativeFormatType.MinusSign;
        }
    }
}
