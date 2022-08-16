//using Cushwake.TreasuryTool.Application.Common.Behaviours;
//using Cushwake.TreasuryTool.Application.Common.Interfaces;
//using Cushwake.TreasuryTool.Application.TodoItems.Commands.CreateTodoItem;
//using Microsoft.Extensions.Logging;
//using Moq;
//using NUnit.Framework;

//namespace Tests.Application.UnitTests.Common.Behaviours;

//public class RequestLoggerTests
//{
//    private Mock<ILogger<CreateTodoItemCommand>> _logger = null!;
//    private Mock<ICurrentIdentityService> _currentUserService = null!;

//    [SetUp]
//    public void Setup()
//    {
//        _logger = new Mock<ILogger<CreateTodoItemCommand>>();
//        _currentUserService = new Mock<ICurrentIdentityService>();
//    }

//    [Test]
//    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
//    {
//        _currentUserService.Setup(x => x.Identity).Returns(Guid.NewGuid().ToString());

//        var requestLogger = new LoggingBehaviour<CreateTodoItemCommand>(_logger.Object, _currentUserService.Object);

//        await requestLogger.Process(new CreateTodoItemCommand { ListId = 1, Title = "title" }, new CancellationToken());

//        //_identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
//    }

//    [Test]
//    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
//    {
//        var requestLogger = new LoggingBehaviour<CreateTodoItemCommand>(_logger.Object, _currentUserService.Object);

//        await requestLogger.Process(new CreateTodoItemCommand { ListId = 1, Title = "title" }, new CancellationToken());

//        //_identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Never);
//    }
//}
