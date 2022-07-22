using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.DataSpecs
{
    public class TextBoxDataSpec : DataSpec
    {
        public TextBoxDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.TextBoxDataSpecType;
        }
        
        public string Text { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public FontSize FontSize { get; set; } = FontSize.Medium;

        [JsonConverter(typeof(StringEnumConverter))]
        public Alignment Alignment { get; set; } = Alignment.Left;
    }
}
