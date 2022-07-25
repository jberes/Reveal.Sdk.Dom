using Newtonsoft.Json;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class TextBoxVisualization : Visualization<TextBoxVisualizationSettings, TextBoxDataDefinition>
    {
        public TextBoxVisualization() : this(null) { }
        public TextBoxVisualization(string title) : base(title)
        {
            DataDefinition = new TextBoxDataDefinition();
            DataDefinition.Bindings = null;
        }

        [JsonIgnore]
        public Alignment Alignment 
        {
            get { return DataDefinition.Alignment; }
            set { DataDefinition.Alignment = value; }
        }

        [JsonIgnore]
        public FontSize FontSize 
        { 
            get { return DataDefinition.FontSize; }
            set { DataDefinition.FontSize = value; }
        }

        [JsonIgnore]
        public string Text
        {
            get { return DataDefinition.Text; }
            set { DataDefinition.Text = value; }
        }
    }
}
