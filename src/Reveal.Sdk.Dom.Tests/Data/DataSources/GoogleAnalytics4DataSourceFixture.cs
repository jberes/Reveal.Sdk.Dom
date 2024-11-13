using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSources
{
    public class GoogleAnalytics4DataSourceFixture
    {
        [Fact]
        public void Constructor_SetProvider_ToMicrosoftSqlServer()
        {
            // Act
            var dataSource = new GoogleAnalytics4DataSource();

            // Assert
            Assert.Equal(DataSourceProvider.GoogleAnalytics4, dataSource.Provider);
        }
    }
}
