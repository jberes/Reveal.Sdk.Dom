using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Core
{
    public class VisualizationCollectionFixture
    {
        [Fact]
        public void Add_AddsVisualizationToCollection()
        {
            // Arrange
            var collection = new VisualizationCollection();
            var visualization = new MockVisualization();

            // Act
            collection.Add(visualization);

            // Assert
            Assert.Contains(visualization, collection);
        }

        [Fact]
        public void AddRange_AddsVisualizationsToCollection()
        {
            // Arrange
            var collection = new VisualizationCollection();
            var visualizations = new List<IVisualization>
            {
                new MockVisualization(),
                new MockVisualization(),
                new MockVisualization()
            };

            // Act
            collection.AddRange(visualizations);

            // Assert
            Assert.Equal(visualizations.Count, collection.Count);
            foreach (var visualization in visualizations)
            {
                Assert.Contains(visualization, collection);
            }
        }

        [Fact]
        public void RemoveById_RemovesVisualizationFromCollection()
        {
            // Arrange
            var collection = new VisualizationCollection();
            var visualization1 = new MockVisualization { Id = "1" };
            var visualization2 = new MockVisualization { Id = "2" };
            var visualization3 = new MockVisualization { Id = "3" };
            collection.AddRange(new List<IVisualization> { visualization1, visualization2, visualization3 });

            // Act
            var result = collection.RemoveById("2");

            // Assert
            Assert.Equal(1, result);
            Assert.DoesNotContain(visualization2, collection);
        }

        [Fact]
        public void RemoveByTitle_RemovesVisualizationsFromCollection()
        {
            // Arrange
            var collection = new VisualizationCollection();
            var visualization1 = new MockVisualization { Title = "Title 1" };
            var visualization2 = new MockVisualization { Title = "Title 2" };
            var visualization3 = new MockVisualization { Title = "Title 3" };
            collection.AddRange(new List<IVisualization> { visualization1, visualization2, visualization3 });

            // Act
            var result = collection.RemoveByTitle("Title 2");

            // Assert
            Assert.Equal(1, result);
            Assert.DoesNotContain(visualization2, collection);
        }

        [Fact]
        public void FindById_ReturnsVisualizationFromCollection()
        {
            // Arrange
            var collection = new VisualizationCollection();
            var visualization1 = new MockVisualization { Id = "1" };
            var visualization2 = new MockVisualization { Id = "2" };
            var visualization3 = new MockVisualization { Id = "3" };
            collection.AddRange(new List<IVisualization> { visualization1, visualization2, visualization3 });

            // Act
            var result = collection.FindById("2");

            // Assert
            Assert.Equal(visualization2, result);
        }

        private class MockVisualization : IVisualization, IParentDocument
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public ChartType ChartType { get; }
            public bool IsTitleVisible { get; set; }
            public int ColumnSpan { get; set; }
            public int RowSpan { get; set; }
            public string Description { get; set; }
            public IDataDefinition DataDefinition { get; }
            RdashDocument IParentDocument.Document { get; set; }
            public List<VisualizationFilter> Filters { get; set; }
            public List<Binding> FilterBindings { get; set;}

            public DataSourceItem GetDataSourceItem()
            {
                throw new System.NotImplementedException();
            }

            public string BackgroundColor { get; set; }
        }
    }
}
