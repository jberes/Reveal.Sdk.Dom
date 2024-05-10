using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data
{
    public interface IDataSourceBuilder
    {
        IDataSourceBuilder SetId(string id);
        IDataSourceBuilder SetFields(IEnumerable<IField> fields);
        IDataSourceBuilder SetFields(params IField[] fields);
        IDataSourceBuilder ConfigureDataSource(Action<DataSource> configureDataSource);
        DataSourceItem Build();
    }
}
