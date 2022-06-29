namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class TextVisualizationSettings : GaugeVisualizationSettings
    {
        public TextVisualizationSettings()
        {
            ViewType = GaugeViewType.SingleValue;
            ConditionalFormattingEnabled = false;
        }
    }

    public class LinearGaugeVisualizationSettings : GaugeVisualizationSettings
    {
        public LinearGaugeVisualizationSettings()
        {
            ViewType = GaugeViewType.Linear;
        }
    }

    public class CircularGaugeVisualizationSettings : GaugeVisualizationSettings
    {
        public CircularGaugeVisualizationSettings()
        {
            ViewType = GaugeViewType.Circular;
        }
    }
}
