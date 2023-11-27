using AspNetCoreRateLimit;
using MarketCarsLibrary.Data;
using MarketCarsLibrary.Data.Interfaces;
using MarketCarsLibrary.Db;
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
            " Authentication by Azure B2C inside BlazorServer, Files control through Azure Blob Storage for uploading images of cars for selling, Azure SQL Database to store tables, procedures and data there. " +
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
            .AddSqlServer(builder.Configuration.GetConnectionString("Azure")!);

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

    public static void AddDbAccessServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton(new ConnectionStringData 
        {
            SqlConnectionName = "Azure"
        });
        builder.Services.AddSingleton<IDataAccess, SqlDb>();
        builder.Services.AddSingleton<ICarsData, CarsData>();
        builder.Services.AddSingleton<IImagesData, ImagesData>();
        builder.Services.AddSingleton<IServicesData, ServicesData>();
        builder.Services.AddSingleton<IUsersData, UsersData>();
    }
}
