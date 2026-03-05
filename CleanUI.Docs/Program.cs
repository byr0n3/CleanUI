using CleanUI.Docs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

Configure(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseHttpsRedirection();
}
else
{
	app.UseExceptionHandler("/error", true);
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.MapStaticAssets();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode()
   .DisableAntiforgery()
   .DisableHttpMetrics();

await app.RunAsync().ConfigureAwait(false);

return;

static void Configure(WebApplicationBuilder builder)
{
	var services = builder.Services;

	services.AddRazorComponents()
			.AddInteractiveServerComponents();
}
