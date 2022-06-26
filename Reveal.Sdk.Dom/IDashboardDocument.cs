using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom
{
    public interface IDashboardDocument
    {
        string Title { get; set; }
        string Description { get; set; }
        string Theme { get; set; }
        string CreatedWith { get; }
        string SavedWith { get; }
        int FormatVersion { get; }
        bool UseAutoLayout { get; set; }
        int? AutoRefreshInterval { get; set; }
        string PasswordHash { get; set; }
        string Tags { get; set; }
        List<DataSource> DataSources { get; }
        List<DashboardFilter> Filters { get; }
        //List<GlobalVariable> GlobalVariables { get; }
        List<IVisualization> Visualizations { get; }

        void Save(string filePath);
        string ToJsonString();
    }
}
