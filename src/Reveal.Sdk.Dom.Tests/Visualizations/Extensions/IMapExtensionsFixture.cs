using Moq;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions
{
    public class IMapExtensionsFixture
    {
        [Fact]
        public void SetMap_UpdateMap_WithMapName()
        {
            // Arrange
            var map = new MockMap();
            var expectedMapName = "TestMap";

            // Act
            map.SetMap(expectedMapName);

            // Assert
            Assert.Equal(expectedMapName, map.Map);
        }

        private class MockMap : IMap
        {
            public string Map { get; set; }
        }
    }
}
