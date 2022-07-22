using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class SparklineVisualizationSettings : GridVisualizationSettingsBase
    {
        internal SparklineVisualizationDataSpec _visualizationDataSpec;

        public SparklineVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.SparklineVisualizationSettingsType;
            VisualizationType = VisualizationTypes.SPARKLINE;
        }        
        
        /// <summary>
        /// Gets or sets the chart type to use for the sparkline visualization.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SparklineChartType ChartType { get; set; } = SparklineChartType.Line;

        /// <summary>
        /// Gets or sets the number of days, months, or years to use for aggregating the data.
        /// </summary>
        [JsonIgnore]
        public int NumberOfPeriods
        {
            get { return _visualizationDataSpec.NumberOfPeriods; }
            set { _visualizationDataSpec.NumberOfPeriods = value; }
        }

        /// <summary>
        /// Gets or sets the aggregation type to use when aggregating the data.
        /// </summary>
        [JsonIgnore]
        public SparklineAggregationType AggregationType
        {
            get { return ConvertIndicatorVisualizationTypeToSparklineAggregationType(_visualizationDataSpec.IndicatorType); }
            set { _visualizationDataSpec.IndicatorType = ConvertSparklineAggregationTypeToIndicatorVisualizationType(value); }
        }

        /// <summary>
        /// Gets or sets whether a positive difference will be displayed with a red color. When false, green is used.
        /// </summary>
        public bool PositiveIsRed { get; set; }

        /// <summary>
        /// Gets or sets whether the grid will display columns representing the last two values in the data set.
        /// </summary>
        public bool ShowLastTwoValues { get; set; } = true;
        
        /// <summary>
        /// Gets or sets whether the grid will display a column representing the difference between the last two values as a percentage.
        /// </summary>
        public bool ShowDifference { get; set; } = true;

        SparklineAggregationType ConvertIndicatorVisualizationTypeToSparklineAggregationType(IndicatorVisualizationType indicatorVisualizationType)
        {
            return indicatorVisualizationType switch
            {
                IndicatorVisualizationType.LastDays => SparklineAggregationType.Days,
                IndicatorVisualizationType.LastMonths => SparklineAggregationType.Months,
                _ => SparklineAggregationType.Years
            };
        }

        IndicatorVisualizationType ConvertSparklineAggregationTypeToIndicatorVisualizationType(SparklineAggregationType sparklineIndicatorType)
        {
            return sparklineIndicatorType switch
            {
                SparklineAggregationType.Days => IndicatorVisualizationType.LastDays,
                SparklineAggregationType.Months => IndicatorVisualizationType.LastMonths,
                _ => IndicatorVisualizationType.LastYears
            };
        }
    }
}
