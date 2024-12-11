using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Xunit;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Core.Serialization;

namespace Reveal.Sdk.Dom.Tests.Data.DataSourceItems
{
    public class WebServiceDataSourceItemFixture
    {
        [Fact]
        public void Constructor_SetsTitleAndDataSource_WhenConstructed()
        {
            // Arrange
            string title = "Test Item";
            var dataSource = new WebServiceDataSource();
            var item = new WebServiceDataSourceItem(title, dataSource);

            // Assert
            Assert.Equal(title, item.Title);
        }

        [Theory]
        [InlineData("https://example.com/api")]
        [InlineData(null)]
        public void Url_SetsAndGetsValue_WithDifferentInputs(string url)
        {
            // Arrange
            var item = new WebServiceDataSourceItem("Test Item", new WebServiceDataSource());

            // Act
            item.Url = url;

            // Assert
            Assert.Equal(url, item.Url);
            Assert.Equal(url, item.Properties.GetValue<string>("Url"));
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
            var webServiceDataSourceItem = document.Visualizations.FirstOrDefault().DataDefinition.DataSourceItem;

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
            var expectedJson =
                """
                {
                  "_type": "DataSourceItemType",
                  "Id": "webServiceItemId",
                  "Title": "Sales by Category",
                  "Subtitle": "Excel2Json",
                  "DataSourceId": "__JSON",
                  "HasTabularData": true,
                  "HasAsset": false,
                  "Properties": {
                    "Url": "https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9"
                  },
                  "Parameters": {
                    "config": {
                      "iterationDepth": 0,
                      "columnsConfig": [
                        {
                          "key": "CategoryID",
                          "type": 1
                        },
                        {
                          "key": "CategoryName",
                          "type": 0
                        },
                        {
                          "key": "ProductName",
                          "type": 0
                        },
                        {
                          "key": "ProductSales",
                          "type": 1
                        }
                      ]
                    }
                  },
                  "ResourceItem": {
                    "_type": "DataSourceItemType",
                    "Id": "webServiceItemId",
                    "Title": "DB Test",
                    "Subtitle": "Excel2Json",
                    "DataSourceId": "JSON",
                    "HasTabularData": true,
                    "HasAsset": false,
                    "Properties": {},
                    "Parameters": {}
                  }
                }
                """;

            var dataSource = new DataSource()
            {
                Id = "JSON",
                Title = "JSON Data Source",
                Subtitle = "JSON Data Source Subtitle",
            };

            var dataSourceItems = new WebServiceDataSourceItem("DB Test", dataSource)
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
            var actualJObject = jObject["Widgets"].FirstOrDefault()["DataSpec"]["DataSourceItem"];

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}