using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Serialization.Converters;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Core
{
    [JsonConverter(typeof(VisualizationCollectionConverter))]
    public sealed class VisualizationCollection : List<IVisualization>
    {
        public VisualizationCollection()
        {
        }

        internal VisualizationCollection(RdashDocument parent)
        {
            Parent = parent;
        }

        internal RdashDocument Parent { get; set; }

        public new void Add(IVisualization visualization)
        {
            ((IParentDocument)visualization).Document = Parent;
            base.Add(visualization);
        }

        public new void AddRange(IEnumerable<IVisualization> visualizations)
        {
            foreach (var visualization in visualizations)
            {
                ((IParentDocument)visualization).Document = Parent;
            }
            base.AddRange(visualizations);
        }

        public int RemoveById(string id)
        {
            return RemoveAll(v => v.Id == id);
        }

        public int RemoveByTitle(string title)
        {
            return RemoveAll(v => v.Title.Trim().ToLower() == title.Trim().ToLower());
        }

        public IVisualization FindById(string id)
        {
            return Find(v => v.Id == id);
        }
    }
}
