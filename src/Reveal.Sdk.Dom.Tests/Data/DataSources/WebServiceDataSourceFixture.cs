using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Core.Serialization;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSources
{
    public class WebServiceDataSourceFixture
    {
        [Fact]
        public void Constructor_SetsProviderToWebService_WhenConstructed()
        {
            // Act
            var dataSource = new WebServiceDataSource();

            // Assert
            Assert.Equal(DataSourceProvider.WebService, dataSource.Provider);
        }

        [Theory]
        [InlineData("https://example.com/api")]
        [InlineData(null)]
        public void Url_SetsAndGetsValue_WithDifferentInputs(string url)
        {
            // Arrange
            var dataSource = new WebServiceDataSource();

            // Act
            dataSource.Url = url;

            // Assert
            Assert.Equal(url, dataSource.Url);
            Assert.Equal(url, dataSource.Properties.GetValue<string>("URL"));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void UseAnonymousAuthentication_SetsAndGetsValue_WithDifferentInputs(bool value)
        {
            // Arrange
            var dataSource = new WebServiceDataSource();

            // Act
            dataSource.UseAnonymousAuthentication = value;

            // Assert
            Assert.Equal(value, dataSource.UseAnonymousAuthentication);
            Assert.Equal(value, dataSource.Properties.GetValue<bool>("UseAnonymousAuthentication"));
        }

        [Fact]
        public void RDashDocument_HasCorrectDataSource_WhenLoadFromFile()
        {
            // Arrange
            var filePath = Path.Combine(Environment.CurrentDirectory, "Dashboards", "TestWebResource.rdash");

            // Act
            var document = RdashDocument.Load(filePath);
            var jsonDataSource = document.DataSources.FirstOrDefault();
            var webServiceDataSource = document.DataSources.LastOrDefault();

            // Assert
            Assert.Equal(DataSourceProvider.JSON, jsonDataSource.Provider);
            Assert.Equal(DataSourceProvider.WebService, webServiceDataSource.Provider);
            Assert.NotNull(webServiceDataSource.Properties.GetValue<string>("Url"));
            Assert.NotNull(webServiceDataSource.Properties.GetValue<string>("_rpUseAnonymousAuthentication"));
        }

        [Fact]
        public void ToJsonString_CreatesFormattedJson_ForWebServiceDataSource()
        {
            // Arrange
            var expectedJson = @"
            {
              ""_type"": ""DataSourceType"",
              ""Id"": ""1821521e-0225-4768-80c2-28c89f55b256"",
              ""Provider"": ""WEBSERVICE"",
              ""Description"": ""JSON DS"",
              ""Subtitle"": ""JSON DS Subtitle"",
              ""Properties"": {}
            }";

            var dataSourceItems = new WebServiceDataSourceItem("DB Test", new DataSource { Title = "JSON DS", Subtitle = "JSON DS Subtitle" })
            {
                Id = "webServiceItemId",
                Title = "Sales by Category",
                Subtitle = "Excel2Json",
                Url = "https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9",
                Fields = new List<IField>
                {
                    new NumberField("CategoryID"),
                    new TextField("CategoryName"),
                    new TextField("ProductName"),
                    new NumberField("ProductSales"),
                }
            };

            var document = new RdashDocument("My Dashboard");
            document.Visualizations.Add(
                new ColumnChartVisualization("Test List", dataSourceItems)
                    .SetLabel("CategoryName")
                    .SetValue("ProductName")
                    );

            var expectedJObject = JObject.Parse(expectedJson);

            // Act
            RdashSerializer.SerializeObject(document);
            var json = document.ToJsonString();
            var jObject = JObject.Parse(json);
            var actualJObject = jObject["DataSources"].LastOrDefault();

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }

        [Fact]
        public void ToJsonString_CreatesFormattedJsonUseCsv_ForWebServiceDataSource()
        {
            // Arrange
            var expectedJson = @"
            {
              ""_type"": ""DataSourceType"",
              ""Id"": ""a30dc863-47a4-4ea4-b9fb-9e8006281ce4"",
              ""Provider"": ""WEBSERVICE"",
              ""Description"": ""JSON DS"",
              ""Subtitle"": ""JSON DS Subtitle"",
              ""Properties"": {
                ""Result-Type"": "".csv""
              }
            }";

            var dataSourceItems = new WebServiceDataSourceItem("DB Test", new DataSource { Title = "JSON DS", Subtitle = "JSON DS Subtitle" })
            {
                Id = "webServiceItemId",
                Title = "Sales by Category",
                Subtitle = "Excel2Json",
                Url = "https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9",
                Fields = new List<IField>
                {
                    new NumberField("CategoryID"),
                    new TextField("CategoryName"),
                    new TextField("ProductName"),
                    new NumberField("ProductSales"),
                }
            };

            dataSourceItems.UseCsv();

            var document = new RdashDocument("My Dashboard");
            document.Visualizations.Add(
                new ColumnChartVisualization("Test List", dataSourceItems)
                    .SetLabel("CategoryName")
                    .SetValue("ProductName")
                    );

            var expectedJObject = JObject.Parse(expectedJson);

            // Act
            RdashSerializer.SerializeObject(document);
            var json = document.ToJsonString();
            var jObject = JObject.Parse(json);
            var actualJObject = jObject["DataSources"].LastOrDefault();

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }

        [Fact]
        public void ToJsonString_CreatesFormattedJsonUseExcel_ForWebServiceDataSource()
        {
            // Arrange
            var expectedJson = @"
            {
              ""_type"": ""DataSourceType"",
              ""Id"": ""97018983-2f13-415b-a38c-e6ff4fa3f123"",
              ""Provider"": ""WEBSERVICE"",
              ""Description"": ""JSON DS"",
              ""Subtitle"": ""JSON DS Subtitle"",
              ""Properties"": {
                ""Result-Type"": "".xlsx""
              }
            }";

            var dataSourceItems = new WebServiceDataSourceItem("DB Test", new DataSource { Title = "JSON DS", Subtitle = "JSON DS Subtitle" })
            {
                Id = "webServiceItemId",
                Title = "Sales by Category",
                Subtitle = "Excel2Json",
                Url = "https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9",
                Fields = new List<IField>
                {
                    new NumberField("CategoryID"),
                    new TextField("CategoryName"),
                    new TextField("ProductName"),
                    new NumberField("ProductSales"),
                }
            };

            dataSourceItems.UseExcel();

            var document = new RdashDocument("My Dashboard");
            document.Visualizations.Add(
                new ColumnChartVisualization("Test List", dataSourceItems)
                    .SetLabel("CategoryName")
                    .SetValue("ProductName")
                    );

            var expectedJObject = JObject.Parse(expectedJson);

            // Act
            RdashSerializer.SerializeObject(document);
            var json = document.ToJsonString();
            var jObject = JObject.Parse(json);
            var actualJObject = jObject["DataSources"].LastOrDefault();

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}