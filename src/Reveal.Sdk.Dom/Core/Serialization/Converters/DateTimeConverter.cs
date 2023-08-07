using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class DateTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime dateTimeValue)
            {
                JObject jObject = new JObject
                {
                    ["_type"] = "date",
                    ["value"] = dateTimeValue
                };
                jObject.WriteTo(writer);
            }
            else
            {
                throw new JsonSerializationException("Expected DateTime object.");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var type = jObject["_type"].Value<string>();
            if (type == "date")
            {
                var value = jObject["value"];
                if (value != null)
                {
                    return value.Value<DateTime>();
                }
                //todo: need to handle the option of XML date time which is a string
                //this code logic can be found on line 248 of JsonUtility.cs in DataLayer.WPF
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(DateTime).IsAssignableFrom(objectType);
        }
    }
}
