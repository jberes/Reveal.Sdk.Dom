using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class GridVisualizationDataSpec : VisualizationDataSpec
    {
        public List<TabularColumn> Columns { get; set; } = new List<TabularColumn>();

        public GridVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.GridVisualizationDataSpecType;
        }
    }
}
