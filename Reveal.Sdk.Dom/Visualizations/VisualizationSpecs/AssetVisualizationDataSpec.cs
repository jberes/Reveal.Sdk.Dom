using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class AssetVisualizationDataSpec : VisualizationDataSpec
    {
        public TabularColumnSpec UrlColumn { get; set; }

        public AssetVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.AssetVisualizationDataSpecType;
        }
    }
}
