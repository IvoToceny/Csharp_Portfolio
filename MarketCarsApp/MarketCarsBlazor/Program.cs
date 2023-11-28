using MarketCarsBlazor.Components;
using MarketCarsBlazor.StartupConfig;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.AddAuthenticationServices();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents().AddMicrosoftIdentityConsentHandler();

builder.Services.AddRazorPages();

builder.Services.AddHttpClient("api", opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl")!);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
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

app.MapControllers();

app.MapRazorPages();

app.Run();
