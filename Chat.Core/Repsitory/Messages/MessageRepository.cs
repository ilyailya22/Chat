using Chat.Entities.Db;
using Chat.Entities.Models.ChatItem;

namespace Chat.Core.Repsitory.Messages
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IDatabaseService _databaseService;

        public MessageRepository(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public Message CreateMessage(string text, Guid userId, Guid groupId)
        {
            var created = _databaseService.AddMessage(text, userId, groupId);

            return created;
        }

        public Message UpdateMessage(Message message)
        {
            return _databaseService.UpdateMessage(message);
        }

        public bool DeleteMessage(Guid id)
        {
            return _databaseService.DeleteMessage(id);
        }

        public IEnumerable<Message> Filter(Guid groupId, int i)
        {
            return _databaseService.Filter(groupId, i);
        }

        public Message GetMessageById(Guid id)
        {
            return _databaseService.GetMessageById(id);
        }
    }
}
