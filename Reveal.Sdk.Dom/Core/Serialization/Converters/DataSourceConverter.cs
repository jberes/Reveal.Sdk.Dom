using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Data;
using System;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class DataSourceConverter : CustomJsonConverter<DataSource>
    {
        public override DataSource ReadJson(JsonReader reader, Type objectType, DataSource existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var type = jObject["Provider"].Value<string>();

            Type bindingType = type switch
            {
                DataSourceProviders.ExcelProvider => typeof(ExcelDataSource),
                DataSourceProviders.WebServiceProvider => typeof(WebResourceDataSource),
                _ => typeof(DataSource)
            };

            var item = Activator.CreateInstance(bindingType, true);
            serializer.Populate(jObject.CreateReader(), item);
            return item as DataSource;
        }
    }
}
