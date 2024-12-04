using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class ComboChartVisualizationSettings : YAxisVisualizationSettings
    {
        public ComboChartVisualizationSettings()
        {
            ChartType = RdashChartType.Composite;
        }

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

        /// <summary>
        /// Gets or sets whether Chart2 is overlayed on top of Chart1 with an opacity applied to the chart on top.
        /// </summary>
        [JsonProperty("CompositeChartTypesSwapped")]
        public bool Chart2OnTop { get; set; }

        /// <summary>
        /// Gets or sets the chart type for Chart1
        /// </summary>
        [JsonProperty("CompositeChartType1")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ComboChartType Chart1Type { get; set; } = ComboChartType.Column;

        /// <summary>
        /// Gets or sets the chart type for Chart2
        /// </summary>
        [JsonProperty("CompositeChartType2")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ComboChartType Chart2Type { get; set; } = ComboChartType.Line;

        /// <summary>
        /// Gets or sets if the right axis will use the Logarithmic scale. Linear is used by default.
        /// </summary>
        [JsonProperty("RightAxisLogarithmic")]
        public bool RightAxisIsLogarithmic { get; set; }

        /// <summary>
        /// Gets or sets the minimum value for the right axis. Default value is 0.
        /// </summary>
        [JsonProperty]
        public double? RightAxisMinValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value for the right axis. Default value is calculated automatically depending on the values.
        /// </summary>
        [JsonProperty]
        public double? RightAxisMaxValue { get; set; }

        /// <summary>
        /// This property is being wrapped by the <see cref="ShowRightAxis"/> in order to match the UI experience. This property is needed for the reveal JSON schema.
        /// </summary>
        [JsonProperty]
        internal bool SingleAxisMode { get; set; }

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
        /// Gets or sets if the visualization will display the right axis.
        /// </summary>
        [JsonIgnore]
        public bool ShowRightAxis 
        { 
            get { return !SingleAxisMode; }
            set { SingleAxisMode = !value; }
        }
    }
}
