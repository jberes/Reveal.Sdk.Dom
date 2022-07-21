using Reveal.Sdk.Dom.Core;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Filters
{
    public abstract class FilterBase : SchemaType, IFilter
    {
        [JsonConverter(typeof(StringEnumConverter))]
		public FilterType FilterType { get; set; } = FilterType.AllValues;
		public List<FilterValue> SelectedValues { get; set; }
	}
}
