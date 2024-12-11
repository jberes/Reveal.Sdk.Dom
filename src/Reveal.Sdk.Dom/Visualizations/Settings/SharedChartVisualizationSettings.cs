using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    /// <summary>
    /// This class provides properties that are used by the Column, Bar, Stack Column, Stacked Bar, Stacked Area, Area, Line, Step Area, Step Line, Spline Area, Spline, and Time Series charts.
    /// </summary>
    public abstract class SharedChartVisualizationSettings : YAxisVisualizationSettings
    {
        protected SharedChartVisualizationSettings() : base() { }

        /// <summary>
        /// Gets or sets a value that determines if the chart will automatcially rotate labels
        /// </summary>
        public bool AutomaticLabelRotation { get; set; } = true;

        /// <summary>
        /// Gets or sets a values that will sync the axis to the visible range.
        /// </summary>
        [JsonProperty("SyncAxisVisibleRange")]
        public bool SyncAxis { get; set; }

        /// <summary>
        /// Gets or sets a value that represents the zoom level of the chart. Zoom level ranges from 0.0 (0% zoom) to 1.0 (100% zoom).
        /// </summary>
        [JsonIgnore]
        public double ZoomLevel 
        { 
            get
            {
                if (ChartType == RdashChartType.Bar || ChartType == RdashChartType.StackedBar)
                    return ZoomScaleVertical;

                return ZoomScaleHorizontal;
            }
            set
            {
                if (ChartType == RdashChartType.Bar || ChartType == RdashChartType.StackedBar)
                    ZoomScaleVertical = CoerceValue(value);
                else
                    ZoomScaleHorizontal = CoerceValue(value);
            }
        }

        [JsonProperty]
        internal double ZoomScaleHorizontal { get; set; } = 1;

        [JsonProperty]
        internal double ZoomScaleVertical { get; set; } = 1;

        double CoerceValue(double value)
        {
            if (value > 1)
                return 1;
            else if (value < 0)
                return 0;
            else
                return value;
        }
    }
}
