using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Serialization.Converters;
using System;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Filters
{
    [JsonConverter(typeof(DashboardFilterConverter))]
    public class DashboardFilter : SchemaType
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
    }
}
