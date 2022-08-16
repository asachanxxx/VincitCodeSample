using System;
using Company.TxTool.Application.Admin.UserManagement.Queries.GetUser;
using FluentAssertions;
using NUnit.Framework;
using static Tests.Application.IntegrationTests.Testing;

namespace Tests.Application.IntegrationTests.Admin.UserManagement.Queries
{
    public class GetUserTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldReturnUser()
        {
            string email = RunAsUser.WorkEmail;

            var query = new GetUserQuery(Guid.Parse("00000000-0000-0000-0000-000000000001"));

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.WorkEmail.Should().Be(email);
        }
    }
}