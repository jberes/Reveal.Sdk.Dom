using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class NumberFormatting : FormattingBase
    {
        public NumberFormatting()
        {
            SchemaTypeName = SchemaTypeNames.NumberFormattingSpecType;
        }

        public string CurrencySymbol { get; set; } = "$";

        public int DecimalDigits { get; set; } = 2;

        [JsonConverter(typeof(StringEnumConverter))]
        public NumberFormattingType FormatType { get; set; } = NumberFormattingType.Number;

        [JsonProperty("MKFormat")]
        [JsonConverter(typeof(StringEnumConverter))]        
        public LargeNumberFormat LargeNumberFormat { get; set; } = LargeNumberFormat.Auto;

        [JsonConverter(typeof(StringEnumConverter))]
        public NegativeFormatType NegativeFormat { get; set; } = NegativeFormatType.MinusSign;

        public bool ShowGroupingSeparator { get; set; }

        [JsonProperty("ShowDataLabelsInChart")]
        public bool ShowDataLabels { get; set; } = true;
    }
}
