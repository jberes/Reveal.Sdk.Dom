namespace Reveal.Sdk.Dom.Visualizations
{
    public static class TextBoxVisualizationExtensions
    {
        public static TextBoxVisualization SetAlignment(this TextBoxVisualization visualization, Alignment alignment)
        {
            visualization.Alignment = alignment;
            return visualization;
        }

        public static TextBoxVisualization SetFontSize(this TextBoxVisualization visualization, FontSize fontSize)
        {
            visualization.FontSize = fontSize;
            return visualization;
        }

        public static TextBoxVisualization SetText(this TextBoxVisualization visualization, string text)
        {
            visualization.Text = text;
            return visualization;
        }
    }
}