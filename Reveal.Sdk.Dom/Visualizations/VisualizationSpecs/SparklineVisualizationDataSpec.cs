using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class SparklineVisualizationDataSpec : IndicatorVisualizationDataSpec
    {
		public int NumberOfPeriods { get; set; } = 12;
		public bool ShowIndicator { get; set; } = true;

		public SparklineVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.SparklineVisualizationDataSpecType;
			IndicatorType = IndicatorVisualizationType.LastMonths;
		}
	}
}
