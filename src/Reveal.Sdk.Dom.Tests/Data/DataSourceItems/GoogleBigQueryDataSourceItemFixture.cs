using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSourceItems
{
    public class GoogleBigQueryDataSourceItemFixture
    {
        [Fact]
        public void Constructor_SetsTitleAndDatasource_AsProvided()
        {
            // Arrange
            var dataSource = new GoogleBigQueryDataSource();
            var title = "Test title";

            // Act
            var dataSourceItem = new GoogleBigQueryDataSourceItem(title, dataSource);

            // Assert
            Assert.Equal(title, dataSourceItem.Title);
            Assert.Equal(dataSource, dataSourceItem.DataSource);
        }

        [Fact]
        public void DataSetId_SaveValueAndProperties_WhenSet()
        {
            // Arrange
            var dataSource = new GoogleBigQueryDataSource();
            var dataSourceItem = new GoogleBigQueryDataSourceItem("Test", dataSource);
            var datasetId = "DatasetId";

            // Act
            dataSourceItem.DataSetId = datasetId;

            // Assert
            Assert.Equal(datasetId, dataSourceItem.DataSetId);
            Assert.Equal(datasetId, dataSourceItem.Properties.GetValue<string>("DataSetId"));
        }

        [Fact]
        public void PropertyId_SaveValueAndProperties_WhenSet()
        {
            // Arrange
            var dataSource = new GoogleBigQueryDataSource();
            var dataSourceItem = new GoogleBigQueryDataSourceItem("Test", dataSource);
            var projectId = "TestPropertyId";

            // Act
            dataSourceItem.ProjectId = projectId;

            // Assert
            Assert.Equal(projectId, dataSourceItem.ProjectId);
            Assert.Equal(projectId, dataSourceItem.Properties.GetValue<string>("ProjectId"));
        }
    }
}
