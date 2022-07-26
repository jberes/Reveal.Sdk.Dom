using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public abstract class PieChartVisualizationSettingsBase : ChartVisualizationSettingsBase
    {
        private double _othersSliceThreshold = 3.0;

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

        /// <summary>
        /// Gets or sets the percentage threshold in which values are combined into the "Others" category. 
        /// Supported values include: 0.0 (0%) - show all slices, 1.0 (1%), 2.0 (2%), 3.0 (3%), 4.0 (4%)
        /// </summary>
        [JsonProperty]
        public double OthersSliceThreshold
        {
            get { return _othersSliceThreshold; }
            set { _othersSliceThreshold = CoerceValue(value); }
        }

        double CoerceValue(double value)
        {
            var round = Math.Round(value, 0, MidpointRounding.AwayFromZero);
            if (round <= 0.0)
                return 0.0;

            if (round <= 4.0)
                return round;

            return 4.0;
        }
    }
}
