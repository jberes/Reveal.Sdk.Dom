using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data
{
    public interface IDataSourceBuilder
    {
        IDataSourceBuilder Id(string id);
        IDataSourceBuilder Fields(IEnumerable<IField> fields);
        IDataSourceBuilder Fields(params IField[] fields);
        IDataSourceBuilder Subtitle(string subtitle);
        IDataSourceBuilder ConfigureDataSource(Action<DataSource> configureDataSource);
        DataSourceItem Build();
    }
}
