using Reveal.Sdk.Dom.Visualizations.DataSpecs;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class TextBoxVisualization : Visualization<TextBoxVisualizationSettings, TextBoxDataSpec>
    {
        internal TextBoxVisualization() : this(null) { }
        protected TextBoxVisualization(string title) : base(title)
        {
            DataSpec = new TextBoxDataSpec();
        }
    }
}
