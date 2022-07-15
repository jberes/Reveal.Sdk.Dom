using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public abstract class ChartVisualizationSettingsBase : VisualizationSettings
    {
        protected ChartVisualizationSettingsBase()
        {
            SchemaTypeName = SchemaTypeNames.ChartVisualizationSettingsType;
            VisualizationType = VisualizationTypes.CHART;
        }

        /// <summary>
        /// Gets or sets the chart type of the Visualization
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        internal ChartType ChartType { get; set; }
    }
}
