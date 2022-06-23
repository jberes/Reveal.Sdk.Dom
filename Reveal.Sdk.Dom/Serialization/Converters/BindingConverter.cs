using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    internal class BindingConverter : JsonConverter<Binding>
    {
        public override Binding Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerAtStart = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            var type = jsonObject.GetProperty("Target").GetProperty("_type").GetString();

            Type bindingSourceType = type switch
            {
                SchemaTypeNames.DateGlobalFilterBindingTargetType => typeof(DashboardDateFilterBinding),
                SchemaTypeNames.DataBasedGlobalFilterBindingTargetType => typeof(DashboardDataFilterBinding),
                _ => throw new JsonException()
            };

            return JsonSerializer.Deserialize(ref readerAtStart, bindingSourceType, options) as Binding;
        }

        public override void Write(Utf8JsonWriter writer, Binding value, JsonSerializerOptions options)
        {
            if (value is DashboardDataFilterBinding ddfb)
                JsonSerializer.Serialize(writer, ddfb, options);
            else if (value is DashboardDateFilterBinding datefb)
                JsonSerializer.Serialize(writer, datefb, options);
            else
                throw new JsonException($"Binding not supported: {value.GetType()}");
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(Binding).IsAssignableFrom(typeToConvert);
        }
    }
}
