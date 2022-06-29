using Reveal.Sdk.Dom.Visualizations.DataSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    //todo: rename
    public interface IDataSpec<out T>
        where T : DataSpec
    {
        T DataSpec { get; }
    }
}