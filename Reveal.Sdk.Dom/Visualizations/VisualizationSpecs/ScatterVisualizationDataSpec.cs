using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class ScatterVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public DimensionColumnSpec Category { get; set; }
		public List<MeasureColumnSpec> XAxis { get; set; }
		public List<MeasureColumnSpec> YAxis { get; set; }
		public ScatterVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.ScatterVisualizationDataSpecType;
			XAxis = new List<MeasureColumnSpec>();
			YAxis = new List<MeasureColumnSpec>();
		}
	}
}
