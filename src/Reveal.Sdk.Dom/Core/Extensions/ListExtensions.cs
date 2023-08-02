using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom
{
    public static class ListExtensions
    {
        public static List<IVisualization> RemoveById(this List<IVisualization> list, string id)
        {
            list.RemoveAll(v => v.Id == id);
            return list;
        }

        public static List<IVisualization> RemoveByTitle(this List<IVisualization> list, string title)
        {
            list.RemoveAll(v => v.Title.Trim().ToLower() == title.Trim().ToLower());
            return list;
        }
    }
}
