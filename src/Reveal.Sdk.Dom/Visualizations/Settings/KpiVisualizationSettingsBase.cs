using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public abstract class KpiVisualizationSettingsBase : VisualizationSettings
    {
        /// <summary>
        /// Gets or sets the mode in which the difference between values will be displayed. As a value, percentage, or both value and percentage.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public IndicatorDifferenceMode DifferenceMode { get; set; } = IndicatorDifferenceMode.Percentage;

        /// <summary>
        /// Gets or sets whether the color f the difference indicator will be Red or Green. If true, the color will be red. Otherwise, green.
        /// </summary>
        public bool PositiveIsRed { get; set; }

        /// <summary>
        /// Gets or sets whether the difference will include the values for the current day.
        /// </summary>
        public bool IncludeToday { get; set; } = true;
    }
}
