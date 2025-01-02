using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class DimensionColumnFixture
    {
        [Fact]
        public void Constructor_SchemaTypeIsDimensionColSpecType_WhenConstructed()
        {

            // Act
            var column = new DimensionColumn();

            // Assert
            Assert.Equal(SchemaTypeNames.DimensionColumnSpecType, column.SchemaTypeName);
        }

        [Fact]
        public void Constructor_SchemaTypeIsDimensionColSpecType_WhenConstructedWithDataField()
        {
            // Arrange
            var dataField = new TextDataField("test field");
            // Act
            var column = new DimensionColumn(dataField);

            // Assert
            Assert.Equal(dataField, column.DataField);
        }

    }
}