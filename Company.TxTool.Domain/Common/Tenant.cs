using System;
using System.Globalization;
using Cushwake.TreasuryTool.Domain.Common.Enums;

namespace Cushwake.TreasuryTool.Domain.Common
{
    public class Tenant
    {
        public int Id
        {
            get; set;
        }

        public TenantEnum Code
        {
            get; private set;
        }

        public string AdminEmail
        {
            get; private set;
        }

        public string CultureCode
        {
            get; private set;
        }

        public CultureInfo CultureInfo => CultureInfo.CreateSpecificCulture(CultureCode);

        public string TimeZoneName
        {
            get; private set;
        }

        public TimeZoneInfo TimeZoneInfo => TimeZoneInfo.FindSystemTimeZoneById(TimeZoneName);

        public bool IsActive
        {
            get; private set;
        }

        public Tenant()
        {
            Code = default!;
            AdminEmail = default!;
            CultureCode = default!;
            TimeZoneName = default!;
        }
    }
}
