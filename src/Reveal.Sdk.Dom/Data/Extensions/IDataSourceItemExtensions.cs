using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data
{
    public static class IDataSourceItemExtensions
    {
        public static T As<T>(this DataSourceItem dsi) where T : DataSourceItem
        {
            return dsi as T;
        }

        public static T SetId<T>(this T dsi, string id) where T : DataSourceItem
        {
            dsi.Id = id;
            return dsi;
        }

        public static T SetFields<T>(this T dsi, IEnumerable<IField> fields) where T : DataSourceItem
        {
            dsi.Fields.Clear();
            dsi.Fields.AddRange(fields);
            return dsi;
        }

        public static T SetFields<T>(this T dsi, params IField[] fields) where T : DataSourceItem
        {
            return SetFields(dsi, (IEnumerable<IField>)fields);
        }

        public static T SetTitle<T>(this T dsi, string title) where T : DataSourceItem
        {
            dsi.Title = title;
            return dsi;
        }

        public static T SetSubtitle<T>(this T dsi, string subtitle) where T : DataSourceItem
        {
            dsi.Subtitle = subtitle;
            return dsi;
        }
    }
}
