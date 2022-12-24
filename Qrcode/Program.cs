using AngryMonkey.Cloud.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Qrcode;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddCloudWeb(new CloudWebOptions()
{
    DefaultTitle = "Angry Monkey Cloud Components",
    TitleSuffix = " - Angry Monkey Cloud Components",
    SiteBundles = new List<CloudBundle>()
    {
		//new CloudBundle(){ JQuery = "3.4.1"},
		new CloudBundle(){ Source = "css/site.css"},
        new CloudBundle(){ Source = "js/site.js"},
          new CloudBundle(){ Source = "Qrcode.styles.css", MinOnRelease = false},

    }
});


builder.RootComponents.Add<CloudHeadInit>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
