using MessageBoard.Controllers;
using MessageBoardServer.BLL;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Collections.Generic;
using MessageBoard.DataContracts;
using System.Linq;

namespace MessageBoardServer.Tests.Controllers
{
    public class MessagesControllerTests
    {
        Mock<ILogger<MessagesController>> mockLogger;

        Mock<IMessagesHandler> mockMessageHandler;

        public MessagesControllerTests()
        {
            mockLogger = new Mock<ILogger<MessagesController>>();
            mockMessageHandler = new Mock<IMessagesHandler>();
        }

        [Fact]
        public void GetReturnsTest()
        {
            var expected = new List<Message>
            {
                new Message { Content = "Message 1" },
                new Message { Content = "Message 2" },
            };

            mockMessageHandler.Setup(handler => handler.GetMessages()).Returns(expected).Verifiable();

            var controller = new MessagesController(mockLogger.Object, mockMessageHandler.Object);
            var actual = controller.Get().Result as OkObjectResult;

            Assert.IsType<OkObjectResult>(actual);
            Assert.Equal(expected.Count, (actual.Value as IEnumerable<Message>).Count());
            for (var index = 0; index < expected.Count; index++)
            {
                Assert.Equal(expected[index].Content, (actual.Value as IEnumerable<Message>).ElementAt(index).Content);
            }

            mockMessageHandler.VerifyAll();
        }

        [Fact]
        public void PostAddsMessageTest()
        {
            var message = new Message { Content = "Message 1" };
            var controller = new MessagesController(mockLogger.Object, mockMessageHandler.Object);
            var actual = controller.Post(message);

            Assert.IsType<OkResult>(actual);
            mockMessageHandler.Verify(handler => handler.AddMessage(message), Times.Once);
        }
    }
}
