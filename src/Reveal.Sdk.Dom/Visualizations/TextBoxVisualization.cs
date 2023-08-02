using Newtonsoft.Json;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The text box visualizations is used to display a text body and an optional title. It is not connected to a data source.
    /// </summary>
    public sealed class TextBoxVisualization : Visualization<TextBoxVisualizationSettings, TextBoxDataDefinition>, ITextBoxDataDefinitionProvider
    {
        /// <summary>
        /// Creates a text box visualization.
        /// </summary>
        public TextBoxVisualization() : this(null) { }

        /// <summary>
        /// Creates a text box visualization and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
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
