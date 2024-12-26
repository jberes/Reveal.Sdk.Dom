using Moq;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions
{
    public class IColumnsExtensionsFixture
    {
        [Fact]
        public void SetColumn_UpdateColumn_WithFieldName()
        {
            // Arrange
            var visualization = new MockIColumns();
            var fieldName = "TestField";
            var expectedColumns = new List<DimensionColumn>
            {
                new DimensionColumn()
                {
                    DataField = new TextDataField(fieldName),
                }
            };

            // Act
            visualization.SetColumn(fieldName);

            // Assert
            Assert.Equivalent(expectedColumns, visualization.Columns);
        }

        [Fact]
        public void SetColumn_UpdateColumn_WithDimensionDataField()
        {
            // Arrange
            var visualization = new MockIColumns();

            var mockDimensionDataField = new Mock<DimensionDataField>("TestField");
            var field = mockDimensionDataField.Object;
            var expectedColumns = new List<DimensionColumn>
            {
                new DimensionColumn()
                {
                    DataField = field
                }
            };

            // Act
            visualization.SetColumn(field);

            // Assert
            Assert.Equivalent(expectedColumns, visualization.Columns);
        }

        [Fact]
        public void SetColumns_UpdateColumns_WithListFieldNames()
        {
            // Arrange
            var visualization = new MockIColumns();
            var fieldNames = new List<string>() { "FirstFieldName", "SecondFieldName" };
            var expectedColumns = fieldNames.Select(x => new DimensionColumn() { DataField = new TextDataField(x) });

            // Act
            visualization.SetColumns(fieldNames.ToArray());

            // Assert
            Assert.Equivalent(expectedColumns, visualization.Columns);
        }

        [Fact]
        public void SetColumns_UpdateColumns_WithListDimensionDataFields()
        {
            // Arrange
            var visualization = new MockIColumns();

            var fields = new List<DimensionDataField>();
            var expectedColumns = new List<DimensionColumn>();

            var mockDimensionDataField1 = new Mock<DimensionDataField>("FirstField");
            var field1 = mockDimensionDataField1.Object;
            fields.Add(field1);
            expectedColumns.Add(new DimensionColumn() { DataField = field1 });

            var mockDimensionDataField2 = new Mock<DimensionDataField>("SecondField");
            var field2 = mockDimensionDataField2.Object;
            fields.Add(field2);
            expectedColumns.Add(new DimensionColumn() { DataField = field2 });

            // Act
            visualization.SetColumns(fields.ToArray());

            // Assert
            Assert.Equivalent(expectedColumns, visualization.Columns);
        }

        private class MockIColumns : IColumns
        {
            public List<DimensionColumn> Columns { get; } = new List<DimensionColumn>();
        }
    }
}
