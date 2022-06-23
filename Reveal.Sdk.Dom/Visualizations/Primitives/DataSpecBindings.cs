using Reveal.Sdk.Dom.Filters;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class DataSpecBindings
    {
        public UrlBinding UrlBinding { get; set; }
        public List<Binding> Bindings { get; set; } = new List<Binding>();
    }
}
