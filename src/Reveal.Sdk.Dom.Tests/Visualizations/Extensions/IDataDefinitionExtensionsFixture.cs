using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions
{
    public class IDataDefinitionExtensionsFixture
    {
        [Fact]
        public void AsTabular_ReturnTabularDataDefinition_InputIsTabularDataDefinitionType()
        {
            // Arrange
            var tabular = new TabularDataDefinition();
            var dataDefinition = (IDataDefinition)tabular;

            // Act
            var actualDataDefinition = dataDefinition.AsTabular();

            // Assert
            Assert.Equal(tabular, actualDataDefinition);
        }

        [Fact]
        public void AsTabular_ReturnNull_InputIsNotTabularDataDefinitionType()
        {
            // Arrange
            var tabular = new XmlaDataDefinition();
            var dataDefinition = (IDataDefinition)tabular;

            // Act
            var actualDataDefinition = dataDefinition.AsTabular();

            // Assert
            Assert.Null(actualDataDefinition);
        }

        [Fact]
        public void AsXmla_ReturnXmlaDataDefinition_InputIsXmlaDataDefinitionType()
        {
            // Arrange
            var xmlaDataDefinition = new XmlaDataDefinition();
            var dataDefinition = (IDataDefinition)xmlaDataDefinition;

            // Act
            var actualDataDefinition = dataDefinition.AsXmla();

            // Assert
            Assert.Equal(xmlaDataDefinition, actualDataDefinition);
        }

        [Fact]
        public void AsXmla_ReturnNull_InputIsNotXmlaDataDefinitionType()
        {
            // Arrange
            var tabular = new TabularDataDefinition();
            var dataDefinition = (IDataDefinition)tabular;

            // Act
            var actualDataDefinition = dataDefinition.AsXmla();

            // Assert
            Assert.Null(actualDataDefinition);
        }
    }
}
