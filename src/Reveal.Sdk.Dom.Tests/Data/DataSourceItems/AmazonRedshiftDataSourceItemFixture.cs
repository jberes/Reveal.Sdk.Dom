using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSourceItems
{
    public class AmazonRedshiftDataSourceItemFixture
    {
        [Fact]
        public void Constructor_CreateRedshiftDSItem_WithTitle()
        {
            // Arrange
            var expectedTitle = "DS Item Title";

            // Act
            var dataSourceItem = new AmazonRedshiftDataSourceItem(expectedTitle);

            // Assert
            Assert.Equal(SchemaTypeNames.DataSourceItemType, dataSourceItem.SchemaTypeName);
            Assert.Equal(expectedTitle, dataSourceItem.Title);
            Assert.Equal(expectedTitle, dataSourceItem.DataSource.Title);
            Assert.NotNull(dataSourceItem.DataSource);
            Assert.IsType<AmazonAthenaDataSource>(dataSourceItem.DataSource);
        }

        [Theory]
        [InlineData("DS Title", "DS Title", "DS Item Title", "DS Item Title")]
        [InlineData(null, "DS Item Title", "DS Item Title", "DS Item Title")]
        public void Constructor_CreateRedshiftDSItem_WithTitleAndDataSource(string dsTitle, string expectedDSTitle, string dsItemTitle, string expectedDSItemTitle)
        {
            // Arrange
            var dataSource = new DataSource() { Title = dsTitle };

            // Act
            var dataSourceItem = new AmazonRedshiftDataSourceItem(dsItemTitle, dataSource);

            // Assert
            Assert.Equal(SchemaTypeNames.DataSourceItemType, dataSourceItem.SchemaTypeName);
            Assert.Equal(expectedDSTitle, dataSourceItem.DataSource.Title);
            Assert.Equal(expectedDSItemTitle, dataSourceItem.Title);
            Assert.Equal(dataSource.Id, dataSourceItem.DataSource.Id);
            Assert.Equal(dataSource.Id, dataSourceItem.DataSourceId);
            Assert.NotSame(dataSource, dataSourceItem.DataSource);
            Assert.IsType<AmazonAthenaDataSource>(dataSourceItem.DataSource);
        }

        [Theory]
        [InlineData("DS Title", "DS Title", "DS Item Title", "DS Item Title")]
        [InlineData(null, "DS Item Title", "DS Item Title", "DS Item Title")]
        public void Constructor_CreateRedshiftDSItem_WithTitleAndRedshiftDataSource(string dsTitle, string expectedDSTitle, string dsItemTitle, string expectedDSItemTitle)
        {
            // Arrange
            var dataSource = new AmazonRedshiftDataSource() { Title = dsTitle };

            // Act
            var dataSourceItem = new AmazonRedshiftDataSourceItem(dsItemTitle, dataSource);

            // Assert
            Assert.Equal(SchemaTypeNames.DataSourceItemType, dataSourceItem.SchemaTypeName);
            Assert.Equal(expectedDSTitle, dataSourceItem.DataSource.Title);
            Assert.Equal(expectedDSItemTitle, dataSourceItem.Title);
            Assert.Equal(dataSource.Id, dataSourceItem.DataSource.Id);
            Assert.Equal(dataSource.Id, dataSourceItem.DataSourceId);
            Assert.Same(dataSource, dataSourceItem.DataSource);
        }
    }
}