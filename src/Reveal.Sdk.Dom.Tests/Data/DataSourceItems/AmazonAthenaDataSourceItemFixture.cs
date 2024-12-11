using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSourceItems
{
    public class AmazonAthenaDataSourceItemFixture
    {
        [Theory]
        [InlineData("DS Title", "DS Title", "DS Item Title", "DS Item Title")]
        [InlineData(null, "DS Item Title", "DS Item Title", "DS Item Title")]
        public void Constructor_CreateAthenaDSItem_WithTitleAndDataSource(string dsTitle, string expectedDSTitle, string dsItemTitle, string expectedDSItemTitle)
        {
            // Arrange
            var dataSource = new AmazonAthenaDataSource() { Title = dsTitle };

            // Act
            var item = new AmazonAthenaDataSourceItem(dsItemTitle, dataSource);

            // Assert
            Assert.Equal(expectedDSTitle, item.DataSource.Title);
            Assert.Equal(expectedDSItemTitle, item.Title);
            Assert.Equal(dataSource.Id, item.DataSource.Id);
            Assert.Equal(dataSource.Id, item.DataSourceId);
            Assert.Same(dataSource, item.DataSource);
        }

        [Theory]
        [InlineData("DS Title", "DS Title", "DS Item Title", "DS Item Title")]
        [InlineData(null, "DS Item Title", "DS Item Title", "DS Item Title")]
        public void Constructor_CreateAthenaDSItem_WithTitleAndAthenaDataSource(string dsTitle, string expectedDSTitle, string dsItemTitle, string expectedDSItemTitle)
        {
            // Arrange
            var dataSource = new DataSource() { Title = dsTitle };

            // Act
            var item = new AmazonAthenaDataSourceItem(dsItemTitle, dataSource);

            // Assert
            Assert.Equal(expectedDSTitle, item.DataSource.Title);
            Assert.Equal(expectedDSItemTitle, item.Title);
            Assert.Equal(dataSource.Id, item.DataSource.Id);
            Assert.Equal(dataSource.Id, item.DataSourceId);
            Assert.NotSame(dataSource, item.DataSource);
            Assert.IsType<AmazonAthenaDataSource>(item.DataSource);
        }

        [Fact]
        public void ToJsonString_HaveSameObject_WithRevealJson()
        {
            // Arrange
            var expectedJson = """
                        {
                          "_type": "DataSourceItemType",
                          "Id": "athenaDSItemId",
                          "Title": "Athena DSItem",
                          "Subtitle": "Athena DSItem Subtitle",
                          "DataSourceId": "athenaDSId",
                          "HasTabularData": true,
                          "HasAsset": false,
                          "Properties": {
                            "Table": "northwindinvoicesparquet"
                          },
                          "Parameters": {}
                        }
                """;
            var dataSource = new AmazonAthenaDataSource()
            {
                Id = "athenaDSId"
            };
            var dataSourceItem = new AmazonAthenaDataSourceItem("Athena DSItem", dataSource)
            {
                Subtitle = "Athena DSItem Subtitle",
                HasAsset = false,
                HasTabularData = true,
                Table = "northwindinvoicesparquet"
            };

            // Act
            var json = dataSourceItem.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(json);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}