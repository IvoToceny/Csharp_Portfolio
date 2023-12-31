using AspNetCoreRateLimit;
using HealthChecks.UI.Client;
using MarketCarsAPI.StartupConfig;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

builder.AddDbAccessServices();

builder.AddVersioningServices();

builder.Services.AddResponseCaching();

//builder.AddHealthCheckServices();

builder.Services.AddMemoryCache();
builder.AddRateLimitServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI(opts =>
{
    opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseRouting();

app.UseHttpsRedirection();

app.UseResponseCaching();

app.MapControllers();

//app.MapHealthChecks("/health", new HealthCheckOptions
//{
//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//});
//app.MapHealthChecksUI();

app.UseIpRateLimiting();

app.Run();
