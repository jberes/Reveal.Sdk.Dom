using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSources
{
    public class GoogleBigQueryDataSourceFixture
    {
        [Fact]
        public void Constructor_SetProviderToGoogleBigQuery_WithoutParameters()
        {
            // Act
            var dataSource = new GoogleBigQueryDataSource();

            // Assert
            Assert.Equal(DataSourceProvider.GoogleBigQuery, dataSource.Provider);
        }

        [Fact]
        public void SetProjectId_ReturnSame_WithSetValue()
        {
            // Arrange
            var dataSource = new GoogleBigQueryDataSource();
            var projectId = "TestProjectId";

            // Act
            dataSource.ProjectId = projectId;

            // Assert
            Assert.Equal(projectId, dataSource.ProjectId);
            Assert.Equal(projectId, dataSource.Properties.GetValue<string>("projectId"));
        }

        [Fact]
        public void ToJsonString_CreatesFormattedJson_NoConditions()
        {
            // Arrange
            var expectedJson = """
                {
                  "_type": "DataSourceType",
                  "Id": "ggBigQueryDSId",
                  "Provider": "BIG_QUERY",
                  "Description": "Big Query",
                  "Subtitle": "Public Data",
                  "Properties": {
                    "projectId": "bigquery-public-data"
                  },
                  "Settings": {}
                }
            """;

            var dataSource = new GoogleBigQueryDataSource()
            {
                Id = "ggBigQueryDSId",
                Title = "Big Query",
                Subtitle = "Public Data",
                ProjectId = "bigquery-public-data"
            };

            // Act
            var json = dataSource.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(json);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);

        }
    }
}
