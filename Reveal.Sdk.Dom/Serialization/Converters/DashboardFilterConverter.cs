using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    internal class DashboardFilterConverter : JsonConverter<DashboardFilter>
    {
        public override DashboardFilter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerAtStart = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            var visualizationType = jsonObject.GetProperty("_type").GetString();

            Type filterType = visualizationType switch
            {
                SchemaTypeNames.DateGlobalFilterType => typeof(DashboardDateFilter),
                SchemaTypeNames.TabularGlobalFilterType => typeof(DashboardDataFilter),
                _ => throw new JsonException($"DashboardFilter not supported {visualizationType}")
            };

            return JsonSerializer.Deserialize(ref readerAtStart, filterType, options) as DashboardFilter;
        }

        public override void Write(Utf8JsonWriter writer, DashboardFilter value, JsonSerializerOptions options)
        {
            if (value is DashboardDateFilter dgf)
                JsonSerializer.Serialize(writer, dgf, options);
            else if (value is DashboardDataFilter ddf)
                JsonSerializer.Serialize(writer, ddf, options);
            else
                throw new JsonException($"DashboardFilter not supported {value}");
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(DashboardFilter).IsAssignableFrom(typeToConvert);
        }
    }
}
