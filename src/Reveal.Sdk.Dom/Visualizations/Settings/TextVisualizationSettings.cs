using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class TextVisualizationSettings : GaugeVisualizationSettings<TextBand>
    {
        public TextVisualizationSettings()
        {
            ViewType = GaugeViewType.SingleValue;
            UpperBand.ValueComparisonType = ValueComparisonType.NumberValue;
            MiddleBand.ValueComparisonType = ValueComparisonType.NumberValue;
            LowerBand.ValueComparisonType = ValueComparisonType.NumberValue;
        }

        /// <summary>
        /// Gets or sets whether different formatting is applied to a field depending on the upper, middle, and lower range of values
        /// </summary>
        [JsonProperty("SingleValueFormattingEnabled")]
        public bool ConditionalFormattingEnabled { get; set; } = false;
    }
}
