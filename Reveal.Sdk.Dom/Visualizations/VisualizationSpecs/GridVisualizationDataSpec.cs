using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class GridVisualizationDataSpec : VisualizationDataSpec
    {
        public List<TabularColumnSpec> Columns { get; set; }

        public GridVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.GridVisualizationDataSpecType;
            Columns = new List<TabularColumnSpec>();
        }
    }
}
