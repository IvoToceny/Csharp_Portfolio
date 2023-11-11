using AspNetCoreRateLimit;

namespace MarketCarsAPI.StartupConfig
{
    public static class ServicesConfig
    {
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
}
