using System.Collections.Generic;
using MessageBoard.DataContracts;
using MessageBoardServer.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MessageBoard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly ILogger<MessagesController> _logger;

        private readonly IMessagesHandler messageHandler;

        public MessagesController(ILogger<MessagesController> logger, IMessagesHandler messageHandler)
        {
            _logger = logger;
            this.messageHandler = messageHandler;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get()
        {
            var value = messageHandler.GetMessages();
            return Ok(value);
        }

        [HttpPost]
        public ActionResult Post(Message message)
        {
            messageHandler.AddMessage(message);
            return Ok();
        }
    }
}
