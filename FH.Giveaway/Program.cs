using FH.Giveaway;
using FH.Giveaway.Components;
using KristofferStrube.Blazor.Confetti;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration["Cosmos:ConnString"];

builder.Services.AddConfettiService();

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton(GetContainer());

builder.Services.AddSingleton(
    new BookInfoSet(builder.Configuration));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

Container GetContainer()
{
    var databaseId = builder.Configuration["Cosmos:DatabaseId"];
    var containerId = builder.Configuration["Cosmos:ContainerId"];

    var cosmos = CosmosHelper.GetCosmosClient(builder.Configuration);

    return cosmos.GetContainer(databaseId, containerId);
}
