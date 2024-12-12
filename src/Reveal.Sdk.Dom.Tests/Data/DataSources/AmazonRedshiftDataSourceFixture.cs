using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSources
{
    public class AmazonRedshiftDataSourceFixture
    {
        [Fact]
        public void Constructor_SetsProviderToAmazonRedshift_WithoutParameters()
        {
            // Act
            var dataSource = new AmazonRedshiftDataSource();

            // Assert
            Assert.Equal(DataSourceProvider.AmazonRedshift, dataSource.Provider);
        }

        [Fact]
        public void GetSchema_ReturnSameValue_WithSetValue()
        {
            // Arrange
            var dataSource = new AmazonRedshiftDataSource();
            var expectedSchema = "TestSchema";

            // Act
            dataSource.Schema = expectedSchema;

            // Assert
            Assert.Equal(expectedSchema, dataSource.Schema);
            Assert.Equal(expectedSchema, dataSource.Properties.GetValue<string>("Schema"));
        }
    }
}