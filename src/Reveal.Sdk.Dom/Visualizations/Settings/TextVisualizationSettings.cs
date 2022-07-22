using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class TextVisualizationSettings : GaugeVisualizationSettings<TextBand>
    {
        public TextVisualizationSettings()
        {
            ViewType = GaugeViewType.SingleValue;
            UpperBand.ValueComparisonType = ValueComparisonType.Number;
            MiddleBand.ValueComparisonType = ValueComparisonType.Number;
            LowerBand.ValueComparisonType = ValueComparisonType.Number;
        }

        /// <summary>
        /// Gets or sets whether different formatting is applied to a field depending on the upper, middle, and lower range of values
        /// </summary>
        [JsonProperty("SingleValueFormattingEnabled")]
        public bool ConditionalFormattingEnabled { get; set; } = false;
    }
}
