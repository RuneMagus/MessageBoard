using MessageBoard.DataContracts;
using MessageBoardServer.BLL;
using Moq;
using Shared;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MessageBoardServer.Tests.BLL
{
    public class MessagesHandlerTests
    {
        Mock<IRepository<MessageData>> mockRepository;

        public MessagesHandlerTests()
        {
            mockRepository = new Mock<IRepository<MessageData>>();
        }

        [Fact]
        public void GetShouldReturnExpectedList()
        {
            var storedMessages = new List<MessageData>
            {
                new MessageData { Content = "Message 1" },
                new MessageData { Content = "Message 2" }
            };

            var expected = new List<Message>
            {
                new Message { Content = storedMessages[0].Content },
                new Message { Content = storedMessages[1].Content },
            };

            mockRepository.Setup(repository => repository.FetchAll()).Returns(storedMessages);
            var handler = new MessagesHandler(mockRepository.Object);
            var actual = handler.GetMessages();
            Assert.Equal(storedMessages.Count, actual.Count());
            // Need to implement IEquality on Message to make the test comparison slicker
            // Assert.Equal(expected, actual);
            for (var index = 0; index < storedMessages.Count; index++)
            {
                Assert.Equal(expected[index].Content, actual.ElementAt(index).Content);
            }
        }

        [Fact]
        public void AddShouldCallOnRepositoryWithCorrectValue()
        {
            var message = new Message { Content = "New message" };
            var handler = new MessagesHandler(mockRepository.Object);
            handler.AddMessage(message);
            mockRepository.Verify(repository => repository.Add(It.Is<MessageData>(arg => arg.Content == "New message")));
        }
    }
}
