using System;
using System.Data;
using Company.TxTool.Application.Common.Interfaces;
using Cushwake.TreasuryTool.Application.Common.Exceptions;
using Cushwake.TreasuryTool.Domain.Common.Enums;
using Cushwake.TreasuryTool.Domain.Security;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cushwake.TreasuryTool.Infrastructure.Persistence
{
    public class DapperDbContext : IDbContextLite
    {
        private readonly string _connectionString;

        public DapperDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureSqlDb");
            SqlMapper.AddTypeHandler(new ApplicationRoleEnumTypeHandler());
        }

        public async Task<UserLite> GetActiveUser(string workEmail)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var sqlStatement =
                $"SELECT u.[UserID], u.[UserGraphID], u.[Name], u.[WorkEmail], t.[TenantID] AS TenantId, t.[Code] AS TenantCode, t.[CultureCode] AS TenantCultureCode, t.[TimeZoneName] AS TenantTimeZoneName, u.[IsActive], r.[ApplicationRoleCode] AS Role FROM [usr].[User] AS u " +
                    $"JOIN [usr].[ApplicationRole] AS r ON u.[ApplicationRoleID] = r.[ApplicationRoleID] " +
                    $"JOIN [app].[Tenant] AS t ON u.[TenantID] = t.[TenantID] " +
                    $"WHERE u.[WorkEmail] = @WorkEmail; " +
                $"SELECT [PermissionCode] FROM [usr].[Permission] WHERE [PermissionID] IN (SELECT [PermissionID] FROM [usr].[ApplicationRole_b_Permission] WHERE [ApplicationRoleID] = (SELECT [ApplicationRoleID] FROM [usr].[User] WHERE [WorkEmail] = @WorkEmail)); ";

            var result = await connection.QueryMultipleAsync(sqlStatement, new { WorkEmail = workEmail });
            var user = await result.ReadSingleOrDefaultAsync<UserLite>();
            if (user is null)
            {
                throw new UserNotFoundException(workEmail);
            }
            if (!user.IsActive)
            {
                throw new UserNotActiveException(user);
            }

            var permissions = await result.ReadAsync<string>();
            user.LoadPermissions(permissions);

            return user;
        }

        public class ApplicationRoleEnumTypeHandler : SqlMapper.TypeHandler<ApplicationRoleEnum>
        {
            public override ApplicationRoleEnum Parse(object value)
            {
                return ApplicationRoleEnum.FromName(value.ToString());
            }

            public override void SetValue(IDbDataParameter parameter, ApplicationRoleEnum value)
            {
                throw new NotImplementedException();
            }
        }
    }
}
