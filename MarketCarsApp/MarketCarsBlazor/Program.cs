using MarketCarsBlazor.Components;
using MarketCarsBlazor.Components.Pages;
using MarketCarsBlazor.StartupConfig;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.AddAuthenticationServices();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents().AddMicrosoftIdentityConsentHandler();

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});

builder.Services.AddRazorPages();

builder.Services.AddHttpClient("api", opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl")!);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHttpsRedirection();
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseRewriter(
    new RewriteOptions().Add(
        context =>
        {
            if(context.HttpContext.Request.Path == "/MicrosoftIdentity/Account/SignedOut")
            {
                context.HttpContext.Response.Redirect("/");
            }
        }
    )
 );

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapBlazorHub();

app.MapControllers();

app.MapRazorPages();

app.Run();
