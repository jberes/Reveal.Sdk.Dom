using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Data;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Serialization.Converters
{
    public class DataSourceItemConverter : JsonConverter<DataSourceItem>
    {
        public override DataSourceItem Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerAtStart = reader;

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDocument.RootElement;

            var type = jsonObject.GetProperty("_type").GetString();

            Type dataSourceItemType = type switch
            {
                SchemaTypeNames.CompositeDataSourceItemType => typeof(CompositeDataSourceItem),
                SchemaTypeNames.DataSourceItemType => typeof(DataSourceItem),
                _ => throw new JsonException()
            };

            return JsonSerializer.Deserialize(ref readerAtStart, dataSourceItemType, options) as DataSourceItem;
        }

        public override void Write(Utf8JsonWriter writer, DataSourceItem value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
