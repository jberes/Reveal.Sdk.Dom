using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class SparklineVisualizationSettings : GridVisualizationSettings
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public SparklineChartType ChartType { get; set; } = SparklineChartType.Line;
        public bool ShowLastTwoValues { get; set; } = true;
        public bool ShowDifference { get; set; } = true;
        public bool PositiveIsRed { get; set; }

        public SparklineVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.SparklineVisualizationSettingsType;
            VisualizationType = VisualizationTypes.SPARKLINE;
        }
    }
}
