using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class PivotVisualizationSettings : GridVisualizationSettingsBase
    {
        internal PivotVisualizationDataSpec _visualizationDataSpec;
        
        public PivotVisualizationSettings() : base()
        {
            SchemaTypeName = SchemaTypeNames.PivotVisualizationSettingsType;
            VisualizationType = VisualizationTypes.PIVOT;
        }

        /// <summary>
        /// Gets are sets whether the pivot grid will display a totals row
        /// </summary>
        [JsonIgnore]
        public bool ShowGrandTotals
        {
            get { return _visualizationDataSpec.ShowGrandTotals; }
            set { _visualizationDataSpec.ShowGrandTotals = value; }
        }

        //todo: what is this used for?
        //[JsonProperty]
        //public List<VisualizationColumnStyle> VisualizationColumns { get; private set; } = new List<VisualizationColumnStyle>();
    }
}
