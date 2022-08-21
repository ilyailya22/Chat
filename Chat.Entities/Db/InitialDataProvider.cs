using Chat.Entities.Models;
using Chat.Entities.Models.ChatItem;
using Chat.Entities.Models.User;

namespace Chat.Entities.Db
{
    public static class InitialDataProvider
    {
        public static void FillDataIfNeeded()
        {
            InitUsers();
            InitGroups();
            InitUsersGroups();
            InitMessageData();
        }

        private static void InitUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Users.Any())
                {
                    var users = new List<UserInfo>
                    {
                        new UserInfo { Login = "Illya", Email = "ilaMerihov@gmail.com", Password = "12345" },
                        new UserInfo { Id = Guid.Parse("D2E464F9-A4BF-4D21-FF4C-08DA7FEC4BE7"), Login = "Oleg", Email = "Oleg@gmail.com", Password = "54321" },
                        new UserInfo { Login = "Ivan", Email = "Ivan@gmail.com", Password = "32145" },
                        new UserInfo { Login = "Maks", Email = "Maks@gmail.com", Password = "21354" },
                        new UserInfo { Login = "Egor", Email = "Egor@gmail.com", Password = "12345" },
                    };

                    db.Users.AddRange(users);
                    db.SaveChanges();
                }

            }
        }

        private static void InitGroups()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Groups.Any())
                {
                    var groups = new List<Group>
                    {
                        new Group { Name = "Illya Oleg Ivan", Type = Models.ChatItem.Type.Public },
                        new Group { Name = "Illya Maks Egor", Type = Models.ChatItem.Type.Public },
                        new Group { Name = "Maks Ivan Oleg", Type = Models.ChatItem.Type.Public }
                    };

                    db.Groups.AddRange(groups);
                    db.SaveChanges();
                }
            }
        }

        private static void InitUsersGroups()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.UsersGroups.Any())
                {
                    var usersGroups = new List<UsersGroup>
                            {
                                new UsersGroup { UserId = db.Users.FirstOrDefault(x=> x.Login =="Illya").Id, GroupId = db.Groups.FirstOrDefault(x=> x.Name =="Illya Oleg Ivan").Id },
                                new UsersGroup { UserId = db.Users.FirstOrDefault(x=> x.Login =="Oleg").Id, GroupId = db.Groups.FirstOrDefault(x=> x.Name =="Illya Oleg Ivan").Id },
                                new UsersGroup { UserId = db.Users.FirstOrDefault(x=> x.Login =="Ivan").Id, GroupId = db.Groups.FirstOrDefault(x=> x.Name =="Illya Oleg Ivan").Id },
                                new UsersGroup { UserId = db.Users.FirstOrDefault(x=> x.Login =="Illya").Id, GroupId = db.Groups.FirstOrDefault(x=> x.Name =="Illya Maks Egor").Id },
                                new UsersGroup { UserId = db.Users.FirstOrDefault(x=> x.Login =="Maks").Id, GroupId = db.Groups.FirstOrDefault(x=> x.Name =="Illya Maks Egor").Id },
                                new UsersGroup { UserId = db.Users.FirstOrDefault(x=> x.Login =="Egor").Id, GroupId = db.Groups.FirstOrDefault(x=> x.Name =="Illya Maks Egor").Id },
                                new UsersGroup { UserId = db.Users.FirstOrDefault(x=> x.Login =="Maks").Id, GroupId = db.Groups.FirstOrDefault(x=> x.Name =="Maks Ivan Oleg").Id },
                                new UsersGroup { UserId = db.Users.FirstOrDefault(x=> x.Login =="Ivan").Id, GroupId = db.Groups.FirstOrDefault(x=> x.Name =="Maks Ivan Oleg").Id },
                                new UsersGroup { UserId = db.Users.FirstOrDefault(x=> x.Login =="Oleg").Id, GroupId = db.Groups.FirstOrDefault(x=> x.Name =="Maks Ivan Oleg").Id },
                            };

                    db.UsersGroups.AddRange(usersGroups);
                    db.SaveChanges();
                }
            }
        }

        private static void InitMessageData()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var groups = db.Groups.FirstOrDefault(x => x.Name == "Illya Oleg Ivan");

                if (groups != null)
                {
                    if (!db.Messages.Any(x => x.GroupId == groups.Id))
                    {
                        var exercises = new List<Message>();
                        exercises.Add(new Message { Text = "Hi", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Illya").Id });
                        exercises.Add(new Message { Text = "Hi", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Oleg").Id });
                        exercises.Add(new Message { Text = "Hi", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Ivan").Id });
                        exercises.Add(new Message { Text = "I write message", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Illya").Id });
                        exercises.Add(new Message { Text = "Me too", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Oleg").Id });
                        exercises.Add(new Message { Text = "And me", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Ivan").Id });
                        exercises.Add(new Message { Text = "Can you delete it?", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Illya").Id });
                        exercises.Add(new Message { Text = "Yes", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Oleg").Id });
                        exercises.Add(new Message { Text = "How about me?", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Ivan").Id });
                        exercises.Add(new Message { Text = "I can edit my message", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Illya").Id });
                        exercises.Add(new Message { Text = "Wow", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Oleg").Id });
                        exercises.Add(new Message { Text = "Cool", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Ivan").Id });
                        exercises.Add(new Message { Text = "Hi", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Illya").Id });
                        exercises.Add(new Message { Text = "Hi", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Oleg").Id });
                        exercises.Add(new Message { Text = "Hi", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Ivan").Id });
                        exercises.Add(new Message { Text = "Hi", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Illya").Id });
                        exercises.Add(new Message { Text = "Hi", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Oleg").Id });
                        exercises.Add(new Message { Text = "Hi", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Ivan").Id });
                        exercises.Add(new Message { Text = "Hi", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Illya").Id });
                        exercises.Add(new Message { Text = "Hi", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Oleg").Id });
                        exercises.Add(new Message { Text = "Hi", Date = DateTime.Now, GroupId = groups.Id, UserId = db.Users.FirstOrDefault(x => x.Login == "Ivan").Id });

                        db.Messages.AddRange(exercises);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
