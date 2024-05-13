using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Core.Utilities
{
    internal static class CloneUtility
    {
        internal static T Clone<T>(T item)
        {
            if (item is null)
                return default;

            var deserializeSettings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };
            var serializeSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(item, serializeSettings), deserializeSettings);
        }

        internal static List<T> Clone<T>(this List<T> list)
        {
            if (list is null)
                return new List<T>();

            return list.Select(item => Clone(item)).ToList();
        }
    }
}
