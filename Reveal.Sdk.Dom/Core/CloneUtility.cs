using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Reveal.Sdk.Dom.Core
{
    internal static class CloneUtility
    {
        //This is a quick and dirty way to clone an object without needing write a ton of code. May have to replace this in the future
        internal static T Clone<T>(T item)
        {
            var serialized = JsonSerializer.Serialize(item);
            return JsonSerializer.Deserialize<T>(serialized);
        }

        internal static List<T> Clone<T>(this List<T> list)
        {
            return list.Select(item => Clone(item)).ToList();
        }
    }
}
