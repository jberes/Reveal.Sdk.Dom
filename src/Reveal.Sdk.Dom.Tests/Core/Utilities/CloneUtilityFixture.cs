using Reveal.Sdk.Dom.Core.Utilities;
using System.Collections.Generic;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Core.Utilities
{
    public class CloneUtilityFixture
    {
        [Fact]
        public void Clone_Null_ReturnsDefault()
        {
            // Arrange
            object item = null;

            // Act
            var result = CloneUtility.Clone(item);

            // Assert
            Assert.Equal(default, result);
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
