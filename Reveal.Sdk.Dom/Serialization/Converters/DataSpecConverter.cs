using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.DataSpecs;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    internal class DataSpecConverter : JsonConverter<DataSpec>
    {
        public override DataSpec Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerAtStart = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            var type = jsonObject.GetProperty("_type").GetString();

            Type dataSpecType = type switch
            {
                SchemaTypeNames.ResourceDataSpecType => throw new JsonException($"DataSpec not supported: {type}"),
                SchemaTypeNames.TabularDataSpecType => typeof(TabularDataSpec),
                SchemaTypeNames.TextBoxDataSpecType => throw new JsonException($"DataSpec not supported: {type}"),
                SchemaTypeNames.XmlaDataSpecType => throw new JsonException($"DataSpec not supported: {type}"),
                _ => throw new JsonException($"DataSpec not supported: {type}")
            };

            return JsonSerializer.Deserialize(ref readerAtStart, dataSpecType, options) as DataSpec;
        }

        public override void Write(Utf8JsonWriter writer, DataSpec value, JsonSerializerOptions options)
        {
            if (value is TabularDataSpec tabular)
                JsonSerializer.Serialize(writer, tabular, options);
            else
                throw new JsonException($"DataSpec not supported: {value.GetType()}");
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(DataSpec).IsAssignableFrom(typeToConvert);
        }
    }
}
