using Chat.Entities.Models.ChatItem;

namespace Chat.Core.Repsitory.Groups
{
    public interface IGroupRepository
    {
        Group CreateGroup(string group, List<Guid> users);

        IEnumerable<Group> GetAllGroups();

        Group GetGroupByName(string name);

        public IEnumerable<Group> GetAllGroupByUser(Guid userId);
    }
}
