using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class FixedLine : SchemaType, IFixedLine
    {
        //todo: figure out a better way to handle this
        public static readonly string FIXED_LINE_AVERAGE_PREFIX = "_rp_fla_";
        public static readonly string FIXED_LINE_DATA_PREFIX = "_rp_fld_";
        public static readonly string FIXED_LINE_FIXEDVALUE_PREFIX = "_rp_flfv_";
        public static readonly string FIXED_LINE_HIGHEST_PREFIX = "_rp_flh_";
        public static readonly string FIXED_LINE_LOWEST_PREFIX = "_rp_fll_";

        public int? Color { get; set; }

        public NumberFormatting Formatting { get; set; }

        //todo: is this public? can this be set externally? doesn't look like it
        //this may be used to prevent the ui from allowing more than one of the same type, fixed line high, fixed line low, fixed line average only allow 1
        //except for the Data, in that case this value is the name of the field - can have multiple, but not of the same field name
        //fixed values allow multiple lines
        [JsonProperty()]
        protected string Identifier { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ChartLineStyle LineStyle { get; set; } = ChartLineStyle.Solid;

        //todo: this isn't public is it? This appears to only be used to indicate the line type of the class. figure this out
        [JsonProperty("LineType")]
        [JsonConverter(typeof(StringEnumConverter))]
        protected FixedLineType FixedLineType { get; set; } = FixedLineType.None;

        public double Thickness { get; set; } = 2;

        public string Title { get; set; }
    }
}
