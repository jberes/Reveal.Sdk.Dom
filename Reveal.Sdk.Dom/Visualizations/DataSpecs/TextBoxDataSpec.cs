using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reveal.Sdk.Dom.Visualizations.DataSpecs
{
    public class TextBoxDataSpec : DataSpec
    {
        public string Text { get; set; }
        public DashboardFontSizeType FontSize { get; set; } = DashboardFontSizeType.Medium;
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
