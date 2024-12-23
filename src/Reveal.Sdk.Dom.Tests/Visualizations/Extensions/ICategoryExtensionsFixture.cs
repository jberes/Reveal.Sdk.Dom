using Moq;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions
{
    public class ICategoryExtensionsFixture
    {
        [Fact]
        public void SetCategory_UpdateCategory_WithFieldName()
        {
            // Arrange
            var visualization = new MockICategory();
            var fieldName = "TestField";
            var expectedCategory = new DimensionColumn()
            {
                DataField = new TextDataField(fieldName)
            };

            // Act
            visualization.SetCategory(fieldName);

            // Assert
            Assert.Equivalent(expectedCategory, visualization.Category);
        }

        [Fact]
        public void SetCategory_UpdateCategory_WithDimensionDataField()
        {
            // Arrange
            var visualization = new MockICategory();
            var fieldName = "TestField";
            var mockDimensionDataField = new Mock<DimensionDataField>(fieldName);
            var field = mockDimensionDataField.Object;
            var expectedCategory = new DimensionColumn()
            {
                DataField = field
            };

            // Act
            visualization.SetCategory(field);

            // Assert
            Assert.Equivalent(expectedCategory, visualization.Category);
        }

        private class MockICategory : ICategory
        {
            public DimensionColumn Category { get; set; }
        }
    }
}
