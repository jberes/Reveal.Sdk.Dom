using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public abstract class PieChartVisualizationSettingsBase : ChartVisualizationSettingsBase
    {
        protected PieChartVisualizationSettingsBase() : base() { }

        /// <summary>
        /// Gets or sets if the chart legend is displayed in the RevealView
        /// </summary>
        [JsonProperty("ShowLegends")]
        public bool ShowLegend { get; set; } = true;

        /// <summary>
        /// Gets or sets the how the slice labels are displayed. Display only the values, only the percentages, or both.
        /// </summary>
        [JsonProperty("LabelDisplayMode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LabelDisplayMode SliceLabelDisplay { get; set; }

        /// <summary>
        /// Gets or sets the color index for the visualization's starting color. A zero-based index is used to set colors instead of a color name.
        /// For example, an index of 5 would be the 6th color in the color scheme regardless of the theme colors being used.
        /// </summary>
        [JsonProperty("BrushOffsetIndex")]
        public int? StartColorIndex { get; set; }

        //todo: this property controls the "Others" slice. It only support 0.0 (0%) - show all slices, 1.0 (1%), 2.0 (2%), 3.0 (3%), 4.0 (4%)
        //what can we do here to make this API nicer and enforce the allowed values?
        [JsonProperty]
        internal double OthersSliceThreshold { get; set; } = 3.0;
    }
}
