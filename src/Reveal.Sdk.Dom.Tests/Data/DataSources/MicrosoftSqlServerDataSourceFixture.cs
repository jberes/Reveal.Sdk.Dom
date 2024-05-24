using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSources
{
    public class MicrosoftSqlServerDataSourceFixture
    {
        [Fact]
        public void Constructor_Should_SetProviderToMicrosoftSqlServer()
        {
            // Arrange
            var dataSource = new MicrosoftSqlServerDataSource();

            // Act
            var provider = dataSource.Provider;

            // Assert
            Assert.Equal(DataSourceProvider.MicrosoftSqlServer, provider);
        }

        [Fact]
        public void Constructor_Should_SetServerAggregationDefaultToTrue()
        {
            // Arrange
            var dataSource = new MicrosoftSqlServerDataSource();

            // Act
            var serverAggregationDefault = dataSource.Properties.GetValue<bool>("ServerAggregationDefault");

            // Assert
            Assert.True(serverAggregationDefault);
        }

        [Fact]
        public void Constructor_Should_SetServerAggregationReadOnlyToFalse()
        {
            // Arrange
            var dataSource = new MicrosoftSqlServerDataSource();

            // Act
            var serverAggregationReadOnly = dataSource.Properties.GetValue<bool>("ServerAggregationReadOnly");

            // Assert
            Assert.False(serverAggregationReadOnly);
        }

        [Fact]
        public void Database_Should_GetAndSetDatabaseProperty()
        {
            // Arrange
            var dataSource = new MicrosoftSqlServerDataSource();
            var database = "TestDatabase";

            // Act
            dataSource.Database = database;
            var result = dataSource.Database;

            // Assert
            Assert.Equal(database, result);
        }

        [Fact]
        public void Host_Should_GetAndSetHostProperty()
        {
            // Arrange
            var dataSource = new MicrosoftSqlServerDataSource();
            var host = "TestHost";

            // Act
            dataSource.Host = host;
            var result = dataSource.Host;

            // Assert
            Assert.Equal(host, result);
        }

        [Fact]
        public void Port_Should_GetAndSetPortProperty()
        {
            // Arrange
            var dataSource = new MicrosoftSqlServerDataSource();
            var port = "1234";

            // Act
            dataSource.Port = port;
            var result = dataSource.Port;

            // Assert
            Assert.Equal(port, result);
        }

        [Fact]
        public void Schema_Should_GetAndSetSchemaProperty()
        {
            // Arrange
            var dataSource = new MicrosoftSqlServerDataSource();
            var schema = "TestSchema";

            // Act
            dataSource.Schema = schema;
            var result = dataSource.Schema;

            // Assert
            Assert.Equal(schema, result);
        }

        [Fact]
        public void Constructor_Should_Set_ServerAggregationDefault_Property()
        {
            // Arrange
            var dataSource = new MicrosoftSqlServerDataSource();

            // Assert
            Assert.True(dataSource.Properties.ContainsKey("ServerAggregationDefault"));
            Assert.True(dataSource.Properties.GetValue<bool>("ServerAggregationDefault"));
        }

        [Fact]
        public void Constructor_Should_Set_ServerAggregationReadOnly_Property()
        {
            // Arrange
            var dataSource = new MicrosoftSqlServerDataSource();

            // Assert
            Assert.True(dataSource.Properties.ContainsKey("ServerAggregationReadOnly"));
            Assert.False(dataSource.Properties.GetValue<bool>("ServerAggregationReadOnly"));
        }
    }
}
