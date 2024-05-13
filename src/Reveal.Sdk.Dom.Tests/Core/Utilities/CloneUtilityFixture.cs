using Reveal.Sdk.Dom.Core.Utilities;
using System.Collections.Generic;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Core.Utilities
{
    public class CloneUtilityFixture
    {
        private class CloneTestClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [Fact]
        public void Clone_ShouldReturnNull_WhenItemIsNull()
        {
            // Arrange
            object item = null;

            // Act
            var result = CloneUtility.Clone(item);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Clone_ShouldReturnDeepCopyOfItem()
        {
            // Arrange
            var item = new CloneTestClass
            {
                Id = 1,
                Name = "Test"
            };

            // Act
            var result = CloneUtility.Clone(item);

            // Assert
            Assert.NotSame(item, result);
            Assert.Equal(item.Id, result.Id);
            Assert.Equal(item.Name, result.Name);
        }

        [Fact]
        public void CloneList_ShouldReturnEmptyList_WhenListIsNull()
        {
            // Arrange
            List<CloneTestClass> list = null;

            // Act
            var result = CloneUtility.Clone(list);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void CloneList_ShouldReturnDeepCopyOfList()
        {
            // Arrange
            var list = new List<CloneTestClass>
            {
                new CloneTestClass { Id = 1, Name = "Test1" },
                new CloneTestClass { Id = 2, Name = "Test2" },
                new CloneTestClass { Id = 3, Name = "Test3" }
            };

            // Act
            var result = CloneUtility.Clone(list);

            // Assert
            Assert.NotSame(list, result);
            Assert.Equal(list.Count, result.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Assert.NotSame(list[i], result[i]);
                Assert.Equal(list[i].Id, result[i].Id);
                Assert.Equal(list[i].Name, result[i].Name);
            }
        }

        [Fact]
        public void Clone_List_ReturnsNewInstanceWithIdenticalValues()
        {
            // Arrange
            var original = new List<string> { "one", "two", "three" };

            // Act
            var result = CloneUtility.Clone(original);

            // Assert
            Assert.Equal(original.Count, result.Count);
            for (int i = 0; i < original.Count; i++)
            {
                Assert.Equal(original[i], result[i]);
            }
        }
    }
}
