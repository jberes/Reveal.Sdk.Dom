using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.DataSpecs
{
    public class TextBoxDataSpec : DataSpec
    {
        public string Text { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public FontSize FontSize { get; set; } = FontSize.Medium;

        [JsonConverter(typeof(StringEnumConverter))]
        public TextAlignment Alignment { get; set; } = TextAlignment.Left;

        public TextBoxDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.TextBoxDataSpecType;
        }
    }
}
