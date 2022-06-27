using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Reveal.Sdk.Dom.Core.Constants;
using System;
using System.IO;
using Xunit;

namespace Reveal.Sdk.Dom.Tests
{
    public class DashboardDocumentFixture
    {
        [Fact]
        public void NewDashboard_SetsTitle()
        {
            var dashboard = new DashboardDocument("Custom Dashboard");

            Assert.Equal("Custom Dashboard", dashboard.Title);
        }

        [Fact]
        public void NewDashboard_SetsDefaultValues()
        {
            var dashboard = new DashboardDocument();

            Assert.Equal("New Dashboard", dashboard.Title);
            Assert.Equal(GlobalConstants.DashboardDocument.CreatedWith, dashboard.CreatedWith);
            Assert.Equal(string.Empty, dashboard.SavedWith);
            Assert.Null(dashboard.Theme);
            Assert.Null(dashboard.Tags);
            Assert.Equal(0, dashboard.FormatVersion);
            Assert.True(dashboard.UseAutoLayout);

            Assert.NotNull(dashboard.DataSources);
            Assert.Empty(dashboard.DataSources);

            Assert.NotNull(dashboard.Filters);
            Assert.Empty(dashboard.Filters);

            Assert.NotNull(dashboard.Visualizations);
            Assert.Empty(dashboard.Visualizations);
        }

        [Fact]
        public void Load_SetsProperties()
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "Dashboards", "Sales.rdash");
            var document = DashboardDocument.Load(filePath);

            Assert.NotNull(document);

            Assert.NotNull(document.Title);
            Assert.NotEqual(GlobalConstants.DashboardDocument.CreatedWith, document.CreatedWith);
            Assert.NotEqual(string.Empty, document.SavedWith);
            Assert.NotNull(document.Theme);
            Assert.NotNull(document.Tags);
            Assert.NotEqual(0, document.FormatVersion);
            Assert.False(document.UseAutoLayout);
            Assert.NotEmpty(document.DataSources);
            Assert.NotEmpty(document.Filters);
            Assert.NotEmpty(document.Visualizations);
        }

        [Fact]
        public void ToJsonString_IsValidSchema()
        {
            var schemaJson = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Schemas", "DashboardDocument.json"));
            var schema = JSchema.Parse(schemaJson);

            var dashboard = new DashboardDocument()
            {
                Title = "New Dashboard",
                Description = "This is a test dashboard",
                Theme = ThemeNames.RockyMountain,
                AutoRefreshInterval = 0,
                PasswordHash = "SomeSecretValue",
                Tags = "tag1,tag2,tag3"
            };
            var json = dashboard.ToJsonString();

            var jsonDocument = JObject.Parse(json);

            bool isValid = jsonDocument.IsValid(schema);

            Assert.True(isValid);
        }

        [Fact]
        public void Save_SavesFile()
        {
            var filePath = Path.Combine(Path.GetTempPath(), $"{Path.GetTempFileName()}.rdash");

            try
            {
                var dashboard = new DashboardDocument();

                if (File.Exists(filePath))
                    File.Delete(filePath);

                dashboard.Save(filePath);

                Assert.Equal("Reveal.Sdk.Dom", dashboard.SavedWith);
                Assert.True(File.Exists(filePath));
            }
            catch
            {
                throw;
            }
            finally
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
        }
    }
}
