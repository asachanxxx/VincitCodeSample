using System;
using Cushwake.TreasuryTool.Domain.Security;

namespace Cushwake.TreasuryTool.Domain.Common
{
    public partial class AppConfig
    {
        public int AppConfigId
        {
            get; set;
        }

        public string? AppConfigCode
        {
            get; set;
        }

        public string AppConfigName { get; set; } = null!;
        public string AppConfigText { get; set; } = null!;

        public bool? IsActive
        {
            get; set;
        }

        public int? MemberOrderKey
        {
            get; set;
        }

        public DateTime? Modified
        {
            get; set;
        }

        public int? ModifiedbyId
        {
            get; set;
        }

        public virtual User? Modifiedby
        {
            get; set;
        }
    }
}