using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data
{
    public class DataSourceFixture
    {
        [Fact]
        public void DataSource_DefaultConstructor_SetsSchemaTypeName()
        {
            // Arrange
            var dataSource = new DataSource();

            // Act

            // Assert
            Assert.Equal(SchemaTypeNames.DataSourceType, dataSource.SchemaTypeName);
        }

        [Fact]
        public void DataSource_DefaultConstructor_SetsProperties()
        {
            // Arrange
            var dataSource = new DataSource();

            // Act

            // Assert
            Assert.NotNull(dataSource.Properties);
        }

        [Fact]
        public void DataSource_DefaultConstructor_GeneratesUniqueId()
        {
            // Arrange
            var dataSource1 = new DataSource();
            var dataSource2 = new DataSource();

            // Act

            // Assert
            Assert.NotEqual(dataSource1.Id, dataSource2.Id);
        }

        [Fact]
        public void DataSource_SetId_NullValue_GeneratesUniqueId()
        {
            // Arrange
            var dataSource = new DataSource();

            // Act
            dataSource.Id = null;

            // Assert
            Assert.NotNull(dataSource.Id);
        }

        [Fact]
        public void DataSource_DefaultRefreshRate_Should_SetAndGetValue()
        {
            // Arrange
            var dataSource = new DataSource();
            var expectedValue = "10 minutes";

            // Act
            dataSource.DefaultRefreshRate = expectedValue;
            var actualValue = dataSource.DefaultRefreshRate;

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void DataSource_Equals_Null_ReturnsFalse()
        {
            // Arrange
            var dataSource = new DataSource();

            // Act
            var result = dataSource.Equals(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DataSource_Equals_SameId_ReturnsTrue()
        {
            // Arrange
            var dataSource1 = new DataSource { Id = "same-id" };
            var dataSource2 = new DataSource { Id = "same-id" };

            // Act
            var result = dataSource1.Equals(dataSource2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DataSource_GetHashCode_ReturnsConsistentValue()
        {
            // Arrange
            var dataSource = new DataSource();

            // Act
            var hashCode1 = dataSource.GetHashCode();
            var hashCode2 = dataSource.GetHashCode();

            // Assert
            Assert.Equal(hashCode1, hashCode2);
        }
    }
}
