using Chat.Core.Repository.User;
using Chat.Core;
using Chat.Entities.Models.User;
using Microsoft.AspNetCore.Mvc;
using Ninject;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController()
        {
            _userRepository = Bootstrapper.Kernel.Get<IUserRepository>();
        }

        [HttpPost]
        public ActionResult<UserInfo> Post(UserInfo userInfo)
        {
            var user = _userRepository.CreateUser(userInfo);
            return Ok(user);
        }
    }
}
