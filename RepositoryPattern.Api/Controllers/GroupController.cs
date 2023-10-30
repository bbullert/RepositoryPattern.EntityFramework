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
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, 
            IGroupService groupService)
            : base(hostingEnvironment)
        {
            _groupService = groupService;
        }
    }
}
