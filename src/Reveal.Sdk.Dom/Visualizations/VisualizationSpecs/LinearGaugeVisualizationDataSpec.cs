using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class LinearGaugeVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public List<MeasureColumn> Value { get; set; } = new List<MeasureColumn>();

		public List<MeasureColumn> Target { get; set; } = new List<MeasureColumn>();

		public LinearGaugeVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.LinearGaugeVisualizationDataSpecType;
		}
	}
}
