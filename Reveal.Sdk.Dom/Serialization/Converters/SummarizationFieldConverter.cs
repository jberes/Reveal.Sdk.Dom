using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    internal class SummarizationFieldConverter : JsonConverter<SummarizationField>
    {
        public override SummarizationField Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerAtStart = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            var type = jsonObject.GetProperty("_type").GetString();

            Type summarizationType = type switch
            {
                SchemaTypeNames.SummarizationDateFieldType => typeof(SummarizationDateField),
                SchemaTypeNames.SummarizationRegularFieldType => typeof(SummarizationRegularField),
                SchemaTypeNames.SummarizationValueFieldType => typeof(SummarizationValueField),
                _ => throw new JsonException($"SummarizationField not supported: {type}")
            };

            return JsonSerializer.Deserialize(ref readerAtStart, summarizationType, options) as SummarizationField;
        }

        public override void Write(Utf8JsonWriter writer, SummarizationField value, JsonSerializerOptions options)
        {
            if (value is SummarizationDateField sdf)
                JsonSerializer.Serialize(writer, sdf, options);
            else if (value is SummarizationRegularField srf)
                JsonSerializer.Serialize(writer, srf, options);
            else if (value is SummarizationValueField svf)
                JsonSerializer.Serialize(writer, svf, options);
            else
                throw new JsonException($"SummarizationField not supported: {value.GetType()}");
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(SummarizationField).IsAssignableFrom(typeToConvert);
        }
    }
}
