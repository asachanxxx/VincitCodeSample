using System;
using Company.TxTool.Application.Common.Interfaces;
using Company.TxTool.FunctionApi.Services;
using Cushwake.TreasuryTool.Infrastructure.Common;
using Cushwake.TreasuryTool.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Company.TxTool.FunctionApi.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped(typeof(ICurrentIdentityService),
            EnvironmentExtensions.InDevelopment ? typeof(MockIdentityService) : typeof(CloudIdentityService));

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        JsonConvert.DefaultSettings = () =>
        {
            var settings = new JsonSerializerSettings();
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            settings.Converters.Add(new StringEnumConverter());
            return settings;
        };

        return services;
    }
}
