using Newtonsoft.Json.Serialization;
using System.Linq;

namespace Reveal.Sdk.Dom.Serialization
{
    public class EnumWithSpacesNamingStrategy : NamingStrategy
    {
        protected override string ResolvePropertyName(string name)
        {
            return string.Concat(name.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart();
        }
    }
}
