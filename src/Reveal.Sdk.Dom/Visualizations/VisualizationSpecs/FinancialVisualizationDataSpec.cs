using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class FinancialVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public List<MeasureColumnSpec> Open { get; set; } = new List<MeasureColumnSpec>();
		public List<MeasureColumnSpec> High { get; set; } = new List<MeasureColumnSpec>();
		public List<MeasureColumnSpec> Low { get; set; } = new List<MeasureColumnSpec>();
		public List<MeasureColumnSpec> Close { get; set; } = new List<MeasureColumnSpec>();

		public FinancialVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.FinancialVisualizationDataSpecType;
		}
	}
}
