using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Serialization.Converters;
using System;

namespace Reveal.Sdk.Dom
{
    public sealed class DateRange
    {
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? From { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? To { get; set; }
    }
}
