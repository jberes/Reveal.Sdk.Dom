using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    /// <summary>
    /// The text box visualizations is used to display a text body and an optional title. It is not connected to a data source.
    /// </summary>
    public sealed class TextBoxVisualization : Visualization<TextBoxVisualizationSettings>
    {
        /// <summary>
        /// Creates a text box visualization.
        /// </summary>
        public TextBoxVisualization() : this(null) { }

        /// <summary>
        /// Creates a text box visualization and sets the title to the provided string.
        /// </summary>
        /// <param name="title">The string to use as the visualization's title.</param>
        public TextBoxVisualization(string title) : base(title, null)
        {
            ChartType = ChartType.TextBox;
            InitializeDataDefinition(null);
        }

        [JsonIgnore]
        public Alignment Alignment 
        {
            get { return TextBoxDataDefinition.Alignment; }
            set { TextBoxDataDefinition.Alignment = value; }
        }

        [JsonIgnore]
        public FontSize FontSize 
        { 
            get { return TextBoxDataDefinition.FontSize; }
            set { TextBoxDataDefinition.FontSize = value; }
        }

        [JsonIgnore]
        public string Text
        {
            get { return TextBoxDataDefinition.Text; }
            set { TextBoxDataDefinition.Text = value; }
        }

        private TextBoxDataDefinition TextBoxDataDefinition
        {
            get => (TextBoxDataDefinition)DataDefinition;
        }

        override protected void InitializeDataDefinition(DataSourceItem dataSourceItem)
        {
            DataDefinition = new TextBoxDataDefinition()
            {
                Bindings = null
            };
        }
    }
}
