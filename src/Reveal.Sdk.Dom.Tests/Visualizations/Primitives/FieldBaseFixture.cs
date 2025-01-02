using Moq;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class FieldBaseFixture
    {
        [Fact]
        public void Constructor_FieldsHaveDefaultValue_WithFieldNameParameter()
        {
            // Act
            var fieldBase = new MockFieldBase("TestFieldName");

            // Assert
            Assert.Equal(DataType.String, ((IFieldDataType)fieldBase).DataType);
            Assert.Empty(fieldBase.Properties);
            Assert.Equal(SortingType.None, fieldBase.Sorting);
        }

        [Fact]
        public void Constructor_UpdateFieldNameAndFieldLabel_WithFieldNameParameter()
        {
            // Arrange
            var testFieldName = "Field Base Field Name";

            // Act
            var fieldBase = new MockFieldBase(testFieldName);

            // Assert
            Assert.Equal(testFieldName, fieldBase.FieldName);
            Assert.Equal(testFieldName, fieldBase.FieldLabel);
        }

        private class MockFieldBase : FieldBase<MockIFilter>
        {
            public MockFieldBase(string fieldName) : base(fieldName)
            {
            }
        }

        private class MockIFilter : IFilter
        { }

        private class MockField : FieldBase<MockIFilter>
        {
            public MockField(string fieldName) : base(fieldName)
            { }
        }
    }
}
