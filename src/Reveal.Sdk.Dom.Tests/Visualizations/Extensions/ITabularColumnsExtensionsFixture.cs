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
    public class ITabularColumnsExtensionsFixture
    {
        [Fact]
        public void SetColumns_UpdateColumns_WithListFieldNames()
        {
            // Arrange
            var mockTabularColumn = new Mock<ITabularColumns>();
            mockTabularColumn.SetupGet(s => s.Columns).Returns(new List<TabularColumn> { new TabularColumn("InitialColumn") });
            var visualization = mockTabularColumn.Object;

            var fieldNames = new List<string> { "FirstField", "SecondField" };
            var expectedColumns = fieldNames.Select(fieldName => new TabularColumn(fieldName)).ToList();

            // Act
            visualization.SetColumns(fieldNames.ToArray());

            // Assert
            Assert.Equivalent(expectedColumns, visualization.Columns);
        }
    }
}
