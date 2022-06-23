using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Data
{
    public class ExcelDataSourceItem : DataSourceItem
    {
        [JsonIgnore]
        public string Sheet
        {
            get
            {
                if (Properties.TryGetValue("Sheet", out object value))
                    return (string)value;
                else
                    return null;
            }
            set
            {
                if (Properties.ContainsKey("Sheet"))
                    Properties["Sheet"] = value;
                else
                    Properties.Add("Sheet", value);
            }
        }

        public ExcelDataSourceItem(ExcelDataSource dataSource, List<Field> fields) : this(dataSource, string.Empty, fields) { }

        //todo: research why the title/subtitle isn't working
        public ExcelDataSourceItem(ExcelDataSource dataSource, string sheet, List<Field> fields)
        {
            Sheet = sheet;
            DataSource = dataSource;
            Fields = fields;

            ResourceItemDataSource = new WebResourceDataSource()
            {
                Title = dataSource.Title,
                Url = dataSource.Url,
                UseAnonymousAuthentication = dataSource.UseAnonymousAuthentication,
            };

            DataSourceId = dataSource.Id;
            Title = dataSource.Title;
            Subtitle = dataSource.Subtitle;
            HasTabularData = true;

            ResourceItem = new DataSourceItem()
            {
                DataSourceId = ResourceItemDataSource.Id,
                Title = Title,
                Subtitle = Subtitle,
            };
            ResourceItem.Properties.Add("Url", dataSource.Url);
        }
    }
}
