using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    internal class FilterConverter : JsonConverter<Filter>
    {
        public override Filter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerAtStart = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            var type = jsonObject.GetProperty("_type").GetString();

            Type filterType = type switch
            {
                SchemaTypeNames.NumberFilterType => typeof(NumberFilter),
                SchemaTypeNames.StringFilterType => typeof(StringFilter),
                SchemaTypeNames.DateTimeFilterType => typeof(DateTimeFilter),
                _ => throw new JsonException($"Filter not supported {type}")
            };

            return JsonSerializer.Deserialize(ref readerAtStart, filterType, options) as Filter;
        }

        public override void Write(Utf8JsonWriter writer, Filter value, JsonSerializerOptions options)
        {
            if (value is NumberFilter nbf)
                JsonSerializer.Serialize(writer, nbf, options);
            else if (value is StringFilter sf)
                JsonSerializer.Serialize(writer, sf, options);
            else if (value is DateTimeFilter dtf)
                JsonSerializer.Serialize(writer, dtf, options);
            else
                throw new JsonException($"Filter not supported {value}");
        }
    }
}
