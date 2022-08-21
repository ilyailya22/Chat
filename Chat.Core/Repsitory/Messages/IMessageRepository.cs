using Chat.Entities.Models.ChatItem;

namespace Chat.Core.Repsitory.Messages
{
    public interface IMessageRepository
    {
        Message CreateMessage(string text, Guid userId, Guid groupId);
        public Message UpdateMessage(Message message);

        public bool DeleteMessage(Guid id);

        public IEnumerable<Message> Filter(Guid groupId, int i);

        public Message GetMessageById(Guid Id);
    }
}
