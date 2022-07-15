using Newtonsoft.Json;
using Reveal.Sdk.Dom.Visualizations.DataSpecs;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class TextBoxVisualization : Visualization<TextBoxVisualizationSettings, TextBoxDataSpec>
    {
        public TextBoxVisualization() : this(null) { }
        public TextBoxVisualization(string title) : base(title)
        {
            DataSpec = new TextBoxDataSpec();
            DataSpec.Bindings = null;
        }

        [JsonIgnore]
        public Alignment Alignment 
        {
            get { return DataSpec.Alignment; }
            set { DataSpec.Alignment = value; }
        }

        [JsonIgnore]
        public FontSize FontSize 
        { 
            get { return DataSpec.FontSize; }
            set { DataSpec.FontSize = value; }
        }

        [JsonIgnore]
        public string Text
        {
            get { return DataSpec.Text; }
            set { DataSpec.Text = value; }
        }
    }
}
