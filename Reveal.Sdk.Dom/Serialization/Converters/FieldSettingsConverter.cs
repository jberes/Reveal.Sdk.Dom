using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    internal class FieldSettingsConverter : JsonConverter<FieldSettings>
    {
        public override FieldSettings Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerAtStart = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            var type = jsonObject.GetProperty("_type").GetString();

            Type fieldSettingsType = type switch
            {
                SchemaTypeNames.DateTimeFieldSettingsType => typeof(DateTimeFieldSettings),
                _ => throw new JsonException($"FieldSettings not supported: {type}")
            };

            return JsonSerializer.Deserialize(ref readerAtStart, fieldSettingsType, options) as FieldSettings;
        }

        public override void Write(Utf8JsonWriter writer, FieldSettings value, JsonSerializerOptions options)
        {
            if (value is DateTimeFieldSettings dtfs)
                JsonSerializer.Serialize(writer, dtfs, options);
            else
                throw new JsonException($"FieldSettings not supported: {value.GetType()}");
        }
    }
}
