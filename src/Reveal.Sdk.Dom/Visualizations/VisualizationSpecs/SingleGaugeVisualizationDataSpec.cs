using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class SingleGaugeVisualizationDataSpec : SingleValueVisualizationDataSpec
    {
        public DimensionColumn Label { get; set; }

        public SingleGaugeVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.SingleGaugeVisualizationDataSpecType;
        }
    }
}
