using Reveal.Sdk.Dom.Visualizations.Primitives;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IDate
    {
        //todo: does this have to be a DimensionColumnSpec?
        DimensionColumnSpec Date { get; set; }
    }
}
