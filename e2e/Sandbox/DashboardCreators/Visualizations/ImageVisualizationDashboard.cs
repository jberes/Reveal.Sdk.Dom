using Reveal.Sdk.Data.Excel;
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.DashboardFactories;
using Sandbox.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.DashboardCreators
{
    internal class ImageVisualizationDashboard : IDashboardCreator
    {
        public string Name => "Image Visualization Dashboard";

        public RdashDocument CreateDashboard()
        {
            var document = new RdashDocument("My Image Visualization Dashboard");

            var excelDSItem = DataSourceFactory.GetMarketingDataSourceItem();

            var calculatedField = new TextField("Fixed image url")
            {
                Expression = "\"https://picsum.photos/200/300\"",
                IsCalculated = true,
            };
            excelDSItem.Fields.Add(calculatedField);

            var vs1 = new ImageVisualization("Image", excelDSItem)
            {
                ColumnSpan = 5,
                RowSpan = 5,
                Description = "Description for Image visualization",
                IsTitleVisible = true,
                Title = "Image VS 1 Title",
                Linker = new VisualizationLinker()
                {
                    Links = new List<IVisualizationLink>()
                    {
                        new UrlLink()
                        {
                            Title = "Linker",
                            Url = "https://help.revealbi.io/web/datasources/",
                            Type = LinkType.OpenUrl
                        }
                    },
                    Trigger = LinkTriggerType.SelectRow
                }
            };
            vs1.SetUrl("Territory");

            var vs2 = new ImageVisualization("Image Fixed", excelDSItem)
            {
                ColumnSpan = 5,
                RowSpan = 5,
                Description = "Description for Image visualization",
                IsTitleVisible = true,
                Title = "Image VS 2 Title",
            };
            vs2.SetUrl("Fixed image url");


            document.Visualizations.Add(vs1);
            document.Visualizations.Add(vs2);

            return document;
        }
    }
}
