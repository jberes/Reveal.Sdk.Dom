using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    //Column, Bar, Area, Line, Step Area, Step Line, Spline Area, Spline, Time Series
    public abstract class ChartVisualizationSettings : LeftAxisVisualizationSettings
    {
        protected ChartVisualizationSettings() : base() { }        

        /// <summary>
        /// Gets or sets whether a total (sum) of values will be displayed in the tooltip. Only applied when categories have been added to the visualization.
        /// </summary>
        [JsonProperty]
        internal bool ShowTotalsInTooltip { get; set; }

        /// <summary>
        /// Gets or sets a trendline to apply to the visualization
        /// </summary>
        [JsonProperty("TrendlineType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TrendlineType Trendline { get; set; }

        //todo: implement properties
        //ZoomLevel
        //AutomaticLabelRotation
        //SyncAxis
    }

    public abstract class TrendlineVisualizationSettings : ChartVisualizationSettings
    {
        protected TrendlineVisualizationSettings() : base() { }

        /// <summary>
        /// Gets or sets a trendline to apply to the visualization
        /// </summary>
        [JsonProperty("TrendlineType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TrendlineType Trendline { get; set; }
    }






    

    
    public abstract class ChartVisualizationSettings2 : ChartVisualizationSettingsBase
    {
        protected ChartVisualizationSettings2() : base() { }

        /// <summary>
        /// Gets or sets if the chart legend is displayed in the RevealView
        /// </summary>
        [JsonProperty("ShowLegends")]
        public bool ShowLegend { get; set; } = true;

        /// <summary>
        /// Gets or sets the color index for the visualization's starting color. A zero-based index is used to set colors instead of a color name.
        /// For example, an index of 5 would be the 6th color in the color scheme regardless of the theme colors being used.
        /// </summary>
        [JsonProperty("BrushOffsetIndex")]
        public int? StartColorIndex { get; set; }
    }

    //combo, stacked column, stacked area, stacked area, bubble, scatter
    public abstract class LeftAxisVisualizationSettings : ChartVisualizationSettings2
    {
        protected LeftAxisVisualizationSettings() : base() { }

        /// <summary>
        /// Gets or sets whether the left axis will use the Logarithmic scale. Linear is used by default.
        /// </summary>
        [JsonProperty("LeftAxisLogarithmic")]
        public bool LeftAxisIsLogarithmic { get; set; }

        /// <summary>
        /// Gets or sets the minimum value for the left axis. Default value is null, which also equates to zero.
        /// </summary>
        [JsonProperty]
        public double? LeftAxisMinValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value for the left axis. Default value is calculated automatically depending on the values.
        /// </summary>
        [JsonProperty]
        public double? LeftAxisMaxValue { get; set; }
    }

    public abstract class CategoryChartVisualizationSettings : ChartVisualizationSettings2
    {
        
    }



}
