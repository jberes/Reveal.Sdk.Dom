using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class GridVisualizationDataSpec : VisualizationDataSpec
    {
        public List<TabularColumnSpec> Columns { get; set; } = new List<TabularColumnSpec>();

        public GridVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.GridVisualizationDataSpecType;
        }
    }
}
