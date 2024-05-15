using System;
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

        public static T GetValue<T>(this IDictionary<string, object> dictionary, string key, T defaultValue = default)
        {
            if (dictionary.TryGetValue(key, out var value) && value != null)
            {
                if (value is T typedValue)
                {
                    return typedValue;
                }
                else
                {
                    try
                    {
                        return (T)Convert.ChangeType(value, typeof(T));
                    }
                    catch (InvalidCastException)
                    {
                        throw new InvalidCastException($"The value associated with the key '{key}' cannot be cast to type {typeof(T).Name}.");
                    }
                }
            }
            return defaultValue;
        }
    }
}
