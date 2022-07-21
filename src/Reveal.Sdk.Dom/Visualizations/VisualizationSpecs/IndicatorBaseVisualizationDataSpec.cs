using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class IndicatorBaseVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public DimensionColumn Date { get; set; }
		public List<MeasureColumn> Value { get; set; } = new List<MeasureColumn>();

        public IndicatorBaseVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.IndicatorBaseVisualizationDataSpecType;
        }
	}
}