using Reveal.Sdk.Dom.Core;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Serialization.Converters;

namespace Reveal.Sdk.Dom.Filters
{
    [JsonConverter(typeof(FilterConverter))]
    public class Filter : SchemaType
    {
        [JsonConverter(typeof(StringEnumConverter))]
		public FilterType FilterType { get; set; } = FilterType.AllValues;
		public List<FilterValue> SelectedValues { get; set; }
	}
}
