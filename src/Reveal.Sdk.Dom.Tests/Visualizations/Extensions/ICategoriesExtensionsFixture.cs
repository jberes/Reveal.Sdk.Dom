using Moq;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions
{
    public class ICategoriesExtensionsFixture
    {
        [Fact]
        public void SetCategory_UpdateCategories_WithFieldName()
        {
            // Arrange
            var visualization = new MockICategories();
            var fieldName = "TestField";
            var expectedCategories = new List<DimensionColumn> {
                new DimensionColumn()
                {
                    DataField = new TextDataField(fieldName),
                }
            };

            // Act
            visualization.SetCategory(fieldName);

            // Assert
            Assert.Equivalent(expectedCategories, visualization.Categories);
        }

        [Fact]
        public void SetCategory_UpdateCategories_WithDimensionDataField()
        {
            // Arrange
            var visualization = new MockICategories();
            var fieldName = "TestField";
            var mockDimensionDataField = new Mock<DimensionDataField>(fieldName);
            var field = mockDimensionDataField.Object;
            var expectedCategories = new List<DimensionColumn> {
                new DimensionColumn()
                {
                    DataField = field,
                }
            };

            // Act
            visualization.SetCategory(field);

            // Assert
            Assert.Equivalent(expectedCategories, visualization.Categories);
        }

        [Fact]
        public void SetCategories_UpdateCategories_WithListFieldNames()
        {
            // Arrange
            var visualization = new MockICategories();
            var fieldNames = new List<string> { "FirstFieldName", "SecondFieldName" };
            var expectedCategories = fieldNames.Select(x => new DimensionColumn { DataField = new TextDataField(x) });

            // Act
            visualization.SetCategories(fieldNames.ToArray());

            // Assert
            Assert.Equivalent(expectedCategories, visualization.Categories);
        }

        [Fact]
        public void SetCategories_UpdateCategories_WithListDimensionDataFields()
        {
            // Arrange
            var visualization = new MockICategories();

            var fields = new List<DimensionDataField>();
            var expectedCategories = new List<DimensionColumn>();

            var mockDimensionDataField1 = new Mock<DimensionDataField>("FirstFieldName");
            var f1 = mockDimensionDataField1.Object;
            fields.Add(f1);
            expectedCategories.Add(new DimensionColumn() { DataField = f1 });

            var mockDimensionDataField2 = new Mock<DimensionDataField>("SecondFieldName");
            var f2 = mockDimensionDataField2.Object;
            fields.Add(f2);
            expectedCategories.Add(new DimensionColumn() { DataField = f2 });

            // Act
            visualization.SetCategories(fields.ToArray());

            // Assert
            Assert.Equivalent(expectedCategories, visualization.Categories);
        }

        private class MockICategories : ICategories
        {
            public List<DimensionColumn> Categories { get; } = new List<DimensionColumn>();
        }
    }
}
