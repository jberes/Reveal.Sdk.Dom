[![Reveal.Sdk.Dom Build](https://github.com/RevealBi/Reveal.Sdk.Dom/actions/workflows/build-dom.yml/badge.svg?branch=main)](https://github.com/RevealBi/Reveal.Sdk.Dom/actions/workflows/build-dom.yml)

# Reveal.Sdk.Dom
The Reveal.Sdk.Dom is a Document Object Model (DOM) for the [Reveal](https://www.revealbi.io/) **.rdash** file format. It allows developer using the [Reveal SDK](https://www.revealbi.io/) to load, edit, and create dashboards using .NET.

The Reveal.Sdk.Dom is currently **BETA** so expect things to not work, or to possibly break in a future release.

Check out the [Samples](https://github.com/RevealBi/Reveal.Sdk.Dom/tree/main/e2e/Sandbox/Factories) in the Sandbox application I am using to develop and test the API.

## Quick Start Guide

Install the Reveal.Sdk.Dom NuGet package.

### Load Dashboard

```cs
string filePath = Path.Combine(Environment.CurrentDirectory, "Sales.rdash");
var document = RdashDocument.Load(filePath);
```

### Create Dashboard

```cs
//create the dashboard document
var document = new RdashDocument("My Dashboard");

//create a data source item using a REST service
var jsonDataSourceItem = new RestBuilder("https://excel2json.io/api/share/6e0f06b3-72d3-4fec-7984-08da43f56bb9")
    .SetTitle("JSON Data Source")
    .SetSubtitle("Sales by Category")
    .SetFields(new List<Field>() //must define the fields returned from the data set
    {
        new NumberField("CategoryID"),
        new TextField("CategoryName"),
        new TextField("ProductName"),
        new NumberField("ProductSales"),
    })
    .Build();

//add a Pie Chart to the dashboard using the REST service as the data source
document.Visualizations.Add(new PieChartVisualization("My Pie Chart", jsonDataSourceItem)
    .AddLabel("CategoryName")
    .AddValue("ProductSales"));

//save the document as an .rdash file
document.Save(filePath);

//optionally load the document into a RevealView
var json = document.ToJsonString();
_revealView.Dashboard = await RVDashboard.LoadFromJsonAsync(json);
```
