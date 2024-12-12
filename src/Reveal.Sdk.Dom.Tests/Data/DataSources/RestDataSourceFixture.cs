using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Core.Serialization;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSources
{
    public class RestDataSourceFixture
    {
        public static IEnumerable<object[]> HeadersTestData =>
            new List<object[]>
            {
                new object[] { new List<string> { "Authorization: Bearer token", "Content-Type: application/json" } },
                new object[] { null }
            };

        [Fact]
        public void Constructor_SetsProviderToREST_WhenConstructed()
        {
            // Arrange & Act
            var dataSource = new RestDataSource();

            // Assert
            Assert.Equal(DataSourceProvider.REST, dataSource.Provider);
        }

        [Theory]
        [InlineData("https://example.com/api/data")]
        [InlineData(null)]
        public void Url_SetsAndGetsValue_WithDifferentInputs(string url)
        {
            // Arrange
            var dataSource = new RestDataSource();

            // Act
            dataSource.Url = url;

            // Assert
            Assert.Equal(url, dataSource.Url);
            Assert.Equal(url, dataSource.Properties.GetValue<string>("URL"));
        }

        [Theory]
        [InlineData("application/json")]
        [InlineData(null)]
        public void ContentType_SetsAndGetsValue_WithDifferentInputs(string contentType)
        {
            // Arrange
            var dataSource = new RestDataSource();

            // Act
            dataSource.ContentType = contentType;

            // Assert
            Assert.Equal(contentType, dataSource.ContentType);
            Assert.Equal(contentType, dataSource.Properties.GetValue<string>("ContentType"));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void UseAnonymousAuthentication_SetsAndGetsValue_WithDifferentInputs(bool value)
        {
            // Arrange
            var dataSource = new RestDataSource();

            // Act
            dataSource.UseAnonymousAuthentication = value;

            // Assert
            Assert.Equal(value, dataSource.UseAnonymousAuthentication);
            Assert.Equal(value, dataSource.Properties.GetValue<bool>("UseAnonymousAuthentication"));
        }

        [Theory]
        [MemberData(nameof(HeadersTestData))]
        public void Headers_SetsAndGetsValue_WithDifferentInputs(string[] headers)
        {
            // Arrange
            var dataSource = new RestDataSource();
            var expectedHeaders = headers?.ToList();

            // Act
            dataSource.Headers = expectedHeaders;

            // Assert
            Assert.Equal(expectedHeaders, dataSource.Headers);
            Assert.Equal(expectedHeaders, dataSource.Properties.GetValue<List<string>>("Headers"));
        }

        [Theory]
        [InlineData("GET")]
        [InlineData(null)]
        public void Method_SetsAndGetsValue_WithDifferentInputs(string method)
        {
            // Arrange
            var dataSource = new RestDataSource();

            // Act
            dataSource.Method = method;

            // Assert
            Assert.Equal(method, dataSource.Method);
            Assert.Equal(method, dataSource.Properties.GetValue<string>("Method"));
        }

        [Fact]
        public void RDashDocument_HasCorrectDataSource_WhenLoadFromFile()
        {
            // Arrange
            var filePath = Path.Combine(Environment.CurrentDirectory, "Dashboards", "TestRest.rdash");

            // Act
            var document = RdashDocument.Load(filePath);
            var dataSource = document.DataSources.LastOrDefault();

            // Assert
            Assert.Equal(DataSourceProvider.REST, dataSource.Provider);
            Assert.NotNull(dataSource.Properties.GetValue<string>("Url"));
            Assert.NotNull(dataSource.Properties.GetValue<string>("_rpUseAnonymousAuthentication"));
            Assert.NotNull(dataSource.Properties.GetValue<string>("_rpUsePreemptiveAuthentication"));
        }

        [Fact]
        public void ToJsonString_CreatesFormattedJson_ForRestDataSource()
        {
            // Arrange
            var expectedJson =
                """
                [
                  {
                    "_type": "DataSourceType",
                    "Id": "__JSON",
                    "Provider": "JSON",
                    "Description": "DB Test",
                    "Properties": {},
                    "Settings": {}
                  },
                  {
                    "_type": "DataSourceType",
                    "Id": "400f6d1c-ba02-4b27-9d5b-4658e2baf859",
                    "Provider": "REST",
                    "Description": "JSON DS",
                    "Subtitle": "JSON DS Subtitle",
                    "Properties": {},
                    "Settings": {}
                  }
                ]
                """;

            var dataSourceItems = new RestDataSourceItem("DB Test", new DataSource { Title = "JSON DS", Subtitle = "JSON DS Subtitle" })
            {
                Id = "RestItem",
                Title = "Rest DS Item",
                Fields = new List<IField>
                {
                    new TextField("_id"),
                    new TextField("name"),
                }
            };

            var document = new RdashDocument("My Dashboard");
            document.Visualizations.Add(new GridVisualization("Test List", dataSourceItems).SetColumns("name"));

            var expectedJArray = JArray.Parse(expectedJson);

            // Act
            var json = document.ToJsonString();
            var jObject = JObject.Parse(json);
            var actualJArray = (JArray)jObject["DataSources"];

            // Assert
            Assert.Equal(expectedJArray.Count, actualJArray.Count);

            for (int i = 0; i < expectedJArray.Count; i++)
            {
                Assert.Equal(expectedJArray[i], actualJArray[i]);
            }
        }

        [Fact]
        public void ToJsonString_CreatesFormattedUseCsv_ForAllRestDataSources()
        {
            // Arrange
            var expectedJson =
                """
                [
                  {
                    "_type": "DataSourceType",
                    "Id": "__CSV",
                    "Provider": "CSVLOCALFILEPROVIDER",
                    "Properties": {},
                    "Settings": {}
                  },
                  {
                    "_type": "DataSourceType",
                    "Id": "4885e4c2-4fc6-4c12-a42d-765f2ee7beb8",
                    "Provider": "REST",
                    "Description": "JSON DS",
                    "Subtitle": "JSON DS Subtitle",
                    "Properties": {
                      "Result-Type": ".csv"
                    },
                    "Settings": {}
                  }
                ]
                """;

            var dataSourceItems = new RestDataSourceItem("DB Test", new DataSource { Title = "JSON DS", Subtitle = "JSON DS Subtitle" })
            {
                Id = "RestItem",
                Title = "Rest DS Item",
                Fields = new List<IField>
                {
                    new TextField("_id"),
                    new TextField("name"),
                }
            };

            dataSourceItems.UseCsv();

            var document = new RdashDocument("My Dashboard");
            document.Visualizations.Add(new GridVisualization("Test List", dataSourceItems).SetColumns("name"));

            var expectedJArray = JArray.Parse(expectedJson);

            // Act
            var json = document.ToJsonString();
            var jObject = JObject.Parse(json);
            var actualJArray = (JArray)jObject["DataSources"];

            // Assert
            Assert.Equal(expectedJArray.Count, actualJArray.Count);

            for (int i = 0; i < expectedJArray.Count; i++)
            {
                Assert.Equal(expectedJArray[i], actualJArray[i]);
            }
        }

        [Fact]
        public void ToJsonString_CreatesFormattedUseExcel_ForRestDataSource()
        {
            // Arrange
            var expectedJson =
                """
                [
                  {
                    "_type": "DataSourceType",
                    "Id": "__EXCEL",
                    "Provider": "EXCELLOCALFILEPROVIDER",
                    "Properties": {},
                    "Settings": {}
                  },
                  {
                    "_type": "DataSourceType",
                    "Id": "865b8a61-757c-4596-8995-560abde4f266",
                    "Provider": "REST",
                    "Description": "JSON DS",
                    "Subtitle": "JSON DS Subtitle",
                    "Properties": {
                      "Result-Type": ".xlsx"
                    },
                    "Settings": {}
                  }
                ]
                """;

            var dataSourceItems = new RestDataSourceItem("DB Test", new DataSource { Title = "JSON DS", Subtitle = "JSON DS Subtitle" })
            {
                Id = "RestItem",
                Title = "Rest DS Item",
                Fields = new List<IField>
                {
                    new TextField("_id"),
                    new TextField("name"),
                }
            };

            dataSourceItems.UseExcel();

            var document = new RdashDocument("My Dashboard");
            document.Visualizations.Add(new GridVisualization("Test List", dataSourceItems).SetColumns("name"));

            var expectedJArray = JArray.Parse(expectedJson);

            // Act
            var json = document.ToJsonString();
            var jObject = JObject.Parse(json);
            var actualJArray = (JArray)jObject["DataSources"];

            // Assert
            Assert.Equal(expectedJArray.Count, actualJArray.Count);

            for (int i = 0; i < expectedJArray.Count; i++)
            {
                Assert.Equal(expectedJArray[i], actualJArray[i]);
            }
        }
    }
}