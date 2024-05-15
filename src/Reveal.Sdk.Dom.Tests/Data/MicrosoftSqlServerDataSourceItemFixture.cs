using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data
{
    public class MicrosoftSqlServerDataSourceItemFixture
    {
        [Fact]
        public void Database_GetSet_ShouldSetDatabaseProperty()
        {
            // Arrange
            var dataSourceItem = new MicrosoftSqlServerDataSourceItem("Test");

            // Act
            dataSourceItem.Database = "MyDatabase";

            // Assert
            Assert.Equal("MyDatabase", dataSourceItem.Database);
            Assert.Equal("MyDatabase", dataSourceItem.DataSource.Properties["Database"]);
        }

        [Fact]
        public void Host_GetSet_ShouldSetHostProperty()
        {
            // Arrange
            var dataSourceItem = new MicrosoftSqlServerDataSourceItem("Test");

            // Act
            dataSourceItem.Host = "localhost";

            // Assert
            Assert.Equal("localhost", dataSourceItem.Host);
        }

        [Fact]
        public void Schema_GetSet_ShouldSetSchemaProperty()
        {
            // Arrange
            var dataSourceItem = new MicrosoftSqlServerDataSourceItem("Test");

            // Act
            dataSourceItem.Schema = "master";

            // Assert
            Assert.Equal("master", dataSourceItem.Schema);
        }

        [Fact]
        public void Schema_Is_Dbo_By_Default()
        {
            // Arrange
            var dataSourceItem = new MicrosoftSqlServerDataSourceItem("Test");

            // Assert
            Assert.Equal("dbo", dataSourceItem.Schema);
        }

        [Fact]
        public void Table_GetSet_ShouldSetTableProperty()
        {
            // Arrange
            var dataSourceItem = new MicrosoftSqlServerDataSourceItem("Test");

            // Act
            dataSourceItem.Table = "MyTable";

            // Assert
            Assert.Equal("MyTable", dataSourceItem.Table);
        }

        [Fact]
        public void InitializeDataSource_Should_Set_Provider_Property()
        {
            // Arrange
            var restDataSourceItem = new MicrosoftSqlServerDataSourceItem("Test");

            // Assert
            Assert.Equal(DataSourceProvider.MicrosoftSqlServer, restDataSourceItem.DataSource.Provider);
        }

        [Fact]
        public void InitializeDataSource_Should_Set_ServerAggregationDefault_Property()
        {
            // Arrange
            var restDataSourceItem = new MicrosoftSqlServerDataSourceItem("Test");

            // Assert
            Assert.True(restDataSourceItem.DataSource.Properties.ContainsKey("ServerAggregationDefault"));
            Assert.True(restDataSourceItem.DataSource.Properties.GetValue<bool>("ServerAggregationDefault"));
        }

        [Fact]
        public void InitializeDataSource_Should_Set_ServerAggregationReadOnly_Property()
        {
            // Arrange
            var restDataSourceItem = new MicrosoftSqlServerDataSourceItem("Test");

            // Assert
            Assert.True(restDataSourceItem.DataSource.Properties.ContainsKey("ServerAggregationReadOnly"));
            Assert.False(restDataSourceItem.DataSource.Properties.GetValue<bool>("ServerAggregationReadOnly"));
        }

        [Fact]
        public void InitializeDataSourceItem_Should_Set_ServerAggregation_Property()
        {
            // Arrange
            var restDataSourceItem = new MicrosoftSqlServerDataSourceItem("Test");

            // Assert
            Assert.True(restDataSourceItem.Properties.ContainsKey("ServerAggregation"));
            Assert.True(restDataSourceItem.Properties.GetValue<bool>("ServerAggregation"));
        }
    }
}
