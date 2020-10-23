using MessageBoard.DataContracts;
using System.Collections.Generic;

namespace MessageBoardServer.BLL
{
    public interface IMessagesHandler
    {
        void AddMessage(Message message);

        IEnumerable<Message> GetMessages();
    }
}