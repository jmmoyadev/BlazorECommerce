using BlazorECommerceWeb_Application;
using BlazorECommerceWeb_Infrastructure;
using BlazorECommerceWeb_Server;
using BlazorECommerceWeb_Server.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    string[] excludedPaths = new string[] { "/css/", ".css", "/js/", ".js", "/health" };

    configuration
        .ReadFrom.Configuration(builder.Configuration)
            .Filter.ByExcluding((e) => e.Properties.ContainsKey("RequestPath")
                                    && excludedPaths.Any(x => e.Properties["RequestPath"].ToString().Contains(x)))
        //.Filter.ByExcluding(Matching.WithProperty("RequestPath", "/js/%"))
        //.Filter.ByExcluding(Matching.WithProperty("RequestPath", "/_blazor/%"))
        .Enrich.FromLogContext()
        .WriteTo.Console();
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRadzenBlazorServices();

builder.Services
    .AddInfrastructureServices(builder.Configuration)
    .AddApplication()
    .AddWebApplication();

/******************************/
/*           APP             */
/*****************************/

var app = builder.Build();

await app.InitialiseDatabaseAsync();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

