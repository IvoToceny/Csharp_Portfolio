﻿using AspNetCoreRateLimit;
using Microsoft.OpenApi.Models;

namespace MarketCarsAPI.StartupConfig;

public static class ServicesConfig
{
    public static void AddVersioningServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(opts =>
        {
            var title = "MarketCars API";
            var description = "This is a Web API for MarketCars App that controls data access to MSSQL using Dapper," +
            " Authentication and Authorization by Azure Active Directory and Files control through Azure Blob Storage. " +
            " API is secured by Rate Limiting, Caching and Data Validation. " +
            "This is a Demo App for my Portfolio. Feel free to use";
            var terms = new Uri("https://localhost:7136/terms");
            var license = new OpenApiLicense()
            {
                Name = "This is my full license information or a link to it."
            };
            var contact = new OpenApiContact()
            {
                Name = "Ivo Točený",
                Email = "ivo6770@gmail.com",
                Url = new Uri("https://github.com/IvoToceny/Csharp_Portfolio")
            };

            opts.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = $"{title} v1",
                Description = description,
                TermsOfService = terms,
                License = license,
                Contact = contact
            });
        });

        builder.Services.AddApiVersioning(opts =>
        {
            opts.AssumeDefaultVersionWhenUnspecified = true;
            opts.DefaultApiVersion = new(1, 0);
            opts.ReportApiVersions = true;
        }).AddApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
    }

    public static void AddHealthCheckServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
            .AddSqlServer(builder.Configuration.GetConnectionString("Default")!);

        builder.Services.AddHealthChecksUI(opts =>
        {
            opts.AddHealthCheckEndpoint("api", "/health");
            opts.SetEvaluationTimeInSeconds(5);
            opts.SetMinimumSecondsBetweenFailureNotifications(10);
        }).AddInMemoryStorage();
    }

    public static void AddRateLimitServices(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<IpRateLimitOptions>(
            builder.Configuration.GetSection("IpRateLimiting"));
        builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
        builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        builder.Services.AddInMemoryRateLimiting();
    }
}