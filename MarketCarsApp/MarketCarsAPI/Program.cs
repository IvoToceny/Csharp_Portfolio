using AspNetCoreRateLimit;
using HealthChecks.UI.Client;
using MarketCarsAPI.Models.BlobStorage;
using MarketCarsAPI.StartupConfig;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.AddDbAccessServices();

builder.AddVersioningServices();

builder.Services.AddSingleton<FileService>();

builder.Services.AddResponseCaching();

builder.AddHealthCheckServices();

builder.Services.AddMemoryCache();
builder.AddRateLimitServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts =>
    {
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseResponseCaching();

app.MapControllers();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecksUI();

app.UseIpRateLimiting();

app.Run();
