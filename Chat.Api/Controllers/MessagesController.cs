using Chat.Core;
using Chat.Core.Repsitory.Messages;
using Chat.Entities.Models.ChatItem;
using Microsoft.AspNetCore.Mvc;
using Ninject;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("api/messages")]
    public class MessagesController : Controller
    {
        private readonly IMessageRepository _messageRepository;
        public MessagesController()
        {
            _messageRepository = Bootstrapper.Kernel.Get<IMessageRepository>();
        }

        [HttpPost]
        public ActionResult<Message> Post(string text, Guid userId, Guid groupId)
        {
            var top = _messageRepository.CreateMessage(text, userId, groupId);
            return Ok(top);
        }

        [HttpPut]
        public ActionResult<Message> Put(Message message)
        {
            var top = _messageRepository.UpdateMessage(message);
            return Ok(top);
        }

        [HttpDelete]
        public ActionResult<Message> Delete(Guid id)
        {
            var top = _messageRepository.DeleteMessage(id);
            return Ok(top);
        }

        [HttpGet]
        public ActionResult<Message> Get20(Guid groupId, int page)
        {
            var top = _messageRepository.Filter(groupId, page);
            return Ok(top);
        }
    }
}
