using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class SingleGaugeVisualizationDataSpec : SingleValueVisualizationDataSpec
    {
        public DimensionColumnSpec Label { get; set; }

        public SingleGaugeVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.SingleGaugeVisualizationDataSpecType;
        }
    }
}
