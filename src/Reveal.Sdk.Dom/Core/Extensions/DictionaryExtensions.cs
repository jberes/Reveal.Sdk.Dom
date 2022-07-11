using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Core.Extensions
{
    internal static class DictionaryExtensions
    {
        public static void SetItem(this Dictionary<string, object> dictionary, string key, object value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);
        }
    }
}
