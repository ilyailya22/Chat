using Chat.Core;
using Chat.Core.Repsitory.Groups;
using Chat.Entities.Models.ChatItem;
using Microsoft.AspNetCore.Mvc;
using Ninject;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("api/groups")]
    public class GroupsController : Controller
    {
        private readonly IGroupRepository _groupRepository;
        public GroupsController()
        {
            _groupRepository = Bootstrapper.Kernel.Get<IGroupRepository>();
        }

        [HttpPost]
        public ActionResult<Group> Post(string nameGroup, List<Guid> list)
        {
            var top = _groupRepository.CreateGroup(nameGroup, list);
            return Ok(top);
        }
    }
}
