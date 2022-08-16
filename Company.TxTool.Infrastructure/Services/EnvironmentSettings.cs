using System;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Infrastructure.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Cushwake.TreasuryTool.Infrastructure.Services;

public class EnvironmentSettings : IEnvironmentSettings
{
    private readonly IConfiguration _configuration;

    public EnvironmentSettings(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool InDevelopmentEnvironment => Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT") == "Development";

    public string BlobStorageContainerPrefix => GetStringValue("BlobStorageContainerPrefix");

    public string MockDevUserEmail => GetStringValue("MockDevUserEmail");

    public string BlobStorageConnectionString => GetConnectionString("BlobStorage");

    public string AzureSqlDbConnectionString => GetConnectionString("AzureSqlDb");

    public string BlobStorageSupportDocumentsFolder => GetStringValue("BlobStorageSupportDocumentsFolder");

    private string GetStringValue(string key)
    {
        var value = _configuration.GetValue<string>(key);
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ConfigurationException(key);
        }
        return value;
    }

    private string GetConnectionString(string key)
    {
        var value = _configuration.GetConnectionString(key);
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ConfigurationException(key);
        }
        return value;
    }
}
