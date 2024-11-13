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
    public class GoogleDriveDataSourceFixture
    {
        [Fact]
        public void GoogleDriveDataSource_IsDataSource_WhenConstructed()
        {
            // Act
            var dataSource = new GoogleDriveDataSource();

            // Assert
            Assert.True(dataSource is DataSource);
        }

        [Fact]
        public void Constructor_SetProviderToGoogleDrive_WhenConstructed()
        {
            // Act
            var dataSource = new GoogleDriveDataSource();

            // Assert
            Assert.Equal(DataSourceProvider.GoogleDrive, dataSource.Provider);
        }
    }
}
