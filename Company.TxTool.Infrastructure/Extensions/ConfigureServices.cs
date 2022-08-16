using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Infrastructure.Common;
using Cushwake.TreasuryTool.Infrastructure.Persistence;
using Cushwake.TreasuryTool.Infrastructure.Persistence.Interceptors;
using Cushwake.TreasuryTool.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cushwake.TreasuryTool.Infrastructure.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //This line added intentionally to check if connection is ok :D -Pls don't remove
        var conn = configuration.GetConnectionString("AzureSqlDb");
        if (conn == null)
        {
            throw new InvalidOperationException("cannot retrieve configuration info for the function app. please contact development team for more info");
        }

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddScoped<TaggedQueryCommandInterceptor>();
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("GlobalTreasuryToolDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("AzureSqlDb")), ServiceLifetime.Transient);
        }
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IStorageService, AzureBlobStorageService>();
        services.AddScoped<IDbContextLite, DapperDbContext>();
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddSingleton<IEnvironmentSettings, EnvironmentSettings>();

        if (EnvironmentExtensions.InDevelopment)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
                loggingBuilder.AddDebug();
            });
        }
        else
        {
            services.AddLogging();
        }

        return services;
    }
}
