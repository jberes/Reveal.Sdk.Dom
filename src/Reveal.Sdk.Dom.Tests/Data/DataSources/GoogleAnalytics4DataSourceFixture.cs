using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSources
{
    public class GoogleAnalytics4DataSourceFixture
    {
        [Fact]
        public void GoogleAnalytics4DataSource_IsDataSource_WhenConstructed()
        {
            // Act
            var dataSource = new GoogleAnalytics4DataSource();

            // Assert
            Assert.True(dataSource is DataSource);
        }

        [Fact]
        public void Constructor_SetProviderToGoogleAnalytics4_WhenConstructed()
        {
            // Act
            var dataSource = new GoogleAnalytics4DataSource();

            // Assert
            Assert.Equal(DataSourceProvider.GoogleAnalytics4, dataSource.Provider);
        }
    }
}
