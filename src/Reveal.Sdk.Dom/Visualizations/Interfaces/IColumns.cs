using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    //todo: add extension methods
    public interface IColumns
    {
        List<DimensionColumnSpec> Columns { get; }
    }
}
