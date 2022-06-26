using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Reveal.Sdk.Dom.Core.Serialization
{
    internal static class RdashSerializer
    {
        const string _rdashJsonFileName = "Dashboard.json";

        internal static DashboardDocument Deserialize(string filePath)
        {
            DashboardDocument document = null;
            using (var stream = File.OpenRead(filePath))
            {
                document = Deserialize(stream);
            }
            return document;
        }

        static DashboardDocument Deserialize(Stream stream)
        {
            string json = DeserializeToJson(stream);
            return JsonConvert.DeserializeObject<DashboardDocument>(json);
        }

        static string DeserializeToJson(Stream stream)
        {
            string json = string.Empty;

            using (var zipArchive = new ZipArchive(stream, ZipArchiveMode.Read))
            {
                var jsonEntry = zipArchive.Entries.FirstOrDefault(e => e.Name == _rdashJsonFileName);
                if (jsonEntry != null)
                {
                    using (var jsonStream = jsonEntry.Open())
                    {
                        using (var reader = new StreamReader(jsonStream))
                        {
                            json = reader.ReadToEnd();
                        }
                    }
                }
            }

            return json;
        }

        internal static string Serialize(DashboardDocument document)
        {
            FixDocumentDataSources(document);
            return JsonConvert.SerializeObject(document, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }

        static void FixDocumentDataSources(DashboardDocument document)
        {
            Dictionary<string, DataSource> dataSources = new Dictionary<string, DataSource>();
            foreach(var viz in document.Visualizations)
            {
                var dsi = viz.DataSpec?.DataSourceItem;
                if (dsi != null)
                {
                    if (dsi.DataSource != null && !dataSources.ContainsKey(dsi.DataSource.Id))
                        dataSources.Add(dsi.DataSource.Id, dsi.DataSource);

                    if (dsi.ResourceItemDataSource != null && !dataSources.ContainsKey(dsi.ResourceItemDataSource.Id))
                        dataSources.Add(dsi.ResourceItemDataSource.Id, dsi.ResourceItemDataSource);
                }
            }

            var allDataSources = document.DataSources?.Union(dataSources.Values.ToArray());
            document.DataSources = allDataSources?.ToList();
        }

        internal static void Save(DashboardDocument dashboard, string filePath)
        {
            dashboard.SavedWith = "Reveal.Sdk.DOM";

            using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create))
                {
                    var dashboardEntry = zipArchive.CreateEntry(_rdashJsonFileName);
                    using (var streamWriter = new StreamWriter(dashboardEntry.Open()))
                    {
                        var json = dashboard.ToJsonString();
                        streamWriter.Write(json);
                    }
                }
            }
        }
    }
}
