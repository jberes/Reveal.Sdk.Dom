using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class BindingConverter : CustomJsonConverter<Binding>
    {
        public override Binding ReadJson(JsonReader reader, Type objectType, Binding existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var type = jObject.SelectToken("Target._type").Value<string>();

            Type bindingType = type switch
            {
                SchemaTypeNames.DateGlobalFilterBindingTargetType => typeof(DashboardDateFilterBinding),
                SchemaTypeNames.DataBasedGlobalFilterBindingTargetType => typeof(DashboardDataFilterBinding),
                _ => throw new JsonException()
            };

            var item = Activator.CreateInstance(bindingType, true);
            serializer.Populate(jObject.CreateReader(), item);
            return item as Binding;
        }
    }
}
