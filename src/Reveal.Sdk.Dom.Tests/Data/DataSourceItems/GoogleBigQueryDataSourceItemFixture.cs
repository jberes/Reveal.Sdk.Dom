using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSourceItems
{
    public class GoogleBigQueryDataSourceItemFixture
    {
        [Fact]
        public void Constructor_CreateGGBigQueryDSItem_WithTitle()
        {
            // Arrange
            var title = "GG BigQuery DS Title";

            // Act
            var dataSourceItem = new GoogleBigQueryDataSourceItem(title);

            // Assert
            Assert.Equal(SchemaTypeNames.DataSourceItemType, dataSourceItem.SchemaTypeName);
            Assert.Equal(title, dataSourceItem.Title);
            Assert.NotNull(dataSourceItem.DataSource);
            Assert.Equal(title, dataSourceItem.DataSource.Title);
            Assert.IsType<GoogleBigQueryDataSource>(dataSourceItem.DataSource);
        }

        [Theory]
        [InlineData("DS Title", "DS Title", "DS Item Title", "DS Item Title")]
        [InlineData(null, "DS Item Title", "DS Item Title", "DS Item Title")]
        public void Constructor_CreateGGBigQueryDSItem_WithTitleAndDatSource(string dsTitle, string expectedDSTitle, string dsItemTitle, string expectedDSItemTitle)
        {
            // Arrange
            var dataSource = new DataSource() { Title =  dsTitle };

            // Act
            var dataSourceItem = new GoogleBigQueryDataSourceItem(dsItemTitle, dataSource);

            // Assert
            Assert.Equal(SchemaTypeNames.DataSourceItemType, dataSourceItem.SchemaTypeName);
            Assert.Equal(expectedDSTitle, dataSourceItem.DataSource.Title);
            Assert.Equal(expectedDSItemTitle, dataSourceItem.Title);
            Assert.Equal(dataSource.Id, dataSourceItem.DataSource.Id);
            Assert.Equal(dataSource.Id, dataSourceItem.DataSourceId);
            Assert.NotSame(dataSource, dataSourceItem.DataSource);
            Assert.IsType<GoogleBigQueryDataSource>(dataSourceItem.DataSource);
        }

        [Theory]
        [InlineData("DS Title", "DS Title", "DS Item Title", "DS Item Title")]
        [InlineData(null, "DS Item Title", "DS Item Title", "DS Item Title")]
        public void Constructor_CreateGGBigQueryDSItem_WithTitleAndGGBigQueryDatSource(string dsTitle, string expectedDSTitle, string dsItemTitle, string expectedDSItemTitle)
        {
            // Arrange
            var dataSource = new GoogleBigQueryDataSource() { Title = dsTitle };

            // Act
            var dataSourceItem = new GoogleBigQueryDataSourceItem(dsItemTitle, dataSource);

            // Assert
            Assert.Equal(SchemaTypeNames.DataSourceItemType, dataSourceItem.SchemaTypeName);
            Assert.Equal(expectedDSTitle, dataSourceItem.DataSource.Title);
            Assert.Equal(expectedDSItemTitle, dataSourceItem.Title);
            Assert.Equal(dataSource.Id, dataSourceItem.DataSource.Id);
            Assert.Equal(dataSource.Id, dataSourceItem.DataSourceId);
            Assert.Same(dataSource, dataSourceItem.DataSource);
        }

        [Fact]
        public void GetDataSetId_ReturnSameValue_WithSetValue()
        {
            // Arrange
            var dataSource = new GoogleBigQueryDataSource();
            var dataSourceItem = new GoogleBigQueryDataSourceItem("Test", dataSource);
            var datasetId = "DatasetId";

            // Act
            dataSourceItem.DataSetId = datasetId;

            // Assert
            Assert.Equal(datasetId, dataSourceItem.DataSetId);
            Assert.Equal(datasetId, dataSourceItem.Properties.GetValue<string>("datasetId"));
        }

        [Fact]
        public void GetProjectId_ReturnSameValue_WithSetValue()
        {
            // Arrange
            var dataSource = new GoogleBigQueryDataSource();
            var dataSourceItem = new GoogleBigQueryDataSourceItem("Test", dataSource);
            var projectId = "ProjectId";

            // Act
            dataSourceItem.ProjectId = projectId;

            // Assert
            Assert.Equal(projectId, dataSourceItem.ProjectId);
            Assert.Equal(projectId, dataSourceItem.Properties.GetValue<string>("ProjectId"));
        }

        [Fact]
        public void GetTable_ReturnSamevalue_WithSetValue()
        {
            // Arrange
            var dataSourceItem = new GoogleBigQueryDataSourceItem("Big Query DS Item");
            var tableName = "TestTable";

            // Act
            dataSourceItem.Table = tableName;

            // Assert
            Assert.Equal(tableName, dataSourceItem.Table);
            Assert.Equal(tableName, dataSourceItem.Properties.GetValue<string>("tableId"));
        }

        [Fact]
        public void ToJsonString_CreatesFormattedJson_NoConditions()
        {
            // Arrange
            var expectedJson = """
                {
                  "_type": "DataSourceItemType",
                  "Id": "bigqueryDSItemId",
                  "Title": "Big Query",
                  "Subtitle": "America Health rankings",
                  "DataSourceId": "bigquery",
                  "HasTabularData": true,
                  "HasAsset": false,
                  "Properties": {
                    "datasetId": "america_health_rankings",
                    "tableId": "ahr"
                  },
                  "Settings": {}
                }
            """;
            var dataSource = new GoogleBigQueryDataSource()
            {
                Id = "bigquery",
            };
            var dataSourceItem = new GoogleBigQueryDataSourceItem("Big Query", dataSource)
            {
                Id = "bigqueryDSItemId",
                Subtitle = "America Health rankings",
                HasTabularData = true,
                HasAsset = false,
                DataSetId = "america_health_rankings",
                Table = "ahr",
            };
            var expectedJObject = JObject.Parse(expectedJson);

            // Act
            var json = dataSourceItem.ToJsonString();
            var actualJObject = JObject.Parse(json);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}
