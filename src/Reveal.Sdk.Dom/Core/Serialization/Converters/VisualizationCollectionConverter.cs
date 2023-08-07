using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Reveal.Sdk.Dom.Visualizations;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class VisualizationCollectionConverter : CustomJsonConverter<VisualizationCollection>
    {
        public override VisualizationCollection ReadJson(JsonReader reader, Type objectType, VisualizationCollection existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var collection = existingValue ?? new VisualizationCollection();
            var token = JToken.Load(reader);

            if (token.Type == JTokenType.Array)
            {
                collection.AddRange(token.ToObject<IEnumerable<IVisualization>>());
            }
            else if (token.Type == JTokenType.Object)
            {
                collection.Add(token.ToObject<IVisualization>());
            }

            return collection;
        }
    }
}
