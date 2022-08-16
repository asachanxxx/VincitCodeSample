using NUnit.Framework;

namespace Tests.Application.IntegrationTests;

[TestFixture]
public abstract class BaseTestFixture
{
    [SetUp]
    public async Task TestSetUp()
    {
        //await ResetState();
        await Task.CompletedTask;
    }
}