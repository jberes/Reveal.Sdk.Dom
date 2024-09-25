using System.Runtime.Serialization;

namespace Reveal.Sdk.Dom.Data
{
    public enum DataSourceProvider
    {
        [EnumMember(Value = "AMAZON_ATHENA")]
        AmazonAthena,

        [EnumMember(Value = "AMAZON_REDSHIFT")]
        AmazonRedshift,

        [EnumMember(Value = "AMAZON_S3")]
        AmazonS3,

        [EnumMember(Value = "ASSET_PROVIDER")]
        Asset,

        [EnumMember(Value = "BOXPROVIDER")]
        Box,

        [EnumMember(Value = "CSVLOCALFILEPROVIDER")]
        CSV,

        [EnumMember(Value = "DROPBOXPROVIDER")]
        Dropbox,

        [EnumMember(Value = "GOOGLE_ADS")]
        GoogleAds,

        [EnumMember(Value = "GOOGLE_ANALYTICS")]
        GoogleAnalytics,

        [EnumMember(Value = "GOOGLE_ANALYTICS_4")]
        GoogleAnalytics4,

        [EnumMember(Value = "BIG_QUERY")]
        GoogleBigQuery,

        [EnumMember(Value = "GOOGLEDRIVEPROVIDER")]
        GoogleDrive,

        [EnumMember(Value = "GOOGLESHEETLOCALFILEPROVIDER")]
        GoogleSheets,

        [EnumMember(Value = "HUBSPOT")]
        HubSpot,

        [EnumMember(Value = "InMemory")]
        InMemory,

        [EnumMember(Value = "JSON")]
        JSON,

        [EnumMember(Value = "LOCALFILE")]
        LocalFile,

        [EnumMember(Value = "MONGODB")]
        MongoDB,

        [EnumMember(Value = "REST")]
        REST,

        [EnumMember(Value = "MARKETO")]
        Marketo,

        [EnumMember(Value = "ANALYSISSERVICES")]
        MicrosoftAnalysisServices,

        [EnumMember(Value = "AZURE_ANALYSIS_SERVICES")]
        MicrosoftAzureAnalysisServices,

        [EnumMember(Value = "AZURE_SQL")]
        MicrosoftAzureSqlServer,

        [EnumMember(Value = "AZURE_SYNAPSE")]
        MicrosoftAzureSynapseAnalytics,

        [EnumMember(Value = "DYNAMICS_CRM")]
        MicrosoftDynamics,

        [EnumMember(Value = "EXCELLOCALFILEPROVIDER")]
        MicrosoftExcel,

        [EnumMember(Value = "ONEDRIVEPROVIDER")]
        MicrosoftOneDrive,

        [EnumMember(Value = "SHAREPOINT")]
        MicrosoftSharePoint,

        [EnumMember(Value = "SQLSERVER")]
        MicrosoftSqlServer,

        [EnumMember(Value = "SSRS")]
        MicrosoftSqlServerReportingServices,

        [EnumMember(Value = "MYSQL")]
        MySQL,

        [EnumMember(Value = "ODATAPROVIDER")]
        OData,

        [EnumMember(Value = "ORACLE")]
        Oracle,

        [EnumMember(Value = "POSTGRES")]
        PostgreSQL,

        [EnumMember(Value = "QUICK_BOOKS")]
        QuickBooks,

        [EnumMember(Value = "QUICK_BOOKS_DESKTOP")]
        QuickBooksDesktop,

        [EnumMember(Value = "SALESFORCE")]
        Salesforce,

        [EnumMember(Value = "SNOWFLAKE")]
        Snowflake,

        [EnumMember(Value = "SYBASE")]
        Sybase,

        [EnumMember(Value = "WEBSERVICE")]
        WebService,
    }
}
