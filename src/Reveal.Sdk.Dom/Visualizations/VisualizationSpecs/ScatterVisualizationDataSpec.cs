using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class ScatterVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public DimensionColumnSpec Category { get; set; }
		public List<MeasureColumnSpec> XAxis { get; set; } = new List<MeasureColumnSpec>();
		public List<MeasureColumnSpec> YAxis { get; set; } = new List<MeasureColumnSpec>();
		public ScatterVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.ScatterVisualizationDataSpecType;
		}
	}
}
