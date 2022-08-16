using System;
using Company.TxTool.Application.Common.Exceptions;

namespace Cushwake.TreasuryTool.Infrastructure.Exceptions
{
    public class ConfigurationException : TreasuryToolApplicationException
    {
        public ConfigurationException(string key) : base(ExceptionCode.BadConfiguration, $"The setting '{key}' is not configured correctly in the system.")
        {
        }
    }
}
