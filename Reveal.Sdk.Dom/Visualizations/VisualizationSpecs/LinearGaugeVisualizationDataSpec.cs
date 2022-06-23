using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    public class LinearGaugeVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public List<MeasureColumnSpec> Value { get; set; } = new List<MeasureColumnSpec>();

		public List<MeasureColumnSpec> Target { get; set; } = new List<MeasureColumnSpec>();

		public LinearGaugeVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.LinearGaugeVisualizationDataSpecType;
		}
	}
}
