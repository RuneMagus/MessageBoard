using MessageBoard.DataContracts;
using Shared;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace MessageBoardServer.BLL
{
    public class MessagesHandler : IMessagesHandler
    {
        private readonly IRepository<MessageData> repository;

        public MessagesHandler(IRepository<MessageData> repository)
        {
            this.repository = repository;
        }

        public void AddMessage(Message message)
        {
            repository.Add(new MessageData { Content = message.Content });
        }

        public IEnumerable<Message> GetMessages()
        {
            return repository.FetchAll().Select(item => new Message() { Content = item.Content }).ToList();
        }
    }
}
