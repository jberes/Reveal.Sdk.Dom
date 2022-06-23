using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    internal class TypeMapConverter<T> : JsonConverter<T>
        where T : class
    {
        protected Dictionary<string, Type> TypeMap { get; set; }
        protected string Selector { get; private set; }

        public TypeMapConverter() : this("_type") { }

        public TypeMapConverter(string selector)
        {
            Selector = selector;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            string key = jObject[Selector]?.Value<string>() ?? string.Empty;

            if (string.IsNullOrEmpty(key))
                return (T)Activator.CreateInstance(typeof(T), true);

            if (TypeMap.TryGetValue(jObject[Selector].Value<string>(), out Type target))
            {
                T item = (T)Activator.CreateInstance(target, true);
                serializer.Populate(jObject.CreateReader(), item);
                return item;
            }

            throw new JsonException($"Type not supported {key}");
        }
    }
}
