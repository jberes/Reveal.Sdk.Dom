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
    }
}
