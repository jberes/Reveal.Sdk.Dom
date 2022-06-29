using Reveal.Sdk.Dom.Filters;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IBindDashboardFilters
    {
        List<Binding> FilterBindings { get; }
    }
}