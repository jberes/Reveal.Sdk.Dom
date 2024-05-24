using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSourceItems
{
    public class SnowflakeDataSourceItemFixture
    {
        [Fact]
        public void ProcessDataOnServer_Should_GetAndSetProperties()
        {
            // Arrange
            var dataSource = new SnowflakeDataSource();
            var dataSourceItem = new SnowflakeDataSourceItem("Test", dataSource);

            // Act
            dataSourceItem.ProcessDataOnServer = true;
            var processDataOnServer = dataSourceItem.ProcessDataOnServer;

            // Assert
            Assert.True(processDataOnServer);
        }

        [Fact]
        public void CreateDataSourceInstance_Should_ReturnSnowflakeDataSourceInstance()
        {
            // Arrange
            var dataSource = new DataSource();
            var dataSourceItem = new SnowflakeDataSourceItem("Test", dataSource);


            // Assert
            Assert.IsType<SnowflakeDataSource>(dataSourceItem.DataSource);
        }
    }
}
