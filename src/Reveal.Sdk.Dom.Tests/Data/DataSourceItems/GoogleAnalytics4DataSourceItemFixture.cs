using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSourceItems
{
    public class GoogleAnalytics4DataSourceItemFixture
    {
        [Fact]
        public void Constructor_SetsTitleAndDatasource_AsInputs()
        {
            // Arrange
            var dataSource = new GoogleAnalytics4DataSource();

            // Act
            var dataSourceItem = new GoogleAnalytics4DataSourceItem("Test title", dataSource);

            // Assert
            Assert.Equal("Test title", dataSourceItem.Title);
            Assert.Equal(dataSource, dataSourceItem.DataSource);
        }

        [Fact]
        public void AccountId_GetAndSet_ShouldSetProperties()
        {
            // Arrange
            var dataSource = new GoogleAnalytics4DataSource();
            var dataSourceItem = new GoogleAnalytics4DataSourceItem("Test", dataSource);

            // Act
            dataSourceItem.AccountId = "TestAccountId";

            // Assert
            Assert.Equal("TestAccountId", dataSourceItem.AccountId);
            Assert.Equal("TestAccountId", dataSourceItem.Properties.GetValue<string>("AccountId"));
        }

        [Fact]
        public void PropertyId_GetAndSet_ShouldSetProperties()
        {
            // Arrange
            var dataSource = new GoogleAnalytics4DataSource();
            var dataSourceItem = new GoogleAnalytics4DataSourceItem("Test", dataSource);

            // Act
            dataSourceItem.PropertyId = "TestPropertyId";

            // Assert
            Assert.Equal("TestPropertyId", dataSourceItem.PropertyId);
            Assert.Equal("TestPropertyId", dataSourceItem.Properties.GetValue<string>("PropertyId"));
        }
    }
}
