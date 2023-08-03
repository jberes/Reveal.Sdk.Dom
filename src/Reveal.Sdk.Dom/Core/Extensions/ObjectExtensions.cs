using Reveal.Sdk.Dom.Core.Serialization;

namespace Reveal.Sdk.Dom
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Converts an object to a JSON string.
        /// </summary>
        /// <param name="object">The object to convert.</param>
        /// <returns>The JSON string.</returns>
        public static string ToJsonString(this object @object)
        {
            return RdashSerializer.SerializeObject(@object);
        }
    }
}
