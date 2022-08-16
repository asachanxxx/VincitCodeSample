using System.Transactions;
using Company.TxTool.Application.Common.Interfaces;
using Company.TxTool.Application.Extensions;
using Company.TxTool.FunctionApi.Services;
using Cushwake.TreasuryTool.Domain.Common.BaseEntities;
using Cushwake.TreasuryTool.Domain.Security;
using Cushwake.TreasuryTool.Infrastructure.Extensions;
using Cushwake.TreasuryTool.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Tests.Application.IntegrationTests;

[SetUpFixture]
public partial class Testing
{
    private static IConfiguration _configuration = null!;
    private static IServiceScopeFactory _scopeFactory = null!;

    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        var services = new ServiceCollection();

        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
        services.AddSingleton(_configuration);

        services.AddApplicationServices();
        services.AddInfrastructureServices(_configuration);

        services.AddScoped(typeof(ICurrentIdentityService), typeof(MockIdentityService));

        _scopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();
    }

    public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        var response = default(TResponse);
        using var scope = _scopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        using (var tscope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            response = await mediator.Send(request);
            tscope.Dispose();
        }

        return response;
    }

    public static UserLite RunAsUser
    {
        get
        {
            using var scope = _scopeFactory.CreateScope();

            var userService = scope.ServiceProvider.GetRequiredService<ICurrentUserService>();

            return userService.User;
        }
    }

    public static async Task<TEntity?> FindAsync<TEntity>(params object[] keyValues)
        where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        return await context.FindAsync<TEntity>(keyValues);
    }

    public static async Task<int> AddAsync<TEntity>(TEntity entity)
           where TEntity : BaseEntity
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Add(entity);

        await context.SaveChangesAsync();

        return entity.Id;
    }

    public static async Task<int> CountAsync<TEntity>() where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        return await context.Set<TEntity>().CountAsync();
    }

    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
    }
}