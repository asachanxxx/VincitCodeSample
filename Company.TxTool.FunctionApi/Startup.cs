using System;
using Company.TxTool.Application.Extensions;
using Company.TxTool.FunctionApi;
using Company.TxTool.FunctionApi.Extensions;
using Cushwake.TreasuryTool.Infrastructure.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Company.TxTool.FunctionApi;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        AppContext.SetSwitch("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", true);

        var configuration = builder.GetContext().Configuration;

        //Injecting required Services
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(configuration);
        builder.Services.AddWebUIServices();
    }
}
