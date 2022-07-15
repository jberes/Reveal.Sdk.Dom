using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class GridVisualizationSettings : GridVisualizationSettingsBase
    {
        public GridVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.GridVisualizationSettingsType;
            VisualizationType = VisualizationTypes.GRID;
        }

        [JsonIgnore]
        public bool FixedLeftColumns
        {
            get { return Style.FixedLeftColumns; }
            set { Style.FixedLeftColumns = value; }
        }
    }

    public abstract class GridVisualizationSettingsBase : VisualizationSettings
    {
        protected GridVisualizationSettingsBase() { }

        [JsonIgnore]
        public Alignment DateFieldAlignment
        {
            get { return Style.DateAlignment; }
            set { Style.DateAlignment = value; }
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public FontSize FontSize { get; set; } = FontSize.Small;

        [JsonIgnore]
        public Alignment NumericFieldAlignment
        {
            get { return Style.NumericAlignment; }
            set { Style.NumericAlignment = value; }
        }

        [JsonIgnore]
        public Alignment TextFieldAlignment 
        {
            get { return Style.TextAlignment; }
            set { Style.TextAlignment = value; }
        }

        [JsonProperty]
        protected GridVisualizationStyle Style { get; set; } = new GridVisualizationStyle();
    }
}
