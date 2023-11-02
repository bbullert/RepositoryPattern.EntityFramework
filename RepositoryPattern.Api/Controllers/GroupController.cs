using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Services;

namespace RepositoryPattern.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class GroupController : ApiController
    {
        private readonly IGroupService _groupService;

        public GroupController(
            IWebHostEnvironment webHostEnvironment,
            IGroupService groupService)
            : base(webHostEnvironment)
        {
            _groupService = groupService;
        }
    }
}
