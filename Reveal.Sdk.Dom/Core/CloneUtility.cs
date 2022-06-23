using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Core
{
    internal static class CloneUtility
    {
        //This is a quick and dirty way to clone an object without needing write a ton of code. May have to replace this in the future
        internal static T Clone<T>(T item)
        {
            if (ReferenceEquals(item, null))
                return default(T);

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
            return list.Select(item => Clone(item)).ToList();
        }
    }
}
