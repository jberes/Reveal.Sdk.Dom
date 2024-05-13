using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data
{
    public interface IDataSourceItemBuilder
    {
        IDataSourceItemBuilder Id(string id);
        IDataSourceItemBuilder Fields(IEnumerable<IField> fields);
        IDataSourceItemBuilder Fields(params IField[] fields);
        IDataSourceItemBuilder Subtitle(string subtitle);
        IDataSourceItemBuilder ConfigureDataSource(Action<DataSource> configureDataSource);
        DataSourceItem Build();
    }
}
