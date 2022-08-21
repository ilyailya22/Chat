using Chat.Entities.Models.User;

namespace Chat.Core.Repository.User
{
    public interface IUserRepository
    {
        UserInfo CreateUser(UserInfo user);

        UserInfo GetUserById(Guid userId);

        UserInfo GetUserByEmail(string email);

        bool CheckUserForAuth(UserLoginModel loginModel);

        public IEnumerable<UserInfo> GetAllUser();
    }
}
