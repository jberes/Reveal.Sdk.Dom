using Reveal.Sdk.Dom.Core;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Filters
{
    public class Filter : SchemaType
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
		public FilterType FilterType { get; set; } = FilterType.AllValues;
		public List<FilterValue> SelectedValues { get; set; }
	}
}
