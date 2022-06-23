using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    internal class FormattingSpecConverter : JsonConverter<FormattingSpec>
    {
        public override FormattingSpec Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerAtStart = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            var type = jsonObject.GetProperty("_type").GetString();

            Type formattingSpecType = type switch
            {
                SchemaTypeNames.NumberFormattingSpecType => typeof(NumberFormattingSpec),
                SchemaTypeNames.DateFormattingSpecType => typeof(DateFormattingSpec),
                _ => throw new JsonException($"FormattingSpec not supported: {type}")
            };

            return JsonSerializer.Deserialize(ref readerAtStart, formattingSpecType, options) as FormattingSpec;
        }

        public override void Write(Utf8JsonWriter writer, FormattingSpec value, JsonSerializerOptions options)
        {
            if (value is NumberFormattingSpec nfs)
                JsonSerializer.Serialize(writer, nfs, options);
            else if (value is DateFormattingSpec dfs)
                JsonSerializer.Serialize(writer, dfs, options);
            else
                throw new JsonException($"FormattingSpec not supported: {value.GetType()}");
        }
    }
}
