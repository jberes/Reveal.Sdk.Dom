using Newtonsoft.Json;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class CustomJsonConverter<T> : JsonConverter<T>
        where T : class
    {
        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite => false;
    }
}
