using System;

namespace Cushwake.TreasuryTool.Infrastructure.Common
{
    public class EnvironmentExtensions
    {
        public static bool InDevelopment => Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT") == "Development";
    }
}