using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EmailGenerator.WebUI;
using MudBlazor.Services;
using EmailGenerator.WebApiClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var services = builder.Services;

services.AddMudServices();
services.AddMudBlazorDialog();

var apiClientName = "Api";
var configureClient = new Action<HttpClient>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["ApiUri"]);
});

services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient(apiClientName));

services.AddHttpClient<StylesClient>(apiClientName, configureClient);
services.AddHttpClient<TemplatesClient>(apiClientName, configureClient);

services.AddScoped<StylesClient>();
services.AddScoped<TemplatesClient>();

await builder.Build().RunAsync();