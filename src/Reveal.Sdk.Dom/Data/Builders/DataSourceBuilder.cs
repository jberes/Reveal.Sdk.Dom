using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data
{
    public class DataSourceBuilder : IDataSourceBuilder
    {
        protected DataSource DataSource { get; } = new DataSource();
        protected DataSourceItem DataSourceItem { get; } = new DataSourceItem();

        public DataSourceBuilder(DataSourceProvider provider, string title, string subtitle)
        {
            DataSource.Provider = provider;
            DataSourceItem.DataSource = DataSource;
            DataSourceItem.DataSourceId = DataSource.Id;
            SetTitle(title);
            SetSubtitle(subtitle);
        }

        public DataSourceItem Build()
        {
            if (DataSourceItem.Fields.Count == 0)
                throw new ArgumentException("You must provide the field definitions for the data source item. Call the SetFields method and provide the fields.");

            return DataSourceItem;
        }

        public IDataSourceBuilder SetId(string id)
        {
            DataSource.Id = id;
            DataSourceItem.DataSourceId = id;
            return this;
        }

        public virtual IDataSourceBuilder SetFields(IEnumerable<IField> fields)
        {
            DataSourceItem.Fields.Clear();
            DataSourceItem.Fields.AddRange(fields);
            return this;
        }

        public virtual IDataSourceBuilder SetFields(params IField[] fields)
        {
            return SetFields((IEnumerable<IField>)fields);
        }

        public IDataSourceBuilder SetSubtitle(string subtitle)
        {
            DataSourceItem.Subtitle = subtitle;
            return this;
        }

        public IDataSourceBuilder SetTitle(string title)
        {
            DataSourceItem.Title = title;
            return this;
        }
    }

}
