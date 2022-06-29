using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.DataSpecs
{
    public class TextBoxDataSpec : DataSpec
    {
        public string Text { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DashboardFontSizeType FontSize { get; set; } = DashboardFontSizeType.Medium;

        [JsonConverter(typeof(StringEnumConverter))]
        public TextAlignment Alignment { get; set; } = TextAlignment.Left;

        //what is this used for in the model?
        //public JsonObjectWrapper/Dictionary<string, object> RichTextFormatting { get; set; }
    }

    public enum DashboardFontSizeType
    {
        Small,
        Medium,
        Large
    }
}
