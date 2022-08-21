
using Chat.Entities.Models.ChatItem;
using Chat.Entities.Models.User;

namespace Chat.Entities.Db
{
    public class DatabaseService : IDatabaseService
    {
        public UserInfo AddUser(UserInfo userInfo)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Add(userInfo);
                db.SaveChanges();

                return userInfo;
            }
        }

        public UserInfo GetUserById(Guid userId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var userInfo = db.Users.FirstOrDefault(u => u.Id == userId);

                return userInfo;
            }
        }

        public UserInfo GetUserByEmail(string email)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var userInfo = db.Users.FirstOrDefault(u => u.Email == email);

                return userInfo;
            }
        }

        public IEnumerable<UserInfo> GetAllUser()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<UserInfo> users = db.Users.ToList();
                return users;
            }
        }

        public void FillDbIfEmpty()
        {
            InitialDataProvider.FillDataIfNeeded();
        }

        public Group AddGroup(string groupName, List<Guid> users)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Models.ChatItem.Type type;
                if(users.Count()==2)
                {
                    type = Models.ChatItem.Type.Private;
                }
                else
                {
                    type = Models.ChatItem.Type.Public;
                }
                Group group = new Group { Id = Guid.NewGuid(), Name = groupName, Type = type };
                db.Groups.Add(group);
                db.SaveChanges();
                AddUsersGroup(group.Id, users);
                return group;
            }
        }

        public IEnumerable<Group> GetAllGroup()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Group> groups = db.Groups.ToList();
                return groups;
            }
        }

        public IEnumerable<Group> GetAllGroupByUser(Guid userId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var userGroups = db.UsersGroups.Where(x=> x.UserId == userId).ToList();
                var groups = new List<Group>();
                foreach(var user in userGroups)
                {
                    groups.AddRange(db.Groups.Where(x => x.Id == user.GroupId));
                }
                return groups;
            }
        }

        public Group GetGroupByName(string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var group = db.Groups.FirstOrDefault(u => u.Name == name);

                return group;
            }
        }

        public void AddUsersGroup(Guid group, List<Guid> users)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var user in users)
                {
                    var usersGroup = db.UsersGroups.Add(new UsersGroup { Id = Guid.NewGuid(), GroupId = group, UserId = user });
                    db.SaveChanges();
                }
            }
        }

        public Message AddMessage(string text, Guid userId, Guid groupId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var message = new Message { Id = Guid.NewGuid(), Date = DateTime.Now, GroupId = groupId, UserId = userId, Text = text };
                db.Messages.Add(message);
                db.SaveChanges();
                return message;
            }
        }

        public Message UpdateMessage(Message message)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var messageToRemove = db.Messages.FirstOrDefault(x => x.Id == message.Id);

                if (messageToRemove != null)
                {
                    db.Messages.Remove(messageToRemove);
                    db.Add(message);
                    db.SaveChanges();

                    return message;
                }

                return null;
            }
        }

        public bool DeleteMessage(Guid id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var messageToRemove = db.Messages.FirstOrDefault(x => x.Id == id);

                if (messageToRemove != null)
                {
                    db.Messages.Remove(messageToRemove);
                    db.SaveChanges();

                    return !db.Messages.Any(x => x.Id == id);
                }

                return false;
            }
        }

        public Message GetMessageById(Guid id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var message = db.Messages.FirstOrDefault(u => u.Id == id);

                return message;
            }
        }

        public IEnumerable<Message> Filter(Guid groupId, int i)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Message> messages = new List<Message>();
                var messagesFromDb = db.Messages.Where(x => x.GroupId == groupId).OrderBy(x=> x.Date).ToList();
                for(int j = i*20; j < (i+1)*20; j++)
                {
                    try 
                    {
                        messages.Add(messagesFromDb[j]);
                    }
                    catch { }
                    
                }
                return messages;
            }
        }
    }
}
