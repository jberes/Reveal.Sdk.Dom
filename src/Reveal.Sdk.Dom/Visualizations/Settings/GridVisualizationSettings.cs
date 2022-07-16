using Newtonsoft.Json;
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

        /// <summary>
        /// Gets or sets whether the first column in the grid is fixed.
        /// </summary>
        [JsonIgnore()]
        public bool FixFirstColumn
        {
            get { return Style.FixedLeftColumns; }
            set { Style.FixedLeftColumns = value; }
        }
    }
}
