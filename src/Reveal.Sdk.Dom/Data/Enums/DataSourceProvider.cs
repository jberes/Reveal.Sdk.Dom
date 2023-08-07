using System.Runtime.Serialization;

namespace Reveal.Sdk.Dom.Data
{
    public enum DataSourceProvider
    {
        [EnumMember(Value = "CSVLOCALFILEPROVIDER")]
        CSV,

        [EnumMember(Value = "JSON")]
        JSON,

        [EnumMember(Value = "REST")]
        REST,

        [EnumMember(Value = "EXCELLOCALFILEPROVIDER")]
        MicrosoftExcel,

        [EnumMember(Value = "SQLSERVER")]
        MicrosoftSqlServer,

        [EnumMember(Value = "WEBSERVICE")]
        WebService
    }
}
