using Chat.Entities.Db;
using Chat.Entities.Models.ChatItem;

namespace Chat.Core.Repsitory.Groups
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IDatabaseService _databaseService;

        public GroupRepository(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public Group CreateGroup(string group, List<Guid> users)
        {
            var created = _databaseService.AddGroup(group, users);

            return created;
        }

        public IEnumerable<Group> GetAllGroups()
        {
            var created = _databaseService.GetAllGroup();

            return created;
        }

        public Group GetGroupByName(string name)
        {
            return _databaseService.GetGroupByName(name);
        }

        public IEnumerable<Group> GetAllGroupByUser(Guid userId)
        {
            return _databaseService.GetAllGroupByUser(userId);
        }
    }
}
