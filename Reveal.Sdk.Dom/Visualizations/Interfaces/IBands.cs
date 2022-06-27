using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{

    public interface IBands
    {
        List<GaugeBand> Bands { get; }
    }
}
