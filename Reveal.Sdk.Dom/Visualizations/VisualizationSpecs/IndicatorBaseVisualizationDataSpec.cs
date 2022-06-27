using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class IndicatorBaseVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public DimensionColumnSpec Date { get; set; }
		public List<MeasureColumnSpec> Value { get; set; } = new List<MeasureColumnSpec>();

        public IndicatorBaseVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.IndicatorBaseVisualizationDataSpecType;
        }
	}
}