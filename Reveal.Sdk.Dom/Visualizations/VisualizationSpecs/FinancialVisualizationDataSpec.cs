using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class FinancialVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public List<MeasureColumnSpec> Open { get; set; }
		public List<MeasureColumnSpec> High { get; set; }
		public List<MeasureColumnSpec> Low { get; set; }
		public List<MeasureColumnSpec> Close { get; set; }
		
		public FinancialVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.FinancialVisualizationDataSpecType;
			Open = new List<MeasureColumnSpec>();
			High = new List<MeasureColumnSpec>();
			Low = new List<MeasureColumnSpec>();
			Close = new List<MeasureColumnSpec>();
		}
	}
}
