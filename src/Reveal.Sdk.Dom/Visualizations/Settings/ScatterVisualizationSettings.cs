using Newtonsoft.Json;
using System;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class ScatterVisualizationSettings : YAxisVisualizationSettings
    {
        public ScatterVisualizationSettings()
        {
            ChartType = RdashChartType.Scatter;
        }

        /// <summary>
        /// Gets or sets if the X axis will use the Logarithmic scale. Linear is used by default.
        /// </summary>
        [JsonProperty("RightAxisLogarithmic")]
        public bool XAxisIsLogarithmic { get; set; }

        /// <summary>
        /// Gets or sets the minimum value for the X axis. Default value is 0.
        /// </summary>
        [JsonProperty("RightAxisMinValue")]
        public double? XAxisMinValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value for the X axis. Default value is calculated automatically depending on the values.
        /// </summary>
        [JsonProperty("RightAxisMaxValue")]
        public double? XAxisMaxValue { get; set; }

        /// <summary>
        /// Gets or sets if the visualization will display the X axis.
        /// This property is being wrapped by the <see cref="AxisDisplayMode"/> to simplify the API.
        /// </summary>
        [JsonProperty]
        internal bool ShowAxisX { get; set; } = true;

        /// <summary>
        /// Gets or sets if the visualization will display the Y axis.
        /// This property is being wrapped by the <see cref="AxisDisplayMode"/> to simplify the API.
        /// </summary>
        [JsonProperty]
        internal bool ShowAxisY { get; set; } = true;

        /// <summary>
        /// Gets or sets the display mode for the axis.
        /// </summary>
        [JsonIgnore]
        public AxisDisplayMode AxisDisplayMode
        {
            get
            {
                if (ShowAxisX && ShowAxisY) return AxisDisplayMode.Both;
                if (!ShowAxisX && !ShowAxisY) return AxisDisplayMode.None;
                if (ShowAxisX) return AxisDisplayMode.XAxis;
                if (ShowAxisY) return AxisDisplayMode.YAxis;
                throw new InvalidOperationException("Invalid axis visibility state.");
            }
            set
            {
                switch (value)
                {
                    case AxisDisplayMode.Both:
                        ShowAxisX = true;
                        ShowAxisY = true;
                        break;
                    case AxisDisplayMode.None:
                        ShowAxisX = false;
                        ShowAxisY = false;
                        break;
                    case AxisDisplayMode.XAxis:
                        ShowAxisX = true;
                        ShowAxisY = false;
                        break;
                    case AxisDisplayMode.YAxis:
                        ShowAxisX = false;
                        ShowAxisY = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
