using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Core.Utilities;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Reveal.Sdk.Dom.Core.Serialization
{
    internal static class RdashSerializer
    {
        const string _rdashJsonFileName = "Dashboard.json";

        internal static RdashDocument Load(string filePath)
        {
            RdashDocument document = null;
            using (var stream = File.OpenRead(filePath))
            {
                document = Deserialize(stream);
            }
            return document;
        }

        static RdashDocument Deserialize(Stream stream)
        {
            string json = DeserializeToJson(stream);
            return JsonConvert.DeserializeObject<RdashDocument>(json);
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
                            var memoryStream = new MemoryStream();
                            jsonStream.CopyTo(memoryStream);
                            json = Encoding.UTF8.GetString(memoryStream.ToArray());
                        }
                    }
                }
            }

            return json;
        }

        internal static string Serialize(RdashDocument document)
        {
            RdashDocumentValidator.FixDocument(document);
            return JsonConvert.SerializeObject(document, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }

        internal static void Save(RdashDocument dashboard, string filePath)
        {
            dashboard.SavedWith = GlobalConstants.RdashDocument.SavedWith;

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
