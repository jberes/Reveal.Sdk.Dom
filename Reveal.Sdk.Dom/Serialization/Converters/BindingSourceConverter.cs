using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    internal class BindingSourceConverter : JsonConverter<BindingSource>
    {
        public override BindingSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerAtStart = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            var type = jsonObject.GetProperty("_type").GetString();

            Type bindingSourceType = type switch
            {
                SchemaTypeNames.FieldBindingSourceType => typeof(FieldBindingSource),
                SchemaTypeNames.ParameterBindingSourceType => typeof(ParameterBindingSource),
                _ => throw new JsonException()
            };

            return JsonSerializer.Deserialize(ref readerAtStart, bindingSourceType, options) as BindingSource;
        }

        public override void Write(Utf8JsonWriter writer, BindingSource value, JsonSerializerOptions options)
        {
            if (value is FieldBindingSource fbs)
                JsonSerializer.Serialize(writer, fbs, options);
            else if (value is ParameterBindingSource pbs)
                JsonSerializer.Serialize(writer, pbs, options);
            else
                throw new JsonException($"BindingSource not supported: {value.GetType()}");
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(BindingSource).IsAssignableFrom(typeToConvert);
        }
    }
}
