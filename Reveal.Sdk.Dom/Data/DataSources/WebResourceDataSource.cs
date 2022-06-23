using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    public class WebResourceDataSource : DataSource
    {
        [JsonIgnore]
        public string Url
        {
            get
            {
                if (Properties.TryGetValue("Url", out object value))
                    return (string)value;
                else
                    return null;
            }
            set
            {
                if (Properties.ContainsKey("Url"))
                    Properties["Url"] = value;
                else
                    Properties.Add("Url", value);
            }
        }

        [JsonIgnore]
        public bool UseAnonymousAuthentication
        {
            get
            {
                if (Properties.TryGetValue("_rpUseAnonymousAuthentication", out object value))
                    return (bool)value;
                else
                    return false;
            }
            set
            {
                if (Properties.ContainsKey("Url"))
                    Properties["_rpUseAnonymousAuthentication"] = value;
                else
                    Properties.Add("_rpUseAnonymousAuthentication", value);
            }
        }

        public WebResourceDataSource()
        {
            Provider = DataSourceProviders.WebServiceProvider;
        }
    }
}
