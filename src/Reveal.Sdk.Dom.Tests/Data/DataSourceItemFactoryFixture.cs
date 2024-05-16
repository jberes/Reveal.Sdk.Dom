using Reveal.Sdk.Dom.Data;
using System;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data
{
    public class DataSourceItemFactoryFixture
    {
        [Fact]
        public void Create_ShouldReturnDataSourceItem_WithDefaultDataSource()
        {
            // Arrange
            var factory = new DataSourceItemFactory();
            var type = DataSourceType.MicrosoftSqlServer;
            var id = "1";
            var title = "Test Title";

            // Act
            var result = factory.Create(type, id, title);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<MicrosoftSqlServerDataSourceItem>(result);
            Assert.Equal(id, result.Id);
            Assert.Equal(title, result.Title);
            Assert.Null(result.Subtitle);
            Assert.NotNull(result.DataSource);
            Assert.IsType<DataSource>(result.DataSource);
        }

        [Fact]
        public void Create_ShouldReturnDataSourceItem_WithCustomDataSource()
        {
            // Arrange
            var factory = new DataSourceItemFactory();
            var type = DataSourceType.MicrosoftSqlServer;
            var id = "2";
            var title = "Test Title";
            var subtitle = "Test Subtitle";
            var dataSource = new DataSource() 
            { 
                Id = "CustomId",
                Title = "Custom Title",
                Subtitle = "Custom Subtitle",
            };

            // Act
            var result = factory.Create(type, id, title, subtitle, dataSource);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<MicrosoftSqlServerDataSourceItem>(result);
            Assert.Equal(id, result.Id);
            Assert.Equal(title, result.Title);
            Assert.Equal(subtitle, result.Subtitle);
            Assert.NotNull(result.DataSource);
            Assert.Same(dataSource, result.DataSource);
        }

        [Fact]
        public void Create_ShouldThrowNotImplementedException_WhenUnknownType()
        {
            // Arrange
            var factory = new DataSourceItemFactory();
            var type = (DataSourceType)99;
            var id = "3";
            var title = "Test Title";

            // Act & Assert
            Assert.Throws<NotImplementedException>(() => factory.Create(type, id, title));
        }
    }
}
