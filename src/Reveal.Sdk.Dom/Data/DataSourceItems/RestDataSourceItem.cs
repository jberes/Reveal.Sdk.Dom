using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Data
{
    public class RestDataSourceItem : WebServiceDataSourceItem
    {
        DataSource _dataSource;

        public RestDataSourceItem(string title) :
            this(title, new DataSource())
        { }

        public RestDataSourceItem(string title, string uri) :
            this(title, uri, new DataSource())
        { }

        public RestDataSourceItem(string title, string uri, DataSource dataSource) :
            this(title, dataSource)
        {
            Uri = uri;
        }

        public RestDataSourceItem(string title, DataSource dataSource) :
            base(title, new JsonDataSource())
        {
            _dataSource = dataSource ?? new DataSource();
            InitializeResourceItem(title);
            UpdateResourceItemDataSource(_dataSource);
        }

        protected void InitializeResourceItem(string title)
        {
            ResourceItemDataSource = new DataSource { Provider = DataSourceProvider.REST };
            ResourceItem = new DataSourceItem
            {
                DataSource = ResourceItemDataSource,
                DataSourceId = ResourceItemDataSource.Id,
                Title = title
            };

            ResourceItemDataSource = ResourceItemDataSource;
            ResourceItem = ResourceItem;
        }
    }
}