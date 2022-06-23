using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Variables;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    internal class BindingTargetConverter : JsonConverter<BindingTarget>
    {
        public override BindingTarget Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerAtStart = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            var type = jsonObject.GetProperty("_type").GetString();

            Type bindingTargetType = type switch
            {
                SchemaTypeNames.DataBasedGlobalFilterBindingTargetType => typeof(DashboardDataFilterBindingTarget),
                SchemaTypeNames.DateGlobalFilterBindingTargetType => typeof(DashboardDateFilterBindingTarget),
                SchemaTypeNames.GlobalVariableBindingTargetType => typeof(GlobalVariableBindingTarget),
                _ => throw new JsonException()
            };

            return JsonSerializer.Deserialize(ref readerAtStart, bindingTargetType, options) as BindingTarget;
        }

        public override void Write(Utf8JsonWriter writer, BindingTarget value, JsonSerializerOptions options)
        {
            if (value is DashboardDataFilterBindingTarget dbgf)
                JsonSerializer.Serialize(writer, dbgf, options);
            else if (value is DashboardDateFilterBindingTarget dgf)
                JsonSerializer.Serialize(writer, dgf, options);
            else if (value is GlobalVariableBindingTarget gvb)
                JsonSerializer.Serialize(writer, gvb, options);
            else
                throw new JsonException($"BindingTarget not supported: {value.GetType()}");
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(BindingTarget).IsAssignableFrom(typeToConvert);
        }
    }
}
