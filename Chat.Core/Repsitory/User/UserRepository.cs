using Chat.Entities.Db;
using Chat.Entities.Models.User;

namespace Chat.Core.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseService _databaseService;

        public UserRepository(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public UserInfo CreateUser(UserInfo user)
        {
            var created = _databaseService.AddUser(user);

            return created;
        }

        public UserInfo GetUserById(Guid userId)
        {
            var user = _databaseService.GetUserById(userId);

            return user;
        }

        public UserInfo GetUserByEmail(string email)
        {
            var user = _databaseService.GetUserByEmail(email);

            return user;
        }

        public bool CheckUserForAuth(UserLoginModel loginModel)
        {
            var user = GetUserByEmail(loginModel.Email);

            if (user == null)
            {
                return false;
            }

            return user.Password == loginModel.Password;
        }

        public IEnumerable<UserInfo> GetAllUser()
        {
            return _databaseService.GetAllUser();
        }
    }
}
