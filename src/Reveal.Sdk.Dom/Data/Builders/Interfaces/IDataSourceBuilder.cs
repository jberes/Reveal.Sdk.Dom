using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data
{
    public interface IDataSourceBuilder
    {
        IDataSourceBuilder SetFields(IEnumerable<IField> fields);
        IDataSourceBuilder SetFields(params IField[] fields);
        IDataSourceBuilder SetTitle(string title);
        IDataSourceBuilder SetSubtitle(string subtitle);
        DataSourceItem Build();
    }

}
