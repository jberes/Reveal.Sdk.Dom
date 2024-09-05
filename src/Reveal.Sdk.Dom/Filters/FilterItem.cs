using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Filters
{
    public sealed class FilterItem
    {
        public FilterItem() { }
        public FilterItem(string fieldName, object value)
        {
            FieldValues.Add(fieldName, value);
        }

        public Dictionary<string, object> FieldValues { get; set; } = new Dictionary<string, object>();
        public List<string> ExpansionPath { get; set; } = new List<string>();
    }
}
