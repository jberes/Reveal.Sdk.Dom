using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	public class FinancialVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public List<MeasureColumn> Open { get; set; } = new List<MeasureColumn>();
		public List<MeasureColumn> High { get; set; } = new List<MeasureColumn>();
		public List<MeasureColumn> Low { get; set; } = new List<MeasureColumn>();
		public List<MeasureColumn> Close { get; set; } = new List<MeasureColumn>();

		public FinancialVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.FinancialVisualizationDataSpecType;
		}
	}
}
