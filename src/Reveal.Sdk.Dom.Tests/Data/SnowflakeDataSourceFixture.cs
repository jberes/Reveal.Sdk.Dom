using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data
{
    public class SnowflakeDataSourceFixture
    {
        [Fact]
        public void SnowflakeDataSource_ShouldSetProviderToSnowflake()
        {
            // Arrange
            var dataSource = new SnowflakeDataSource();

            // Act

            // Assert
            Assert.Equal(DataSourceProvider.Snowflake, dataSource.Provider);
        }

        [Fact]
        public void SnowflakeDataSource_ShouldSetAccount()
        {
            // Arrange
            var dataSource = new SnowflakeDataSource();
            var account = "testAccount";

            // Act
            dataSource.Account = account;

            // Assert
            Assert.Equal(account, dataSource.Account);
        }

        [Fact]
        public void SnowflakeDataSource_ShouldSetRole()
        {
            // Arrange
            var dataSource = new SnowflakeDataSource();
            var role = "testRole";

            // Act
            dataSource.Role = role;

            // Assert
            Assert.Equal(role, dataSource.Role);
        }

        [Fact]
        public void SnowflakeDataSource_ShouldSetWarehouse()
        {
            // Arrange
            var dataSource = new SnowflakeDataSource();
            var warehouse = "testWarehouse";

            // Act
            dataSource.Warehouse = warehouse;

            // Assert
            Assert.Equal(warehouse, dataSource.Warehouse);
        }
    }
}
