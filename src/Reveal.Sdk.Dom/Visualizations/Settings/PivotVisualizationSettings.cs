using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public sealed class PivotVisualizationSettings : GridVisualizationSettingsBase
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
    }
}
