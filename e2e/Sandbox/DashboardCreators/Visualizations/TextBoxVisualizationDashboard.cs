using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Visualizations;
using Sandbox.DashboardFactories;
using Sandbox.Helpers;

namespace Sandbox.DashboardCreators
{
    internal class TextBoxVisualizationDashboard : IDashboardCreator
    {
        public string Name => "Text Box Vizualization Dashboard";

        public RdashDocument CreateDashboard()
        {
            var document = new RdashDocument("My Text Box Visualization Dashboard");

            var excelDSItem = DataSourceFactory.GetMarketingDataSourceItem();

            var textBoxVs1 = new TextBoxVisualization("Text Box Visualization Large")
            {
                Text = "This is a big text box",
                Alignment = Alignment.Center,
                FontSize = FontSize.Large,
                ColumnSpan = 3,
                RowSpan = 4,
            };

            var textBoxVs2 = new TextBoxVisualization("Text Box Visualization Small")
            {
                Text = "This is small cute text box :3",
                Alignment = Alignment.Left,
                FontSize = FontSize.Small,
                ColumnSpan = 1,
                RowSpan = 1,
            };

            var textBoxVs3 = new TextBoxVisualization("Text Box Visualization Medium")
            {
                Text = "This is medium text box :3",
                Alignment = Alignment.Left,
                FontSize = FontSize.Medium,
                ColumnSpan = 1,
                RowSpan = 4,
            };

            document.Visualizations.Add(textBoxVs1);
            document.Visualizations.Add(textBoxVs2);
            document.Visualizations.Add(textBoxVs3);

            return document;
        }
    }
}
