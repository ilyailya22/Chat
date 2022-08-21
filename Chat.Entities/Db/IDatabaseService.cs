using Chat.Entities.Models.ChatItem;
using Chat.Entities.Models.User;

namespace Chat.Entities.Db
{
    public interface IDatabaseService
    {
        UserInfo AddUser(UserInfo userInfo);

        UserInfo GetUserById(Guid userId);

        UserInfo GetUserByEmail(string email);

        public void FillDbIfEmpty();

        public Group AddGroup(string groupName, List<Guid> users);

        public IEnumerable<Group> GetAllGroup();

        public Group GetGroupByName(string name);

        public IEnumerable<UserInfo> GetAllUser();

        public IEnumerable<Group> GetAllGroupByUser(Guid userId);

        public void AddUsersGroup(Guid group, List<Guid> users);

        public Message AddMessage(string text, Guid userId, Guid groupId);

        public Message UpdateMessage(Message message);

        public Message GetMessageById(Guid id);

        public bool DeleteMessage(Guid id);

        public IEnumerable<Message> Filter(Guid groupId, int i);

    }
}
