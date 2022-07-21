using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class ScatterVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public DimensionColumn Category { get; set; }
		public List<MeasureColumn> XAxis { get; set; } = new List<MeasureColumn>();
		public List<MeasureColumn> YAxis { get; set; } = new List<MeasureColumn>();
		public ScatterVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.ScatterVisualizationDataSpecType;
		}
	}
}
