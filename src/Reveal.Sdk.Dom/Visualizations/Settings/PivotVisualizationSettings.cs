using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class PivotVisualizationSettings : GridVisualizationSettingsBase
    {        
        public PivotVisualizationSettings() : base()
        {
            SchemaTypeName = SchemaTypeNames.PivotVisualizationSettingsType;
            VisualizationType = VisualizationTypes.PIVOT;
        }

        public bool HideGrandTotals { get; set; }

        [JsonProperty]
        public List<VisualizationColumnStyle> VisualizationColumns { get; private set; } = new List<VisualizationColumnStyle>();
    }
}
