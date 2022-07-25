using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class ComboChartVisualizationSettings : YAxisVisualizationSettings
    {
        public ComboChartVisualizationSettings()
        {
            ChartType = ChartType.Composite;
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

        //todo: revisit this approach and see if we can do somethig better. Possibly just a better name like ShowLeftAxisOnly or something
        //ideally we don't have to do this wrapping - need more feedback here
        /// <summary>
        /// This property is being wrapped by the <see cref="ShowRightAxis"/> in order to match the RevealView UI experience. This property is needed for the reveal JSON schema.
        /// </summary>
        [JsonProperty]
        internal bool SingleAxisMode { get; set; }
        
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
